import { useState, useEffect, Fragment } from "react";
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

const CRUD = () => {
    const [Workout, setWorkout] = useState('');
    const [editID, setEditID] = useState('');
    const [editWorkout, setEditWorkout] = useState('');
    const [data, setData] = useState([]);

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        axios.get('https://localhost:7187/api/Api')
            .then((result) => {
                console.log(result.data);
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const handleEdit = (ID) => {
        handleShow();
        axios.get(`https://localhost:7187/api/Api/${ID}`)
            .then((result) => {
                console.log('Workout data opgehaald:', result.data);
                setEditWorkout(result.data.name);
                setEditID(ID);
                console.log('editWorkout updated to:', result.data.name);
            })
            .catch((error) => {
                console.error('Error bij het ophalen van workout:', error);
            });
    };



    const handleDelete = (ID) => {
        if (window.confirm("Are you sure you want to delete this workout?")) {
            axios.delete(`https://localhost:7187/api/Api/${ID}`)
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
        const url = `https://localhost:7187/api/Api/${editID}`;
        const data = {
            "workoutId": editID,
            "workoutName": editWorkout
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

        axios.put(url, data)
            .then((response) => {
                if (response.status === 200) {
                    getData();
                    clear();
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




    const handelSave = () => {
        const url = "https://localhost:7187/api/Api";
        const data = {
            "workoutName": Workout
        };

        const clear = () => {
            setWorkout('');
            setEditWorkout('');
            setEditID('');
        };

        axios.post(url, data)
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






    return (
        <Fragment>
            <ToastContainer />
            <Container>
                <Row className="container-row">
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
                    <button className="btn btn-primary" onClick={handelSave}>Submit</button>
                </Row>
            </Container>
            <br></br>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Workout</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {data.length > 0 ? (
                        data.map((item, index) => (
                            <tr key={index}>
                                <td>{item.id}</td>
                                <td>{item.name}</td>
                                <td colSpan={2}>
                                    <button className="btn btn-primary" onClick={() => handleEdit(item.id)}>Edit</button> | <button className="btn btn-danger" onClick={() => handleDelete(item.id)}>Delete</button>
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
