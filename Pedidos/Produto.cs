using System;
using InfoContato;

namespace Pedidos;

public class Produto : ObjetoComNome
{
    public Produto(String Nome, double Valor, int Quantidade)
    {
        this.Nome = Nome;
        this.Valor = Valor;
        this.Quantidade = Quantidade;
    }
    public double Valor {get;set;}
    public int Quantidade {get;set;}

}
