using System;
using InfoContato;

namespace ProjetoLoja;

public class InterefaceGraficaConsole
{
    Usuario[] User = new Usuario[2]; // mover vetor p. base de dados
    public void MenuInicial()
    {
        Console.WriteLine("1 - Fazer login");
        Console.WriteLine("2 - Cadastrar novo usuário");
        int op = int.Parse(Console.ReadLine());
        do
        {
            if (op == 1)
            {
                Console.WriteLine("Usuário: ");
                String User = Console.ReadLine();
                Console.WriteLine("Senha: ");
                String Senha = Console.ReadLine();
                FazerLogin();
            }
            else
                if (op == 2)
            {
                FazerCadastro();
            }
            else
            {
                Console.WriteLine("Opção inválida")
                }
        } while (op != 1 && op != 2);
    }
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