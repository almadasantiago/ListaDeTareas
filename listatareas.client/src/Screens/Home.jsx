import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

const Home = () => {
    return (
        <div className="min-vh-100 bg-light d-flex flex-column" style={{ background: 'linear-gradient(to bottom, #ffffff, #dee2e6)' }}>
            <div className="d-flex justify-content-end p-3">
                <button className="btn btn-outline-primary me-2">Iniciar sesión</button>
                <button className="btn btn-primary">Registrarse</button>
            </div>
            <div className="flex-grow-1 d-flex justify-content-center align-items-center text-center">
                <div>
                    <h1 className="display-4 mb-4 text-primary fw-bold">¡Bienvenido a Lista de Tareas!</h1>
                    <p className="lead text-secondary">Organizá tus tareas diarias de forma rápida y sencilla.</p>
                </div>
            </div>

        </div>
    );
};

export default Home;
