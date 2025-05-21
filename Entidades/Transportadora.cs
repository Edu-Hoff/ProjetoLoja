using System;

namespace Entidades;

public class Transportadora : ObjetoComNome
{
    public Transportadora(String Nome, double ValorPorKM)
    {
        this.Nome = Nome;
        this.ValorPorKM = ValorPorKM;
    }
    double ValorPorKM { get; set; }
    
    //obter descrição ou overrride do ToString
}
