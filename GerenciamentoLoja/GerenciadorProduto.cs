using System;
using System.ComponentModel.DataAnnotations;

namespace Pedidos;

public class GerenciadorProduto
{
    Produto[] TodosProdutos = new Produto[5];
    public void CadastraProduto()
    {
        Console.WriteLine("Informe o nome produto:");
        String Nome = Console.ReadLine();
        Console.WriteLine("Informe o valor do produto: ");
        Double Valor = double.Parse(Console.ReadLine());
        Console.WriteLine("Informe a quantidade de unidades do produto em estoque: ");
        int Quantidade = int.Parse(Console.ReadLine());

        Produto[] NovoVetorProdutos = new Produto[TodosProdutos.Length + 1];
        for (int i = 0; i < TodosProdutos.Length; i++)
        {
            NovoVetorProdutos[i] = TodosProdutos[i];
        }
        NovoVetorProdutos[NovoVetorProdutos.Length - 1] = new Produto(Nome, Valor, Quantidade);
        TodosProdutos = NovoVetorProdutos;
    }
    public void AlteraProduto(int Id) // revisar
    {
        foreach (Produto prod in TodosProdutos)
        {
            if (Id == prod.Id) // adicionar classe ObjetoComId (por isso o erro, dps adiciono)
            {
                Console.WriteLine("Qual dos parâmetros do produto deseja modificar?\n1 - Nome\n2 - Valor\n3 - Quantidade em estoque");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Novo nome: ");
                        prod.Nome = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Novo valor do produto: ");
                        prod.Valor = double.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("1 - Modificar por sobreescrita de valor\n2 - Adicionar quantidade\n3 - Remover quantidade");
                        switch (op)
                        {
                            case 1:
                                Console.Write("Nova quantidade: ");
                                prod.Quantidade = int.Parse(Console.ReadLine());
                                break;
                            case 2:
                                Console.Write("Quantidade a ser adicionada: ");
                                prod.Quantidade += int.Parse(Console.ReadLine());
                                break;
                            case 3:
                                Console.Write("Quantidade a ser removida: ");
                                int qtd = int.Parse(Console.ReadLine());
                                if (qtd <= prod.Quantidade)
                                {
                                    prod.Quantidade = qtd;
                                }
                                break;
                            default:
                                Console.WriteLine("Opção inválida!");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Parâmetro inválido!");
                        break;
                }
            }
        }
    }
    public void ExcluiProduto(int Id)
    {

    }
    public String ObterItemCodigo(int Id)
    {
        return "";
    }
    public String ObterItemNome(String Nome)
    {
        return "";
    }
}
