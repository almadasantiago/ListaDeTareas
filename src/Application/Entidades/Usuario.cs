namespace ListaTareas.Application;
public class Usuario{
 public string? Nombre {get;set;}
    public string? Apellido {get;set;}
    public string? Email {get;set;}
    public string? nombreUsuario {get; set;}
    public string? Password {get;set;}

 public Usuario(string? nombre, string? apellido, string? email,string? NombreUsuario, string? password){
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        nombreUsuario=NombreUsuario; 
        Password = password;
    }

    public Usuario(){
    }

}