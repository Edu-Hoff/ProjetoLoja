using System;
using Gerenciadores;
using Entidades;

namespace InterfaceConsole;

public class InterfacePrincipal : GerenciadorEntradasSaidas
{
    GerenciadorLoja GerenciadorDeLoja{ get; set; }
    public InterfacePrincipal(GerenciadorLoja GerenciadorDeLoja)
    {
        this.GerenciadorDeLoja = GerenciadorDeLoja;
    }


    public void MenuInicial(String NomeLoja)
    {
        LimparTela(NomeLoja,ConsoleColor.DarkBlue);
        while (true)
        {
            int Opcao;
            Console.WriteLine("1 - Fazer login");
            Console.WriteLine("2 - Cadastrar novo usuário");
            Console.WriteLine("0 - Sair");
            do
            {
                Opcao = LerIntConsole("Escolha: ");
                if (Opcao == 1)
                {
                    String Nome = LerString("Informe seu username: ");
                    String Senha = LerString("Informe sua senha: ");
                    Usuario? User = GerenciadorDeLoja.GerenciadorDeUsuario.FazerLogin(Nome, Senha);
                    if (User != null)
                    {
                        LimparTela($"Seja Bem-vindo(a) {User.Nome}", ConsoleColor.DarkBlue);
                        if (User.Admin)
                        {
                            MenuAdmin(User, NomeLoja);
                        }
                        else
                        {
                            MenuCliente(User, NomeLoja);
                        }
                    }
                    else
                        LimparTela("Username ou senha Invalido",ConsoleColor.DarkRed);
                }
                else if (Opcao == 2)
                {
                    String Nome = LerString("Informe seu username: ");
                    String Senha = LerString("Informe sua senha: ");
                    String Admin = LerString("Administrador S/N: ");
                    Console.Clear();
                    if (GerenciadorDeLoja.GerenciadorDeUsuario.FazerCadastro(Nome, Senha, Admin))
                    {
                        LimparTela("Cadastro Realizado", ConsoleColor.Green);
                    }
                    else
                        LimparTela("Cadastro Nao Realizado", ConsoleColor.DarkRed);
                }
                //exception op invalida
            } while (Opcao != 1 && Opcao != 2 && Opcao != 0);
            if (Opcao == 0) break;
        }
        LimparTela("Programa Encerrado...",ConsoleColor.DarkBlue);
        Console.ReadKey();
    }


    public void MenuAdmin(Usuario user, String nomeLoja)
    {
        int Opcao;
        do
        {
            Console.WriteLine("-------Operações-------");
            Console.WriteLine("1 - Usuario");
            Console.WriteLine("2 - Produto");
            Console.WriteLine("3 - Fornecedor");
            Console.WriteLine("4 - Transportadora");
            Console.WriteLine("0 - Sair");
            
            Opcao = LerIntConsole("Escolha: ");
            switch (Opcao)
            {
                case 1:
                    {
                        Console.Clear();
                        InterfaceUsuario InterfaceDoUsuario = new InterfaceUsuario(GerenciadorDeLoja.GerenciadorDeUsuario);
                        if (InterfaceDoUsuario.MenuUsuarios(user)) {Opcao = 0; LimparTela("Você foi automaticamente desconectado",ConsoleColor.DarkRed); }
                        else LimparTela("Menu Principal", ConsoleColor.Blue);
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        InterfaceProduto InterfaceDoProduto = new InterfaceProduto(GerenciadorDeLoja.GerenciadorDeProduto);
                        InterfaceDoProduto.MenuProdutos();
                        LimparTela("Menu Principal", ConsoleColor.Blue);
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        InterfaceFornecedor InterfaceDoFornecedor = new InterfaceFornecedor(GerenciadorDeLoja.GerenciadorDeFornecedor);
                        InterfaceDoFornecedor.MenuFornecedores();
                        LimparTela("Menu Principal", ConsoleColor.Blue);
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        InterfaceTransportadora InterfaceDaTranportadora = new InterfaceTransportadora(GerenciadorDeLoja.GerenciadorDeTransportadora);
                        InterfaceDaTranportadora.MenuTransportadoras();
                        LimparTela("Menu Principal", ConsoleColor.Blue);
                        break;
                    }
                case 0:
                    break;
                default:
                    //exception
                    LimparTela("Opção Invalida", ConsoleColor.DarkRed);
                    break;
            }
        } while (Opcao != 0);
        LimparTela(nomeLoja, ConsoleColor.DarkBlue);
    }

    public void MenuCliente(Usuario user, String nomeLoja)
    {
        Console.WriteLine("Este menu ainda nao esta disponivel");
    }
}