using System;
using Gerenciadores;
using InfoContato;
using InterfaceConsole;
using Pedidos;

namespace ProjetoLoja;

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
            int op;
            Console.WriteLine("1 - Fazer login");
            Console.WriteLine("2 - Cadastrar novo usuário");
            Console.WriteLine("0 - Sair");
            do
            {
                op = LerIntConsole();
                if (op == 1)
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
                else if (op == 2)
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
            } while (op != 1 && op != 2 && op != 0);
            if (op == 0) break;
        }
    }


    public void MenuAdmin(Usuario user)
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
            op = LerIntConsole();
            switch (op)
            {
                case 1:
                    {
                        InterfaceFornecedor IF = new InterfaceFornecedor();
                        IF.MenuFornecedores(GerenciadorDeLoja.GerenciadorDeFornecedor);
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
        } while (op != 0);

    }
    public void MenuCliente(Usuario user)
    {

    }
}