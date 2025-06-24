using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using listaTareas.Server.DTOs;
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
            var tarea = db.Tareas.FirstOrDefault(t => t.Id == idTarea && t.UsuarioId == idUsuario);
            if (tarea == null) {throw new Exception($"Tarea con ID {idTarea} no encontrado. "); }

            tarea.Nombre = nuevoNombre;
            tarea.Descripcion = nuevaDesc;
            tarea.Fecha = DateTime.Now; 
            
            db.SaveChanges();
        }
        public PagedResult<Tarea> ListarPaginado(int idUsuario, int pagina, int tamanioPagina)
        {
            var query = db.Tareas.Where(t => t.UsuarioId == idUsuario).OrderBy(t => t.Id);
            var total = query.Count();
            var items = query.Skip((pagina - 1) * tamanioPagina)
                             .Take(tamanioPagina)
                             .ToList();
            return new PagedResult<Tarea> { Items = items, Page = pagina, PageSize = tamanioPagina, TotalItems = total };
        }



    }
}

