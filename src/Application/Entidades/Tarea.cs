namespace ListaTareas.Tarea;  

public class Tarea
{
    public string? nombre {get; set;} 
    public string? descripcion {get; set;} 
    public string? estado {get; set;} 
    public DateTime? fechaCreacion {get; set; } 
    public DateTime? fechaFin {get; set; }

    public Tarea (string? Nombre, string? Descripcion, string? Estado, DateTime? FechaCreacion, DateTime? FechaFin)
    {
        this.nombre = Nombre; 
        this.descripcion= Descripcion;
        this.estado= Estado; 
        this.fechaCreacion=FechaCreacion;
        this.fechaFin=FechaFin;
    }

}
