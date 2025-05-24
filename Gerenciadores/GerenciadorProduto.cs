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
        Produto Produto = ObterItemNome(Nome);
        if (Produto != null)
        {
            BaseDeDados.RemoverItem(BaseDeDados.TodosProdutos, Produto);
        }
        else
        {
            //item nao existe
        }
    }
    public void ExcluiProduto(int Id)
    {
        Produto Produto = ObterItemId(Id);
        if (Produto != null)
        {
            BaseDeDados.RemoverItem(BaseDeDados.TodosProdutos, Produto);
        }
        else
        {
            //item nao existe
        }
    }
    
//retorna item do vetor, se encontrar
    public Produto ObterItemId(int Id)
    {
        int i = BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosProdutos, Id);
        if (i != -1)
        {
            return BaseDeDados.TodosProdutos[i];
        }
        return null;
    }
    public Produto ObterItemNome(String Nome)
    {
        int i = BaseDeDados.ProcuraItemExpecificoPorNome(BaseDeDados.TodosProdutos, Nome);
        if (i != -1)
        {
            return BaseDeDados.TodosProdutos[i];
        }
        return null;
    }
}
