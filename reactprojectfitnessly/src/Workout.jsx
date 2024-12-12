import { useState, useEffect, Fragment } from "react";
import { useNavigate } from "react-router-dom";
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
import './Workout.css';
import { jwtDecode } from 'jwt-decode' // import dependency
// If using v3 or earlier, use this instead:
// import jwtDecode from 'jwt-decode' // import dependency


const CRUD = () => {
    const [Workout, setWorkout] = useState('');
    const [editID, setEditID] = useState('');
    const [editWorkout, setEditWorkout] = useState('');
    const [data, setData] = useState([]);
    const navigate = useNavigate();

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const token = localStorage.getItem('token');
        console.log("Sending Token:", token);
        axios.get('https://localhost:7187/api/Workout', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((result) => {
                console.log(result.data);
                setData(result.data);
            })
            .catch((error) => {
                console.error('Error fetching workouts:', error);
                toast.error("Failed to fetch workouts");
            });
    };

    const handleEdit = (ID) => {
        const token = localStorage.getItem('token');
        handleShow();
        axios.get(`https://localhost:7187/api/Workout/${ID}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((result) => {
                console.log('Workout data opgehaald:', result.data);
                setEditWorkout(result.data.name);
                setEditID(ID);
                console.log('editWorkout updated to:', result.data.name);
            })
            .catch((error) => {
                console.error('Error bij het ophalen van workout:', error);
                toast.error("Failed to fetch workout");
            });
    };

    const handleDelete = (ID) => {
        const token = localStorage.getItem('token');
        if (window.confirm("Are you sure you want to delete this workout?")) {
            axios.delete(`https://localhost:7187/api/Workout/${ID}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            })
                .then((result) => {
                    if (result.status === 200) {
                        toast.success("Workout has been deleted");
                        getData();
                    }
                })
                .catch((error) => {
                    toast.error("Failed deleting workout");
                    console.log(error);
                });
        }
    };

    const handleUpdate = () => {
        const token = localStorage.getItem('token');
        if (!token) {
            toast.error('No token found'); return;
        } 
            const decodedToken = jwtDecode(token);
            const userId = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];


        const url = `https://localhost:7187/api/Workout/${editID}`;
        const data = {
            "workoutId": editID,
            "workoutName": editWorkout,
            "userId" : userId
        };

        const clear = () => {
            setWorkout('');
            setEditWorkout('');
            setEditID('');
        };

        if (editWorkout.trim() === '') {
            toast.error('Workout name cannot be empty');
            return;
        }

        axios.put(url, data, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((response) => {
                if (response.status === 200) {
                    getData();
                    clear();
                    handleClose();
                    toast.success('Workout has been updated');
                } else {
                    toast.error(`Error updating workout: ${response.data.message}`);
                }
            })
            .catch((error) => {
                console.error('Error details:', error.response);
                const errorMessages = error.response?.data?.messages || [error.response?.data?.message || 'Error updating workout'];
                errorMessages.forEach(msg => toast.error(msg));
            });
    };


    const handleSave = () => {
        const token = localStorage.getItem('token');
        if (!token) {
            return; // Zorg ervoor dat er een token is
        }

        const decodedToken = jwtDecode(token);
        const userId = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"]; // Gebruik de juiste claim

        console.log(decodedToken); // Controleer de inhoud van het gedecodeerde token

        const url = "https://localhost:7187/api/Workout";
        const data = {
            "userId": userId,
            "workoutName": Workout
        };

        const clear = () => {
            setWorkout('');
            setEditWorkout('');
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
                    handleClose();
                    toast.success('Workout has been added');
                } else {
                    toast.error(`Error adding workout: ${response.data.message}`);
                }
            })
            .catch((error) => {
                const errorMessages = error.response?.data?.messages || [error.response?.data?.message || 'Error adding workout'];
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

    const handleRowClick = (workoutId) => {
        const token = localStorage.getItem('token');
        navigate(`/exercise/${workoutId}`, { state: { token: token } });
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
                <Row className="container-row mt-3 justify-content-center">
                    <Col xs={12} sm={8} md={6} lg={4} xl={3} className="mx-auto text-center">
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Enter workout name"
                            value={Workout}
                            onChange={(e) => setWorkout(e.target.value)}
                            minLength={3}
                            maxLength={50}
                            required
                        />
                        <Button className="btn submit-btn mt-3" onClick={handleSave}>Submit</Button>
                    </Col>
                </Row>
            </Container>
            <br />
            <Container fluid>
                <Table striped bordered hover className="custom-table">
                    <thead className="header-row">
                        <tr>
                            <th>#</th>
                            <th>Workout</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.length > 0 ? (
                            data.map((item, index) => (
                                <tr key={index} onClick={() => handleRowClick(item.id)}>
                                    <td>{index + 1}</td>
                                    <td>{item.name}</td>
                                    <td>
                                        <Button className="btn edit-btn" onClick={(e) => { e.stopPropagation(); handleEdit(item.id); }}>Edit</Button> |
                                        <Button className="btn delete-btn" onClick={(e) => { e.stopPropagation(); handleDelete(item.id); }}>Delete</Button>
                                    </td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="3">Loading...</td>
                            </tr>
                        )}
                    </tbody>

                </Table>
            </Container>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Change Workout</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col>
                            <input
                                type="text"
                                className="form-control"
                                placeholder="Enter workout name"
                                value={editWorkout}
                                onChange={(e) => setEditWorkout(e.target.value)}
                                minLength={3}
                                maxLength={50}
                                required
                            />
                        </Col>
                    </Row>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>Close</Button>
                    <Button variant="primary" onClick={handleUpdate}>Save Changes</Button>
                </Modal.Footer>
            </Modal>
        </Fragment>
    );
};

export default CRUD;