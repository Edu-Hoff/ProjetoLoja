using System;
using Gerenciadores;
using Entidades;

namespace InterfaceConsole;

public class InterfacePrincipal : GerenciadorEntradas
{
    GerenciadorLoja GerenciadorDeLoja{ get; set; }
    public InterfacePrincipal(GerenciadorLoja GerenciadorDeLoja)
    {
        this.GerenciadorDeLoja = GerenciadorDeLoja;
    }


    public void MenuInicial()
    {
        while (true)
        {
            int Opcao;
            Console.WriteLine("1 - Fazer login");
            Console.WriteLine("2 - Cadastrar novo usuário");
            Console.WriteLine("0 - Sair");
            do
            {
                Opcao = LerIntConsole();
                if (Opcao == 1)
                {
                    String Nome = LerString("Informe seu username: ");
                    String Senha = LerString("Informe sua senha: ");
                    Usuario user = GerenciadorDeLoja.GerenciadorDeUsuario.FazerLogin(Nome, Senha);
                    if (user != null)
                    {
                        Console.Clear();
                        if (user.Admin)
                        {
                            MenuAdmin(user);
                        }
                        else
                        {
                            MenuCliente(user);
                        }
                    }
                }
                else if (Opcao == 2)
                {
                    String Nome = LerString("Informe seu username: ");
                    String Senha = LerString("Informe sua senha: ");
                    String Admin = LerString("Administrador S/N: ");
                    Console.Clear();
                    if (GerenciadorDeLoja.GerenciadorDeUsuario.FazerCadastro(Nome, Senha, Admin))
                    {
                        Console.WriteLine("Cadastro Realizado");
                        Console.WriteLine("---------------------------");
                    }
                    // else exception
                }
                //exception op invalida
            } while (Opcao != 1 && Opcao != 2 && Opcao != 0);
            if (Opcao == 0) break;
        }
        Console.WriteLine("Programa Encerrado...");
        Console.ReadKey();
    }


    public void MenuAdmin(Usuario user)
    {
        int Opcao;
        do
        {
            Console.WriteLine("-------Operações-------");
            Console.WriteLine("1 - Fornecedor");
            Console.WriteLine("2 - Produto");
            Console.WriteLine("3 - Usuario");
            Console.WriteLine("4 - Transportadora");
            Console.WriteLine("0 - Sair");
            Opcao = LerIntConsole();
            switch (Opcao)
            {
                case 1:
                    {
                        InterfaceFornecedor InterfaceDoFornecedor = new InterfaceFornecedor();
                        InterfaceDoFornecedor.MenuFornecedores(GerenciadorDeLoja.GerenciadorDeFornecedor);
                        break;
                    }
                case 2:
                    //MenuProdutos();
                    break;
                case 3:
                    //MenuUsuarios();
                    break;
                case 4:
                    //MenuTransportadoras();
                    break;
                default:
                    //exception
                    Console.Clear();
                    break;
            }
        } while (Opcao != 0);

    }
    public void MenuCliente(Usuario user)
    {
        Console.WriteLine("Teste");
    }
}