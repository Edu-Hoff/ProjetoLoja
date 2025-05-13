using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;


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
    

Console.WriteLine("\n\n\n\n");


    string chave = "chavesecreta1234chavesecreta1234"; 

    string Criptografar(string texto)
    {
        byte[] key = Encoding.UTF8.GetBytes(chave);
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.Mode = CipherMode.ECB;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] criptografado = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            return Convert.ToBase64String(criptografado);
        }
    }

    string Descriptografar(string criptografado)
    {
        byte[] key = Encoding.UTF8.GetBytes(chave);
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.Mode = CipherMode.ECB;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor();
            byte[] bytes = Convert.FromBase64String(criptografado);
            byte[] descriptografado = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            return Encoding.UTF8.GetString(descriptografado);
        }
    }

    
        string senha = "minhaSenha123";
        string criptografada = Criptografar(senha);
        string descriptografada = Descriptografar(criptografada);

        Console.WriteLine("Original: " + senha);
        Console.WriteLine("Criptografada: " + criptografada);
        Console.WriteLine("Descriptografada: " + descriptografada);
    

