using System;
using System.ComponentModel.DataAnnotations;
using BaseDeDados;
using Entidades;

namespace Gerenciadores;

public class GerenciadorProduto
{
    public GerenciadorProduto(BaseDados BaseDeDados)
    {
        this.BaseDeDados = BaseDeDados;
    }
    private BaseDados BaseDeDados { get; set; }
//cadastro
    public void CadastraProduto(String Nome, double Valor, int Quantidade, String Fornecedor)
    {
        GerenciadorFornecedor gerenciadorFornecedor = new GerenciadorFornecedor(BaseDeDados);
        if (gerenciadorFornecedor.ProcuraFornecedor(Fornecedor))
        {
            Produto Produto = new Produto(Nome, Valor, Quantidade, gerenciadorFornecedor.ProcuraFornecedorTemporario(Fornecedor));
            BaseDeDados.AdicionarItem(BaseDeDados.TodosProdutos, Produto);
        }
    }
//alteracao
    public void AlteraProduto(String Nome)
    {

    }
//exclusao
    public void ExcluiProduto(String Nome)
    {

    }
    public void ExcluiProduto(int Id)
    {

    }
//procura
    public void ObterItemCodigo(int Id)
    {

    }
    public void ObterItemNome(String Nome)
    {

    }
}
