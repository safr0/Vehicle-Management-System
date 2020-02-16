import React, { Component, useContext, useState, useEffect } from 'react';
import { Button, Icon, List, Dropdown } from 'semantic-ui-react';
import { useHistory } from "react-router-dom";
import { store } from '../store';
const vehicleList = [

    {

        ID : 1,
        Title : "Audi 80",
        Make : "Audi",
        Model : "80",
        Seats : 5,
        VinNumber : "VIN1234567",
        SpecificationId : 1,
        Doors : 4,
        BodyType : "Sedan"


    },

    {

        ID: 2,
        Title: "Audi 2",
        Make: "Audi2",
        Model: "80",
        Seats: 5,
        VinNumber: "VIN1234567",
        SpecificationId: 1,
        Doors: 4,
        BodyType: "Sedan"


    },
    {

        ID: 3,
        Title: "Audi 808",
        Make: "Audi",
        Model: "80",
        Seats: 5,
        VinNumber: "VIN1234567",
        SpecificationId: 1,
        Doors: 4,
        BodyType: "Sedan"


    },

    {

        ID: 4,
        Title: "Audi 202",
        Make: "Audi2",
        Model: "80",
        Seats: 5,
        VinNumber: "VIN1234567",
        SpecificationId: 1,
        Doors: 4,
        BodyType: "Sedan"


    }

];
export default function Vehicles(){




  //constructor(props) {
  //  super(props);
  //  this.state = { currentCount: 0, vehicles:[], isLoading: true };
  //  }
    //const context = useContext(store);
    //console.log('context value', context);
    const [vehicles, setVehicles] = useState([]);
    const [isLoading, setisLLoading] = useState(true);
    const history = useHistory();
    //componentWillMount() {

    //    setTimeout(() => {
    //        //this.setState({ vehicles: vehicleList, isLoading: false })
    //        this.setState({ vehicles: vehicleList,  isLoading: false});
    //    }, 3000);
        
    //}
    useEffect(() => {
        setTimeout(() => {
            setVehicles(vehicleList);
            setisLLoading(false);
        }, 3000);
    }, []);
    const createCar = () => {

        history.push('/createCar');
    }

        const loading = <div>fetching vehicles <Icon loading size="massive" name='spinner' /> </div>
     
    const vehicleArray = vehicleList.map(function (c, index) {
        return <List key={c.ID} divided relaxed>
            <List.Item key={c.ID}>
                    <List.Icon name='bus' size='large' verticalAlign='middle' />
                    <List.Content>
                        <List.Header as='a'>{c.Title}</List.Header>
                        <List.Description as='a'>{c.Make} | having {c.Doors} Doors </List.Description>
                    </List.Content>
                </List.Item>
            </List>;
        }); 

            


    return (
        <div>

            <Dropdown
                button
                className='icon'
                floating
                labeled
                onClick={createCar}
                icon='add'
                options={[{ key: "Cars", text: "Cars" }]}
                text='Create'
            />

            {isLoading ? loading :
                vehicleArray}
      </div>
    );
}
