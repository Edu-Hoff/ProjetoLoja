using System;
using BaseDeDados;
using Entidades;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceFornecedor : GerenciadorEntradasSaidas
{
    public InterfaceFornecedor(GerenciadorFornecedor GerenciadorDeFornecedor)
    {
        this.GerenciadorDeFornecedor = GerenciadorDeFornecedor;
    }
    private GerenciadorFornecedor GerenciadorDeFornecedor;
    public void MenuFornecedores()
    {
        int Opcao;
        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar fornecedores-------");
            Console.WriteLine("1 - Cadastrar fornecedor");
            Console.WriteLine("2 - Alterar fornecedor");
            Console.WriteLine("3 - Remover fornecedor");
            Console.WriteLine("4 - Consultar fornecedor");
            Console.WriteLine("0 - Voltar");
            Opcao = LerIntConsole();
            switch (Opcao)
            {
                case 1:
                    Cadastrar();
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
                    break;
                default:
                    //exception
                    LimparTela("Opção Invalida", ConsoleColor.DarkRed);
                    break;
            }
        } while (Opcao != 0);
    }

    private void Cadastrar()
    {
        LimparTela("Cadastro de Fornecedor");
        Console.WriteLine("Digite \"0\"  no nome para cancelar");
        String Nome = LerString("Informe o nome: ");
        if (Nome == "0")
        {
            LimparTela("Cadastro Cancelado", ConsoleColor.Blue);
            return;
        }
        if (GerenciadorDeFornecedor.ProcuraFornecedor(Nome))
        {
            LimparTela("Fornecedor já esta no sistema", ConsoleColor.Red);
            return;
        }
        String Descricao = LerString("Informe a descrição: ");
        String Telefone = LerString("Informe o telefone: ");
        String Email = LerString("Informe o email: ");
        Fornecedor Fornecedor = new Fornecedor(Nome, Descricao, Telefone, Email, LeEndereco());
        GerenciadorDeFornecedor.CadastraFornecedor(Fornecedor);
        LimparTela("Cadastro Realizado",ConsoleColor.Green);    
    }

    private void MenuAltera()
    {
        int ind;
        LimparTela("Edição de Fornecedor");
        if (LerIntConsole("Digite 1 se quiser a lista atual de fornecedores: ") == 1)
        {
            EscreveVetor(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores);
            Console.WriteLine("------------------------------");
        }
        Console.WriteLine("1 - Informar ID atual");
        Console.WriteLine("2 - Informar Nome atual");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole();
        if (op == 1)
        {
            int ID;
            ID = LerIntConsole("Informe o ID do fornecedor: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(ID))
            {
                ind = GerenciadorDeFornecedor.BaseDeDados.ProcuraItemPorId(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ID);
                LimparTela("Informe o novo atributo ou nada para não alterar ", ConsoleColor.Magenta);
                Fornecedor Fornecedor = LeFornecedorParaAlterar();
                GerenciadorDeFornecedor.AlteraFornecedor(ind, Fornecedor);
                LimparTela("Fornecedor editado", ConsoleColor.Green);
            }
            else
                LimparTela("Fornecedor Não Encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome;
            Nome = LerString("Informe o nome do fornecedor: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(Nome))
            {
                ind = GerenciadorDeFornecedor.BaseDeDados.ProcuraItemExpecificoPorNome(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, Nome);
                LimparTela("Informe o novo atributo ou nada para não alterar ", ConsoleColor.Magenta);
                Fornecedor Fornecedor = LeFornecedorParaAlterar();
                GerenciadorDeFornecedor.AlteraFornecedor(ind, Fornecedor);
                LimparTela("Fornecedor editado", ConsoleColor.Green);
            }
            else
                LimparTela("Fornecedor Não Encontrado", ConsoleColor.DarkRed);
        }
        else
            LimparTela("Edição Cancelada",ConsoleColor.Blue);
    }

    private void MenuExclui()
    {
        LimparTela("Remoção de Fornecedor");
        if (LerIntConsole("Digite 1 se quiser a lista atual de fornecedores: ") == 1)
        {
            EscreveVetor(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores);
            Console.WriteLine("------------------------------");
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole();
        if (op == 1)
        {
            if (GerenciadorDeFornecedor.ExcluiFornecedor(LerIntConsole("Informe o ID do fornecedor")))
                LimparTela("Fornecedor Removido",ConsoleColor.Green);
            else
                LimparTela("Fornecedor Não Encontrado",ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            if (GerenciadorDeFornecedor.ExcluiFornecedor(LerString("Informe o nome cadastrado: ")))
                LimparTela("Fornecedor Removido",ConsoleColor.Green);
            else
                LimparTela("Fornecedor Não Encontrado",ConsoleColor.DarkRed);
        }
        else
            LimparTela("Remoção Cancelada",ConsoleColor.Blue);
    }

    private void MenuConsulta()
    {
        int ind;
        LimparTela("Consulta de Fornecedor");
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar nome exato");
        Console.WriteLine("3 - Informar parte do nome");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole();
        if (op == 1)
        {
            int ID;
            ID = LerIntConsole("Informe o ID: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(ID))
            {
                ind = GerenciadorDeFornecedor.BaseDeDados.ProcuraItemPorId(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ID);
                EscreveVetorComEndereco(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ind);
            }
            else
                LimparTela("Fornecedor Não Encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome;
            Nome = LerString("Informe o nome: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(Nome))
            {
                ind = GerenciadorDeFornecedor.BaseDeDados.ProcuraItemExpecificoPorNome(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, Nome);
                EscreveVetorComEndereco(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ind);
            }
            else
                LimparTela("Fornecedor Não Encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 3)
        {
            String Nome;
            Nome = LerString("Informe o nome: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(Nome))
            {
                Fornecedor[] vet = GerenciadorDeFornecedor.BaseDeDados.ProcuraItensComNome(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, Nome);
                EscreveVetorComEndereco(vet);
            }
            else
                LimparTela("Fornecedor Não Encontrado", ConsoleColor.DarkRed);
        }
        else
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
    }
}
