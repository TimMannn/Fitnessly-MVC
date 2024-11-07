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
                setEditWorkout(result.data.name);
                setEditID(ID);
            })
            .catch((error) => {
                console.log(error);
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

        axios.put(url, data)
            .then(() => {
                getData();
                clear();
                toast.success('Workout has been updated');
                handleClose();
            })
            .catch((error) => {
                toast.error('Error updating workout');
                console.log(error);
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
            .then(() => {
                getData();
                clear();
                toast.success('Workout has been added');
            })
            .catch((error) => {
                toast.error('Error adding workout');
                console.log(error);
            });
    };

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <Fragment>
            <ToastContainer />
            <Container>
                <Row className="container-row">
                    <input type="text" className="form-control" placeholder="Enter workout name"
                        value={Workout} onChange={(e) => setWorkout(e.target.value)} />
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
                            <input type="text" className="form-control" placeholder="Enter workout name"
                                value={editWorkout} onChange={(e) => setEditWorkout(e.target.value)} />
                        </Col>
                    </Row>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleUpdate}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </Fragment>
    );
};

export default CRUD;
