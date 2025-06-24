using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.DTOs;

namespace listaTareas.Server.Aplicacion.Interfaces
{
    public interface IUsuarioRepositorio
    {
        int usuarioAlta(string nombre, string password, string correo);
        void usuarioModificacion(int id, string nuevoNombre, string nuevaPassword, string nuevoCorreo, List<Tarea> tareas);

        int UsuarioInicioDeSesion(string email, string password);
        bool nombreRepetido(string nombre);

         Task<UsuarioDTO> ObtenerPorId(int id);


        }
    }
