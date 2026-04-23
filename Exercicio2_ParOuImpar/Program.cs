// Exercício 2 – Par ou Ímpar
// Objetivo: Ler um número inteiro e informar se é par ou ímpar.
//           Repetir até o usuário digitar 0.

Console.WriteLine("=== Par ou Ímpar ===");
Console.WriteLine("(Digite 0 para sair)");

while (true)
{
    Console.Write("\nDigite um número inteiro: ");
    if (!int.TryParse(Console.ReadLine(), out int numero))
    {
        Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
        continue;
    }

    if (numero == 0)
    {
        Console.WriteLine("Encerrando o programa. Até logo!");
        break;
    }

    string resultado = numero % 2 == 0 ? "PAR" : "ÍMPAR";
    Console.WriteLine($"O número {numero} é {resultado}.");
}
