using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Aplicacion.Validadores;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoUsuarioModificar
    {
        private readonly IUsuarioRepositorio repo;
        private readonly UsuarioValidador validador;

        public CasoDeUsoUsuarioModificar(IUsuarioRepositorio repo, UsuarioValidador validador)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.validador = validador ?? throw new ArgumentNullException(nameof(validador));
        }

        public void Ejecutar(int idUsuario, string nombre, string password, string email)
        {
            if (!validador.validarModificacion(idUsuario, nombre))
            {
                throw new Exception("El nombre de usuario ingresado ya existe.");
            }

            string passwordHasheada = ServicioFuncionHash.FuncionHashSHA256(password);
            repo.usuarioModificacion(idUsuario, nombre, passwordHasheada, email);
        }
    }
}
