// Exercício 1 – Calculadora Simples
// Objetivo: Ler dois números e uma operação (+, -, *, /) e exibir o resultado.

Console.WriteLine("=== Calculadora Simples ===");

Console.Write("Digite o primeiro número: ");
double a = double.Parse(Console.ReadLine()!);

Console.Write("Digite o segundo número: ");
double b = double.Parse(Console.ReadLine()!);

Console.Write("Escolha a operação (+, -, *, /): ");
string operacao = Console.ReadLine()!.Trim();

double resultado;
switch (operacao)
{
    case "+":
        resultado = a + b;
        Console.WriteLine($"Resultado: {a} + {b} = {resultado}");
        break;
    case "-":
        resultado = a - b;
        Console.WriteLine($"Resultado: {a} - {b} = {resultado}");
        break;
    case "*":
        resultado = a * b;
        Console.WriteLine($"Resultado: {a} * {b} = {resultado}");
        break;
    case "/":
        if (b == 0)
        {
            Console.WriteLine("Erro: divisão por zero não é permitida.");
        }
        else
        {
            resultado = a / b;
            Console.WriteLine($"Resultado: {a} / {b} = {resultado}");
        }
        break;
    default:
        Console.WriteLine("Operação inválida.");
        break;
}
