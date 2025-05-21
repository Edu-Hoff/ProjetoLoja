using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades;

public class Fornecedor : Contato, IHasEndereco//herda nome, telefone e email da classe Endereco
{
    public Fornecedor(String Nome, String Descricao, String Telefone, String Email, Endereco Endereco)
    {
        this.Nome = Nome;
        this.Descricao = Descricao;
        this.Telefone = Telefone;
        this.Email = Email;
        this.Endereco = Endereco;
    }
    public String Descricao { get; set; }

    public Endereco Endereco { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Nome}\n{Descricao}\n{Telefone} - {Email}";
    }
}