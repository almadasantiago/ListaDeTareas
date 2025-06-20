using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoTarea
{
    public class CasoDeUsoModificarTarea (ITareaRepositorio repo)
    {
        public void Ejecutar (int idTarea, string nuevoNombre, string nuevaDesc, Usuario usuario)
        {
            repo.modificarTarea(idTarea, nuevoNombre, nuevaDesc, usuario);
        }
    }
}
