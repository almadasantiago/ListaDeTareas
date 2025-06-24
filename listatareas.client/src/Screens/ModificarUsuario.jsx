import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';
import UsuarioService from '../services/UsuarioService';
import { useNavigate } from 'react-router-dom';

const ModificarUsuario = () => {
    const [form, setForm] = useState({ nombreUsuario: '', password: '', correo: '' });
    const [cargando, setCargando] = useState(true);
    const navigate = useNavigate();
    const usuarioId = parseInt(localStorage.getItem('usuarioId'));

    useEffect(() => {
        const cargarDatos = async () => {
            try {
                const data = await UsuarioService.obtener(usuarioId);
                setForm({
                    nombreUsuario: data.nombreUsuario,
                    password: data.password,
                    correo: data.correo
                });
                setCargando(false);
            } catch (error) {
                alert("Error al cargar datos del usuario.");
            }
        };
        cargarDatos();
    }, [usuarioId]);

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await UsuarioService.modificar(usuarioId, form);
            alert("Datos actualizados correctamente.");
            navigate("/tareas");
        } catch {
            alert("Error al actualizar el perfil.");
        }
    };

    if (cargando) return null;

    return (
        <div className="home-container d-flex align-items-center justify-content-center text-white position-relative">
            <div className="overlay"></div>
            <div className="modal-formulario position-fixed top-50 start-50 translate-middle shadow" style={{ zIndex: 1050 }}>
                <form onSubmit={handleSubmit} className="formulario-tarea-transparent p-4 rounded">
                    <h5 className="mb-4 text-center">Modificar Perfil</h5>
                    <div className="form-group mb-3">
                        <label>Nombre de Usuario</label>
                        <input type="text" name="nombreUsuario" className="form-control" value={form.nombreUsuario} onChange={handleChange} required />
                    </div>
                    <div className="form-group mb-3">
                        <label>Correo</label>
                        <input type="email" name="correo" className="form-control" value={form.correo} onChange={handleChange} required />
                    </div>
                    <div className="form-group mb-3">
                        <label>Contraseña</label>
                        <input type="password" name="password" className="form-control" value={form.password} onChange={handleChange} required />
                    </div>
                    <button type="submit" className="btn btn-outline-light w-100 mb-2">Guardar Cambios</button>
                    <button type="button" className="btn btn-danger w-100" onClick={() => navigate("/tareas")}>Cancelar</button>
                </form>
            </div>
        </div>
    );
};

export default ModificarUsuario;
