using System;

using BaseDeDados;

namespace Gerenciadores;

public class GerenciadorLoja
{
    public GerenciadorLoja()
    {
        BD = new BaseDados();
        GerF = new GerenciadorFornecedor(BD);
        GerT = new GerenciadorTransportadora(BD);
        GerU = new GerenciadorUsuario(BD);
        //GC = new GerenciadorCliente(BD);
    }
    public BaseDados BD;
    public GerenciadorFornecedor GerF;
    public GerenciadorTransportadora GerT;
    public GerenciadorUsuario GerU;
    //public GerenciadorCliente GC;
}
