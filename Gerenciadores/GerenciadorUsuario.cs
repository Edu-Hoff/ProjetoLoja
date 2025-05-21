using System;
using InfoContato;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BaseDeDados;

namespace Gerenciadores;

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
        user.Nome = username;

    }
    public Usuario? FazerLogin(String Nome, String Senha)
    {
        String HSenha = HashSenha(Senha);
        foreach (Usuario user in BD.TodosUsuarios)
        {
            if (user.Nome == Nome && user.Senha == HSenha)
            {
                return user;
            }
        }
        return null;
    }
    public bool FazerCadastro(String Nome, String Senha, String Admin)
    {
        int ind = ProcuraItemExpecificoPorNome(BD.TodosUsuarios, Nome);
        if (ind == -1)
        {
            AdicionarItem(BD.TodosUsuarios, new Usuario(Nome, HashSenha(Senha), Admin == "S" || Admin == "s" ? true : false));
            return true;
        }
        //else exception
        return false;
    }
}
