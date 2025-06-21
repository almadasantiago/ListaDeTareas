using listaTareas.Server.Aplicacion;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Infraestructura.Persistencia;

namespace listaTareas.Server.Repositorios
{
    public class UsuarioRepositorios : IUsuarioRepositorio 
    {
        private readonly ApplicationDbContext context;         
        
        bool IUsuarioRepositorio.nombreRepetido(string nombre)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u._nombreusuario.ToLower() == nombre.ToLower());
            return usuario != null; 
        }

        int IUsuarioRepositorio.usuarioAlta(string nombre, string password, string correo)
        {    
                var usuario = new Usuario(nombre, password, correo);
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            return usuario._id;
        }

        int IUsuarioRepositorio.UsuarioInicioDeSesion(string email, string password)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u._correo!.ToLower() == email.ToLower());
            if (usuario != null)
            {   if (usuario._password == password)
                {
                    return usuario._id;
                }
                else
                {
                    throw new Exception("La contraseña ingresada no corresponde con el email ingresado");
                }
            }
            else
            {
                throw new Exception("El email ingresado no existe en el repositorio");
            }
        }

        void IUsuarioRepositorio.usuarioModificacion(int idUsuario, string nuevoNombre, string nuevaPassword, string nuevoCorreo, List<Tarea> Nuevastareas)
        {
            var usuarioAModificar = context.Usuarios.FirstOrDefault( u => u._id == idUsuario); 
            if ( usuarioAModificar != null )
            {
                usuarioAModificar._id = idUsuario;
                usuarioAModificar._nombreusuario = nuevoNombre;
                usuarioAModificar._password = nuevaPassword;
                usuarioAModificar._correo = nuevoCorreo;
                usuarioAModificar.tareas = Nuevastareas;
                context.SaveChanges();
            }
                else
            {
                throw new Exception(" El usuario no existe ");
            } 
        }
    }
}
