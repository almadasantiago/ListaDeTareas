using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoUsuarioIniciarSesion (IUsuarioRepositorio repo) 
    {
        public int Ejecutar(string nombreUsuario, string password) 
        {
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
            return repo.UsuarioInicioDeSesion(nombreUsuario, password); 
        }
    }
}
