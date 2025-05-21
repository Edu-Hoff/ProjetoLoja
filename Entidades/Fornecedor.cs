using System;
using System.ComponentModel.DataAnnotations;
using Pedidos;

namespace Entidades;

public class Fornecedor : Endereco //herda nome, telefone e email da classe Endereco
{
    public String Descricao { get; set; }

    public Fornecedor(int Id, String Nome, String Descricao, String Telefone, String Email)
    {
        this.Id = Id;
        this.Nome = Nome;
        this.Descricao = Descricao;
        this.Telefone = Telefone;
        this.Email = Email;
    }

    public String ObterFornecedor()
    {
        return "Nome: " + Nome + "Descrição: " + Descricao + "Telefone: " + Telefone + "Email: " + Email;
    }


}