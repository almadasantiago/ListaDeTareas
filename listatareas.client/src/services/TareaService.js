import axios from 'axios';

const API_URL = 'https://localhost:5001/api/tareas';

const TareaService = {
    listar: async (idUsuario) => {
        const response = await axios.get(`${API_URL}/${idUsuario}`);
        return response.data;
    },
    crear: async (tarea) => {
        const response = await axios.post(`${API_URL}/crear`, tarea);
        return response.data;
    },
    finalizar: async (idTarea) => {
        const response = await axios.delete(`${API_URL}/${idTarea}`);
        return response.data;
    }
};

export default TareaService;

