import { useState, useEffect, Fragment } from "react";
import Table from 'react-bootstrap/Table';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';


const CRUD = () => {
    const FitnesslyData = [
        { ID: 1, Workout: 'Push' },
        { ID: 2, Workout: 'Pull' },
        { ID: 3, Workout: 'Legs' }
    ];

    const [Workout, setWorkout] = useState('')

    const [editID, setEditID] = useState('')
    const [editWorkout, setEditWorkout] = useState('')

    const [data, setData] = useState([]);

    useEffect(() => {
        setData(FitnesslyData);
    }, []);

    const handleEdit = (ID) => {
        //alert(ID);
        handleShow();
    }

    const handleDelete = (ID) => {
        if (window.confirm("Are you sure you want to delete this workout?") == true)
        {
            alert(ID);
        }
    }

    const handleUpdate = () => {

    }

    //pop-up bootstrap modal
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <Fragment>
            <Container>
                <Row>
                    <Col>
                        <input type="text" className="fomr-control" placeholder="Enter workout name"
                            value={Workout} onChange={(e)=> setWorkout(e.target.value)}
                        />
                    </Col>
                    <Col>
                        <button className="btn btn-primary">Submit</button>
                    </Col>
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
                                  <td>{item.ID}</td>
                                  <td>{item.Workout}</td>
                                  <td colSpan={2}>
                                      <button className="btn btn-primary" onClick={() => handleEdit(item.ID)}>Edit</button> | <button className="btn btn-danger" onClick={()=> handleDelete(item.ID) }>Delete</button>
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
                    <Modal.Title>Chance Workout</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>
                        <Col>
                            <input type="text" className="fomr-control" placeholder="Enter workout name"
                                value={editWorkout} onChange={(e) => setEditWorkout(e.target.value)}
                            />
                        </Col>
                        <Col>
                            <button className="btn btn-primary">Update</button>
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
