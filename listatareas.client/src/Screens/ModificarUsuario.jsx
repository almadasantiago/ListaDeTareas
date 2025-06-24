import React, { useEffect, useState } from 'react';
import UsuarioService from '../services/UsuarioService';

const ModalModificarPerfil = ({ mostrar, cerrarModal }) => {
    const [formData, setFormData] = useState({
        nombreUsuario: '',
        correo: '',
        password: ''
    });

    const usuarioId = parseInt(localStorage.getItem("usuarioId"), 10);

    useEffect(() => {
        const fetchUsuario = async () => {
            if (!usuarioId || isNaN(usuarioId)) {
                alert("ID de usuario inválido.");
                return;
            }

            try {
                const usuario = await UsuarioService.obtenerPorId(usuarioId);
                setFormData({
                    nombreUsuario: usuario.nombreUsuario,
                    correo: usuario.correo,
                    password: ''
                });
            } catch (e) {
                alert("Error al cargar los datos del perfil.");
            }
        };

        if (mostrar) fetchUsuario();
    }, [mostrar, usuarioId]);

    const handleChange = e => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async e => {
        e.preventDefault();
        try {
            await UsuarioService.modificar(usuarioId, formData);
            localStorage.setItem("nombreUsuario", formData.nombreUsuario);
            alert("Perfil actualizado correctamente.");
            cerrarModal();
        } catch {
            alert("Error al modificar perfil.");
        }
    };

    if (!mostrar) return null;

    return (
        <div className="modal-formulario position-fixed top-50 start-50 translate-middle shadow" style={{ zIndex: 1050 }}>
            <form onSubmit={handleSubmit} className="formulario-tarea-transparent p-4 rounded">
                <h5 className="mb-4 text-center">Modificar Perfil</h5>
                <div className="form-group mb-3">
                    <label>Nombre de Usuario</label>
                    <input
                        type="text"
                        className="form-control"
                        name="nombreUsuario"
                        value={formData.nombreUsuario}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group mb-3">
                    <label>Correo</label>
                    <input
                        type="email"
                        className="form-control"
                        name="correo"
                        value={formData.correo}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group mb-3">
                    <label>Contraseña</label>
                    <input
                        type="password"
                        className="form-control"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit" className="btn btn-outline-light w-100 mb-2">Guardar Cambios</button>
                <button type="button" className="btn btn-danger w-100" onClick={cerrarModal}>Cancelar</button>
            </form>
        </div>
    );
};

export default ModalModificarPerfil;
