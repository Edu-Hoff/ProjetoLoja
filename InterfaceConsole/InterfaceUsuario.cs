using System;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceUsuario : GerenciadorEntradas
{

    public void MenuUsuarios(GerenciadorUsuario GerU)
    {
        int op;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar usuarios-------");
            Console.WriteLine("1 - Cadastrar usuário");
            Console.WriteLine("2 - Alterar usuário");
            Console.WriteLine("3 - Excluir usuário");
            Console.WriteLine("4 - Consultar usuário");
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
