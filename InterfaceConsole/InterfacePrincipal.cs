using System;
using GerenciamentoLoja;
using InfoContato;
using InterfaceConsole;
using Pedidos;

namespace ProjetoLoja;

public class InterfacePrincipal
{
    GerenciadorEntradas GenEnt = new GerenciadorEntradas();
    Usuario[] User = new Usuario[2]; // mover vetor p. base de dados
    public void MenuInicial()
    {
        Console.WriteLine("1 - Fazer login");
        Console.WriteLine("2 - Cadastrar novo usuário");
        do
        {
            int op = GenEnt.LerIntConsole();
            GerenciadorUsuario GerenciadorUser = new GerenciadorUsuario();
            if (op == 1)
            {
                Usuario user = GerenciadorUser.FazerLogin();
                if (user != null)
                {
                    if (user.Admin)
                    {
                        MenuAdmin();
                    }
                    else
                    {
                        MenuNaoAdmin();
                    }
                }
            }
            else if (op == 2)
            {
                GerenciadorUser.FazerCadastro();
            }
            //exception op invalida
        } while (op != 1 && op != 2);
    }
    public void MenuAdmin()
    {
        int op;
        do
        {
            Console.WriteLine("-------Operações-------");
            Console.WriteLine("1 - Fornecedor");
            Console.WriteLine("2 - Produto");
            Console.WriteLine("3 - Usuario");
            Console.WriteLine("4 - Transportadora");
            Console.WriteLine("0 - Sair");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    MenuFornecedores();
                    break;
                case 2:
                    MenuProdutos();
                    break;
                case 3:
                    MenuUsuarios();
                    break;
                case 4:
                    MenuTransportadoras();
                    break;
                default:
                    //exception
                    break;
            }
        } while (op != 0);

    }
    public void MenuNaoAdmin()
    {

    }
    public void MenuFornecedores()
    {
        int op;
        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar fornecedores-------");
            Console.WriteLine("1 - Cadastrar fornecedor");
            Console.WriteLine("2 - Alterar fornecedor");
            Console.WriteLine("3 - Excluir fornecedor");
            Console.WriteLine("4 - Consultar fornecedor");
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
            op = int.Parse(Console.ReadLine());

        } while (op != 0);
    }
    public void MenuProdutos()
    {
        int op;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            GerenciadorProduto GerenciadorProduto = new GerenciadorProduto();
            Console.WriteLine("-------Gerenciar produtos-------");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Alterar produto");
            Console.WriteLine("3 - Excluir produto");
            Console.WriteLine("4 - Consultar produto");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: \n");

            op = int.Parse(Console.ReadLine());
            String Nome;
            switch (op)
            {
                case 1:
                    GerenciadorProduto.CadastraProduto();
                    break;
                case 2:
                    Nome = Console.ReadLine();
                    GerenciadorProduto.AlteraProduto(Nome);
                    break;
                case 3:
                    Nome = Console.ReadLine();
                    GerenciadorProduto.ExcluiProduto(Nome);
                    break;
                case 4:
                    //por nome ou id
                    break;
                default:
                    //exception
                    break;
            }

        } while (op != 0);
    }
    public void MenuUsuarios()
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
    public void MenuTransportadoras()
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