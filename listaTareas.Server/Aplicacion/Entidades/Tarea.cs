using listaTareas.Server.Aplicacion.Entidades;

public class Tarea
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public bool Finalizo { get; set; }
    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; }

    public Tarea() { }

    public Tarea(string nombre, string descripcion, DateTime fecha, bool finalizo, int idUsuario)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Fecha = fecha;
        Finalizo = finalizo;
        UsuarioId = idUsuario;
    }
}
