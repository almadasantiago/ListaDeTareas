using listaTareas.Server.Aplicacion.Interfaces;

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
            Console.WriteLine("DEBUG: Validando nombre de usuario " + nombreUsuario);
            var resultado = repo.nombreRepetido(nombreUsuario);
            Console.WriteLine("DEBUG: Resultado de nombreRepetido: " + resultado);
            return resultado;
        }
    }
}

