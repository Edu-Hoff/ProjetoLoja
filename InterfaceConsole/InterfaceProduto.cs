using System;
using System.Runtime.InteropServices;
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
            Console.WriteLine("5 - Listar produtos");
            Console.WriteLine("0 - Voltar");

            Op = LerIntConsole("Escolha: ");
            switch (Op)
            {
                case 1:
                    MenuCadastra();
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
                    EscreveVetorComQuantidadeFornecedor(GerenciadorDeProduto.BaseDeDados.TodosProdutos);
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
    public void MenuCadastra()
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
            LimparTela("Produto já esta cadastrado no sistema", ConsoleColor.DarkRed);
            return;
        }
        double Valor = LerDoubleConsole("Valor do produto: ");
        int Quantidade = LerIntConsole("Quantidade em estoque: ");
        String Fornecedor = LerString("Fornecedor do produto: ");
        if (-1 == GerenciadorDeProduto.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeProduto.BaseDeDados.TodosFornecedores, Fornecedor))
        {
            LimparTela("Fornecedor não encontrado", ConsoleColor.DarkRed);
            return;
        }
        GerenciadorDeProduto.CadastraProduto(Nome, Valor, Quantidade, Fornecedor);
        LimparTela("Produto Cadastrado", ConsoleColor.Green);
    }
    public void MenuAltera()
    {
        LimparTela("Edição de produto");
        if (LerIntConsole("Digite 1 se quiser a lista atual de produtos: ") == 1)
        {
            EscreveVetor(GerenciadorDeProduto.BaseDeDados.TodosProdutos);
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome atual");
        Console.WriteLine("0 - Cancelar");
        int op = LerIntConsole("Escolha: ");
        int indice = -1;
        if (op == 1)
        {
            int Id = LerIntConsole("Codigo do produto: ");
            if (GerenciadorDeProduto.ProcuraProduto(Id))
            {
                indice = GerenciadorDeProduto.BaseDeDados.ProcuraItemPorId(GerenciadorDeProduto.BaseDeDados.TodosProdutos, Id);
            }
            else
                LimparTela("Produto não encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome = LerString("Nome do produto: ");
            if (GerenciadorDeProduto.ProcuraProduto(Nome))
            {
                indice = GerenciadorDeProduto.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeProduto.BaseDeDados.TodosProdutos, Nome);
            }
            else
                LimparTela("Produto não encontrado", ConsoleColor.DarkRed);
        }
        else 
            LimparTela("Edição Cancelada", ConsoleColor.Blue);//excepiton
        if (indice != -1)
        {
            Console.WriteLine("Atributos atuais: ");
            EscreveVetorComQuantidadeFornecedor(GerenciadorDeProduto.BaseDeDados.TodosProdutos, indice);
            String Nome;
            Double Valor;
            int Quantidade;
            String Fornecedor;
            Console.WriteLine("Escolha se quer modificar cada um dos atributos a seguir:\n1 - sim\n0 - não");
            op = LerIntConsole("Nome: ");
            if (op == 1)
            {
                Nome = LerString("Novo: ");
                if (GerenciadorDeProduto.ProcuraProduto(Nome))
                {
                    LimparTela("Nome já cadastrado no sistema");
                    return;
                }
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
                Console.WriteLine("Utilize +, - ou = para modificar a quantidade");
                Quantidade = LerIntComOperacao(GerenciadorDeProduto.BaseDeDados.TodosProdutos[indice].Quantidade, "Nova: ");
                if (Quantidade < 0) Quantidade = 0;
            }
            else
            {
                Quantidade = GerenciadorDeProduto.BaseDeDados.TodosProdutos[indice].Quantidade;
            }
            op = LerIntConsole("Fornecedor: ");
            if (op == 1)
            {
                Fornecedor = LerString("Novo(nome): ");
                if (-1 == GerenciadorDeProduto.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeProduto.BaseDeDados.TodosFornecedores, Fornecedor))
                {
                    LimparTela("Fornecedor não encontrado", ConsoleColor.DarkRed);
                    return;
                }
            }
            else
            {
                Fornecedor = GerenciadorDeProduto.BaseDeDados.TodosProdutos[indice].Fornecedor.Nome;
            }
            GerenciadorDeProduto.AlteraProduto(indice, Nome, Valor, Quantidade, Fornecedor);
            LimparTela("Produto Editado", ConsoleColor.Green);
        }        
    }
    public void MenuExclui()
    {
        LimparTela("Remoção de um produto");
        if (LerIntConsole("Digite 1 se quiser a lista atual de produtos: ") == 1)
        {
            EscreveVetor(GerenciadorDeProduto.BaseDeDados.TodosProdutos);
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome");
        Console.WriteLine("0 - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            if (GerenciadorDeProduto.ExcluiProduto(LerIntConsole("Informe o ID do produto: ")))
                LimparTela("Produto Removido",ConsoleColor.Green);
            else
                LimparTela("Produto não encontrado",ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            if (GerenciadorDeProduto.ExcluiProduto(LerString("Informe o nome cadastrado: ")))
                LimparTela("Produto Removido",ConsoleColor.Green);
            else
                LimparTela("Produto não encontrado",ConsoleColor.DarkRed);
        }
        else
        {
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
        }
    }
    private void MenuConsulta()
    {
        int indice;
        LimparTela("Consulta de Produto");
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar nome exato");
        Console.WriteLine("3 - Informar parte do nome");
        Console.WriteLine("0 - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            int Id = LerIntConsole("Informe o ID: ");
            if (GerenciadorDeProduto.ProcuraProduto(Id))
            {
                indice = GerenciadorDeProduto.BaseDeDados.ProcuraItemPorId(GerenciadorDeProduto.BaseDeDados.TodosProdutos, Id);
                EscreveVetorComQuantidadeFornecedor(GerenciadorDeProduto.BaseDeDados.TodosProdutos, indice);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Produto não encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome = LerString("Informe o nome: ");
            if (GerenciadorDeProduto.ProcuraProduto(Nome))
            {
                indice = GerenciadorDeProduto.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeProduto.BaseDeDados.TodosProdutos, Nome);
                EscreveVetorComQuantidadeFornecedor(GerenciadorDeProduto.BaseDeDados.TodosProdutos, indice);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Produto não encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 3)
        {
            String Nome = LerString("Informe o nome: ");
            Produto[] vet = GerenciadorDeProduto.BaseDeDados.ProcuraItensComNome(GerenciadorDeProduto.BaseDeDados.TodosProdutos, Nome);
            if (vet.Length > 0)
            {
                LimparTela($"Todos Produtos com \"{Nome}\"");
                EscreveVetorComQuantidadeFornecedor(vet);
                Console.WriteLine("Pressione para continuar\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
                LimparTela("Nenhum Produto Encontrado", ConsoleColor.DarkRed);
        }
        else
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
    }
}
