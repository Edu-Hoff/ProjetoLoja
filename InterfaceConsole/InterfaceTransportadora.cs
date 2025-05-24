using System;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceTransportadora : GerenciadorEntradasSaidas
{
    public InterfaceTransportadora(GerenciadorTransportadora GerenciadorDeTransportadora)
    {
        this.GerenciadorDeTransportadora = GerenciadorDeTransportadora;
    }
    public GerenciadorTransportadora GerenciadorDeTransportadora;
    public void MenuTransportadoras()
    {
        int Opcao;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar transportadoras-------");
            Console.WriteLine("1 - Cadastrar transportadora");
            Console.WriteLine("2 - Alterar transportadora");
            Console.WriteLine("3 - Excluir transportadora");
            Console.WriteLine("4 - Consultar transportadora");
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
                case 0:
                    break;
                default:
                    //exception
                    LimparTela("Opção Invalida", ConsoleColor.DarkRed);
                    break;
            }

        } while (Opcao != 0);
    }

    public void MenuCadastro()
    {

    }

    public void MenuAltera()
    {

    }

    public void MenuExclui()
    {

    }
    
    public void MenuConsulta()
    {
        
    }
}
