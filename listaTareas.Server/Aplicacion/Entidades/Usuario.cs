namespace listaTareas.Server.Aplicacion.Entidades
{
    public class Usuario
    { public int _id { get; set; }
        public string _nombreusuario { get; set; }
        public string _password { get; set; }
        public string _correo { get; set; }

        public List<Tarea> tareas = new List<Tarea>();

        public Usuario(string nombre, string password, string correo)
        {
            this._nombreusuario = nombre;
            this._password = password;
        }


    }

}
