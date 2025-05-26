using System;
using Entidades;
using Gerenciadores;
using Microsoft.VisualBasic;

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
            Console.WriteLine("1 - Editar meu usuário");
            Console.WriteLine("2 - Excluir meu usuário");
            Console.WriteLine("3 - Cadastrar novo usuário");
            Console.WriteLine("4 - Editar usuários");
            Console.WriteLine("5 - Excluir usuário");
            Console.WriteLine("6 - Consultar usuário");
            Console.WriteLine("7 - Listar usuários");
            Console.WriteLine("0 - Voltar");

            Opcao = LerIntConsole("Escolha: ");
            switch (Opcao)
            {
                case 1:
                    AlterarUsuario(User);
                    break;
                case 2:
                    ExcluirMeuUser(User);
                    break;
                case 3:
                    CadastrarUsuario();
                    break;
                case 4:
                    AlterarOutroUser();
                    break;
                case 5:
                    ExcluirUser();
                    break;
                case 6:
                    MenuConsulta();
                    break;
                case 7:
                    EscreveVetor(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios);
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

    private void CadastrarUsuario()
    {
        LimparTela("Cadastro de Usuario");
        Console.WriteLine("Digite \"0\"  no username para cancelar");
        String Nome = LerString("Informe o username: ");
        if (Nome == "0")
        {
            LimparTela("Cadastro Cancelado", ConsoleColor.Blue);
            return;
        }
        if (GerenciadorDeUsuario.ProcuraUsuario(Nome))
        {
            LimparTela("Usuario já esta no sistema", ConsoleColor.DarkRed);
            return;
        }
        String Senha = LerString("Informe a senha: ");
        String Admin = LerString("Administrador S/N: ");
        Console.Clear();
        if (GerenciadorDeUsuario.FazerCadastro(Nome, Senha, Admin))
        {
            LimparTela("Cadastro Realizado", ConsoleColor.Green);
        }
        else
            LimparTela("Cadastro Nao Realizado", ConsoleColor.DarkRed);
    }

    private void AlterarUsuario(Usuario User)
    {
        LimparTela("Informe o novo atributo ou nada para não alterar ");
        String NovoNome = LerStringAlterar("Informe o novo username: ");
        if (GerenciadorDeUsuario.ProcuraUsuario(NovoNome))
        {
            LimparTela("Username já cadastrado no sistema", ConsoleColor.DarkRed);
            return;
        }
        String NovaSenha = LerStringAlterar("Informe a nova senha: ");
        String Adm = LerStringAlterar("É Administrador? S/N ");
        bool Admin;
        if (Adm == "") Admin = User.Admin;
        else if (Adm == "S" || Adm == "s") Admin = true;
        else Admin = false;
        Usuario UserAlterado = new Usuario(NovoNome, NovaSenha, Admin);
        GerenciadorDeUsuario.AlteraUsuario(User, UserAlterado);
        LimparTela("Usuario editado", ConsoleColor.Green);

    }

    private void AlterarOutroUser()
    {
        Usuario? Usr = EncontraUsuario("Edição de usuarios");
        if (Usr != null)
        {
            AlterarUsuario(Usr);
            if (LerIntConsole("Digite 1 se quiser a lista atual de usuarios: ") == 1)
            {
                EscreveVetor(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios);
            }
        }
    }

    private void ExcluirMeuUser(Usuario User)
    {
        if (Confirmacao("Você esta prestes a excluir seu usuario."))
        {
            GerenciadorDeUsuario.RemoverUsuario(User);
            LimparTela("Usuario Removido", ConsoleColor.Green);
        }
        else
            LimparTela("Usuario não removido", ConsoleColor.DarkRed);
    }

    private void ExcluirUser()
    {
        Usuario? User = EncontraUsuario("Remoção de Usuario");
        if(User == null) return;
        if (Confirmacao($"Você esta prestes a excluir o usuario {User.Nome}."))
        {
            GerenciadorDeUsuario.RemoverUsuario(User);
            LimparTela("Usuario Removido", ConsoleColor.Green);
        }
        else
            LimparTela("Usuario não removido", ConsoleColor.DarkRed);
    }

    public Usuario? EncontraUsuario(String msg = "")
    {
        int ind;
        LimparTela(msg);
        if (LerIntConsole("Digite 1 se quiser a lista atual de usuarios: ") == 1)
        {
            EscreveVetor(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios);
        }
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar Nome atual");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            int ID;
            ID = LerIntConsole("Informe o ID do usuario: ");
            if (GerenciadorDeUsuario.ProcuraUsuario(ID))
            {
                ind = GerenciadorDeUsuario.BaseDeDados.ProcuraItemPorId(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios, ID);
                return GerenciadorDeUsuario.BaseDeDados.TodosUsuarios[ind];
            }
            else
                LimparTela("Usuario Não Encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome;
            Nome = LerString("Informe o nome do usuario: ");
            if (GerenciadorDeUsuario.ProcuraUsuario(Nome))
            {
                ind = GerenciadorDeUsuario.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios, Nome);
                return GerenciadorDeUsuario.BaseDeDados.TodosUsuarios[ind];
            }
            else
                LimparTela("Usuario Não Encontrado", ConsoleColor.DarkRed);
        }
        else
            LimparTela("Ação Cancelada", ConsoleColor.Blue);
        return null;
    }
    
    private void MenuConsulta()
    {
        int ind;
        LimparTela("Consulta de Usuario");
        Console.WriteLine("1 - Informar ID");
        Console.WriteLine("2 - Informar nome exato");
        Console.WriteLine("3 - Informar parte do nome");
        Console.WriteLine("≠ - Cancelar");
        int op = LerIntConsole("Escolha: ");
        if (op == 1)
        {
            int ID;
            ID = LerIntConsole("Informe o ID: ");
            if (GerenciadorDeUsuario.ProcuraUsuario(ID))
            {
                ind = GerenciadorDeUsuario.BaseDeDados.ProcuraItemPorId(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios, ID);
                EscreveVetor(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios, ind);
            }
            else
                LimparTela("Usuario Não Encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 2)
        {
            String Nome;
            Nome = LerString("Informe o nome: ");
            if (GerenciadorDeUsuario.ProcuraUsuario(Nome))
            {
                ind = GerenciadorDeUsuario.BaseDeDados.ProcuraItemEspecificoPorNome(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios, Nome);
                EscreveVetor(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios, ind);
            }
            else
                LimparTela("Usuario Não Encontrado", ConsoleColor.DarkRed);
        }
        else if (op == 3)
        {
            String Nome;
            Nome = LerString("Informe o nome: ");
            Usuario[] vet = GerenciadorDeUsuario.BaseDeDados.ProcuraItensComNome(GerenciadorDeUsuario.BaseDeDados.TodosUsuarios, Nome);
            if(vet.Length > 0)
                EscreveVetor(vet);
            else
                LimparTela("Nenhum Usuario Encontrado", ConsoleColor.DarkRed);
        }
        else
            LimparTela("Consulta Cancelada",ConsoleColor.Blue);
    }

    public bool Confirmacao(String msg)
    {
        String temp = LerStringAlterar($"{msg}\nConfirmar? S/N: ");
        if (temp == "S" || temp == "s")
            return true;
        return false;
    }
}