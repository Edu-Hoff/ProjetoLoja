using System;
using System.Data.Common;
using Entidades;
using ProjetoLoja;

namespace GerenciamentoLoja;

public class GerenciadorFornecedor:GerenciamentoVetor
{
    public GerenciadorFornecedor(BaseDados BD)
    {
        this.BD = BD; 
    }
    private BaseDados BD { get; set; }

    public void CadastraFornecedor()
    {
        Console.WriteLine("Nome do fornecedor: \n");
        String Nome = Console.ReadLine();
        Console.WriteLine("Descrição do fornecedor: \n");
        String Descricao = Console.ReadLine();
        Console.WriteLine("Telefone do fornecedor: \n");
        String Telefone = Console.ReadLine();
        Console.WriteLine("Email do fornecedor: \n");
        String Email = Console.ReadLine();


        Fornecedor novo = new Fornecedor(BD.TodosFornecedores.Length, Nome, Descricao, Telefone, Email);

        BD.TodosFornecedores = AdicionarItem(BD.TodosFornecedores, novo);


        //AdicionarItem(ref todosFornecedores,novo);

        /*
        Fornecedor[] novoVetorFornecedores = new Fornecedor[todosFornecedores.Length + 1]; //novo vetor com uma posição a mais que o original
        //usado para copiar os elementos do antigo vetor e adicionar novos fornecedores

        for (int i = 0; i < todosFornecedores.Length; i++) //copia os valores do vetor antigo no novo vetor
        {
            novoVetorFornecedores[i] = todosFornecedores[i];
        }
        novoVetorFornecedores[novoVetorFornecedores.Length - 1] = new Fornecedor(Id, Nome, Descricao, Telefone, Email); //adiciona o novo fornecedor na última posição do vetor
        todosFornecedores = novoVetorFornecedores; //atualiza o vetor com o fornecedor recém adicionado
        */
    }
    public void AlteraFornecedor()
    {
        Console.Write("Informe o Id do fornecedor:\n");
        int IdCodigo = int.Parse(Console.ReadLine());

        for (int i = 0; i < BD.TodosFornecedores.Length; i++)
        {
            if (BD.TodosFornecedores[i].Id == IdCodigo) //se os dois códigos forem iguais, altera as informações de tal código
            {
                Console.Write("Novo nome do fornecedor:\n");
                BD.TodosFornecedores[i].Nome = Console.ReadLine();
                Console.Write("Nova descrição do fornecedor:\n");
                BD.TodosFornecedores[i].Descricao = Console.ReadLine();
                Console.Write("Novo telefone do fornecedor:\n");
                BD.TodosFornecedores[i].Telefone = Console.ReadLine();
                Console.Write("Novo email do fornecedor:\n");
                BD.TodosFornecedores[i].Email = Console.ReadLine();

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

            for (int i = 0; i < BD.TodosFornecedores.Length; i++)
            {
                if (codigoFornecedor == BD.TodosFornecedores[i].Id) //se o código digitado for igual ao código salvo no vetor, mostra o fornecedor
                {
                    BD.TodosFornecedores[i].ObterFornecedor();
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

            for (int i = 0; i < BD.TodosFornecedores.Length; i++)
            {
                if (nomeFornecedor == BD.TodosFornecedores[i].Nome) //se o nome digitado for igual ao nome salvo no vetor, mostra o fornecedor
                {
                    BD.TodosFornecedores[i].ObterFornecedor();
                }
                else
                {
                    Console.WriteLine("Nome de fornecedor não encontrado!\n");
                }
            }
        }
    }
}
    