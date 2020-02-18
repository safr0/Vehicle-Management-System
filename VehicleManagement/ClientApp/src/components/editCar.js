import React, { useState, useEffect } from 'react'
import { Button, Checkbox, Form } from 'semantic-ui-react';
import { useHistory, useParams } from "react-router-dom";


const EditCar = () => {

    let { id } = useParams();
    const history = useHistory();
    const [vehicle, setVehicle] = useState({});
    useEffect(() => {

        fetch("vehiclemanagement/" + id)
            .then(response => response.json())
            .then(data => setVehicle(data));
    }, []);

    const cancelCar = (event) => {
        history.push('/vehicles');
    }
    const editCar = (event) => {
        event.preventDefault();
        console.log(vehicle);

        fetch('vehiclemanagement/' + id, {
            method: 'PUT', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(vehicle),
        })
            .then((response) => response.json())
            .then((data) => {
                history.push('/vehicles');
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
    const updateForm = (e) => {
        console.log(e.target.value);
        setVehicle({ ...vehicle, [e.target.name]: e.target.value });
    }
    return (
        <Form onSubmit={editCar} >
            <Form.Field>
                <label>Title</label>
                <input required name="title" value={vehicle.title} onChange={updateForm} placeholder='Title' />
            </Form.Field>
            <Form.Field>
                <label>Make</label>
                <input required name="make" value={vehicle.make} onChange={updateForm} placeholder='Make' />
            </Form.Field>
            <Form.Field>
                <label>Model</label>
                <input required name="model" value={vehicle.model} onChange={updateForm} placeholder='Model' />
            </Form.Field>

            <Form.Field>
                <label>Seats</label>
                <input max="24" min="1" type="number" name="seats" value={vehicle.seats} onChange={updateForm} placeholder='seats' />
            </Form.Field>

            <Form.Field>
                <label>VINNumber</label>
                <input required name="vinNumber" value={vehicle.vinNumber} onChange={updateForm} placeholder='Model' />
            </Form.Field>

            <Form.Field>
                <label>Engine</label>
                <input required name="engine" value={vehicle.engine} onChange={updateForm} placeholder='Model' />
            </Form.Field>
            <Form.Field>
                <label>Doors</label>
                <input required type="number" max="10" min="1" name="doors" value={vehicle.doors} onChange={updateForm} placeholder='Model' />
            </Form.Field>



            <Button className="mrrm" type='submit'>Submit</Button>
            <Button onClick={cancelCar}>Cancel</Button>
        </Form>
    );
}

export default EditCar