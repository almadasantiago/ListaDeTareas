import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';
import { Link } from 'react-router-dom';

const tareasEjemplo = [
    {
        id: 1,
        titulo: 'Estudiar React',
        descripcion: 'Revisar hooks y componentes funcionales',
        fecha: '2025-06-18',
        estado: 'Activa'
    },
    {
        id: 2,
        titulo: 'Hacer ejercicio',
        descripcion: 'Correr 30 minutos al aire libre',
        fecha: '2025-06-17',
        estado: 'Activa'
    }
];

const Tareas = () => {
    return (
        <div className="home-container text-white position-relative">
            <div className="overlay"></div>

            {/* Encabezado y botón */}
            <div className="d-flex justify-content-between align-items-center px-4 pt-3">
                <h2 className="fw-bold">Tus Tareas</h2>
                <button className="btn btn-light">Agregar Tarea</button>
            </div>

            {/* Contenedor de tareas */}
            <div className="container mt-4">
                <div className="row">
                    {tareasEjemplo.map((tarea) => (
                        <div key={tarea.id} className="col-md-6 col-lg-4 mb-4">
                            <div className="card bg-transparent border-light text-white shadow-sm h-100">
                                <div className="card-body">
                                    <h5 className="card-title">{tarea.titulo}</h5>
                                    <p className="card-text">{tarea.descripcion}</p>
                                    <p className="mb-1">
                                        <strong>Fecha:</strong> {tarea.fecha}
                                    </p>
                                    <p>
                                        <strong>Estado:</strong> <span className="text-success">{tarea.estado}</span>
                                    </p>
                                    <div className="d-flex justify-content-between mt-3">
                                        <button className="btn btn-outline-light btn-sm">Modificar</button>
                                        <button className="btn btn-danger btn-sm">Finalizar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

export default Tareas;
