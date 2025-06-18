namespace listaTareas.Server.Aplicacion.Entidades
{
    public class Usuario
    { public int _id { get; set; }
        private string _nombreusuario { get; set; }
        private string _password { get; set; }
        private string _correo { get; set; }

        public List<Tarea> tareas = new List<Tarea>();
    }

    public Usuario (string nombre, string password, string correo)
        {
            this._nombreusuario = nombre;
            this._password = password;  
        }
}
