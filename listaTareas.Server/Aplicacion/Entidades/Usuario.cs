namespace listaTareas.Server.Aplicacion.Entidades
{
    public class Usuario
    { public int _id { get; set; }
        private string _nombreusuario { get; set; }
        private string _password { get; set; }
        private string _correo { get; set; }

        public List<Tarea> tareas = new List<Tarea>();
    }
}
