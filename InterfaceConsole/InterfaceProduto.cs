using System;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceProduto : GerenciadorEntradas
{
    public void MenuProdutos(GerenciadorProduto GerP)
    {
        int Opcao;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar produtos-------");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Alterar produto");
            Console.WriteLine("3 - Excluir produto");
            Console.WriteLine("4 - Consultar produto");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: \n");

            Opcao = LerIntConsole();
            String Nome;
            switch (Opcao)
            {
                case 1:
                    break;
                case 2:
                    Nome = Console.ReadLine();
                    GerP.AlteraProduto(Nome);
                    break;
                case 3:
                    Nome = Console.ReadLine();
                    GerP.ExcluiProduto(Nome);
                    //verificar se esta em algum fornecedor, chamar funcao excluir p. fornecedor tb
                    break;
                case 4:
                    //por nome ou id
                    break;
                default:
                    //exception
                    break;
            }

        } while (Opcao != 0);
    }
}
