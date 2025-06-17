import React from "react";
import { Link } from "react-router-dom";

const NavBar = () => {
    return (
        <nav className="navbar navbar-expand-lg navbar-dark bg-transparent fixed-top">
            <div className="container">
                <Link className="navbar-brand" to="/">ListaTareas</Link>
                <button
                    className="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNav"
                    aria-controls="navbarNav"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <span className="navbar-toggler-icon" />
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav ms-auto align-items-center">
                        <li className="nav-item ms-3">
                            <Link className="btn btn-outline-light" to="/Registro">
                                Registrarse
                            </Link>
                        </li>
                        <li className="nav-item ms-2">
                            <Link className="btn btn-outline-light" to="/IniciarSesion">
                                Iniciar Sesion
                            </Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
};

export default NavBar;
