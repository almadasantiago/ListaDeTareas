import React from 'react';
import NavBar from '../components/NavBar';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';

const Home = () => {
    return (
        <div className="home-container text-white position-relative">
            <div className="overlay"></div>
            <NavBar />
            <div className="d-flex align-items-center justify-content-center h-100">
                <div className="home-content text-center p-4 rounded shadow-lg">
                    <h1 className="display-4 mb-3">Bienvenido a la Lista de Tareas</h1>
                    <p className="lead">Comienza gestionando tus tareas de forma sencilla.</p>
                </div>
            </div>
        </div>
    );
};

export default Home;
