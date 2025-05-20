using System;
using System.Globalization;
using InfoContato;

namespace Gerenciadores;

public abstract class GerenciamentoVetor
{
    //Passar o vetor por referencia "ref" antes da variavel 
    public T[] AdicionarItem<T>(T[] vetor, T item)
    {
        int tamanho = (vetor != null) ? vetor.Length + 1 : 1;
        T[] novoVetor = new T[tamanho];
        if (vetor != null)
        {
            for (int i = 0; i < tamanho; i++)
                novoVetor[i] = vetor[i];
        }
        novoVetor[tamanho - 1] = item;
        return novoVetor;
    }

    //Se nao existia (null) ele cria o vetor com 0 itens
    public T[] RemoverItem<T>(T[] vetor, T item)
    {
        if (vetor == null || vetor.Count() == 0)
        {
            vetor = new T[0];
            return vetor;
        }
        int indice = Array.IndexOf(vetor, item);
        if (indice == -1) return vetor;

        T[] novoVetor = new T[vetor.Length - 1];
        for (int i = 0, j = 0; i < vetor.Length; i++)
        {
            if (i == indice) continue;
            novoVetor[j++] = vetor[i];
        }
        vetor = novoVetor;
        return novoVetor;
    }

    //Funcao para generica procurar um item
    //Retorna o indice do item no vetor, -1 se nao esta no vetor 
    public int ProcuraItemPorId<T>(T[] vetor, int Id) where T : ObjetoComId
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
                return i;
            }
        }
        return -1;
    }

    public int ProcuraItemExpecificoPorNome<T>(T[] vetor, String Nome) where T : ObjetoComNome
    {
        if (vetor == null || vetor.Count() == 0)
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

    public T[] ProcuraItensComNome<T>(T[] vetor, String Nome) where T : ObjetoComNome
    {
        T[] newVet = new T[0];
        if (vetor == null || vetor.Count() == 0)
        {
            return newVet;
        }

        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i].Nome.Contains(Nome))
            {
                newVet = AdicionarItem(newVet, vetor[i]);
            }
        }
        return newVet;
    }

    //Funcoes de edicoes tem que ser individual, basta procurar o aluno e editar o vetor no indice retornado, se existente 

}
