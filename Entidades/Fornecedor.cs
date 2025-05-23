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

    public void SubstituiSeNaoVazio(Fornecedor novosDados)
    {
        if (novosDados.Nome != "")                  Nome = novosDados.Nome;
        if (novosDados.Descricao != "")             Descricao = novosDados.Descricao;
        if (novosDados.Telefone != "")              Telefone = novosDados.Telefone;
        if (novosDados.Email != "")                 Email = novosDados.Email;
        if (novosDados.Endereco.Rua != "")          Endereco.Rua = novosDados.Endereco.Rua;
        if (novosDados.Endereco.Numero != "")       Endereco.Numero = novosDados.Endereco.Numero;
        if (novosDados.Endereco.Complemento != "")  Endereco.Complemento = novosDados.Endereco.Complemento;
        if (novosDados.Endereco.Cep != "")          Endereco.Cep = novosDados.Endereco.Cep;
        if (novosDados.Endereco.Bairro != "")       Endereco.Bairro = novosDados.Endereco.Bairro;
        if (novosDados.Endereco.Cidade != "")       Endereco.Cidade = novosDados.Endereco.Cidade;
        if (novosDados.Endereco.Estado != "")       Endereco.Estado = novosDados.Endereco.Estado;
    }
}