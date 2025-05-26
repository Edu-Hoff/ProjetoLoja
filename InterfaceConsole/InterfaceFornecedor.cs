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
            bool ExisteAlgo = GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores.Length > 0;
            bool Limpar = false;
            Console.WriteLine("-------Gerenciar fornecedores-------");
            Console.WriteLine("1 - Cadastrar fornecedor");
            if (ExisteAlgo)
            {
                Console.WriteLine("2 - Alterar fornecedor");
                Console.WriteLine("3 - Remover fornecedor");
                Console.WriteLine("4 - Consultar fornecedor");
                Console.WriteLine("5 - Listar fornecedores");
            }
            Console.WriteLine("0 - Voltar");

            Opcao = LerIntConsole("Escolha: ");
            switch (Opcao)
            {
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    if (ExisteAlgo)
                        MenuAltera();
                    else Limpar = true;
                    break;
                case 3:
                    if (ExisteAlgo)
                        MenuExclui();
                    else Limpar = true;
                    break;
                case 4:
                    if (ExisteAlgo)
                        MenuConsulta();
                    else Limpar = true;
                    break;
                case 5:
                    if (ExisteAlgo)
                    {
                        Console.Clear();
                        EscreveVetor(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores);
                    }
                    else Limpar = true;
                    break;
                case 0:
                    break;
                default:
                    //exception
                    LimparTela("Opção Invalida", ConsoleColor.DarkRed);
                    break;
            }
            if (Limpar) LimparTela("Opção Invalida", ConsoleColor.DarkRed);
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
            LimparTela("Fornecedor já esta no sistema", ConsoleColor.DarkRed);
            return;
        }
        String Descricao = LerString("Informe a descrição: ");
        String Telefone = LerString("Informe o telefone: ");
        String Email = LerString("Informe o email: ");
        GerenciadorDeFornecedor.CadastraFornecedor(new Fornecedor(Nome, Descricao, Telefone, Email, LeEndereco()));
        LimparTela("Cadastro Realizado",ConsoleColor.Green);    
    }

    private void MenuAltera()
    {
        int ind;
        LimparTela("Edição de Fornecedor");
        if (LerIntConsole("Digite 1 se quiser a lista atual de fornecedores: ") == 1)
        {
            EscreveVetor(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores);
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome atual");
        Console.WriteLine("0 - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            int ID;
            ID = LerIntConsole("Informe o ID do fornecedor: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(ID))
            {
                ind = GerenciadorDeFornecedor.BaseDeDados.ProcuraItemPorId(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ID);
                LimparTela("Atuais Atributos");
                EscreveVetorComEndereco(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ind);
                Console.WriteLine("Informe o novo atributo ou nada para não alterar ");
                String Nome = LerStringAlterar("Informe o nome: ");
                if (GerenciadorDeFornecedor.ProcuraFornecedor(Nome))
                {
                    LimparTela("Nome já cadastrado no sistema", ConsoleColor.DarkRed);
                    return;
                }
                Fornecedor Fornecedor = LeFornecedorParaAlterar(Nome);
                GerenciadorDeFornecedor.AlteraFornecedor(ind, Fornecedor);
                LimparTela("Fornecedor editado", ConsoleColor.Green);
            }
            else
                LimparTela("Fornecedor não encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome;
            Nome = LerString("Informe o nome do fornecedor: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(Nome))
            {
                ind = GerenciadorDeFornecedor.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, Nome);
                LimparTela("Informe o novo atributo ou nada para não alterar ");
                String NovoNome = LerStringAlterar("Informe o nome: ");
                if (GerenciadorDeFornecedor.ProcuraFornecedor(NovoNome))
                {
                    LimparTela("Nome já cadastrado no sistema", ConsoleColor.DarkRed);
                    return;
                }
                Fornecedor Fornecedor = LeFornecedorParaAlterar(NovoNome);
                GerenciadorDeFornecedor.AlteraFornecedor(ind, Fornecedor);
                LimparTela("Fornecedor editado", ConsoleColor.Green);
            }
            else
                LimparTela("Fornecedor não encontrado", ConsoleColor.DarkRed);
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
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome");
        Console.WriteLine("0 - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            if (GerenciadorDeFornecedor.ExcluiFornecedor(LerIntConsole("Informe o ID do fornecedor: ")))
                LimparTela("Fornecedor Removido",ConsoleColor.Green);
            else
                LimparTela("Fornecedor não Encontrado",ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            if (GerenciadorDeFornecedor.ExcluiFornecedor(LerString("Informe o nome cadastrado: ")))
                LimparTela("Fornecedor Removido",ConsoleColor.Green);
            else
                LimparTela("Fornecedor não Encontrado",ConsoleColor.DarkRed);
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
        Console.WriteLine("0 - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            int ID;
            ID = LerIntConsole("Informe o ID: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(ID))
            {
                ind = GerenciadorDeFornecedor.BaseDeDados.ProcuraItemPorId(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ID);
                EscreveVetorComEndereco(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ind);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Fornecedor não encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome;
            Nome = LerString("Informe o nome: ");
            if (GerenciadorDeFornecedor.ProcuraFornecedor(Nome))
            {
                ind = GerenciadorDeFornecedor.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, Nome);
                EscreveVetorComEndereco(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, ind);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Fornecedor não encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 3)
        {
            String Nome;
            Nome = LerString("Informe o nome: ");
            Fornecedor[] vet = GerenciadorDeFornecedor.BaseDeDados.ProcuraItensComNome(GerenciadorDeFornecedor.BaseDeDados.TodosFornecedores, Nome);
            if (vet.Length > 0)
            {
                LimparTela($"Todos Fornecedores com \"{Nome}\"");
                EscreveVetorComEndereco(vet);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Nenhum Fornecedor Encontrado", ConsoleColor.DarkRed);
        }
        else
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
    }
}
