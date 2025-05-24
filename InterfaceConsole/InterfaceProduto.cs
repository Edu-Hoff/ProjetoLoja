using System;
using BaseDeDados;
using Entidades;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceProduto : GerenciadorEntradasSaidas
{
    public InterfaceProduto(GerenciadorProduto GerenciadorDeProduto)
    {
        this.GerenciadorDeProduto = GerenciadorDeProduto;
    }

    public GerenciadorProduto GerenciadorDeProduto;
    public void MenuProdutos()
    {
        int Op;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar produtos-------");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Alterar produto");
            Console.WriteLine("3 - Excluir produto");
            Console.WriteLine("4 - Consultar produto");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: \n");

            Op = LerIntConsole();
            switch (Op)
            {
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    Alterar();
                    break;
                case 3:
                    Console.Write("Id do item: ");
                    int Id = LerIntConsole();
                    GerenciadorDeProduto.ExcluiProduto(Id);
                    //verificar se esta em algum fornecedor, chamar funcao excluir p. fornecedor tb
                    break;
                case 4:
                    Console.Write("1 - Consulta por nome\n2 - Consulta por código\nEscolha: ");
                    Op = LerIntConsole();
                    if (Op == 1)
                    {
                        ConsultaNome();
                    }
                    else if (Op == 2)
                    {
                        ConsultaId();
                    }
                    else
                    {
                        //exception    
                    }
                    break;
                case 0:
                    break;
                default:
                    //exception
                    LimparTela("Opção Invalida", ConsoleColor.DarkRed);
                    break;
            }

        } while (Op != 0);
    }
    public void Cadastrar()
    {
        String Nome = LerString("Nome do produto: ");
        Console.Write("Valor do produto: ");
        double Valor = LerDoubleConsole();
        Console.Write("Quantidade em estoque: ");
        int Quantidade = LerIntConsole();
        String Fornecedor = LerString("Fornecedor do produto: ");
        GerenciadorDeProduto.CadastraProduto(Nome, Valor, Quantidade, Fornecedor);
    }
    public void Alterar()
    {
        Console.Write("Qual dos parâmetros do produto deseja modificar?\n1 - Nome\n2 - Valor\n3 - Quantidade em estoque\nEscolha: ");
        int Op = LerIntConsole();
        switch (Op)
        {
            case 1:
                String Nome = LerString("Novo nome: ");
                break;
            case 2:
                Console.Write("Novo valor: ");
                double Valor = LerDoubleConsole();
                break;
            case 3:
                break;
        }
    }
    public void Excluir()
    {

    }
    public void ConsultaNome()
    {
        String Nome = LerString("Nome: ");
        GerenciadorDeProduto.ObterItemNome(Nome);
    }
    public void ConsultaId()
    {
        Console.Write("Código: ");
        int Id = LerIntConsole();
        GerenciadorDeProduto.ObterItemCodigo(Id);
    }

}
