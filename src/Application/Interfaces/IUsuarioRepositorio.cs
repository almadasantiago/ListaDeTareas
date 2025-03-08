namespace Application; 

public interface IUsuarioRepositorio
{
    int? usuarioAlta (string nombre, string apellido, string email, string nombreUsuario, string password); 
    void usuarioModificacion(int? idUsuario, string nombre, string apellido, string email, string nombreUsuario, string password);
    Usuario UsuarioInicioDeSesion(string email, string password);
    bool EmailRepetido(string? email); 


}