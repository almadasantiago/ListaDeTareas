using listaTareas.Server.Aplicacion.Entidades;

namespace listaTareas.Server.Aplicacion.Interfaces
{
    public interface IUsuarioRepositorio
    {
        int usuarioAlta(string nombre, string password, string correo);
        void usuarioModificacion(int id, string nuevoNombre, string nuevaPassword, string nuevoCorreo, List<Tarea> tareas);

        int UsuarioInicioDeSesion(string email, string password);
        bool nombreRepetido(string nombre); 


    }
}
