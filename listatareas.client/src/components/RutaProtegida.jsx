import React from 'react';
import { Navigate } from 'react-router-dom';

const RutaProtegida = ({ children }) => {
    const usuarioId = localStorage.getItem('usuarioId');

    if (!usuarioId) {
        return <Navigate to="/IniciarSesion" replace />;
    }
    return children;
};

export default RutaProtegida;
