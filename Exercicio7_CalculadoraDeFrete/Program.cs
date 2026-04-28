// Exercício 7 – Calculadora de Frete
// Objetivo: Calcular o valor do frete com base no peso do pacote e na distância de entrega.
//           Diferentes faixas de peso e distância aplicam tarifas distintas.

Console.WriteLine("=== Calculadora de Frete ===\n");

// Exemplos de cálculo
var pedidos = new (string Descricao, double PesoKg, double DistanciaKm)[]
{
    ("Livro",          0.5,   50),
    ("Caixa de sapato",2.0,  200),
    ("Eletrodoméstico",15.0, 500),
    ("Palete de carga", 80.0, 1200),
};

foreach (var (descricao, peso, distancia) in pedidos)
{
    decimal frete = CalculadoraFrete.Calcular(peso, distancia);
    Console.WriteLine($"  {descricao,-22} | {peso,6:F1} kg | {distancia,6:F0} km | Frete: R$ {frete:F2}");
}

// ─────────────────────────────────────────────────────────────────────────────
// Lógica de cálculo
// ─────────────────────────────────────────────────────────────────────────────

static class CalculadoraFrete
{
    // Tarifa base por kg segundo faixa de peso
    private static decimal TarifaPorPeso(double pesoKg) => pesoKg switch
    {
        <= 1    => 5.00m,
        <= 5    => 10.00m,
        <= 20   => 15.00m,
        <= 50   => 20.00m,
        _       => 30.00m,
    };

    // Multiplicador de distância
    private static decimal MultiplicadorDistancia(double distanciaKm) => distanciaKm switch
    {
        <= 100  => 1.0m,
        <= 300  => 1.5m,
        <= 600  => 2.0m,
        <= 1000 => 2.8m,
        _       => 3.5m,
    };

    public static decimal Calcular(double pesoKg, double distanciaKm)
    {
        if (pesoKg <= 0)
            throw new ArgumentException("O peso deve ser maior que zero.", nameof(pesoKg));
        if (distanciaKm <= 0)
            throw new ArgumentException("A distância deve ser maior que zero.", nameof(distanciaKm));

        decimal tarifaBase = TarifaPorPeso(pesoKg) * (decimal)pesoKg;
        return tarifaBase * MultiplicadorDistancia(distanciaKm);
    }
}
