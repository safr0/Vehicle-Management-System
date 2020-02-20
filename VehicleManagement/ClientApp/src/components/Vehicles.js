import React, { Component, useContext, useState, useEffect } from 'react';
import { Button, Icon, List, Dropdown, Input } from 'semantic-ui-react';
import { useHistory } from "react-router-dom";

export default function Vehicles() {
    const [vehicles, setVehicles] = useState([]);
    const [searchVehicles, setSearchVehicles] = useState([]);

    const [isLoading, setisLLoading] = useState(true);

    const history = useHistory();
    useEffect(() => {
        fetch("vehiclemanagement")
            .then(response => response.json())
            .then(data => {
                setVehicles(data);
                setSearchVehicles(data);
            });

        setisLLoading(false);
    }, []);
    const createCar = () => {
        history.push('/createCar');
    }
    const editCar = (id) => {
        history.push('/editCar/' + id);
    }

    const loading = <div>fetching vehicles <Icon loading size="massive" name='spinner' /> </div>

    const searchVehicle = (event) => {
        let val = event.target.value;
        if (!val || val === "") {
            setSearchVehicles(vehicles);

        }
        else {
            val = val.toLowerCase();
            let searchResult = vehicles.filter(e => e.title.toLowerCase().indexOf(val) > -1 || e.make.toLowerCase().indexOf(val) > -1);
            setSearchVehicles(searchResult);
        }
    }

    const vehicleArray = searchVehicles.map(function (c, index) {
        return <List key={c.id} divided relaxed>
            <List.Item key={c.id}>
                <List.Icon name='car' size='large' verticalAlign='middle' />
                <List.Content>
                    <List.Header as='a' onClick={() => { editCar(c.id) }}>{c.title}</List.Header>
                    <List.Description as='a'>Manufactured by {c.make} | having {c.doors} Doors | with {c.engine} Engine and spacious {c.seats} seats for a family car</List.Description>
                </List.Content>
            </List.Item>
        </List>;
    });

    return (
        <div >
            <div className="displayInline"><Input className="mrrm" onChange={searchVehicle} icon={{ name: 'search', circular: true, link: true }} placeholder='Search...' />
            </div>
            <Dropdown
                button
                className='icon'
                floating
                labeled
                onChange={createCar}
                pointing='top left'
                icon='add'
                options={[{ key: "Cars", text: "Car", icon: 'car' }]}
                text='Create'/>
            {isLoading ? loading : vehicleArray}
        </div>
    );
}
