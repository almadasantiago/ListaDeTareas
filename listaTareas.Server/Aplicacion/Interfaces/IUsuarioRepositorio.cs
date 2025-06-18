using listaTareas.Server.Aplicacion.Entidades;

namespace listaTareas.Server.Aplicacion.Interfaces
{
    public interface IUsuarioRepositorio
    {
        void usuarioAlta(string nombre, string password, string correo);
        void usuarioModificiacion(string nuevoNombre, string nuevaPassword, string nuevoCorreo, List<Tarea> tareas);

        Usuario UsuarioInicioDeSesion(string email, string password);
        bool emailRepetido(string email); 


    }
}
