using Google.Cloud.Firestore;
using Application; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListaTareas.Application;
using Google.Cloud.Firestore.V1;
using ListaTareas.Tarea;

namespace Repositories 
{ 
    public class TareaRepository
    {
        private readonly FirestoreDb db; 

        public TareaRepository (FirebaseDbContext dbContext)
        { 
            db = dbContext.GetDatabase(); 
        } 

        public async Task <string> AgregarTarea(string nombre, string descripcion, string estado) 
        {
            var tarea = new Tarea (nombre,descripcion,estado,DateTime.Now);
            var tareaRef = db.Collection("tarea").Document(); 
            await tareaRef.SetAsync(tarea); 
            return tareaRef.Id; 
        } 

        public async Task <bool> ModificarTarea (string tareaid, string nombre, string descripcion, string estado)
        {   
            var tareaRef = db.Collection("tarea").Document(tareaid); 
            var tareaDoc = await tareaRef.GetSnapshotAsync();

            if (!tareaDoc.Exists)
            {
                return false;
            }
            var tareaActualizada = new Tarea(nombre,descripcion,estado,DateTime.Now); 
            await tareaRef.SetAsync(tareaActualizada,SetOptions.MergeAll);
            return true; 
        }

        public async Task <bool> EliminarTarea (string tareaid)
        {   
            var tareaRef = db.Collection("tarea").Document(tareaid); 
            var tareaDoc = await tareaRef.GetSnapshotAsync(); 
            
            if (!tareaDoc.Exists)
            {
                return false; 
            }
                await tareaRef.DeleteAsync(); 
            return true; 
        }

    }

}