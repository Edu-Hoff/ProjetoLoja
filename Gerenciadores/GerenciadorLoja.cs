using System;

using BaseDeDados;
using Entidades;

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

    public void InicializaEntidades()
    {
        BaseDeDados.TodosUsuarios = BaseDeDados.AdicionarItem(BaseDeDados.TodosUsuarios, new Usuario("Cliente 1", GerenciadorDeUsuario.HashSenha("Cliente 1")));
        BaseDeDados.TodosUsuarios = BaseDeDados.AdicionarItem(BaseDeDados.TodosUsuarios, new Usuario("Admin 1",GerenciadorDeUsuario.HashSenha("Admin 1"),true));
    }
    public BaseDados BaseDeDados;
    public GerenciadorFornecedor GerenciadorDeFornecedor;
    public GerenciadorTransportadora GerenciadorDeTransportadora;
    public GerenciadorUsuario GerenciadorDeUsuario;
    public GerenciadorProduto GerenciadorDeProduto;
    //public GerenciadorCliente GerenciadorDeCliente;
}
