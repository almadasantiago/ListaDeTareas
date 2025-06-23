using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;    

namespace listaTareas.Server.Repositorios
{
    public class TareaRepositorios : ITareaRepositorio 
    {
        private readonly ApplicationDbContext db;

        public TareaRepositorios (ApplicationDbContext context) {
            db = context; 
        }
        void ITareaRepositorio.darDeAltaTarea(string nombre, string descripcion, int idUsuario)
        {  
            var tarea = new Tarea(nombre, descripcion, DateTime.Now, false, idUsuario);
                db.Tareas.Add(tarea);
                db.SaveChanges();
        }

        void ITareaRepositorio.darDeBajaTarea(int idTarea)
        {       var tarea  = db.Tareas.FirstOrDefault(t => t.Id == idTarea);
            if (tarea == null)
            {
                throw new Exception(" Tarea inexistente ");
            }
            else
            {
                db.Tareas.Remove(tarea);
                db.SaveChanges();
            }
        }

        List<Tarea> ITareaRepositorio.listarTareas()
        {
            var tareas = db.Tareas.ToList();
            if (tareas == null) { throw new Exception(" Las tareas aun no fueron cargadas "); }
            else return tareas;  
        }


        void ITareaRepositorio.modificarTarea(int idTarea, string nuevoNombre, string nuevaDesc, int idUsuario)
        {
            var tarea = db.Tareas.FirstOrDefault(t => t.Id == idTarea);
            if (tarea == null) {throw new Exception($"Tarea con ID {idTarea} no encontrado. "); }
            else
            {
               tarea = new Tarea(nuevoNombre, nuevaDesc, DateTime.Now, false, idUsuario);// reseteo y establezco datos nuevos 
            }
            db.SaveChanges();
        }
    
    
    }
}

