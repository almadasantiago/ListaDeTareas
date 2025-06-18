import React from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';

const Login = () => {
    return (
        <div className="home-container d-flex align-items-center justify-content-center text-white position-relative">
            <div className="overlay"></div>
            <div className="home-content text-center p-4 rounded shadow-lg">
                <h2 className="mb-4">Iniciar Sesion</h2>
                <form>
                    <div className="form-group mb-3 text-start">
                        <label htmlFor="username">Nombre de usuario</label>
                        <input
                            type="text"
                            className="form-control"
                            id="username"
                            placeholder="Ingresar nombre de usuario"
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
                        Ingresar
                    </button>
                    <Link to="/" className="btn btn-outline-light w-100">Volver al Home</Link>
                </form>
            </div>
        </div>
    );
};

export default Login;
