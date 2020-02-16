import React, { useState } from 'react'
import { Button, Checkbox, Form } from 'semantic-ui-react'

const CreateCar = () => {

    


    const addCar = (event, v, b) => {
        event.preventDefault();
        console.log(event.target.elements.Title.value) // from elements property
        console.log(event.target.Make.value)   
    }

    return (
        <Form onSubmit={addCar} >
            <Form.Field>
                <label>Title</label>
                <input name="Title" placeholder='Title' />
            </Form.Field>
            <Form.Field>
                <label>Make</label>
                <input name="Make" placeholder='Make' />
            </Form.Field>
            <Form.Field>
                <label>Model</label>
                <input placeholder='Model' />
            </Form.Field>

            <Button  type='submit'>Submit</Button>
        </Form>
    );
}

export default CreateCar