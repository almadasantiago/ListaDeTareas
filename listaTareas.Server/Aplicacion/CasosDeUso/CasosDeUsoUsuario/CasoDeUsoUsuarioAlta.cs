using System.ComponentModel.DataAnnotations;
using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Aplicacion.Validadores;

namespace listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoUsuario
{       public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repo, UsuarioValidador validador)
        {
            public void Ejecutar(string nombreUsuario, string password, string correo)
            {
                Console.WriteLine("DEBUG: Ejecutando CasoDeUsoUsuarioAlta");
                 
                if (validador != null && repo != null   )
                {
                    Console.WriteLine("DEBUG: Validador y repositorio no son null");
                }

                if (validador.validar(nombreUsuario))
                {
                    Console.WriteLine("DEBUG: Nombre de usuario válido");

                    string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
                    Console.WriteLine("DEBUG: Password hasheada");

                    int idUsuario = repo.usuarioAlta(nombreUsuario, passwordPasadaPorHash, correo);
                    Console.WriteLine("DEBUG: Usuario creado con ID " + idUsuario);
                }
                else
                {
                    Console.WriteLine("DEBUG: El nombre de usuario ya existe");
                    throw new Exception("El nombre de usuario ingresado ya se encuentra registrado");
                }
            }
        }


    }

