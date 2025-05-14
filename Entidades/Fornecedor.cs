using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades;

public class Fornecedor : Endereco //herda nome, telefone e email da classe Endereco
{
    public String Descricao { get; set; }

    public String ObterFornecedor()
    {
        return "Nome: " + Nome + "Descrição: " + Descricao + "Telefone: " + Telefone + "Email: " + Email;
    }


}