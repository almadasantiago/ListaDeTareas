using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Aplicacion.Entidades;

namespace listaTareas.Server.Aplicacion.Validadores
{
    public class UsuarioValidador
    {
        private readonly IUsuarioRepositorio repo;

        public UsuarioValidador(IUsuarioRepositorio repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public bool validar(string nombreUsuario)
        {
            var usuarioExistente = repo.buscarPorNombre(nombreUsuario);
            return usuarioExistente == null;
        }
        public bool validarModificacion(int idUsuario, string nombreUsuario)
        {
            var usuarioExistente = repo.buscarPorNombre(nombreUsuario);
            if (usuarioExistente == null) return true;
            return usuarioExistente.Id == idUsuario;  
        }
    }
}
