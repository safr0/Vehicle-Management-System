import React, { createContext } from 'react';
import App from './App';
export let color = "Black";

const initialState = {};
const store = createContext(initialState);
const { Provider } = store;

const StateProvider = () => {

    return <Provider value={color} > <App /> </ Provider>
}
export { store, StateProvider };
