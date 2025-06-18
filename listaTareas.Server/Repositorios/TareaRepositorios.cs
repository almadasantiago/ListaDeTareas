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
        void ITareaRepositorio.darDeAltaTarea(string nombre, string descripcion, Usuario usuario)
        {  
            try { var tarea = new Tarea(nombre, descripcion, DateTime.Now, false, usuario);
                db.Tareas.Add(tarea);
                db.SaveChanges();
            }   
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Error al agregar la tarea: {dbEx.Message}");
                Console.WriteLine($"Inner Exception: {dbEx.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {dbEx.StackTrace}");
            }
        }

        void ITareaRepositorio.darDeBajaTarea(int idTarea)
        {  
                var tarea = db.Tareas.FirstOrDefault(t => t._id == idTarea);
                if (tarea == null)
                {
                    throw new Exception($" Tarea con id {idTarea} no encontrado. ");
                }
                db.Tareas.Remove(tarea);
                db.SaveChanges();
        }

        List<Tarea> ITareaRepositorio.listarTareas()
        {
            var tareas = db.Tareas.ToList();
            if (tareas == null) { throw new Exception(" Las tareas aun no fueron cargadas "); }
            else return tareas;  
        }


        void ITareaRepositorio.modificarTarea(int idTarea, string nuevoNombre, string nuevaDesc, Usuario usuario)
        {
            var tarea = db.Tareas.FirstOrDefault(t => t._id == idTarea);
            if (tarea == null) {throw new Exception($"Tarea con ID {idTarea} no encontrado. "); }
            else
            {
               tarea = new Tarea(nuevoNombre, nuevaDesc, DateTime.Now, false, usuario);// reseteo y establezco datos nuevos 
            }
            db.SaveChanges();
        }
    
    
    }
}

