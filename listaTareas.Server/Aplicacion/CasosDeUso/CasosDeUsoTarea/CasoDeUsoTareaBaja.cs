using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoTarea
{
    public class CasoDeUsoTareaBaja (ITareaRepositorio repo)
    {
        public void Ejecutar(int idTarea)
        {
            repo.darDeBajaTarea(idTarea);
        }
    }
}
