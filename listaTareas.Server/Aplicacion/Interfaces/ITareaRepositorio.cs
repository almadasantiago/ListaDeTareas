using listaTareas.Server.Aplicacion.Entidades;

namespace listaTareas.Server.Aplicacion.Interfaces
{
    public interface ITareaRepositorio
    {

        public void darDeAltaTarea(string nombre, string descripcion, Usuario usuario);
        public void darDeBajaTarea(int id);
        public void modificarTarea(int idTarea, string nuevoNombre, string nuevaDesc, Usuario usuario);
        public List<Tarea> listarTareas();
    }
}
