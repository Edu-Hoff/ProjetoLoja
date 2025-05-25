using System;
using Entidades;
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
                    MenuCadastro();
                    break;
                case 2:
                    MenuAltera();
                    break;
                case 3:
                    MenuExclui();
                    break;
                case 4:
                    MenuConsulta();
                    break;
                case 0:
                    LimparTela("Voltando...", ConsoleColor.DarkYellow);
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
        LimparTela("Cadastro de Transportadora");
        Console.WriteLine("Digite \"0\" em Transportadora para cancelar");
        String Nome = LerString("Informe a transportadora: ");
        if (Nome == "0")
        {
            LimparTela("Cadastro Cancelado", ConsoleColor.Blue);
            return;
        }
        if (GerenciadorDeTransportadora.ProcuraTransportadora(Nome))
        {
            LimparTela("Produto já esta cadastrado no sistema", ConsoleColor.Red);
            return;
        }
        double ValorPorKM = LerDoubleConsole("Valor por quilômetro: ");
        GerenciadorDeTransportadora.CadastraTransportadora(Nome, ValorPorKM);
    }

    public void MenuAltera()
    {
        //add
    }

    public void MenuExclui()
    {
        LimparTela("Remoção de uma transportadora");
        if (LerIntConsole("Digite 1 se quiser a lista atual de transportadoras: ") == 1)
        {
            EscreveVetor(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras);
            Console.WriteLine("------------------------------");
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            if (GerenciadorDeTransportadora.ExcluiTransportadora(LerIntConsole("Informe o ID da transportadora: ")))
                LimparTela("Transportadora Removida",ConsoleColor.Green);
            else
                LimparTela("Transportadora não Encontrada",ConsoleColor.Red);
        }
        else if (op == 2)
        {
            if (GerenciadorDeTransportadora.ExcluiTransportadora(LerString("Informe o nome cadastrado: ")))
                LimparTela("Transportadora Removida",ConsoleColor.Green);
            else
                LimparTela("Transportadora Não Encontrada",ConsoleColor.Red);
        }
        else
        {
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
        }
    }
    public void MenuConsulta()
    {
        int indice;
        LimparTela("Consulta de Transportadora");
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar nome exato");
        Console.WriteLine("3 - Informar parte do nome");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole();
        if (op == 1)
        {
            int Id = LerIntConsole("Informe o ID: ");
            if (GerenciadorDeTransportadora.ProcuraTransportadora(Id))
            {
                indice = GerenciadorDeTransportadora.BaseDeDados.ProcuraItemPorId(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, Id);
                EscreveVetor(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, indice);
            }
            else
                LimparTela("Transportadora Não Encontrada", ConsoleColor.Red);
        }
        else if (op == 2)
        {
            String Nome = LerString("Informe o nome: ");
            if (GerenciadorDeTransportadora.ProcuraTransportadora(Nome))
            {
                indice = GerenciadorDeTransportadora.BaseDeDados.ProcuraItemExpecificoPorNome(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, Nome);
                EscreveVetor(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, indice);
            }
            else
                LimparTela("Transportadora Não Encontrada", ConsoleColor.Red);
        }
        else if (op == 3)
        {
            String Nome = LerString("Informe o nome: ");
            if (GerenciadorDeTransportadora.ProcuraTransportadora(Nome))
            {
                Transportadora[] vet = GerenciadorDeTransportadora.BaseDeDados.ProcuraItensComNome(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, Nome);
                EscreveVetor(vet);
            }
            else
                LimparTela("Transportadora Não Encontrada", ConsoleColor.Red);
        }
        else
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
    }
}
