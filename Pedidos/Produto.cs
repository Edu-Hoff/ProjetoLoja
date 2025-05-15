using System;
using InfoContato;

namespace Pedidos;

public class Produto : ObjetoComId
{
    public Produto(String Nome, double Valor, int Quantidade)
    {
        this.Nome = Nome;
        this.Valor = Valor;
        this.Quantidade = Quantidade;
    }
    public String Nome { get; set; }
    public double Valor {get;set;}
    public int Quantidade {get;set;}

}
