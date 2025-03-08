using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;

public class AuthService
{
    public AuthService()
    {
        if (FirebaseApp.DefaultInstance == null)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("config/firebase_credentials.json")
            });
        }
    }

    // Registrar usuario con email y contraseña
    public async Task<string> RegistrarUsuarioAsync(string email, string password)
    {
        var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs
        {
            Email = email,
            Password = password
        });

        return userRecord.Uid;
    }

    // Generar token de autenticación (para iniciar sesión)
    public async Task<string> GenerarTokenAsync(string uid)
    {
        return await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid);
    }

    // Verificar token de autenticación
    public async Task<bool> VerificarTokenAsync(string token)
    {
        try
        {
            var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
