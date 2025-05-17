using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

//
//  GerenciadorLoja gl = new GerenciadorLoja(); 
//
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

 
        string senhaOriginal = "minhaSenha123";
        string senhaHash = HashSenha(senhaOriginal);

        Console.WriteLine("Senha original: " + senhaOriginal);
        Console.WriteLine("Senha hash: " + senhaHash);
        Console.WriteLine("Senha hash: " + HashSenha("MinhaSenha123"));

Console.WriteLine("\n\n\n\n");


    
    

