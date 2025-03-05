using Google.Cloud.Firestore; 
using System.IO; 

namespace Repositories
{
public class FirebaseDbContext 
{
    private readonly FirestoreDb _firestoreDb; 

    public FirebaseDbContext() 
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(),"config","firebase-config.json");
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        _firestoreDb = FirestoreDb.Create("listatareas-1");
    }
     public FirestoreDb GetDatabase()
        {
            return _firestoreDb;
        }
}

} 