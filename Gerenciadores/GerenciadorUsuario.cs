using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BaseDeDados;
using Entidades;

namespace Gerenciadores;

public class GerenciadorUsuario
{
    public GerenciadorUsuario(BaseDados BaseDeDados)
    {
        this.BaseDeDados = BaseDeDados;
    }
    public BaseDados BaseDeDados { get; set; }

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

    public void AlteraUsuario(Usuario User, Usuario UserEditado)
    {
        if (UserEditado.Nome != "")
                User.Nome = UserEditado.Nome;
        if (UserEditado.Senha != "")
            User.Senha = HashSenha(UserEditado.Senha);
        User.Admin = UserEditado.Admin;
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

    public bool ProcuraUsuario(String Nome)
    {
        return BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodosUsuarios, Nome) != -1;
    }
    public bool ProcuraUsuario(int ID)
    {
        return BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosUsuarios, ID) != -1;

    }
    public bool FazerCadastro(String Nome, String Senha, String Admin)
    {
        int Indice = BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodosUsuarios, Nome);
        if (Indice == -1)
        {
            bool isAdmin = Admin.Trim().ToUpper() == "S";
            BaseDeDados.TodosUsuarios = BaseDeDados.AdicionarItem(BaseDeDados.TodosUsuarios, new Usuario(Nome, HashSenha(Senha), isAdmin));
            return true;
        }
        //else exception
        return false;
    }

    public void RemoverUsuario(Usuario User)
    {
        BaseDeDados.TodosUsuarios = BaseDeDados.RemoverItem(BaseDeDados.TodosUsuarios, User);
    }
}
