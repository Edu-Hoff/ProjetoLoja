using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BaseDeDados;
using Entidades;

namespace Gerenciadores;

public class GerenciadorUsuario : GerenciamentoVetor
{
    public GerenciadorUsuario(BaseDados BaseDeDados)
    {
        this.BaseDeDados = BaseDeDados; 
    }
    private BaseDados BaseDeDados { get; set; }

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
        foreach (Usuario user in BaseDeDados.TodosUsuarios)
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
        int Indice = BaseDeDados.ProcuraItemExpecificoPorNome(BaseDeDados.TodosUsuarios, Nome);
        if (Indice == -1)
        {
           BaseDeDados.TodosUsuarios = BaseDeDados.AdicionarItem(BaseDeDados.TodosUsuarios, new Usuario(Nome, HashSenha(Senha), Admin == "S" || Admin == "s" ? true : false));
            return true;
        }
        //else exception
        return false;
    }
}
