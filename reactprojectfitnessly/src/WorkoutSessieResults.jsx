import { useEffect, useState, Fragment } from "react";
import axios from "axios";
import { useParams, useNavigate } from "react-router-dom";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import Container from "react-bootstrap/Container";
import Button from "react-bootstrap/Button";
import { FaSignOutAlt } from "react-icons/fa";
import { ToastContainer, toast } from "react-toastify";
import "bootstrap/dist/css/bootstrap.min.css";
import "react-toastify/dist/ReactToastify.css";

const WorkoutSessieResults = () => {
    const { workoutSessieId } = useParams();
    const [results, setResults] = useState({
        workoutSessieExerciseResults: [],
        workoutSessieExerciseStats: []
    });
    const navigate = useNavigate();

    const getData = () => {
        const token = localStorage.getItem("token");

        axios
            .get(`https://localhost:7187/api/WorkoutSessie/${workoutSessieId}/results`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((response) => {
                console.log("Full response:", response);
                console.log("Fetched results:", response.data); // Log de response data
                setResults(response.data);
            })
            .catch((error) => {
                console.error("Error fetching results:", error);
                toast.error("Failed to fetch results");
            });
    };

    useEffect(() => {
        getData();
    }, []);

    useEffect(() => {
        console.log("Results state updated:", results); // Log de results state update
    }, [results]);



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
                }
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
                console.error("Error logging out:", error);
                toast.error("Error logging out");
            });
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
                <h1>Resultaten</h1>
                {results && results.workoutSessieExerciseResults ? (
                    results.workoutSessieExerciseResults.length > 0 ? (
                        results.workoutSessieExerciseResults.map((exerciseResult, exerciseIndex) => (
                            <div className="exercise-box" key={exerciseIndex}>
                                <h2>{exerciseResult.name}</h2>
                                {[...Array(exerciseResult.sets)].map((_, setIndex) => {
                                    const currentIndex =
                                        exerciseIndex * exerciseResult.sets + setIndex;
                                    const stats = results.workoutSessieExerciseStats[currentIndex];
                                    return (
                                        <div key={setIndex}>
                                            <h4>Rep: {setIndex + 1}</h4>
                                            {stats ? (
                                                <h5>
                                                    Gewicht: {stats.gewicht} | Reps: {stats.reps}
                                                </h5>
                                            ) : (
                                                <h5>No stats available</h5>
                                            )}
                                        </div>
                                    );
                                })}
                            </div>
                        ))
                    ) : (
                        <p>Geen resultaten beschikbaar.</p>
                    )
                ) : (
                    <p>Gegevens worden geladen...</p>
                )}
                <div className="button">
                    <Button onClick={() => navigate("/workout")}>Terug naar workouts</Button>
                </div>
            </Container>
        </Fragment>
    );
};

export default WorkoutSessieResults;
