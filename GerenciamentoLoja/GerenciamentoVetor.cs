using System;
using System.Globalization;

namespace GerenciamentoLoja;

public abstract class GerenciamentoVetor
{
    //Passar o vetor por referencia "ref" antes da variavel 
    public void AdicionarItem<T>(ref T[] vetor, T item)
    {
        int tamanho = (vetor != null) ? vetor.Length + 1 : 1;
        T[] novoVetor = new T[tamanho];
        if (vetor != null)
        {
            for (int i = 0; i < tamanho; i++)
                novoVetor[i] = vetor[i];
        }
        novoVetor[tamanho - 1] = item;
        vetor = novoVetor;
    }

    //Passar o vetor por referencia "ref" antes da variavel 
    //Retorna 1 se removeu, -1 se nao encontrou, e 0 se o vetor nao existia  ou se nao tinha nenhum item
    //Se nao existia (null) ele cria o vetor com 0 itens
    public int RemoverItem<T>(ref T[] vetor, T item)
    {
        if (vetor == null || vetor.Count() == 0)
        {
            vetor = new T[0];
            return 0;
        }
        int indice = Array.IndexOf(vetor, item);
        if (indice == -1) return -1;

        T[] novoVetor = new T[vetor.Length - 1];
        for (int i = 0, j = 0; i < vetor.Length; i++)
        {
            if (i == indice) continue;
            novoVetor[j++] = vetor[i];
        }
        vetor = novoVetor;
        return 1;
    }

    //Funcao para generica procurar um item
    //Retorna o indice do item no vetor, -1 se nao esta no vetor ou -2 se o vetor nao existia ou nao tinha nada 
    public int ProcuraItem<T>(T[] vetor, int Id)
    {
        if (vetor == null || vetor.Count() == 0)
        {
            vetor = new T[0];
            return -1;
        }

        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i].Id == Id)
            {
                return item;
            }
        }
        return -1;
    }

    //Funcoes de edicoes tem que ser individual, basta procurar o aluno e editar o vetor no indice retornado, se existente 

}
