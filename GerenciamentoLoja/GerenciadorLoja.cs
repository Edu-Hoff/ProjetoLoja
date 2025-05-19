using System;
using ProjetoLoja;

namespace GerenciamentoLoja;

public class GerenciadorLoja
{
    public GerenciadorLoja()
    {
        BD = new BaseDados();
        GF = new GerenciadorFornecedor(BD);
        GT = new GerenciadorTransportadora(BD);
        GU = new GerenciadorUsuario(BD);
    }
    public BaseDados BD;
    public GerenciadorFornecedor GF;
    public GerenciadorTransportadora GT;
    public GerenciadorUsuario GU;
    //public GerenciadorClienete GC;
}
