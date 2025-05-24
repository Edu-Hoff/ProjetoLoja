using System;
using Entidades;
using Gerenciadores;

namespace InterfaceConsole;

public class InterfaceUsuario : GerenciadorEntradasSaidas
{
    public InterfaceUsuario(GerenciadorUsuario GerenciadorDeUsuario)
    {
        this.GerenciadorDeUsuario = GerenciadorDeUsuario;
    }
    public GerenciadorUsuario GerenciadorDeUsuario;
    public void MenuUsuarios(Usuario User)
    {
        int Opcao;

        do //executa enquanto o usuário não digitar 0 para sair
        {
            //Todos usuarios
            Console.WriteLine("-------Gerenciar usuarios-------");
            Console.WriteLine("1 - Cadastrar usuário");
            Console.WriteLine("2 - Alterar usuário");
            Console.WriteLine("3 - Excluir usuário");
            Console.WriteLine("4 - Consultar usuário");
            Console.WriteLine("0 - Voltar");
            Opcao = LerIntConsole();
            switch (Opcao)
            {
                case 1:

                    break;
                case 2:
                    AlterarUsername(User);
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 0:
                    break;
                default:
                    //exception
                    LimparTela("Opção Invalida", ConsoleColor.DarkRed);
                    break;
            }
        } while (Opcao != 0);
    }

    private void AlterarUsername(Usuario User)
    {
        LimparTela("Edição de Usuario");
        Console.WriteLine("1 - Alterar username");
        Console.WriteLine("2 - Alterar senha");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole();
        if (op == 1)
        {
            String NovoNome = LerStringAlterar("Informe seu novo username: ");
            String Confirmacao = LerStringAlterar($"Tem certeza que deseja trocar\n\"{User.Nome}\" por \"{NovoNome}\"")
            if (GerenciadorDeFornecedor.ExcluiFornecedor(LerIntConsole("Informe o ID do fornecedor")))
                LimparTela("Fornecedor Removido", ConsoleColor.Green);
            else
                LimparTela("Fornecedor Não Encontrado", ConsoleColor.Red);
        }
        else if (op == 2)
        {
            if (GerenciadorDeFornecedor.ExcluiFornecedor(LerString("Informe o nome cadastrado: ")))
                LimparTela("Fornecedor Removido",ConsoleColor.Green);
            else
                LimparTela("Fornecedor Não Encontrado",ConsoleColor.Red);
        }
        else
            LimparTela("Edição Cancelada",ConsoleColor.Blue);
    }
}