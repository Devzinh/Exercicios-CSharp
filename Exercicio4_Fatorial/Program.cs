// Exercício 4 – Fatorial
// Objetivo: Calcular o fatorial de um número usando recursão e de forma iterativa.

Console.WriteLine("=== Cálculo de Fatorial ===");

Console.Write("Digite um número inteiro não-negativo: ");
int n;
while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
{
    Console.Write("Por favor, digite um número inteiro não-negativo: ");
}

long fatRecursivo = FatorialRecursivo(n);
long fatIterativo = FatorialIterativo(n);

Console.WriteLine($"\n{n}! (recursivo) = {fatRecursivo}");
Console.WriteLine($"{n}! (iterativo) = {fatIterativo}");

// --- Métodos ---

static long FatorialRecursivo(int numero)
{
    if (numero <= 1)
        return 1;
    return numero * FatorialRecursivo(numero - 1);
}

static long FatorialIterativo(int numero)
{
    long resultado = 1;
    for (int i = 2; i <= numero; i++)
        resultado *= i;
    return resultado;
}
