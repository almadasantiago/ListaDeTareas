using Google.Cloud.Firestore;
using Application; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTareas.Application;

namespace Repositories
{
    public class UsuarioRepository
    {
        private readonly FirestoreDb db;

        public UsuarioRepository(FirebaseDbContext dbContext)
        {
            db = dbContext.GetDatabase();
        }

        public async Task<string> UsuarioAltaAsync(string nombre, string apellido, string email, string nombreUsuario, string password)
        {
            var usuario = new Usuario (nombre, apellido,email,nombreUsuario,password); 
            var usuarioRef = db.Collection("usuario").Document(); // equivalente a db.Add(Usuario);
            await usuarioRef.SetAsync(usuario); // equivalente a SaveChanges();
            return usuarioRef.Id;
        }

        public async Task<bool> ModificarUsuarioAsync (string usuarioId, string nombre, string apellido, string email, string nombreUsuario, string password) 
        {   
            var usuarioRef = db.Collection("usuario").Document(usuarioId); 
            var usuarioDoc = await usuarioRef.GetSnapshotAsync(); 

            if (!usuarioDoc.Exists)
            {
                return false; 
            }
                var usuarioActualizado = new Usuario(nombre,apellido,email,nombreUsuario,password); 
                await usuarioRef.SetAsync(usuarioActualizado, SetOptions.MergeAll); 
                return true; 
        }

        public async Task <Usuario> UsuarioIniciarSesion (string nombreUsuario, string password) 
        {
            var usuarioRef = db.Collection("usuario").WhereEqualTo("nombreUsuario",nombreUsuario); 
            var snapshots = await usuarioRef.GetSnapshotAsync();  

            if (snapshots.Documents.Count == 0)
            {
                return null;
            }
            var usuarioDoc = snapshots.Documents[0]; 
            var usuario = usuarioDoc.ConvertTo<Usuario>(); 
            
            return usuario; 
        }


    }
}
