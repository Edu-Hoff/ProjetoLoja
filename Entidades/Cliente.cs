using System;

namespace Entidades;

public class Cliente : Contato, IHasEndereco
{
    public Cliente(String Nome, String Telefone, String Email, Endereco Endereco)
    {
        this.Nome = Nome;
        this.Telefone = Telefone;
        this.Email = Email;
        this.Endereco = Endereco;
    }
    public Endereco Endereco { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Nome}\n{Telefone} - {Email}";
    }
}
