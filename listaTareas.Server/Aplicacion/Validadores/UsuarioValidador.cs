using listaTareas.Server.Aplicacion.Interfaces;

namespace listaTareas.Server.Aplicacion.Validadores
{
    public class UsuarioValidador (IUsuarioRepositorio repo)
    { public bool validar(string nombreUsuario)
        {
            return repo.nombreRepetido(nombreUsuario); 
        } 
    }
}
