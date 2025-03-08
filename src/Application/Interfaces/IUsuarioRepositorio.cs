using System.Threading.Tasks;
using Application;
using ListaTareas.Application;
using Repositories; 

namespace Repositories
{
    public interface IUsuarioRepositorio
    {
        Task<string> UsuarioAltaAsync(string nombre, string apellido, string email, string nombreUsuario, string password);
        Task<bool> ModificarUsuarioAsync(string usuarioId, string nombre, string apellido, string email, string nombreUsuario, string password);
        Task <Usuario> UsuarioInicioDeSesion(string nombreUsuario);
        Task<bool> EmailRepetido(string? email);
    }
}