using System;

namespace Entidades;

public class Usuario : ObjetoComNome
{
    //Recebe a senha depois do Hash
    public Usuario(String nome, String senha, bool admin = false)
    {
        Nome = nome;
        Senha = senha;
        Admin = admin;
    }

    public String Senha { get; set; }
    public bool Admin { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Nome} - {(Admin?"Administrador":"Cliente")}";
    }
}
