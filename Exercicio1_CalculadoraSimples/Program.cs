// Exercício 1 – Calculadora Simples
// Objetivo: Ler dois números e uma operação (+, -, *, /) e exibir o resultado.

Console.WriteLine("=== Calculadora Simples ===");

Console.Write("Digite o primeiro número: ");
double a;
while (!double.TryParse(Console.ReadLine(), out a))
{
    Console.Write("Entrada inválida. Digite um número: ");
}

Console.Write("Digite o segundo número: ");
double b;
while (!double.TryParse(Console.ReadLine(), out b))
{
    Console.Write("Entrada inválida. Digite um número: ");
}

Console.Write("Escolha a operação (+, -, *, /): ");
string operacao = Console.ReadLine()!.Trim();

switch (operacao)
{
    case "+":
        Console.WriteLine($"Resultado: {a} + {b} = {a + b}");
        break;
    case "-":
        Console.WriteLine($"Resultado: {a} - {b} = {a - b}");
        break;
    case "*":
        Console.WriteLine($"Resultado: {a} * {b} = {a * b}");
        break;
    case "/":
        if (b == 0)
        {
            Console.WriteLine("Erro: divisão por zero não é permitida.");
        }
        else
        {
            Console.WriteLine($"Resultado: {a} / {b} = {a / b}");
        }
        break;
    default:
        Console.WriteLine("Operação inválida.");
        break;
}
