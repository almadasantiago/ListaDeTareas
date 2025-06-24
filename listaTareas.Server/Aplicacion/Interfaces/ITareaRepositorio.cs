using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.DTOs; 

namespace listaTareas.Server.Aplicacion.Interfaces
{
    public interface ITareaRepositorio
    {

        public void darDeAltaTarea(string nombre, string descripcion, int idUsuario);
        public void darDeBajaTarea(int idTarea);
        public void modificarTarea(int idTarea, string nuevoNombre, string nuevaDesc, int idUsuario);
        public List<Tarea> listarTareas();
       PagedResult<Tarea> ListarPaginado(int idUsuario, int pagina, int tamanioPagina);
    }
}
