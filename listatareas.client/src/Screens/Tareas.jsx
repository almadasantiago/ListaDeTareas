import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';
import { useNavigate } from 'react-router-dom';
import TareaService from '../services/TareaService';

const Tareas = () => {
    const [tareas, setTareas] = useState([]);
    const [mostrarFormulario, setMostrarFormulario] = useState(false);
    const [nuevaTarea, setNuevaTarea] = useState({ titulo: '', descripcion: '' });

    const navigate = useNavigate();
    const usuarioId = localStorage.getItem('usuarioId');

    useEffect(() => {
        const cargarTareas = async () => {
            try {
                if (!usuarioId) {
                    navigate('/IniciarSesion');
                    return;
                }
                const data = await TareaService.listar(usuarioId);
                setTareas(data);
            } catch (error) {
                console.error("Error al obtener tareas:", error);
                alert("No se pudieron cargar las tareas.");
            }
        };

        cargarTareas();
    }, [usuarioId, navigate]);

    const handleInputChange = (e) => {
        setNuevaTarea({ ...nuevaTarea, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await TareaService.crear({ ...nuevaTarea, idUsuario: parseInt(usuarioId) });
            setNuevaTarea({ titulo: '', descripcion: '' });
            setMostrarFormulario(false);

            const dataActualizada = await TareaService.listar(usuarioId);
            setTareas(dataActualizada);
        } catch (error) {
            console.error("Error al crear tarea:", error);
            alert("No se pudo crear la tarea.");
        }
    };

    const finalizarTarea = async (id) => {
        try {
            await TareaService.finalizar(id);
            const tareasActualizadas = await TareaService.listar(usuarioId);
            setTareas(tareasActualizadas);
        } catch (error) {
            console.error("Error al finalizar tarea:", error);
            alert("No se pudo finalizar la tarea.");
        }
    };

    return (
        <div className="home-container text-white position-relative">
            <div className="overlay"></div>

            <div className="d-flex justify-content-between align-items-center px-4 pt-3">
                <h2 className="fw-bold">Tus Tareas</h2>
                <button
                    className="btn btn-light"
                    onClick={() => setMostrarFormulario(!mostrarFormulario)}
                >
                    {mostrarFormulario ? "Cancelar" : "Agregar Tarea"}
                </button>
            </div>

            {mostrarFormulario && (
                <div className="container mt-4">
                    <form onSubmit={handleSubmit} className="bg-dark p-4 rounded shadow-sm">
                        <div className="form-group mb-3">
                            <label htmlFor="titulo">Título</label>
                            <input
                                type="text"
                                name="titulo"
                                className="form-control"
                                value={nuevaTarea.titulo}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div className="form-group mb-3">
                            <label htmlFor="descripcion">Descripción</label>
                            <textarea
                                name="descripcion"
                                className="form-control"
                                rows="3"
                                value={nuevaTarea.descripcion}
                                onChange={handleInputChange}
                                required
                            ></textarea>
                        </div>
                        <button type="submit" className="btn btn-success w-100">
                            Crear Tarea
                        </button>
                    </form>
                </div>
            )}

            <div className="container mt-4">
                <div className="row">
                    {tareas.map((tarea) => (
                        <div key={tarea.id} className="col-md-6 col-lg-4 mb-4">
                            <div className="card bg-transparent border-light text-white shadow-sm h-100">
                                <div className="card-body">
                                    <h5 className="card-title">{tarea.titulo}</h5>
                                    <p className="card-text">{tarea.descripcion}</p>
                                    <p className="mb-1"><strong>Fecha:</strong> {tarea.fechaAlta}</p>
                                    <p><strong>Estado:</strong> <span className="text-success">Activa</span></p>
                                    <div className="d-flex justify-content-between mt-3">
                                        <button className="btn btn-outline-light btn-sm">Modificar</button>
                                        <button
                                            className="btn btn-danger btn-sm"
                                            onClick={() => finalizarTarea(tarea.id)}
                                        >
                                            Finalizar
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}
                    {tareas.length === 0 && (
                        <div className="text-center text-white mt-4">
                            <p>No tenés tareas activas.</p>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default Tareas;
