using System;


namespace InfoContato;

public class Usuario : ObjetoComNome
{
    //Recebe a senha depois do Hash
    public Usuario(String name, String senha, bool admin=false)
    {
        Nome = name;
        Senha = senha;
        Admin = admin;
    }

    public String Senha {get;set;}
    public bool Admin {get;set;}
}
