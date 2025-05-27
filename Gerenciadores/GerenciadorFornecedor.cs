using System;
using System.Data.Common;
using Entidades;
using BaseDeDados;

namespace Gerenciadores;

public class GerenciadorFornecedor
{
    public GerenciadorFornecedor(BaseDados BaseDeDados)
    {
        this.BaseDeDados = BaseDeDados;
    }
    public BaseDados BaseDeDados { get; set; }

    public Fornecedor ObtemFornecedor(String Nome)
    {
        int i = BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodosFornecedores, Nome);
        return BaseDeDados.TodosFornecedores[i];
    }
    public bool ProcuraFornecedor(String Nome)
    {
        return BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodosFornecedores, Nome) != -1;
    }
    public bool ProcuraFornecedor(int ID)
    {
        return BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosFornecedores, ID) != -1;
    }
    public void CadastraFornecedor(String Nome, String Descricao, String Telefone, String Email, String Estado, String Cidade, String Cep, String Beirro, String Rua, String Numero, String Complemento)
    {
        BaseDeDados.TodosFornecedores = BaseDeDados.AdicionarItem(BaseDeDados.TodosFornecedores, new Fornecedor(Nome,Descricao,Telefone,Email,new Endereco(Rua,Numero,Complemento,Beirro,Cep,Cidade,Estado)));
    }
    //modificar - interface
    public void AlteraFornecedor(int Indice, Fornecedor novosDados)
    {
        BaseDeDados.TodosFornecedores[Indice].SubstituiSeNaoVazio(novosDados);
    }
    public bool ExcluiFornecedor(int Id)
    {
        int indice = BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosFornecedores, Id);
        if (indice != -1)
        {
            ExcluiProdutos(BaseDeDados.TodosFornecedores[indice]);
            BaseDeDados.TodosFornecedores = BaseDeDados.RemoverItem(BaseDeDados.TodosFornecedores, BaseDeDados.TodosFornecedores[indice]);
            return true;
        }
        return false;
    }

    public bool ExcluiFornecedor(String Nome)
    {
        int indice = BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodosFornecedores, Nome);
        if (indice != -1)
        {
            ExcluiProdutos(BaseDeDados.TodosFornecedores[indice]);
            BaseDeDados.TodosFornecedores = BaseDeDados.RemoverItem(BaseDeDados.TodosFornecedores, BaseDeDados.TodosFornecedores[indice]);
            return true;
        }
        return false;
    }

    private void ExcluiProdutos(Fornecedor fornecedor)
    {
        Produto[] Todos = BaseDeDados.TodosProdutos.ToArray();
        foreach (Produto prod in Todos)
        {
            if (prod.Fornecedor.Nome == fornecedor.Nome)
            {
                BaseDeDados.TodosProdutos = BaseDeDados.RemoverItem(BaseDeDados.TodosProdutos, prod);
            }
        }
    }
}
    