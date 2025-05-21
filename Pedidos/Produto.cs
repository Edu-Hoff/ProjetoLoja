using System;
using Entidades;
using InfoContato;

namespace Pedidos;

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

}
