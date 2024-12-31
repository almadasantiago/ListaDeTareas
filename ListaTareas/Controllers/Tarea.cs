namespace ListaTareas.Controllers
{
    public class Tarea
    {
        public int id;
        public string nombre;
        public string descripcion;
        public DateTime fechaInicio;
        public DateTime fechaFin;

        public Tarea(int id, string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            this.id = id; 
            this.nombre = nombre;  
            this.descripcion = descripcion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
        }

        public int getId() 
        { 
            return id; 
        }  
        public void setId(int id) 
        { 
            this.id = id; 
        } 
        public string getNombre()
        {
            return nombre; 
         }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;  
        }

        public string getDescripcion() 
        {   
            return descripcion; 
        }
        
        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion; 
        }

        public DateTime getFechaInicio() 
        { 
            return fechaInicio; 
        }   

        public void setFechaInicio(DateTime fecha)
        {
            this.fechaInicio = fecha;
        }

        public DateTime getFechaFin()
        { 
            return fechaFin; 
        }  

        public void setFechaFin(DateTime fechafin)
        {
            this.fechaFin= fechafin;
        }


    }
}
