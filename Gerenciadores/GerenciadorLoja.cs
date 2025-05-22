using System;

using BaseDeDados;

namespace Gerenciadores;

public class GerenciadorLoja
{
    public GerenciadorLoja()
    {
        BaseDeDados = new BaseDados();
        GerenciadorDeFornecedor = new GerenciadorFornecedor(BaseDeDados);
        GerenciadorDeTransportadora = new GerenciadorTransportadora(BaseDeDados);
        GerenciadorDeUsuario = new GerenciadorUsuario(BaseDeDados);
        GerenciadorDeProduto = new GerenciadorProduto(BaseDeDados);
        //GerenciadorDeCliente = new GerenciadorCliente(BD);
    }
    public BaseDados BaseDeDados;
    public GerenciadorFornecedor GerenciadorDeFornecedor;
    public GerenciadorTransportadora GerenciadorDeTransportadora;
    public GerenciadorUsuario GerenciadorDeUsuario;
    public GerenciadorProduto GerenciadorDeProduto;
    //public GerenciadorCliente GerenciadorDeCliente;
}
