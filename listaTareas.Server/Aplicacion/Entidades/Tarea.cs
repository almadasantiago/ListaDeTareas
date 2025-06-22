using listaTareas.Server.Aplicacion.Entidades;

public class Tarea
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public bool Finalizo { get; set; }
    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; } = null!;

    public Tarea() { }

    public Tarea(string nombre, string descripcion, DateTime fecha, bool finalizo, Usuario usuario)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Fecha = fecha;
        Finalizo = finalizo;
        Usuario = usuario;
        UsuarioId = usuario.Id;
    }
}
