namespace listaTareas.Server.Aplicacion.Entidades
{
    public class Tarea
    {
        private int _id { get; set; }
        private string _nombre { get; set; }
        private string _descripcion { get; set; }
        private DateTime _fecha { get; set; }
        private Boolean finalizo { get; set; }
        
        private int UsuarioId { get; set; }
        public Usuario usuario { get; set; } 
    }
}
