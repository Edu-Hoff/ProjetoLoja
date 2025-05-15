using System;


namespace InfoContato;

public class Usuario
{
    //Recebe a senha depois do Hash
    public Usuario(String name, String senha, bool admin)
    {
        UserName = name;
        Senha = senha;
        Admin = admin;
    }

    public String UserName { get; set; }
    public String Senha {get;set;}
    private bool Admin {get;set;}

    
}
