import axios from 'axios';

const API_URL = 'http://localhost:5000/api/tareas'; 

const TareaService = {
    listar: async (idUsuario) => {
        const response = await axios.get(`${API_URL}/${idUsuario}`);
        return response.data;
    },

    crear: async (tarea) => {
        const response = await axios.post(`${API_URL}/crear`, tarea);
        return response.data;
    },

    finalizar: async (id) => {
        await axios.delete(`${API_URL}/${id}`);
    },
};

export default TareaService;

