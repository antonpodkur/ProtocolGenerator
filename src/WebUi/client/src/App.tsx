import React from 'react';
import {BrowserRouter, Switch, Link, Route} from 'react-router-dom';
import './App.css';

import Login from './Screens/Login';
import Navbar from "./Components/Navbar";
import Home from "./Screens/Home";
import Register from "./Screens/Register";

function App() {
  return (
        <BrowserRouter>
            <header>
                <Navbar/>
            </header>
            <main>
                    <Switch>
                        <Route path="/" component={Home} exact/>
                        <Route path="/login" component={Login}/>
                        <Route path="/register" component={Register}/>
                    </Switch>
            </main>
            <footer>
                
            </footer>
        </BrowserRouter>
  );
}

export default App;
