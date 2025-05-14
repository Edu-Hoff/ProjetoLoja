using System;

namespace Pedidos;

public class GerenciadorProduto
{
    Produto[] TodosProdutos = new Produto[5];
    public void CadastraProduto()
    {
        Console.WriteLine("Informe o nome produto:");
        String Nome = Console.ReadLine();
    }
    public void AlteraProduto(int Id)
    {

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
