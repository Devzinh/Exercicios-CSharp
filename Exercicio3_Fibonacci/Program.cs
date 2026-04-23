// Exercício 3 – Sequência de Fibonacci
// Objetivo: Exibir os N primeiros termos da sequência de Fibonacci.
//           A sequência começa: 0, 1, 1, 2, 3, 5, 8, 13, ...

Console.WriteLine("=== Sequência de Fibonacci ===");

Console.Write("Quantos termos deseja exibir? ");
int n;
while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
{
    Console.Write("Por favor, digite um número inteiro positivo: ");
}

Console.Write("Sequência: ");

long anterior = 0;
long atual = 1;

for (int i = 0; i < n; i++)
{
    Console.Write(anterior);
    if (i < n - 1)
        Console.Write(", ");

    long proximo = anterior + atual;
    anterior = atual;
    atual = proximo;
}

Console.WriteLine();
