using System;
using Entidades;

namespace InterfaceConsole;

public class GerenciadorEntradasSaidas
{
    public GerenciadorEntradasSaidas() { }

    //Le inteiro sem chance de outros caracteres
    public int LerIntConsole(String msg="")
    {
        Console.Write(msg);
        string input = "";
        ConsoleKeyInfo tecla;

        Console.ForegroundColor = ConsoleColor.Yellow;

        do
        {
            tecla = Console.ReadKey(intercept: true);

            if (char.IsDigit(tecla.KeyChar))
            {
                input += tecla.KeyChar;
                Console.Write(tecla.KeyChar);
            }
            else if (tecla.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Substring(0, input.Length - 1);
                Console.Write("\b \b");
            }
        }
        while (tecla.Key != ConsoleKey.Enter);

        Console.WriteLine("");
        Console.ResetColor();

        if (string.IsNullOrEmpty(input))
        {
            return 0;
        }

        if (int.TryParse(input, out int resultado))
            return resultado;
        else
            return 0;

    }

    public double LerDoubleConsole(String msg="")
    {
        Console.Write(msg);
        string input = "";
        ConsoleKeyInfo tecla;
        bool jaTemSeparadorDecimal = false;
        Console.ForegroundColor = ConsoleColor.Yellow;

        do
        {
            tecla = Console.ReadKey(intercept: true);

            if (char.IsDigit(tecla.KeyChar))
            {
                input += tecla.KeyChar;
                Console.Write(tecla.KeyChar);
            }
            else if ((tecla.KeyChar == '.' || tecla.KeyChar == ',') && !jaTemSeparadorDecimal)
            {
                input += ',';
                Console.Write(',');
                jaTemSeparadorDecimal = true;
            }
            else if (tecla.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                if (input[input.Length - 1] == ',')
                    jaTemSeparadorDecimal = false;

                input = input.Substring(0, input.Length - 1);
                Console.Write("\b \b");
            }
        }
        while (tecla.Key != ConsoleKey.Enter);

        Console.WriteLine();
        Console.ResetColor();

        if (string.IsNullOrWhiteSpace(input))
            return 0.0;

        return double.Parse(input);
    }

//  Obrigatoriamente deve ser digitado algo 
    public String LerString(String msg)
    {
        Console.Write(msg);
        Console.ForegroundColor = ConsoleColor.Yellow;
        String str;
        do
        {
            str = Console.ReadLine() ?? "";
        } while (string.IsNullOrWhiteSpace(str));
        Console.ResetColor();
        return str;
    }

//  Retorna vazio se so der enter ou so ter espacos
    public String LerStringAlterar(String msg)
    {
        Console.Write(msg);
        Console.ForegroundColor = ConsoleColor.Yellow;
        String str = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(str))
            return "";
            Console.ResetColor();
        return str;
    }
    /*
            -----Exemplo de Utilizacao no Usuario-----
        String temp; // Nao e necessario criar uma pra cada variavel pode se utilizar o msm
        if((temp=LerStringAlterar("Informe seu novo username: ")) != "")
        {
            user.Nome = temp;
        }
    */

    //Escreve qualquer vetor que tenha ToString();
    //Se enviar um indice escreve so o item do indice
    public void EscreveVetor<T>(T[] vetor, int ind = -1)
    {
        if (vetor == null || vetor.Length == 0)
        {
            return;
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        if (ind != -1)
        {
            Console.WriteLine(vetor[ind]?.ToString());
            return;
        }
        else for (int i = 0; i < vetor.Length; i++)
            {
                Console.WriteLine(vetor[i]?.ToString());
            }
        Console.ResetColor();
    }

    //Usar so com vetores de fornecedores e clientes
    //Se enviar um indice escreve so o item do indice
    public void EscreveVetorComEndereco<T>(T[] vetor, int ind = -1) where T : IHasEndereco
    {
        if (vetor == null || vetor.Length == 0)
        {
            return;
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        if (ind != -1)
        {
            Console.WriteLine(vetor[ind]?.ToString() + "\n" + vetor[ind].Endereco.ObterEndereco());
        }
        else for (int i = 0; i < vetor.Length; i++)
            {
                Console.WriteLine(vetor[i]?.ToString() + "\n" + vetor[i].Endereco.ObterEndereco());
            }
        Console.ResetColor();
    }

    //Usar so com vetor de Produtos
    //Se enviar um indice escreve so o item do indice
    public void EscreveVetorComQuantidadeFornecedor<T>(T[] vetor, int ind = -1) where T : Produto
    {
        if (vetor == null || vetor.Length == 0)
        {
            return;
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        if (ind != -1)
        {
            Console.WriteLine(vetor[ind]?.ToString() + "\n" + vetor[ind].ObterQuantidadeFornecedor());
        }
        else for (int i = 0; i < vetor.Length; i++)
            {
                Console.WriteLine(vetor[i]?.ToString() + "\n" + vetor[i].ObterQuantidadeFornecedor());
            }
        Console.ResetColor();
    }

    public Endereco LeEndereco()
    {
        String Estado = LerString("Informe o estado: ");
        String Cidade = LerString("Informe a cidade: ");
        String Cep =    LerString("Informe o cep: ");
        String Bairro = LerString("Informe o bairro: ");
        String Rua =    LerString("Informe a rua: ");
        String Numero = LerString("Informe o numero: ");
        String Complemento = LerStringAlterar("Informe o complemento: ");
        return new Endereco(Rua,Numero,Complemento,Bairro,Cep,Cidade,Estado);
    }

    public Endereco LeEnderecoAlterar()
    {
        String Estado = LerStringAlterar("Informe o estado: ");
        String Cidade = LerStringAlterar("Informe a cidade: ");
        String Cep =    LerStringAlterar("Informe o cep: ");
        String Bairro = LerStringAlterar("Informe o bairro: ");
        String Rua =    LerStringAlterar("Informe a rua: ");
        String Numero = LerStringAlterar("Informe o numero: ");
        String Complemento = LerStringAlterar("Informe o complemento: ");
        return new Endereco(Rua,Numero,Complemento,Bairro,Cep,Cidade,Estado);
    }

    public Fornecedor LeFornecedorParaAlterar()
    {
        String Nome = LerStringAlterar("Informe o nome: ");
        String Descricao = LerStringAlterar("Informe a descrição: ");
        String Telefone = LerStringAlterar("Informe o telefone: ");
        String Email = LerStringAlterar("Informe o email: ");
        return new Fornecedor(Nome, Descricao, Telefone, Email, LeEnderecoAlterar());
    }

    //Limpa a tela e deixa a msg do parametro no menu, como cadastro realizado, e apos isso um separador
    //Se nao tiver nada imprime so o separador
    //Caso nao queira nenhum e nem o outro use Console.Clear();
    public void LimparTela(String str = "", ConsoleColor cor = ConsoleColor.White)
    {
        Console.Clear();

        Console.ForegroundColor = cor;

        if (str != "") str += "\n";
        Console.Write(str);

        Console.ResetColor();

        Console.WriteLine("---------------------------");
    }
}
