using System;
using Entidades;

namespace InterfaceConsole;

public class GerenciadorEntradasSaidas
{
    public GerenciadorEntradasSaidas() { }

    //Le inteiro sem chance de outros caracteres
    public int LerIntConsole()
    {
        string input = "";
        ConsoleKeyInfo tecla;

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

        if (string.IsNullOrEmpty(input))
        {
            return 1000;
        }

        return int.Parse(input);
    }

    public double LerDoubleConsole()
    {
        string input = "";
        ConsoleKeyInfo tecla;
        bool jaTemSeparadorDecimal = false;

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

        if (string.IsNullOrWhiteSpace(input))
            return 0.0;

        return double.Parse(input);
    }

//  Obrigatoriamente deve ser digitado algo 
    public String LerString(String msg)
    {
        Console.Write(msg);
        String str;
        do
        {
            str = Console.ReadLine() ?? "";
        } while (string.IsNullOrWhiteSpace(str));
        return str;
    }

//  Retorna vazio se so der enter ou so ter espacos
    public String LerStringAlterar(String msg)
    {
        Console.Write(msg);
        String str = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(str))
            return "";
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
    public void EscreveVetor<T>(T[] vetor)
    {
        if (vetor == null || vetor.Length == 0)
        {
            return;
        }
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.WriteLine(vetor[i]?.ToString());
        }
    }

    //Usar so com fornecedores e clientes
    public void EscreveVetorComEndereco<T>(T[] vetor) where T : IHasEndereco
    {
        if (vetor == null || vetor.Length == 0)
        {
            return;
        }
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.WriteLine(vetor[i]?.ToString() + "/n" + vetor[i].Endereco.ObterEndereco());
        }
    }

    //Usar so com fornecedores e clientes
    public void EscreveVetorComQuantidadeFornecedor<T>(T[] vetor) where T : Produto
    {
        if (vetor == null || vetor.Length == 0)
        {
            return;
        }
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.WriteLine(vetor[i]?.ToString() + "/n" + vetor[i].ObterQuantidadeFornecedor());
        }
    }

    //Limpa a tela e deixa a msg do parametro no menu, como cadastro realizado, e apos isso um separador
    //Se nao tiver nada imprime so o separador
    //Caso nao queira nenhum e nem o outro use Console.Clear();
    public void LimparTela(String str = "")
    {
        Console.Clear();
        if (str != "") str += "\n";
        Console.Write(str);
        Console.WriteLine("---------------------------");
    }
}
