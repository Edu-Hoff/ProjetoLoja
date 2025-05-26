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
        //clientes
        BaseDeDados.TodosUsuarios = BaseDeDados.AdicionarItem(BaseDeDados.TodosUsuarios, new Usuario("Cliente 1", GerenciadorDeUsuario.HashSenha("Cliente 1")));
        BaseDeDados.TodosUsuarios = BaseDeDados.AdicionarItem(BaseDeDados.TodosUsuarios, new Usuario("Cliente 2", GerenciadorDeUsuario.HashSenha("Cliente 2")));
        //admins
        BaseDeDados.TodosUsuarios = BaseDeDados.AdicionarItem(BaseDeDados.TodosUsuarios, new Usuario("Admin 1", GerenciadorDeUsuario.HashSenha("Admin 1"), true));
        BaseDeDados.TodosUsuarios = BaseDeDados.AdicionarItem(BaseDeDados.TodosUsuarios, new Usuario("Admin 2", GerenciadorDeUsuario.HashSenha("Admin 2"), true));
        //fornecedores
        BaseDeDados.TodosFornecedores = BaseDeDados.AdicionarItem(BaseDeDados.TodosFornecedores, new Fornecedor("Fornecedor 1", "", "5554999453276", "fornecedor1@gmail.com", new Endereco("Barão do Triunfo", "354", "240", "Juventude", "95760-000", "Caxias Do Sul", "Rio Grande do Sul")));
        BaseDeDados.TodosFornecedores = BaseDeDados.AdicionarItem(BaseDeDados.TodosFornecedores, new Fornecedor("Fornecedor 2", "", "5554996763267", "fornecedor2@gmail.com", new Endereco("Julio de Castilhos", "1520", "54", "São José", "95020-060", "Farroupilha", "Rio Grande do Sul")));
        //produtos
        BaseDeDados.TodosProdutos = BaseDeDados.AdicionarItem(BaseDeDados.TodosProdutos, new Produto("Açucar 1kg", 7.60, 100, BaseDeDados.TodosFornecedores[1]));
        BaseDeDados.TodosProdutos = BaseDeDados.AdicionarItem(BaseDeDados.TodosProdutos, new Produto("Farinha 1kg", 5.10, 180, BaseDeDados.TodosFornecedores[1]));
        BaseDeDados.TodosProdutos = BaseDeDados.AdicionarItem(BaseDeDados.TodosProdutos, new Produto("Água 510ml", 2.5, 150, BaseDeDados.TodosFornecedores[0]));
        BaseDeDados.TodosProdutos = BaseDeDados.AdicionarItem(BaseDeDados.TodosProdutos, new Produto("Café 500g", 42.90, 80, BaseDeDados.TodosFornecedores[0]));
        BaseDeDados.TodosProdutos = BaseDeDados.AdicionarItem(BaseDeDados.TodosProdutos, new Produto("Suco 1L", 9.99, 120, BaseDeDados.TodosFornecedores[0]));
        //transportadoras
        BaseDeDados.TodasTransportadoras = BaseDeDados.AdicionarItem(BaseDeDados.TodasTransportadoras, new Transportadora("Transportadora 1", 3.6));
        BaseDeDados.TodasTransportadoras = BaseDeDados.AdicionarItem(BaseDeDados.TodasTransportadoras, new Transportadora("Transportadora 2", 3.2));
    }
    public BaseDados BaseDeDados;
    public GerenciadorFornecedor GerenciadorDeFornecedor;
    public GerenciadorTransportadora GerenciadorDeTransportadora;
    public GerenciadorUsuario GerenciadorDeUsuario;
    public GerenciadorProduto GerenciadorDeProduto;
    //public GerenciadorCliente GerenciadorDeCliente;
}
