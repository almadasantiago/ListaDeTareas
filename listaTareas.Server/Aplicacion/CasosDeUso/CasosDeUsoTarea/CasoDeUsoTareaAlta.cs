using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoTarea
{
    public class CasoDeUsoTareaAlta(ITareaRepositorio repo) 
    {
        public void Ejecutar(string nombre, string descripcion, int idUsuario)
        {
            repo.darDeAltaTarea(nombre, descripcion, idUsuario); 
        }
    }
}
