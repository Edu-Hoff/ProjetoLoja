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
            BaseDeDados.AdicionarItem(BaseDeDados.TodosProdutos, Produto);
        }
    }
    //alteracao
    public void AlteraProduto(int indice, String Nome, double Valor, int Quantidade, String Fornecedor)
    {
        GerenciadorFornecedor gerenciadorFornecedor = new GerenciadorFornecedor(BaseDeDados);
        if (gerenciadorFornecedor.ProcuraFornecedor(Fornecedor))
        {
            Produto Produto = new Produto(Nome, Valor, Quantidade, gerenciadorFornecedor.ObtemFornecedor(Fornecedor));
            BaseDeDados.TodosProdutos[indice] = Produto; 
        }
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
        int indice = BaseDeDados.ProcuraItemExpecificoPorNome(BaseDeDados.TodosProdutos, Nome);
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
        if (BaseDeDados.ProcuraItemExpecificoPorNome(BaseDeDados.TodosProdutos, Nome) == -1)
            return false;
        return true;
    }
    public bool ProcuraProduto(int ID)
    {
        if (BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosProdutos, ID) == -1)
            return false;
        return true;
    }
//funcao para alterar quantidade de um produto
    
}
