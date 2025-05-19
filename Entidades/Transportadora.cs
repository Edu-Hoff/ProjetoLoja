using System;
using InfoContato;

namespace Entidades;

public class Transportadora : ObjetoComNome
{
    public Transportadora(String Nome, double ValorPorKM)
    {
        this.Nome = Nome;
        this.ValorPorKM = ValorPorKM;
    }
    String Nome   { get; set; }
    double ValorPorKM           { get; set; }
}
