using System;
using BaseDeDados;
using Entidades;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceProduto : GerenciadorEntradasSaidas
{
    public void MenuProdutos(GerenciadorProduto GerenciadorProduto)
    {
        int Op;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar produtos-------");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Alterar produto");
            Console.WriteLine("3 - Excluir produto");
            Console.WriteLine("4 - Consultar produto");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: \n");

            Op = LerIntConsole();
            String Nome;
            switch (Op)
            {
                case 1:
                    Nome = LerString("Nome do produto: ");
                    Console.Write("Valor do produto: ");
                    double Valor = LerDoubleConsole();
                    Console.Write("Quantidade em estoque: ");
                    int Quantidade = LerIntConsole();
                    String Fornecedor = LerString("Fornecedor do produto: ");
                    GerenciadorProduto.CadastraProduto(Nome, Valor, Quantidade, Fornecedor);
                    break;
                case 2:
                    //add
                    break;
                case 3:
                    Console.Write("Id do item: ");
                    int Id = LerIntConsole();
                    GerenciadorProduto.ExcluiProduto(Id);
                    //verificar se esta em algum fornecedor, chamar funcao excluir p. fornecedor tb
                    break;
                case 4:
                    Console.Write("1 - Consulta por nome\n2 - Consulta por código\nEscolha: ");
                    Op = LerIntConsole();
                    if (Op == 1)
                    {
                        Console.Write("Código: ");
                        Id = LerIntConsole();
                        GerenciadorProduto.ObterItemCodigo(Id);
                    }
                    else if (Op == 2)
                    {
                        Nome = LerString("Nome: ");
                        GerenciadorProduto.ObterItemNome(Nome);
                    }
                    else
                    {
                        //exception    
                    }
                    break;
                default:
                    //exception
                    break;
            }

        } while (Op != 0);
    }
    //deixei aqui, mas acho que nao precisa da funcao embaixo, depois vejo certinho
    public void ModificarProduto()
    {
        int Op;
        Console.Write("Qual dos parâmetros do produto deseja modificar?\n1 - Nome\n2 - Valor\n3 - Quantidade em estoque\nEscolha: ");
        Op = LerIntConsole();
        switch (Op)
        {
            case 1:
                String Nome = LerString("Novo nome: ");
                break;
            case 2:
                Console.Write("Novo valor: ");
                double Valor = LerDoubleConsole();
                break;
            case 3:
                break;
        }
    }
}
