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
    public BaseDados BaseDeDados { get; set; }
    //cadastro
    public void CadastraProduto(String Nome, double Valor, int Quantidade, String NomeFornecedor)
    {
        GerenciadorFornecedor gerenciadorFornecedor = new GerenciadorFornecedor(BaseDeDados);
        if (gerenciadorFornecedor.ProcuraFornecedor(NomeFornecedor))
        {
            Produto Produto = new Produto(Nome, Valor, Quantidade, gerenciadorFornecedor.ObtemFornecedor(NomeFornecedor));
            BaseDeDados.TodosProdutos = BaseDeDados.AdicionarItem(BaseDeDados.TodosProdutos, Produto);
        }
        //else Exception
    }
    //alteracao
    public void AlteraProduto(int indice, String Nome, double Valor, int Quantidade, String Fornecedor)
    {
        GerenciadorFornecedor GerenciadorDeFornecedor = new GerenciadorFornecedor(BaseDeDados);
        if (GerenciadorDeFornecedor.ProcuraFornecedor(Fornecedor))
        {
            Produto Produto = BaseDeDados.TodosProdutos[indice];
            Produto.Valor = Valor;
            Produto.Quantidade = Quantidade;
            Produto.Fornecedor = GerenciadorDeFornecedor.ObtemFornecedor(Fornecedor);
        }
        //else Exception
    }
    //exclusao
    public bool ExcluiProduto(int Id)
    {
        int indice = BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosProdutos, Id);
        if (indice != -1)
        {
            BaseDeDados.TodosProdutos = BaseDeDados.RemoverItem(BaseDeDados.TodosProdutos, BaseDeDados.TodosProdutos[indice]);
            return true;
        }
        return false;
    }

    public bool ExcluiProduto(String Nome)
    {
        int indice = BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodosProdutos, Nome);
        if (indice != -1)
        {
            BaseDeDados.TodosProdutos = BaseDeDados.RemoverItem(BaseDeDados.TodosProdutos, BaseDeDados.TodosProdutos[indice]);
            return true;
        }
        return false;
    }

    //retorna item do vetor, se encontrar
    public bool ProcuraProduto(String Nome)
    {
        return BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodosProdutos, Nome) != -1;
    }
    public bool ProcuraProduto(int ID)
    {
        return BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosProdutos, ID) != -1;
    }
//funcao para alterar quantidade de um produto
    
}
