using System;

namespace Entidades;

public class Produto : ObjetoComNome
{
    public Produto(String Nome, double Valor, int Quantidade, Fornecedor Fornecedor)
    {
        this.Nome = Nome;
        this.Valor = Valor;
        this.Quantidade = Quantidade;
        this.Fornecedor = Fornecedor;
    }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public Fornecedor Fornecedor { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Nome}\n{Valor:C2}";
    }

    //Apenas para Adim
    public string ObterQuantidadeFornecedor()
    {
        return $"Quantidade: {Quantidade} - Fornecido por: {Fornecedor.Id} - {Fornecedor.Nome}";
    }
}
