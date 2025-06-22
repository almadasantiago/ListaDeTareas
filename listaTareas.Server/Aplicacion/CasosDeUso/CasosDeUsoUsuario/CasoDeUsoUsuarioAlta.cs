using System.ComponentModel.DataAnnotations;
using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Aplicacion.Validadores;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repo, UsuarioValidador validador)
    {
        public void Ejecutar(string nombreUsuario, string password, string correo)
        {
            if (validador.validar(nombreUsuario))
            {
                throw new Exception("El nombre de usuario ingresado ya se encuentra registrado");
            }
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password); 
            int idUsuario = repo.usuarioAlta(nombreUsuario, passwordPasadaPorHash, correo);

            Console.WriteLine($"Usuario creado con ID {idUsuario}"); 
        }
    }
}
