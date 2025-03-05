namespace ListaTareas.Tarea;  

public class Tarea
{
    public string? nombre {get; set;}; 
    public string? descripcion {get; set;}; 
    public string? estado {get; set;}; 
    public LocalDate? fechaCreacion {get; set; }; 
    public LocalDate? fechaFin {get; set; }; 

    public Tarea (string? Nombre, string? Descripcion, string? Estado, LocalDate? FechaCreacion, LocalDate? FechaFin)
    {
        this.nombre = Nombre; 
        this.descripcion= Descripcion;
        this.estado= Estado; 
        this.fechaCreacion=FechaCreacion;
        this.fechaFin=FechaFin;
    }

}