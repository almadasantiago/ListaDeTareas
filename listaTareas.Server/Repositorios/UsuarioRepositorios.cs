using listaTareas.Server.Aplicacion;
using listaTareas.Server.Aplicacion.Entidades;
using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace listaTareas.Server.Repositorios
{
    public class UsuarioRepositorios : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext context;

        public UsuarioRepositorios(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool nombreRepetido(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.");

            var usuario = context.Usuarios.FirstOrDefault(u =>
                !string.IsNullOrWhiteSpace(u.Nombreusuario) &&
                u.Nombreusuario.ToLower() == nombre.ToLower());

            return usuario != null;
        }

        public int usuarioAlta(string nombre, string password, string correo)
        {
            Console.WriteLine("DEBUG: Entrando a usuarioAlta");

            var usuario = new Usuario(nombre, password, correo);
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            Console.WriteLine("DEBUG: Usuario guardado con ID " + usuario.Id);
            return usuario.Id;
        }

        public int UsuarioInicioDeSesion(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Email y contraseña no pueden ser vacíos.");

            var usuario = context.Usuarios.FirstOrDefault(u =>
                !string.IsNullOrWhiteSpace(u.Nombreusuario) &&
                u.Nombreusuario.ToLower() == email.ToLower());

            if (usuario != null)
            {
                if (usuario.Password == password)
                {
                    return usuario.Id;
                }
                else
                {
                    throw new Exception("La contraseña ingresada no corresponde con el nombre de usuario ingresado");
                }
            }
            else
            {
                throw new Exception("El nombre de usuario ingresado no existe en el repositorio");
            }
        }

        public void usuarioModificacion(int idUsuario, string nuevoNombre, string nuevaPassword, string nuevoCorreo, List<Tarea> Nuevastareas)
        {
            var usuarioAModificar = context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);

            if (usuarioAModificar == null)
                throw new Exception("El usuario no existe");

            usuarioAModificar.Nombreusuario = nuevoNombre;
            usuarioAModificar.Password = nuevaPassword;
            usuarioAModificar.Correo = nuevoCorreo;
            usuarioAModificar.Tareas = Nuevastareas;

            context.SaveChanges();
        }
    }
}
