import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './Screens/Home';
import Login from './Screens/Login';
import Register from './Screens/Register';
import Tareas from './Screens/Tareas';
import RutaProtegida from './components/RutaProtegida';
import LayoutConNav from './components/LayoutConNav'; 

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<LayoutConNav />}>
                    <Route index element={<Home />} />
                    <Route path="IniciarSesion" element={<Login />} />
                    <Route path="Registro" element={<Register />} />
                    <Route
                        path="tareas"
                        element={
                            <RutaProtegida>
                                <Tareas />
                            </RutaProtegida>
                        }
                    />
                </Route>
            </Routes>
        </Router>
    );
};

export default App;
