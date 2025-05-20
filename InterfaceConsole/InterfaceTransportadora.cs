using System;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceTransportadora : GerenciadorEntradas
{
    public void MenuTransportadoras(GerenciadorTransportadora GerT)
    {
        int op;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar transportadoras-------");
            Console.WriteLine("1 - Cadastrar transportadora");
            Console.WriteLine("2 - Alterar transportadora");
            Console.WriteLine("3 - Excluir transportadora");
            Console.WriteLine("4 - Consultar transportadora");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: \n");

            op = int.Parse(Console.ReadLine());
            switch (op)
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
                    break;
            }

        } while (op != 0);
    }
}
