using System;

namespace Entidades;

public class Transportadora
{
    public Transportadora(String NomeTransportadora, double ValorPorKM)
    {
        this.NomeTransportadora = NomeTransportadora;
        this.ValorPorKM = ValorPorKM;
    }
    String NomeTransportadora   { get; set; }
    double ValorPorKM           { get; set; }
}
