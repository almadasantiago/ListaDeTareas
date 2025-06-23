using listaTareas.Server.Aplicacion.Entidades;

namespace listaTareas.Server.DTOs
{
    public class TareaDTO
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime fecha { get; set; }
        public int idUsuario { get; set; }
    }
}
