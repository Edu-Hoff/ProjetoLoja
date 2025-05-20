using System;
using InfoContato;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using ProjetoLoja;

namespace GerenciamentoLoja;

public class GerenciadorUsuario : GerenciamentoVetor
{
    public GerenciadorUsuario(BaseDados BD)
    {
        this.BD = BD; 
    }
    private BaseDados BD { get; set; }

    public string HashSenha(string senha)
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

    public void AlterarSenha(Usuario user, String novaSenha)
    {
        user.Senha = HashSenha(novaSenha);
    }

    public void AlterarUsername(Usuario user, String username)
    {
        user.UserName = username;

    }
    public Usuario FazerLogin()
    {
        Console.WriteLine("Usuário: ");
        String Nome = Console.ReadLine();
        Console.WriteLine("Senha: ");
        String Senha = Console.ReadLine();
        foreach (Usuario user in BD.TodosUsuarios)
        {
            if (user.UserName == Nome && user.Senha == HashSenha(Senha))
            {
                return user;
            }
        }
        return null; //não sei se pode
    }
    public void FazerCadastro()
    {

    }
}
