import { useState, useEffect, Fragment } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './Exercise.css';
import { FaArrowLeft, FaSignOutAlt } from 'react-icons/fa'


const WorkoutSessie = () => {
    const [data, setData] = useState([]);
    const navigate = useNavigate();
    const { workoutId, workoutName } = useParams();

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
                        <Button variant="outline-light" className="logout-btn" onClick={handleLogout}>Logout <FaSignOutAlt /></Button>
                    </Nav>
                </Container>
            </Navbar>
            <Container fluid>
                <Row className="align-items-center flex-container">
                    <Col xs="auto">
                        <Button className="btn back-btn" onClick={handleBack}> <FaArrowLeft /> Terug </Button>
                    </Col>
                    <Col xs="auto" className="flex-grow-1 text-center">
                        <h2> {workoutName} </h2>
                    </Col>
                </Row>
            </Container>

            <br />
            <Container fluid>
                <Table striped bordered hover className="exercise-custom-table">
                    <thead className="header-row">
                        <tr>
                            <th>#</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.length > 0 ? (
                            data.map((item, index) => (
                                <tr key={index}>
                                    <td>{index + 1}</td>
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
        </Fragment>
    );
};

export default WorkoutSessie;
