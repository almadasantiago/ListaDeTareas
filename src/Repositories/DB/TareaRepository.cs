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
            var tarea = new Tarea (nombre,descripcion,estado,DateTime.Now,null);
            var tareaRef = db.Collection("tarea").Document(); 
            await tareaRef.SetAsync(tarea); 
            return tareaRef.Id; 
        } 

    }

}