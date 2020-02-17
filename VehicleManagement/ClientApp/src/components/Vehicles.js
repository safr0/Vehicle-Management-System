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
        SpecificationId: 1,
        Engine: "V8",
        Doors : 4,
        BodyType : "Sedan"
    },

    {
        ID: 2,
        Title: "Audi 2",
        Make: "Audi",
        Model: "80",
        Seats: 5,
        VinNumber: "VIN1234567",
        SpecificationId: 1,
        Doors: 4,
        BodyType: "Sedan",
        Engine: "V6",
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
        BodyType: "Sedan",
        Engine: "3.6 lit",
    },
    {
        ID: 4,
        Title: "Audi 202",
        Make: "Audi",
        Model: "80",
        Seats: 5,
        VinNumber: "VIN1234567",
        SpecificationId: 1,
        Doors: 4,
        BodyType: "Sedan",
        Engine: "3.6 lit",
    }
];


//async GetCarList() {
//    const response = await fetch('vehiclemanagement/GetCars');
//    const data = await response.json();
//    this.setState({ carlist: data, loading: false });
//}


export default function Vehicles() {
  


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
        
            //setVehicles(vehicleList);            
            fetch("vehiclemanagement")
                .then(response => response.json())
                .then(data => setVehicles(data));

            setisLLoading(false);

      
    }, []);
    const createCar = () => {

        history.push('/createCar');
    }
    const editCar = (id) => {
        history.push('/editCar/'+id);
    }

    const loading = <div>fetching vehicles <Icon loading size="massive" name='spinner' /> </div>
     
    const vehicleArray = vehicles.map(function (c, index) {
        return <List key={c.id} divided relaxed>
            <List.Item key={c.id}>
                    <List.Icon name='bus' size='large' verticalAlign='middle' />
                <List.Content>
                    <List.Header as='a' onClick={() => { editCar(c.id) }}>{c.title}</List.Header>
                    <List.Description as='a'>Manufactured by {c.make} | having {c.doors} Doors | with {c.engine} Engine and spacious {c.seats} seats for a family car</List.Description>
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
