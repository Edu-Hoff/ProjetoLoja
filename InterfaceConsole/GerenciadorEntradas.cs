using System;

namespace InterfaceConsole;

public class GerenciadorEntradas
{
    public GerenciadorEntradas() { }

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
    public String LerString(String msg)
    {
        Console.Write(msg);
        String str;
        do
        {
            str = Console.ReadLine() ?? "";
        } while (str == "");
        return str;
    }
}
