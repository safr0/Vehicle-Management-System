import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Vehicles  from './components/Vehicles';
import CreateCar from './components/CreateCar';
import EditCar from './components/EditCar';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Vehicles} />
            <Route path='/vehicles' component={Vehicles} />
            <Route path='/createCar' component={CreateCar} />
            <Route path='/editCar/:id' component={EditCar} />
        </Layout>
    );
  }
}
