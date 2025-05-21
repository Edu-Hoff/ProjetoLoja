using System;
using System.Data.Common;
using Entidades;
using BaseDeDados;

namespace Gerenciadores;

public class GerenciadorFornecedor:GerenciamentoVetor
{
    public GerenciadorFornecedor(BaseDados BD)
    {
        this.TodosFornecedores = BD.TodosFornecedores; 
    }
    private Fornecedor[] TodosFornecedores;

    public void CadastraFornecedor()
    {

    }
    public void AlteraFornecedor()
    {
        Console.Write("Informe o Id do fornecedor:\n");
        int IdCodigo = int.Parse(Console.ReadLine());

        for (int i = 0; i < TodosFornecedores.Length; i++)
        {
            if (TodosFornecedores[i].Id == IdCodigo) //se os dois códigos forem iguais, altera as informações de tal código
            {
                Console.Write("Novo nome do fornecedor:\n");
                TodosFornecedores[i].Nome = Console.ReadLine();
                Console.Write("Nova descrição do fornecedor:\n");
                TodosFornecedores[i].Descricao = Console.ReadLine();
                Console.Write("Novo telefone do fornecedor:\n");
                TodosFornecedores[i].Telefone = Console.ReadLine();
                Console.Write("Novo email do fornecedor:\n");
                TodosFornecedores[i].Email = Console.ReadLine();

                Console.WriteLine("Fornecedor alterado com sucesso!\n");
            }
            Console.WriteLine("Fornecedor não encontrado!\n");
        }
    }
    public void ExcluiFornecedor()
    {

    }

    public void ConsultarFornecedor()
    {
        Console.Write("Consultar por (1) Código ou (2) Nome: \n");
        int opcaoFornecedor = int.Parse(Console.ReadLine());

        if (opcaoFornecedor == 1) //código
        {
            Console.Write("Informe o código do fornecedor: \n");
            int codigoFornecedor = int.Parse(Console.ReadLine());

            for (int i = 0; i < TodosFornecedores.Length; i++)
            {
                if (codigoFornecedor == TodosFornecedores[i].Id) //se o código digitado for igual ao código salvo no vetor, mostra o fornecedor
                {
                    TodosFornecedores[i].ObterFornecedor();
                }
                else
                {
                    Console.WriteLine("Código de fornecedor não encontrado!\n");
                }
            }
        }
        else if (opcaoFornecedor == 2) //nome
        {
            Console.Write("Informe o nome do fornecedor: \n");
            String nomeFornecedor = Console.ReadLine();

            for (int i = 0; i < TodosFornecedores.Length; i++)
            {
                if (nomeFornecedor == TodosFornecedores[i].Nome) //se o nome digitado for igual ao nome salvo no vetor, mostra o fornecedor
                {
                    TodosFornecedores[i].ObterFornecedor();
                }
                else
                {
                    Console.WriteLine("Nome de fornecedor não encontrado!\n");
                }
            }
        }
    }
}
    