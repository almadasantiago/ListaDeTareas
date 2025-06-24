import axios from 'axios';
const API_URL = 'http://localhost:5000/api/tareas';

const TareaService = {
    listarPaginado: async (idUsuario, pagina, tamanioPagina) => {
        const resp = await axios.get(API_URL, {
            params: { idUsuario, pagina, tamanioPagina }
        });
        return resp.data;
    },
    crear: async (tarea) => {
        const resp = await axios.post(`${API_URL}/crear`, tarea);
        return resp.data;
    },
    finalizar: async (id) => {
        await axios.delete(`${API_URL}/${id}`);
    },
    modificar: async (tarea) => {
        await axios.put(`${API_URL}/modificar`, tarea);
    }
};

export default TareaService;
