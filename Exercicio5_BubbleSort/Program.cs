// Exercício 5 – Ordenação: Bubble Sort
// Objetivo: Ler N números inteiros e ordená-los em ordem crescente usando Bubble Sort.

Console.WriteLine("=== Bubble Sort ===");

Console.Write("Quantos números deseja ordenar? ");
int n;
while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
{
    Console.Write("Por favor, digite um número inteiro positivo: ");
}

int[] numeros = new int[n];

for (int i = 0; i < n; i++)
{
    Console.Write($"Digite o número {i + 1}: ");
    while (!int.TryParse(Console.ReadLine(), out numeros[i]))
    {
        Console.Write("Entrada inválida. Digite um número inteiro: ");
    }
}

Console.WriteLine($"\nAntes da ordenação: [{string.Join(", ", numeros)}]");

BubbleSort(numeros);

Console.WriteLine($"Após a ordenação:   [{string.Join(", ", numeros)}]");

// --- Método ---

static void BubbleSort(int[] arr)
{
    int tamanho = arr.Length;
    for (int i = 0; i < tamanho - 1; i++)
    {
        bool trocou = false;
        for (int j = 0; j < tamanho - 1 - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                trocou = true;
            }
        }
        // Otimização: se nenhuma troca ocorreu, o vetor já está ordenado
        if (!trocou)
            break;
    }
}
