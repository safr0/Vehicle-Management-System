import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import Vehicles  from './components/Vehicles';
import CreateCar from './components/CreateCar';
import EditCar from './components/editCar';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
            <Route path='/fetch-data' component={FetchData} />
            <Route path='/vehicles' component={Vehicles} />
            <Route path='/createCar' component={CreateCar} />
            <Route path='/editCar/:id' component={EditCar} />

        </Layout>
    );
  }
}
