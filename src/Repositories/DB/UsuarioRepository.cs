using Google.Cloud.Firestore;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks; 

namespace Repositories
{
    public class UsuarioRepository  
    {
        private readonly FirestoreDb db; 

        public UsuarioRepository (FirebaseDbContext dbContext)
        {
            db =dbContext.GetDatabase(); 
        }

    }
    
    public async Task <string> UsuarioAltaAsync (string nombre, string apellido, string email,string nombreUsuario, string password)
    {
        var usuario = new Usuario(nombre, apellido, email,nombreUsuario,password); 
        var usuarioRef = db.Collection("usuario").Document(); // equivalente a db.Add(Usuario); 
        await usuarioRef.SetAsync(usuario); // equivalente a SaveChanges(); 
        return usuarioRef.Id; 
    }

}