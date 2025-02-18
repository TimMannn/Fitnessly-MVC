import { useState, useEffect, useRef, Fragment } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import Table from "react-bootstrap/Table";
import "bootstrap/dist/css/bootstrap.min.css";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import Form from "react-bootstrap/Form"
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Container from "react-bootstrap/Container";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import "./WorkoutSessie.css";
import "react-toastify/dist/ReactToastify.css";
import { FaSignOutAlt } from "react-icons/fa";
import { IoMdStopwatch } from "react-icons/io";
//import { jwtDecode } from "jwt-decode";

const WorkoutSessie = () => {
    const [data, setData] = useState([]);
    const [timer, setTimer] = useState(0);
    const timerRef = useRef(null);
    const startTimeRef = useRef(null);
    const navigate = useNavigate();
    const { workoutId, workoutName, workoutSessieId } = useParams();

    const [showModal, setShowModal] = useState(false);
    const [selectedExercise, setSelectedExercise] = useState(null);

    const handleClose = () => setShowModal(false);
    const handleShow = (exercise) => {
        setSelectedExercise(exercise);
        setShowModal(true);
    };

    useEffect(() => {
        getData();
        startTimer();
        return () => cancelAnimationFrame(timerRef.current);
    }, []);


    const getData = () => {
        const token = localStorage.getItem("token");
        console.log("Sending Token:", token);
        axios
            .get(`https://localhost:7187/api/Exercise/${workoutId}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((result) => {
                console.log(result.data);
                setData(result.data);
            })
            .catch((error) => {
                console.error("Error fetching exercises:", error);
                toast.error("Failed to fetch exercises");
            });
    };

    const handleSave = async () => {
        const token = localStorage.getItem("token");

        try {
            const workoutSessieExerciseResponse = await axios.post(
                `https://localhost:7187/api/WorkoutSessie/${workoutSessieId}/exercises`,
                {
                    exerciseName: selectedExercise.name,
                    sets: selectedExercise.sets,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );

            const workoutSessieExerciseId = workoutSessieExerciseResponse.data;

            const stats = [];
            for (let i = 0; i < selectedExercise.sets; i++) {
                stats.push({
                    gewicht: document.getElementById(`SetsModels_${i}_Gewicht`).value,
                    reps: document.getElementById(`SetsModels_${i}_Reps`).value,
                });
            }

            console.log("Workout Sessie Exercise ID:", workoutSessieExerciseId);
            console.log("Stats:", stats);

            await Promise.all(
                stats.map(stat =>
                    axios.post(
                        `https://localhost:7187/api/WorkoutSessie/exercises/${workoutSessieExerciseId}/stats`,
                        stat,
                        {
                            headers: {
                                Authorization: `Bearer ${token}`,
                            },
                        }
                    )
                )
            );

            toast.success("Exercise stats saved successfully!");
            handleClose();
        } catch (error) {
            console.error("Error saving exercise stats:", error);
            toast.error("Failed to save exercise stats.");
        }
    };




    const handleLogout = () => {
        const token = localStorage.getItem("token");
        axios
            .post(
                "https://localhost:7187/api/Account/logout",
                {},
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                },
            )
            .then((response) => {
                if (response.status === 200) {
                    localStorage.removeItem("token");
                    navigate("/Login");
                } else {
                    toast.error("Error logging out");
                }
            })
            .catch((error) => {
                console.error("Error:", error); 
                toast.error("Error logging out");
            });
    };

    const handleKlaarClick = (exerciseId) => {
        const token = localStorage.getItem("token");
        axios
            .put(
                `https://localhost:7187/api/Exercise/display/false/${exerciseId}`,
                {},
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                },
            )
            .then(() => {
                setData(prevData =>
                    prevData.map(item =>
                        item.id === exerciseId ? { ...item, display: "false" } : item
                    )
                );
            })
            .catch((error) => {
                console.error("Error setting display to false:", error);
                toast.error("Failed to update exercise display");
            });
    };

    const handleStoppenClick = () => {
        cancelAnimationFrame(timerRef.current);
        const token = localStorage.getItem("token");
        axios
            .put(
                `https://localhost:7187/api/Exercise/display/true`,
                {},
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                },
            )
            .then(() => {
                setData(prevData =>
                    prevData.map(item => ({ ...item, display: "true" }))
                );
            })
            .catch((error) => {
                console.error("Error setting all exercises to true:", error);
                toast.error("Failed to update all exercises display");
            });

        navigate(`/workoutsessieresults/${workoutSessieId}`, {
            state: { token: token },
        });
    };

    const startTimer = () => {
        startTimeRef.current = Date.now() - timer * 1000;
        const updateTimer = () => {
            setTimer(Math.floor((Date.now() - startTimeRef.current) / 1000));
            timerRef.current = requestAnimationFrame(updateTimer);
        };
        timerRef.current = requestAnimationFrame(updateTimer);
    };


    const formatTime = (seconds) => {
        const hrs = String(Math.floor(seconds / 3600)).padStart(2, '0');
        const minutes = String(Math.floor((seconds % 3600) / 60)).padStart(2, '0');
        const secs = String(seconds % 60).padStart(2, '0');
        return `${hrs}:${minutes}:${secs}`;
    };


    return (
        <Fragment>
            <ToastContainer />
            <Navbar bg="primary" variant="dark" expand="lg">
                <Container>
                    <Navbar.Brand href="#home">Fitnessly</Navbar.Brand>
                    <Nav className="ml-auto">
                        <Button
                            variant="outline-light"
                            className="logout-btn"
                            onClick={handleLogout}
                        >
                            Logout <FaSignOutAlt />
                        </Button>
                    </Nav>
                </Container>
            </Navbar>
            <Container fluid>
                <Row className="align-items-center flex-container">
                    <Col xs="auto">
                        <div className="verstopt"></div>
                    </Col>
                    <Col xs="auto" className="flex-grow-1 text-center">
                        <h2> {workoutName} </h2>
                    </Col>
                    <Col xs="auto">
                        <Button className="btn submit-btn" onClick={handleStoppenClick}>
                            Stoppen <IoMdStopwatch />
                        </Button>
                    </Col>
                </Row>
            </Container>
            <div className="timer">
                <p>{formatTime(timer)}</p>
            </div>

            <br />
            <Container fluid>
                <Table striped bordered hover className="exercise-custom-table">
                    <thead className="header-row">
                        <tr>
                            <th>#</th>
                            <th>Exercise</th>
                            <th>Gewicht</th>
                            <th>Sets</th>
                            <th>Reps</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.length > 0 ? (
                            data
                                .filter(item => item.display === "true")
                                .map((item, index) => (
                                <tr key={index}>
                                    <td>{index + 1}</td>
                                    <td>{item.name}</td>
                                    <td>{item.gewicht} kg</td>
                                    <td>{item.sets}x</td>
                                    <td>{item.reps}x</td>
                                    <td>
                                        <Button
                                            className="btn edit-btn"
                                            onClick={(e) => {
                                                e.stopPropagation();
                                                handleKlaarClick(item.id);
                                                handleShow(item);
                                            }}
                                        >
                                            Klaar
                                        </Button>
                                    </td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="6">Voeg eerst oefeningen toe voordat je een workout begint!</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Container>

                <Modal show={showModal} onHide={handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>Bewerk oefening</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        {selectedExercise && (
                            <Form>
                                <input type="hidden" name="WorkoutID" value={workoutId} />
                                <input type="hidden" id="WorkoutSessieStatsSets" name="WorkoutSessieStatsSets" value={selectedExercise.sets} />
                                <input type="hidden" id="WorkoutSessieStatsName" name="WorkoutSessieStatsName" value={selectedExercise.name} />
                                <input type="hidden" name="ExerciseID" value={selectedExercise.id} />

                                {[...Array(selectedExercise.sets)].map((_, i) => (
                                    <div key={i}>
                                        <h2>Set: {i + 1}</h2>
                                        <Form.Group controlId={`SetsModels_${i}_Gewicht`}>
                                            <Form.Label>Gewicht:</Form.Label>
                                            <Form.Control type="text" defaultValue={selectedExercise.gewicht} required />
                                        </Form.Group>
                                        <h3> </h3>
                                        <Form.Group controlId={`SetsModels_${i}_Reps`}>
                                            <Form.Label>Hoeveelheid Reps:</Form.Label>
                                            <Form.Control type="text" defaultValue={selectedExercise.reps} required />
                                        </Form.Group>
                                        <h2> </h2>
                                    </div>
                                ))}
                            </Form>
                        )}
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>
                            Sluiten
                        </Button>
                        <Button variant="primary" onClick={handleSave}>
                            Opslaan
                        </Button>
                    </Modal.Footer>
                </Modal>
        </Fragment>
    );
};

export default WorkoutSessie;
