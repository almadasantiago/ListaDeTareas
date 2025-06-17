import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';

const Home = () => {
    return (
        <div className="home-container d-flex align-items-center justify-content-center text-white position-relative">
            <div className="overlay"></div>
            <div className="home-content text-center p-4 rounded shadow-lg">
                <h1 className="display-4 mb-3">Bienvenido a la Lista de Tareas</h1>
                <p className="lead">Comienza gestionando tus tareas de forma sencilla.</p>
            </div>
        </div>
    );
};

export default Home;

