using System;
using GerenciamentoLoja;
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
            GerenciadorUsuario GerenciadorUser = new GerenciadorUsuario();
            if (op == 1)
            {
                Usuario user = GerenciadorUser.FazerLogin();
                if (user != null)
                {
                    if (user.Admin)
                    {
                        //chama menu de admin
                    }
                    else
                    {
                        //chama menu de não admin
                    }
                }
            }
            else if (op == 2)
            {
                GerenciadorUser.FazerCadastro();
            }
            //exception op invalida
        } while (op != 1 && op != 2);
    }
    public void MenuAdmin()
    {
        
    }
    public void MenuNaoAdmin()
    {
        
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