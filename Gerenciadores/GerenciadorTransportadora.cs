using System;
using BaseDeDados;

namespace Gerenciadores;

public class GerenciadorTransportadora
{
    public GerenciadorTransportadora(BaseDados BaseDeDados)
    {
        this.BaseDeDados = BaseDeDados;
    }
    private BaseDados BaseDeDados { get; set; }
}
