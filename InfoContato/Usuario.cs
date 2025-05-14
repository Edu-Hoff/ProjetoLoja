using System;
using System.Text;
using System.Security.Cryptography;

namespace InfoContato;

public class Usuario
{
    public Usuario (String name, String senha  , bool adim)
    {
        UserName = name;
        Senha = HashSenha(senha);
        Adim=adim;
    }

    string HashSenha(string senha)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
    public String UserName {get; set;}
    public String Senha {get;set;}
    private bool Adim {get;set;}

    
}
