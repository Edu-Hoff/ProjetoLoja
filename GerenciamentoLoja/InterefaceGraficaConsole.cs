using System;

namespace ProjetoLoja;

public class InterefaceGraficaConsole
{
    
    public void MenuFornecedores()
    {
        int opcao;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            Console.WriteLine("-------Gerenciar fornecedores-------");
            Console.WriteLine("1 - Cadastrar fornecedor");
            Console.WriteLine("2 - Alterar fornecedor");
            Console.WriteLine("3 - Excluir fornecedor");
            Console.WriteLine("4 - Consultar fornecedor");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: \n");
            
            opcao = int.Parse(Console.ReadLine());

        } while (opcao != 0);
    }
}
