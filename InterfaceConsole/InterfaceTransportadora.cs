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
            Console.WriteLine("3 - Remover transportadora");
            Console.WriteLine("4 - Consultar transportadora");
            Console.WriteLine("5 - Listar transportadoras");
            Console.WriteLine("0 - Voltar");

            Opcao = LerIntConsole("Escolha: ");
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
                case 5:
                    Console.Clear();
                    EscreveVetor(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras);
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
            LimparTela("Transportadora já esta cadastrado no sistema", ConsoleColor.DarkRed);
            return;
        }
        double ValorPorKM = LerDoubleConsole("Valor por quilômetro: ");
        GerenciadorDeTransportadora.CadastraTransportadora(Nome, ValorPorKM);
        LimparTela("Cadastro Realizado",ConsoleColor.Green); 
    }

    public void MenuAltera()
    {
        int ind;
        LimparTela("Edição de Transportadora");
        if (LerIntConsole("Digite 1 se quiser a lista atual de transportadoras: ") == 1)
        {
            EscreveVetor(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras);
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome atual");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            int ID;
            ID = LerIntConsole("Informe o ID da transportadora: ");
            if (GerenciadorDeTransportadora.ProcuraTransportadora(ID))
            {
                ind = GerenciadorDeTransportadora.BaseDeDados.ProcuraItemPorId(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, ID);
                String Nome = ""; double ValorPorKM = -1;
                String Resposta = LerStringAlterar("Deseja alterar o nome? S/N: ");
                if (Resposta == "S" || Resposta == "s")
                {
                    Nome = LerString("Informe o novo nome: ");
                    if (GerenciadorDeTransportadora.ProcuraTransportadora(Nome))
                    {
                        LimparTela("Nome já cadastrado no sistema", ConsoleColor.DarkRed);
                        return;
                    }
                }
                Resposta = LerStringAlterar("Deseja alterar o valor por KM? S/N: ");
                if (Resposta == "S" || Resposta == "s")
                    ValorPorKM = LerDoubleConsole("Informe o novo valor por KM: ");
                Transportadora Transportadora = new Transportadora(Nome, ValorPorKM);
                GerenciadorDeTransportadora.AlteraTransportadora(ind, Transportadora);
                LimparTela("Transportadora Editada", ConsoleColor.Cyan);
            }
            else
                LimparTela("Transportadora não encontrada", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome;
            Nome = LerString("Informe o nome da transportadora: ");
            if (GerenciadorDeTransportadora.ProcuraTransportadora(Nome))
            {
                ind = GerenciadorDeTransportadora.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, Nome);
                String NomeNovo = ""; double ValorPorKM = -1;
                String Resposta = LerStringAlterar("Deseja alterar o nome? S/N: ");
                if (Resposta == "S" || Resposta == "s")
                {
                    NomeNovo = LerString("Informe o novo nome: ");
                    if (GerenciadorDeTransportadora.ProcuraTransportadora(NomeNovo))
                    {
                        LimparTela("Nome já cadastrado no sistema", ConsoleColor.DarkRed);
                        return;
                    }
                }
                Resposta = LerStringAlterar("Deseja alterar o valor por KM? S/N: ");
                if (Resposta == "S" || Resposta == "s")
                    ValorPorKM = LerDoubleConsole("Informe o novo valor por KM: ");
                Transportadora Transportadora = new Transportadora(NomeNovo, ValorPorKM);
                GerenciadorDeTransportadora.AlteraTransportadora(ind, Transportadora);
                LimparTela("Transportadora Editada", ConsoleColor.Cyan);
            }
            else
                LimparTela("Transportadora não encontrada", ConsoleColor.DarkRed);
        }
        else
            LimparTela("Edição Cancelada",ConsoleColor.Blue);
    }

    public void MenuExclui()
    {
        LimparTela("Remoção de transportadora");
        if (LerIntConsole("Digite 1 se quiser a lista atual de transportadoras: ") == 1)
        {
            EscreveVetor(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras);
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
                LimparTela("Transportadora não Encontrada",ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            if (GerenciadorDeTransportadora.ExcluiTransportadora(LerString("Informe o nome cadastrado: ")))
                LimparTela("Transportadora Removida",ConsoleColor.Green);
            else
                LimparTela("Transportadora não Encontrada",ConsoleColor.DarkRed);
        }
        else
        {
            LimparTela("Remoção Cancelada",ConsoleColor.Blue);
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
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            int Id = LerIntConsole("Informe o ID: ");
            if (GerenciadorDeTransportadora.ProcuraTransportadora(Id))
            {
                indice = GerenciadorDeTransportadora.BaseDeDados.ProcuraItemPorId(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, Id);
                EscreveVetor(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, indice);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Transportadora não encontrada", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome = LerString("Informe o nome: ");
            if (GerenciadorDeTransportadora.ProcuraTransportadora(Nome))
            {
                indice = GerenciadorDeTransportadora.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, Nome);
                EscreveVetor(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, indice);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Transportadora não encontrada", ConsoleColor.DarkRed);
        }
        else if (op == 3)
        {
            String Nome = LerString("Informe o nome: ");
            Transportadora[] vet = GerenciadorDeTransportadora.BaseDeDados.ProcuraItensComNome(GerenciadorDeTransportadora.BaseDeDados.TodasTransportadoras, Nome);
            if (vet.Length > 0)
            {
                LimparTela($"Todas Transportadoras com \"{Nome}\"",ConsoleColor.Magenta);
                EscreveVetor(vet);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Nenhuma Transportadora Encontrada", ConsoleColor.DarkRed);
        }
        else
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
    }
}
