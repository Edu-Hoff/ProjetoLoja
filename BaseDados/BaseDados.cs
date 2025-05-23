using System;
using Entidades;


namespace BaseDeDados;

public class BaseDados
{
    public BaseDados()
    {
        TodosFornecedores = new Fornecedor[0];
        TodasTransportadoras = new Transportadora[0];
        TodosClientes = new Cliente[0];
        TodosUsuarios = new Usuario[0];
        TodosProdutos = new Produto[0];
        Indice = 100;
    }

    public int Indice { get; set; }
    public Fornecedor[] TodosFornecedores { get; set; }
    public Transportadora[] TodasTransportadoras { get; set; }
    public Cliente[] TodosClientes { get; set; }
    public Usuario[] TodosUsuarios { get; set; }
    public Produto[] TodosProdutos { get; set; }

    /**************************************************************/
    /*************** GERENCIAMENTO DA BASE DE DADOS ***************/
    /**************************************************************/

    public T[] AdicionarItem<T>(T[] vetor, T item) where T : ObjetoComId
    {
        int tamanho = (vetor != null) ? vetor.Length + 1 : 1;
        T[] novoVetor = new T[tamanho];
        item.Id = ++Indice;
        if (vetor != null)
        {
            for (int i = 0; i < vetor.Length; i++)
                novoVetor[i] = vetor[i];
        }
        novoVetor[tamanho - 1] = item;
        return novoVetor;
    }

    public T[] RemoverItem<T>(T[] vetor, T item)
    {
        if (vetor == null || vetor.Length == 0)
        {
            return new T[0];
        }
        int indice = Array.IndexOf(vetor, item);
        if (indice == -1) return vetor;

        T[] novoVetor = new T[vetor.Length - 1];
        for (int i = 0, j = 0; i < vetor.Length; i++)
        {
            if (i == indice) continue;
            novoVetor[j++] = vetor[i];
        }
        return novoVetor;
    }
    
    //Funcao para generica procurar um item
    //Retorna o indice do item no vetor, -1 se nao esta no vetor 
    public int ProcuraItemPorId<T>(T[] vetor, int Id) where T : ObjetoComId
    {
        if (vetor == null || vetor.Length == 0)
        {
            vetor = new T[0];
            return -1;
        }

        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i].Id == Id)
            {
                return i;
            }
        }
        return -1;
    }

    //Funcao para generica procurar um item
    //Retorna o indice do item no vetor, -1 se nao esta no vetor 
    public int ProcuraItemExpecificoPorNome<T>(T[] vetor, String Nome) where T : ObjetoComNome
    {
        if (vetor == null || vetor.Length == 0)
        {
            return -1;
        }

        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i].Nome == Nome)
            {
                return i;
            }
        }
        return -1;
    }

    //Funcao para generica procurar itens que contenham uma string no nome
    //Retorna vetor com os itens encontrados, ou vetor vazio [0]
    public T[] ProcuraItensComNome<T>(T[] vetor, String Nome) where T : ObjetoComNome
    {
        T[] newVet = new T[0];
        if (vetor == null || vetor.Length == 0)
        {
            return newVet;
        }
        BaseDados BaseDeDados = new BaseDados(); 
        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i].Nome.Contains(Nome))
            {
                newVet = BaseDeDados.AdicionarItem(newVet, vetor[i]);
            }
        }
        return newVet;
    }
}
