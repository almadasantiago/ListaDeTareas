using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoListarTareas (ITareaRepositorio repo)
    {
        public List<Tarea> Ejecutar()
        {
            return repo.listarTareas();  
        }

    }
}
