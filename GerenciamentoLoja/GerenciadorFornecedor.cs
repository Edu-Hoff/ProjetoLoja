using System;
using System.Data.Common;
using Entidades;

namespace GerenciamentoLoja;

public class GerenciadorFornecedor
{
    Fornecedor[] todosFornecedores = new Fornecedor[5]; //vetor inicial
    public void CadastraFornecedor()
    {
        Console.WriteLine("Id do fornecedor: ");
        Id = Console.ReadLine();
        Console.WriteLine("Nome do fornecedor: ");
        Nome = Console.ReadLine();
        Console.WriteLine("Descrição do fornecedor: ");
        Descricao = Console.ReadLine();
        Console.WriteLine("Telefone do fornecedor: ");
        Telefone = Console.ReadLine();
        Console.WriteLine("Email do fornecedor: ");
        Email = Console.ReadLine();

        Fornecedor[] novoVetorFornecedores = new Fornecedor[todosFornecedores.Length + 1];
        for (int i = 0; i < todosFornecedores.Length; i++)
        {
            novoVetorFornecedores[i] = todosFornecedores[i];
        }
        novoVetorFornecedores[novoVetorFornecedores.Length - 1] = new Fornecedor(Id, Nome, Descricao, Telefone, Email);
        todosFornecedores = novoVetorFornecedores;
    }
    public void AlteraFornecedor()
    {
        Console.Write("Informe o Id do fornecedor:\n");
        String IdCodigo = Console.ReadLine();

        for (int i = 0; i < todosFornecedores.Length; i++)
        {
            if (todosFornecedores[i].Id == IdCodigo) //se os dois códigos forem iguais, altera as informações de tal código
            {
                Console.Write("Novo nome do fornecedor:\n");
                todosFornecedores[i].Nome = Console.ReadLine();
                Console.Write("Nova descrição do fornecedor:\n");
                todosFornecedores[i].Descricao = Console.ReadLine();
                Console.Write("Novo telefone do fornecedor:\n");
                todosFornecedores[i].Telefone = Console.ReadLine();
                Console.Write("Novo email do fornecedor:\n");
                todosFornecedores[i].Email = Console.ReadLine();

                Console.WriteLine("Fornecedor alterado com sucesso!\n");
            }
            Console.WriteLine("Fornecedor não encontrado!\n");
        }
    }
    public void ExcluiFornecedor()
    {
        Console.Write("Informe o Id do fornecedor:\n");
        String IdCodigo = Console.ReadLine();

        for (int i = 0; i < todosFornecedores.Length; i++)
        {
            if (todosFornecedores[i].Id == IdCodigo)
            {
                
            }
        }
    }
}