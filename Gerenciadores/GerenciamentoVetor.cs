using System;
using BaseDeDados;
using Entidades;

namespace Gerenciadores;

public abstract class GerenciamentoVetor
{
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
