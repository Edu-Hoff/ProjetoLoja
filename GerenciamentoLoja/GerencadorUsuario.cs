using System;
using InfoContato;
using System.Text;
using System.Security.Cryptography;

namespace GerenciamentoLoja;

public class GerencadorUsuario
{
    public Usuario[] todosUsuarios = new Usuario[4];
    
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

    public void AlterarSenha(String nome, String senha, String novaSenha)
    {
        senha = HashSenha(senha);
        //TodosUsuarios Vetor com todos usuario
        foreach (Usuario user in todosUsuarios)
        {
            if (user.UserName == nome && user.Senha == senha)
            {
                user.Senha = HashSenha(novaSenha);
                return;
            }
        }
        //Excecao
    }

    public void ExcluiUsuario (Usuario alvo)
    {
        //TodosUsuarios Vetor com todos usuario
        foreach (Usuario user in todosUsuarios)  
        {
            if(user == alvo)
            {
                
                return;
            }
        }
        //Excecao
    }
}
