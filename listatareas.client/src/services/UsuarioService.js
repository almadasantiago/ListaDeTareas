import axios from 'axios';

const API_URL = 'https://localhost:5001/api/usuarios';

const UsuarioService = {
    registrar: async (usuario) => {
        const response = await axios.post(`${API_URL}/registrar`, usuario);
        return response.data;
    },
    login: async (credenciales) => {
        const response = await axios.post(`${API_URL}/login`, credenciales);
        return response.data;
    }
};

export default UsuarioService;
