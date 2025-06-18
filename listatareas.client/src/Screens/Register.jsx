import React from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css'; 

const Register = () => {
    return (
        <div className="home-container d-flex align-items-center justify-content-center text-white position-relative">
            <div className="overlay"></div>
            <div className="home-content text-center p-4 rounded shadow-lg">
                <h2 className="mb-4">Registrarse</h2>
                <form>
                    <div className="form-group mb-3 text-start">
                        <label htmlFor="nombreusuario">Nombre de usuario</label>
                        <input
                            type="text"
                            className="form-control"
                            id="nombreusuario"
                            placeholder="Ingresa un nombre de usuario"
                        />
                    </div>
                    <div className="form-group mb-3 text-start">
                        <label htmlFor="correo">Correo electronico</label>
                        <input
                            type="email"
                            className="form-control"
                            id="correo"
                            placeholder="ejemplo@correo.com"
                        />
                    </div>
                    <div className="form-group mb-4 text-start">
                        <label htmlFor="password">Password</label>
                        <input
                            type="password"
                            className="form-control"
                            id="password"
                            placeholder="Ingresar password"
                        />
                    </div>
                    <button type="submit" className="btn btn-light w-100 mb-3">
                        Crear cuenta
                    </button>
                    <Link to="/" className="btn btn-outline-light w-100">
                        Volver al Home
                    </Link>
                </form>
            </div>
        </div>
    );
};

export default Register;
