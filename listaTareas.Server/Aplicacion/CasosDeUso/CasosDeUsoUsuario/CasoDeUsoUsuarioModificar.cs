using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Aplicacion.Validadores;
using System.ComponentModel.DataAnnotations;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoUsuarioModificar(IUsuarioRepositorio repo, UsuarioValidador validador)
    {
        public void Ejecutar(int idUsuario, string nombre,string password, string email, List<Tarea> tareas)
        {
            if (!validador.validar(nombre))
            {
                throw new Exception("El nombre de usuario ingresado ya existe ");
            };
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
            repo.usuarioModificacion(idUsuario, nombre,passwordPasadaPorHash,email,tareas);
        }
    }
}
