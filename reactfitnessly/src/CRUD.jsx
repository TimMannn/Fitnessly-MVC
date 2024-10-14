import { useState, useEffect, Fragment } from "react";
import Table from 'react-bootstrap/Table';

const CRUD = () => {

    const FitnesslyData = [
        {
            ID: 1,
            Workout: 'Push'
        },
        {
            ID: 2,
            Workout: 'Pull'
        },
        {
            ID: 3,
            Workout: 'Legs'
        }
    ]

    const [data, setData] = useState([]);

    useEffect(() => {
        setData(FitnesslyData);
    }, [])

    return (
        <Fragment>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>ID</th>
                        <th>Workout</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        data && data.length > 0 ?
                            data.map((item, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{index + 1}</td>
                                        <td>{item.ID}</td>
                                        <td>{item.Workout}</td>
                                    </tr>
                                )
                            })
                            :
                            'Loading...'
                    }
                </tbody>
            </Table>
        </Fragment>
    )
}

export default CRUD;