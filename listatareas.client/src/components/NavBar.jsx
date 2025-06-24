import React, { useState } from "react";
import { Link, useLocation, useNavigate } from "react-router-dom";
import ModalModificarPerfil from "../Screens/ModificarUsuario";

const NavBar = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const [mostrarModalPerfil, setMostrarModalPerfil] = useState(false);

    const usuarioId = localStorage.getItem("usuarioId");
    const nombreUsuario = localStorage.getItem("nombreUsuario") || "Usuario";

    const handleCerrarSesion = () => {
        localStorage.clear();
        navigate("/IniciarSesion");
    };

    const handleVolverInicio = () => {
        navigate("/");
    };

    const rutaActual = location.pathname;

    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-dark bg-transparent fixed-top">
                <div className="container-fluid px-4">
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
                        {usuarioId ? (
                            <div className="d-flex justify-content-between w-100">
                                <button className="btn btn-outline-light" onClick={handleVolverInicio}>
                                    Volver al inicio
                                </button>

                                <div className="dropdown ms-auto">
                                    <button
                                        className="btn btn-outline-light dropdown-toggle"
                                        type="button"
                                        id="dropdownUsuario"
                                        data-bs-toggle="dropdown"
                                        aria-expanded="false"
                                    >
                                        Perfil ({nombreUsuario})
                                    </button>
                                    <ul className="dropdown-menu dropdown-menu-end bg-dark border-light" aria-labelledby="dropdownUsuario">
                                        <li>
                                            <button
                                                className="dropdown-item text-white bg-transparent"
                                                onClick={() => setMostrarModalPerfil(true)}
                                            >
                                                Modificar Perfil
                                            </button>
                                        </li>
                                        <li>
                                            <button className="dropdown-item text-white bg-transparent" onClick={handleCerrarSesion}>
                                                Cerrar Sesión
                                            </button>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        ) : (
                            <ul className="navbar-nav ms-auto align-items-center">
                                {(rutaActual === "/" || rutaActual === "/IniciarSesion") && (
                                    <li className="nav-item ms-2">
                                        <Link className="btn btn-outline-light" to="/Registro">
                                            Registrarse
                                        </Link>
                                    </li>
                                )}
                                {rutaActual === "/Registro" && (
                                    <li className="nav-item ms-2">
                                        <Link className="btn btn-outline-light" to="/IniciarSesion">
                                            Iniciar Sesión
                                        </Link>
                                    </li>
                                )}
                            </ul>
                        )}
                    </div>
                </div>
            </nav>

            {mostrarModalPerfil && (
                <ModalModificarPerfil
                    mostrar={mostrarModalPerfil}
                    cerrarModal={() => setMostrarModalPerfil(false)}
                />
            )}
        </>
    );
};

export default NavBar;
