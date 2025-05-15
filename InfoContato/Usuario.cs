using System;


namespace InfoContato;

public class Usuario
{
    //Recebe a senha depois do Hash
    public Usuario(String name, String senha, bool adim)
    {
        UserName = name;
        Senha = senha;
        Adim = adim;
    }

    public String UserName { get; set; }
    public String Senha {get;set;}
    private bool Adim {get;set;}

    
}
