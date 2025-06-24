import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';
import UsuarioService from '../services/UsuarioService';

const Login = () => {
    const [form, setForm] = useState({ nombreUsuario: '', password: '' });
    const navigate = useNavigate();

    const handleChange = (e) => {
        setForm({ ...form, [e.target.id]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const data = await UsuarioService.login(form);
            localStorage.setItem('usuarioId', data.idUsuario);
            localStorage.setItem('nombreUsuario', data.nombreUsuario);
            navigate('/tareas'); 
        } catch (error) {
            alert(error.response?.data?.error || "Error al iniciar sesión");
        }
    };

    return (
        <div className="home-container d-flex align-items-center justify-content-center text-white position-relative">
            <div className="overlay"></div>
            <div className="home-content text-center p-4 rounded shadow-lg">
                <h2 className="mb-4">Iniciar Sesion</h2>
                <form onSubmit={handleSubmit}>
                    <div className="form-group mb-3 text-start">
                        <label htmlFor="nombreUsuario">Nombre de usuario</label>
                        <input
                            type="text"
                            className="form-control"
                            id="nombreUsuario"
                            placeholder="Ingresar nombre de usuario"
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="form-group mb-4 text-start">
                        <label htmlFor="password">Password</label>
                        <input
                            type="password"
                            className="form-control"
                            id="password"
                            placeholder="Ingresar password"
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-light w-100 mb-3">
                        Ingresar
                    </button>
                    <Link to="/" className="btn btn-outline-light w-100">
                        Volver al Home
                    </Link>
                </form>
            </div>
        </div>
    );
};

export default Login;
