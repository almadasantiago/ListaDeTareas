namespace listaTareas.Server.Aplicacion.Entidades
{
    public class Usuario
    { public int Id { get; set; }
        public string Nombreusuario { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }

        public List<Tarea> Tareas = new List<Tarea>();

        public Usuario() 
        {
            Tareas = new List<Tarea>();
        }
        public Usuario(string nombre, string password, string correo)
        {
            Nombreusuario = nombre;
            Password = password;
            Correo = correo;
            Tareas = new List<Tarea>();
        }



    }

}
