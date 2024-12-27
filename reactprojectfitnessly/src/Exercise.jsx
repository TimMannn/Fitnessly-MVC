import { useState, useEffect, Fragment } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './Exercise.css';
import { FaArrowLeft } from 'react-icons/fa'
import { jwtDecode } from 'jwt-decode'



const Exercise = () => {
    const [ExerciseName, setExerciseName] = useState('');
    const [ExerciseGewicht, setExerciseGewicht] = useState('');
    const [ExerciseSets, setExerciseSets] = useState('');
    const [ExerciseReps, setExerciseReps] = useState('');
    const [editID, setEditID] = useState('');
    const [editExercise, setEditExercise] = useState('');
    const [editExerciseGewicht, setEditExerciseGewicht] = useState('');
    const [editExerciseSets, setEditExerciseSets] = useState('');
    const [editExerciseReps, setEditExerciseReps] = useState('');
    const [data, setData] = useState([]);
    const navigate = useNavigate();
    const { workoutId } = useParams();

    const [showAdd, setShowAdd] = useState(false);
    const handleCloseAdd = () => setShowAdd(false);
    const handleShowAdd = () => setShowAdd(true);

    const [showEdit, setShowEdit] = useState(false);
    const handleCloseEdit = () => setShowEdit(false);
    const handleShowEdit = () => setShowEdit(true);

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const token = localStorage.getItem('token');
        console.log("Sending Token:", token);
        axios.get(`https://localhost:7187/api/Exercise/${workoutId}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((result) => {
                console.log(result.data);
                setData(result.data);
            })
            .catch((error) => {
                console.error('Error fetching exercises:', error);
                toast.error("Failed to fetch exercises");
            });
    };

    const handleEdit = (ID) => {
        const token = localStorage.getItem('token');
        handleShowEdit();
        axios.get(`https://localhost:7187/api/Exercise/exercise/${ID}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((result) => {
                console.log('Exercise data opgehaald:', result.data);
                setEditExercise(result.data.name);
                setEditExerciseGewicht(result.data.gewicht);
                setEditExerciseSets(result.data.sets);
                setEditExerciseReps(result.data.reps);
                setEditID(ID);
                console.log('editExercise updated to:', result.data.name);
            })
            .catch((error) => {
                console.error('Error bij het ophalen van exercise:', error);
                toast.error("Failed to fetch exercise");
            });
    };

    const handleDelete = (ID) => {
        const token = localStorage.getItem('token');
        if (window.confirm("Are you sure you want to delete this exercise?")) {
            axios.delete(`https://localhost:7187/api/Exercise/${ID}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
                .then((result) => {
                    if (result.status === 200) {
                        toast.success("Exercise has been deleted");
                        getData();
                    }
                })
                .catch((error) => {
                    toast.error("Failed deleting exercise");
                    console.log(error);
                });
        }
    };

    const handleUpdate = () => {
        const token = localStorage.getItem('token');
        if (!token) {
            toast.error('No token found'); return;
        }

        const url = `https://localhost:7187/api/Exercise/${editID}`;
        const data = {
            "exerciseID": editID,
            "exerciseName": editExercise,
            "exerciseGewicht": editExerciseGewicht,
            "exerciseSets": editExerciseSets,
            "exerciseReps": editExerciseReps,
            "display": "true",
            "workoutID": workoutId
        };

        const clear = () => {
            setEditExercise('');
            setEditExerciseGewicht('');
            setEditExerciseSets('');
            setEditExerciseReps('');
            setEditID('');
        };

        axios.put(url, data, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((response) => {
                if (response.status === 200) {
                    getData();
                    clear();
                    handleCloseEdit();
                    toast.success('Exercise has been updated');
                } else {
                    toast.error(`Error updating exercise: ${response.data.message}`);
                }
            })
            .catch((error) => {
                console.error('Error details:', error.response);
                const errorMessages = error.response?.data?.messages || [error.response?.data?.message || 'Error updating exercise'];
                errorMessages.forEach(msg => toast.error(msg));
            });
    };

    const handleSave = () => {
        const token = localStorage.getItem('token');
        if (!token) {
            return; // Zorg ervoor dat er een token is
        }

        const decodedToken = jwtDecode(token);

        console.log(decodedToken); // Controleer de inhoud van het gedecodeerde token

        const url = "https://localhost:7187/api/Exercise";
        const data = {
            "exerciseName": ExerciseName,
            "exerciseGewicht": ExerciseGewicht,
            "exerciseSets": ExerciseSets,
            "exerciseReps": ExerciseReps,
            "display": "true",
            "workoutID": workoutId
        };

        const clear = () => {
            setExerciseName('');
            setExerciseGewicht('');
            setExerciseSets('');
            setExerciseReps('');
            setEditID('');
        };

        axios.post(url, data, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((response) => {
                if (response.status === 201) {
                    getData();
                    clear();
                    handleCloseAdd();
                    toast.success('Exercise has been added');
                } else {
                    toast.error(`Error adding exercise: ${response.data.message}`);
                }
            })
            .catch((error) => {
                const errorMessages = error.response?.data?.messages || [error.response?.data?.message || 'Error adding exercise'];
                errorMessages.forEach(msg => toast.error(msg));
            });
    };

    const handleLogout = () => {
        const token = localStorage.getItem('token');
        axios.post('https://localhost:7187/api/Account/logout', {}, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((response) => {
                if (response.status === 200) {
                    localStorage.removeItem('token');
                    navigate('/Login');
                } else {
                    toast.error('Error logging out');
                }
            })
            .catch((error) => {
                console.error('Error:', error); // Debugging line
                toast.error('Error logging out');
            });
    };

    const handleBack = () => {
        navigate('/workout');
    };


    return (
        <Fragment>
            <ToastContainer />
            <Navbar bg="primary" variant="dark" expand="lg">
                <Container>
                    <Navbar.Brand href="#home">Fitnessly</Navbar.Brand>
                    <Nav className="ml-auto">
                        <Button variant="outline-light" className="logout-btn" onClick={handleLogout}>Logout</Button>
                    </Nav>
                </Container>
            </Navbar>
            <Container fluid>
                <Button className="btn back-btn" onClick={handleBack}> <FaArrowLeft /> Terug </Button>
                <Row className="container-row mt-3 justify-content-center">
                    <Col xs={12} sm={8} md={6} lg={4} xl={3} className="mx-auto text-center">
                        <Button className="btn submit-btn mt-3" onClick={handleShowAdd}>Toevoegen</Button>
                    </Col>
                </Row>
            </Container>
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
                            data.map((item, index) => (
                                <tr key={index}>
                                    <td>{index + 1}</td>
                                    <td>{item.name}</td>
                                    <td>{item.gewicht} kg</td>
                                    <td>{item.sets}x</td>
                                    <td>{item.reps}x</td>
                                    <td>
                                        <Button className="btn edit-btn" onClick={(e) => { e.stopPropagation(); handleEdit(item.id); }}>Edit</Button> |
                                        <Button className="btn delete-btn" onClick={(e) => { e.stopPropagation(); handleDelete(item.id); }}>Delete</Button>
                                    </td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="6">Voeg een exercise toe</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Container>
            <Modal show={showAdd} onHide={handleCloseAdd}>
                <Modal.Header closeButton>
                    <Modal.Title>Nieuwe Exercise Toevoegen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col>
                            <input
                                type="text"
                                className="form-control"
                                placeholder="Enter exercise name"
                                value={ExerciseName}
                                onChange={(e) => setExerciseName(e.target.value)}
                                minLength={3}
                                maxLength={50}
                                required
                            />
                        </Col>
                    </Row>
                    <Row className="mt-3">
                        <Col>
                            <input
                                type="number"
                                className="form-control"
                                placeholder="Enter weight"
                                value={ExerciseGewicht}
                                onChange={(e) => setExerciseGewicht(e.target.value)}
                                required
                            />
                        </Col>
                    </Row>
                    <Row className="mt-3">
                        <Col>
                            <input
                                type="number"
                                className="form-control"
                                placeholder="Enter sets"
                                value={ExerciseSets}
                                onChange={(e) => setExerciseSets(e.target.value)}
                                required
                            />
                        </Col>
                    </Row>
                    <Row className="mt-3">
                        <Col>
                            <input
                                type="number"
                                className="form-control"
                                placeholder="Enter reps"
                                value={ExerciseReps}
                                onChange={(e) => setExerciseReps(e.target.value)}
                                required
                            />
                        </Col>
                    </Row>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseAdd}>Close</Button>
                    <Button variant="primary" onClick={handleSave}>Save Changes</Button>
                </Modal.Footer>
            </Modal>
            <Modal show={showEdit} onHide={handleCloseEdit}>
                <Modal.Header closeButton>
                    <Modal.Title>Exercise Bewerken</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col>
                            <input
                                type="text"
                                className="form-control"
                                placeholder="Enter exercise name"
                                value={editExercise}
                                onChange={(e) => setEditExercise(e.target.value)}
                                minLength={3}
                                maxLength={50}
                                required
                            />
                        </Col>
                    </Row>
                    <Row className="mt-3">
                        <Col>
                            <input
                                type="number"
                                className="form-control"
                                placeholder="Enter weight"
                                value={editExerciseGewicht}
                                onChange={(e) => setEditExerciseGewicht(e.target.value)}
                                required
                            />
                        </Col>
                    </Row>
                    <Row className="mt-3">
                        <Col>
                            <input
                                type="number"
                                className="form-control"
                                placeholder="Enter sets"
                                value={editExerciseSets}
                                onChange={(e) => setEditExerciseSets(e.target.value)}
                                required
                            />
                        </Col>
                    </Row>
                    <Row className="mt-3">
                        <Col>
                            <input
                                type="number"
                                className="form-control"
                                placeholder="Enter reps"
                                value={editExerciseReps}
                                onChange={(e) => setEditExerciseReps(e.target.value)}
                                required
                            />
                        </Col>
                    </Row>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseEdit}>Close</Button>
                    <Button variant="primary" onClick={handleUpdate}>Save Changes</Button>
                </Modal.Footer>
            </Modal>
        </Fragment>
    );
};

export default Exercise;
