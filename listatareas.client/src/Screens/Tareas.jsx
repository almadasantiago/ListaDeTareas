import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';
import { useNavigate } from 'react-router-dom';
import TareaService from '../services/TareaService';

const Tareas = () => {
    const [tareasData, setTareasData] = useState({ items: [], page: 1, totalPages: 1 });
    const [mostrarFormulario, setMostrarFormulario] = useState(false);
    const [modoEdicion, setModoEdicion] = useState(false);
    const [tareaEditando, setTareaEditando] = useState(null);
    const [tareaForm, setTareaForm] = useState({ Nombre: '', Descripcion: '' });

    const navigate = useNavigate();
    const usuarioId = parseInt(localStorage.getItem('usuarioId'));
    const tamanioPagina = 5;

    useEffect(() => {
        if (!usuarioId) { navigate('/IniciarSesion'); return; }
        fetchPage(1);
    }, [usuarioId, navigate]);

    const fetchPage = async (pagina) => {
        try {
            const data = await TareaService.listarPaginado(usuarioId, pagina, tamanioPagina);
            setTareasData(data);
        } catch (e) {
            console.error(e); alert("Error al cargar tareas.");
        }
    };

    const handlePageClick = (n) => fetchPage(n);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (modoEdicion && tareaEditando) {
                await TareaService.modificar({
                    id: tareaEditando.id,
                    nombre: tareaForm.Nombre,
                    descripcion: tareaForm.Descripcion,
                    idUsuario: usuarioId
                });
            } else {
                await TareaService.crear({
                    nombre: tareaForm.Nombre,
                    descripcion: tareaForm.Descripcion,
                    idUsuario: usuarioId
                });
            }
            toggleFormulario();
            fetchPage(tareasData.page);
        } catch {
            alert("Error al guardar tarea.");
        }
    };

    const toggleFormulario = () => {
        setMostrarFormulario(!mostrarFormulario);
        setModoEdicion(false); setTareaEditando(null);
        setTareaForm({ Nombre: '', Descripcion: '' });
    };

    const editarTarea = (t) => {
        setModoEdicion(true);
        setTareaEditando(t);
        setTareaForm({ Nombre: t.nombre, Descripcion: t.descripcion });
        setMostrarFormulario(true);
    };

    return (
        <div className="home-container text-white position-relative">
            <div className="overlay"></div>
            <div className="d-flex justify-content-between align-items-center px-4 pt-3 position-relative" style={{ zIndex: 2 }}>
                <h2 className="fw-bold">Tus Tareas</h2>
                <button className="btn btn-outline-light" onClick={toggleFormulario} style={{ zIndex: 3 }}>
                    {mostrarFormulario ? "Cerrar Formulario" : "Agregar Tarea"}
                </button>
            </div>
            {mostrarFormulario && (
                <div className="modal-formulario position-fixed top-50 start-50 translate-middle shadow" style={{ zIndex: 1050 }}>
                    <form onSubmit={handleSubmit} className="formulario-tarea-transparent p-4 rounded">
                        <h5 className="mb-4 text-center">{modoEdicion ? "Modificar Tarea" : "Nueva Tarea"}</h5>
                        <div className="form-group mb-3">
                            <label>Titulo</label>
                            <input name="Nombre" className="form-control" value={tareaForm.Nombre} onChange={e => setTareaForm({ ...tareaForm, Nombre: e.target.value })} required />
                        </div>
                        <div className="form-group mb-3">
                            <label>Descripcion</label>
                            <textarea name="Descripcion" className="form-control" rows="3" value={tareaForm.Descripcion} onChange={e => setTareaForm({ ...tareaForm, Descripcion: e.target.value })} required />
                        </div>
                        <button type="submit" className="btn btn-outline-light w-100 mb-2">
                            {modoEdicion ? "Guardar Cambios" : "Crear Tarea"}
                        </button>
                        <button type="button" className="btn btn-danger w-100" onClick={toggleFormulario}>Cancelar</button>
                    </form>
                </div>
            )}

            <div className="container mt-4 position-relative" style={{ zIndex: 2 }}>
                <div className="row">
                    {tareasData.items.map(t => (
                        <div key={t.id} className="col-md-6 col-lg-4 mb-4">
                            <div className="card bg-transparent border-light text-white shadow-sm h-100">
                                <div className="card-body">
                                    <h5 className="card-title">{t.nombre}</h5>
                                    <p className="card-text">{t.descripcion}</p>
                                    <p className="mb-1"><strong>Fecha:</strong> {new Date(t.fecha).toLocaleDateString()}</p>
                                    <div className="d-flex justify-content-between mt-3">
                                        <button className="btn btn-outline-light btn-sm" onClick={() => editarTarea(t)}>Modificar</button>
                                        <button className="btn btn-danger btn-sm" onClick={() => { TareaService.finalizar(t.id).then(() => fetchPage(tareasData.page)); }}>Finalizar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}
                    {tareasData.items.length === 0 && <p className="text-center text-white mt-4">No tenes tareas activas.</p>}
                </div>
                {tareasData.totalPages > 1 && (
                    <ul className="pagination justify-content-center">
                        {Array.from({ length: tareasData.totalPages }, (_, i) => (
                            <li key={i + 1} className="page-item">
                                <button
                                    className={`btn btn-outline-light mx-1 ${tareasData.page === i + 1 ? 'active' : ''}`}
                                    style={{ backgroundColor: 'transparent', borderColor: 'white', color: 'white' }}
                                    onClick={() => handlePageClick(i + 1)}
                                >
                                    {i + 1}
                                </button>
                            </li>
                        ))}
                    </ul>

                )}
            </div>
        </div>
    );
};

export default Tareas;
