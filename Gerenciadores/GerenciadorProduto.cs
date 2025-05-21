using System;
using System.ComponentModel.DataAnnotations;
using BaseDeDados;
using Pedidos;

namespace Gerenciadores;

public class GerenciadorProduto
{
    Produto[] TodosProdutos = new Produto[5];
    public void CadastraProduto()
    {
        //funcao generica
    }
//inteface - aquic modifica direto
    public void AlteraProduto(String Nome) // revisar
    {
        foreach (Produto prod in TodosProdutos)
        {
            if (Nome == prod.Nome) // adicionar classe ObjetoComId (por isso o erro, dps adiciono)
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
    public void ExcluiProduto(String Nome)
    {

    }
    public void ObterItemCodigo(int Id)
    {
        
    }
    public void ObterItemNome(String Nome)
    {

    }
}
