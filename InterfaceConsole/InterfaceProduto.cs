using System;
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
                    break;
                case 2:
                    Nome = Console.ReadLine();
                    GerenciadorProduto.AlteraProduto(Nome);
                    break;
                case 3:
                    Nome = Console.ReadLine();
                    GerenciadorProduto.ExcluiProduto(Nome);
                    //verificar se esta em algum fornecedor, chamar funcao excluir p. fornecedor tb
                    break;
                case 4:
                    //por nome ou id
                    break;
                default:
                    //exception
                    break;
            }

        } while (Op != 0);
    }
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
                double Valor = double.Parse(Console.ReadLine()); //depois adiciono uma função pra double
                break;
            case 3:
                Console.Write("");
                int Quantidade = LerIntConsole();
                break;
        }
    }
}
