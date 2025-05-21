using System;

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

    public void LimparTela(String str = "")
    {
        Console.Clear();
        if (str != "") str += "\n";
        Console.Write(str);
        Console.WriteLine("---------------------------");
    }
}
