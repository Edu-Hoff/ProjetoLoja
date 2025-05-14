using System;
using Entidades;

namespace GerenciamentoLoja;

public class GerenciadorFornecedor
{
    Fornecedor[] todosFornecedores = new Fornecedor[1];
    public void CadastraFornecedor()
    {
        Console.WriteLine("Id do fornecedor: ");
        String Id = Console.ReadLine();
        Console.WriteLine("Nome do fornecedor: ");
        String Nome = Console.ReadLine();
        Console.WriteLine("Descrição do fornecedor: ");
        String Descricao = Console.ReadLine();
        Console.WriteLine("Telefone do fornecedor: ");
        String Telefone = Console.ReadLine();
        Console.WriteLine("Email do fornecedor: ");
        String Email = Console.ReadLine();
    }
    public void AlteraFornecedor()
    {
        
    }
    public void ExcluiFornecedor()
    {
        
    }
}