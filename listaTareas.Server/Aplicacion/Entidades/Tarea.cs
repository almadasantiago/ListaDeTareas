namespace listaTareas.Server.Aplicacion.Entidades
{
    public class Tarea
    {
        public int _id { get; set; }
        private string _nombre { get; set; }
        private string _descripcion { get; set; }
        private DateTime _fecha { get; set; }
        private Boolean finalizo { get; set; }
        
        public int UsuarioId { get; set; }
        public Usuario usuario { get; set; } 
    
        public Tarea (string nombre, string descripcion , DateTime fecha, Boolean finalizo, Usuario usuario)
        {
            this._nombre = nombre;
            this._descripcion = descripcion; 
            this._fecha = fecha;
            this.finalizo = finalizo;
            this.UsuarioId = usuario._id;
            this.usuario = usuario; 
        }
    
    }
}
