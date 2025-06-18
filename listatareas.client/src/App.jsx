import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './Screens/Home';
import Login from './Screens/Login';
import Register from './Screens/Register'; 

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/IniciarSesion" element={<Login />} />
                <Route path="/Registro" element={<Register />} />
            </Routes>
        </Router>
    );
};

export default App;

