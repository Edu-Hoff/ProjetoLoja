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
                    Excluir();
                    break;
                case 4:
                    Consultar();
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
        LimparTela("Cadastro de Produto");
        Console.WriteLine("Digite \"0\" no nome para cancelar");
        String Nome = LerString("Informe o Nome: ");
        if (Nome == "0")
        {
            LimparTela("Cadastro Cancelado", ConsoleColor.Blue);
            return;
        }
        if (GerenciadorDeProduto.ProcuraProduto(Nome))
        {
            LimparTela("Produto já esta cadastrado no sistema", ConsoleColor.Red);
            return;
        }
        double Valor = LerDoubleConsole("Valor do produto: ");
        int Quantidade = LerIntConsole("Quantidade em estoque: ");
        String Fornecedor = LerString("Fornecedor do produto: ");
        GerenciadorDeProduto.CadastraProduto(Nome, Valor, Quantidade, Fornecedor);
    }
    public void Alterar() //por enquanto está assim, mas qualquer coisa pode alterar
    {
        LimparTela("Edição de produto");
        Console.WriteLine("1 - Informar ID atual");
        Console.WriteLine("2 - Informar Nome atual");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole("Escolha: ");
        int indice = -1;
        if (op == 1)
        {
            int Id = LerIntConsole("Codigo do produto: ");
            if (GerenciadorDeProduto.ProcuraProduto(Id))
            {
                indice = GerenciadorDeProduto.BaseDeDados.ProcuraItemPorId(GerenciadorDeProduto.BaseDeDados.TodosFornecedores, Id);
                //GerenciadorDeProduto.AlteraProduto();
            }
            else
                LimparTela("Produto Não Encontrado", ConsoleColor.Red);
        }
        else
            if (op == 2)
            {
            String Nome = LerString("Nome do produto: ");
            if (GerenciadorDeProduto.ProcuraProduto(Nome))
            {
                indice = GerenciadorDeProduto.BaseDeDados.ProcuraItemExpecificoPorNome(GerenciadorDeProduto.BaseDeDados.TodosFornecedores, Nome);
                //GerenciadorDeProduto.AlteraProduto();
            }
            else
                LimparTela("Produto Não Encontrado", ConsoleColor.Red);
            }
        if (indice != -1)
        {
            String Nome;
            Double Valor;
            int Quantidade;
            String Fornecedor;
            Console.WriteLine("Escolha se quer modificar cada um dos parâmetros a seguir:\n 1 - sim\n0 - não");
            op = LerIntConsole("Nome: ");
            if (op == 1)
            {
                Nome = LerString("Novo: ");
            }
            else
            {
                Nome = GerenciadorDeProduto.BaseDeDados.TodosProdutos[indice].Nome;
            }

            op = LerIntConsole("Valor: ");
            if (op == 1)
            {
                Valor = LerDoubleConsole("Novo: ");
            }
            else
            {
                Valor = GerenciadorDeProduto.BaseDeDados.TodosProdutos[indice].Valor;
            }

            op = LerIntConsole("Quantidade: ");
            if (op == 1)
            {
                Quantidade = LerIntConsole("Nova: ");
            }
            else
            {
                Quantidade = GerenciadorDeProduto.BaseDeDados.TodosProdutos[indice].Quantidade;
            }
            op = LerIntConsole("Fornecedor: ");
            if (op == 1)
            {
                Fornecedor = LerString("Novo: ");
            }
            else
            {
                Fornecedor = GerenciadorDeProduto.BaseDeDados.TodosProdutos[indice].Fornecedor.Nome;
            }
            GerenciadorDeProduto.AlteraProduto(indice, Nome, Valor, Quantidade, Fornecedor);
        }
    }
    public void Excluir()
    {
        LimparTela("Remoção de um produto");
        if (LerIntConsole("Digite 1 se quiser a lista atual de produtos: ") == 1)
        {
            EscreveVetor(GerenciadorDeProduto.BaseDeDados.TodosProdutos);
            Console.WriteLine("------------------------------");
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            if (GerenciadorDeProduto.ExcluiProduto(LerIntConsole("Informe o ID do produto: ")))
                LimparTela("Produto Removido",ConsoleColor.Green);
            else
                LimparTela("Produto Não Encontrado",ConsoleColor.Red);
        }
        else if (op == 2)
        {
            if (GerenciadorDeProduto.ExcluiProduto(LerString("Informe o nome cadastrado: ")))
                LimparTela("Produto Removido",ConsoleColor.Green);
            else
                LimparTela("Produto Não Encontrado",ConsoleColor.Red);
        }
        else
        {
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
        }
    }
    private void Consultar()
    {
        int indice;
        LimparTela("Consulta de Produto");
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar nome exato");
        Console.WriteLine("3 - Informar parte do nome");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole();
        if (op == 1)
        {
            int Id = LerIntConsole("Informe o ID: ");
            if (GerenciadorDeProduto.ProcuraProduto(Id))
            {
                indice = GerenciadorDeProduto.BaseDeDados.ProcuraItemPorId(GerenciadorDeProduto.BaseDeDados.TodosProdutos, Id);
                EscreveVetor(GerenciadorDeProduto.BaseDeDados.TodosProdutos, indice);
            }
            else
                LimparTela("Produto Não Encontrado", ConsoleColor.Red);
        }
        else if (op == 2)
        {
            String Nome = LerString("Informe o nome: ");
            if (GerenciadorDeProduto.ProcuraProduto(Nome))
            {
                indice = GerenciadorDeProduto.BaseDeDados.ProcuraItemExpecificoPorNome(GerenciadorDeProduto.BaseDeDados.TodosProdutos, Nome);
                EscreveVetor(GerenciadorDeProduto.BaseDeDados.TodosProdutos, indice);
            }
            else
                LimparTela("Produto Não Encontrado", ConsoleColor.Red);
        }
        else if (op == 3)
        {
            String Nome = LerString("Informe o nome: ");
            if (GerenciadorDeProduto.ProcuraProduto(Nome))
            {
                Produto[] vet = GerenciadorDeProduto.BaseDeDados.ProcuraItensComNome(GerenciadorDeProduto.BaseDeDados.TodosProdutos, Nome);
                EscreveVetor(vet);
            }
            else
                LimparTela("Produto Não Encontrado", ConsoleColor.Red);
        }
        else
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
    }
}
