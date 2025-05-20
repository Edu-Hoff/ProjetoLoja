using System;

Console.WriteLine("Teste");

Console.Write("Digite um número inteiro ppositivo: ");
int numero = LerInteiroPositivoDoConsole();
Console.WriteLine("\nVocê digitou: " + numero);

Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();

int LerInteiroPositivoDoConsole()
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

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("\nEntrada inválida. Valor padrão 0 retornado.");
        return 0;
    }

    return int.Parse(input);
}
