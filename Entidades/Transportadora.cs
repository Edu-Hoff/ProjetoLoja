using System;

namespace Entidades;

public class Transportadora : ObjetoComNome
{
    public Transportadora(String Nome, double ValorPorKM)
    {
        this.Nome = Nome;
        this.ValorPorKM = ValorPorKM;
    }
    public double ValorPorKM { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Nome}\n{ValorPorKM:C2} por KM";
    }
    //obter descrição ou overrride do ToString
}
