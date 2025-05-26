using System;
using System.Data.Common;
using Entidades;
using BaseDeDados;
using Microsoft.VisualBasic;

namespace Gerenciadores;

public class GerenciadorFornecedor 
{
    public GerenciadorFornecedor (BaseDados BaseDeDados)
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
        if (BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodosFornecedores, Nome) == -1)
            return false;
        return true;
    }
    public bool ProcuraFornecedor(int ID)
    {
        if (BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosFornecedores, ID) == -1)
            return false;
        return true;
    }
    public void CadastraFornecedor(Fornecedor Fornecedor)
    {
        BaseDeDados.TodosFornecedores = BaseDeDados.AdicionarItem(BaseDeDados.TodosFornecedores, Fornecedor);
    }
    //modificar - interface
    public void AlteraFornecedor(int Indice, Fornecedor novosDados)
    {
        if (ProcuraFornecedor(novosDados.Nome))
        {
            novosDados.Nome = BaseDeDados.TodosFornecedores[Indice].Nome;
            //Exception nome invalido
        }
        BaseDeDados.TodosFornecedores[Indice].SubstituiSeNaoVazio(novosDados);
    }
    public bool ExcluiFornecedor(int Id)
    {
        int indice = BaseDeDados.ProcuraItemPorId(BaseDeDados.TodosFornecedores, Id);
        if (indice != -1)
        {
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
            BaseDeDados.TodosFornecedores = BaseDeDados.RemoverItem(BaseDeDados.TodosFornecedores, BaseDeDados.TodosFornecedores[indice]);
            return true;
        }
        return false;
    }

}
    