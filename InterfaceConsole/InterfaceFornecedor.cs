using System;
using Entidades;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceFornecedor : GerenciadorEntradasSaidas
{
    public void MenuFornecedores(GerenciadorFornecedor GerF)
    {
        int Opcao;
        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar fornecedores-------");
            Console.WriteLine("1 - Cadastrar fornecedor");
            Console.WriteLine("2 - Alterar fornecedor");
            Console.WriteLine("3 - Excluir fornecedor");
            Console.WriteLine("4 - Consultar fornecedor");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: \n");
            Opcao = LerIntConsole();
            switch (Opcao)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                default:
                    //exception
                    Console.Clear();
                    break;
            }
        } while (Opcao != 0);
    }
}
