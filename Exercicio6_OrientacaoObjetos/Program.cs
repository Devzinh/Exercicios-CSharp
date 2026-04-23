// Exercício 6 – Orientação a Objetos: Sistema Bancário Simples
// Objetivo: Modelar contas bancárias usando classes, encapsulamento e herança.
//           ContaCorrente cobra taxa de saque; ContaPoupança rende juros mensais.

// --- Demonstração ---

Console.WriteLine("=== Sistema Bancário – POO ===\n");

ContaCorrente cc = new("João Silva", 1500.00m);
ContaPoupanca cp = new("Maria Oliveira", 800.00m);

Console.WriteLine(cc);
cc.Depositar(500);
cc.Sacar(200);
Console.WriteLine(cc);

Console.WriteLine();

Console.WriteLine(cp);
cp.Depositar(200);
cp.AplicarRendimentoMensal();
Console.WriteLine(cp);

// ─────────────────────────────────────────────────────────────────────────────
// Classes
// ─────────────────────────────────────────────────────────────────────────────

abstract class ContaBancaria
{
    public string Titular { get; }
    protected decimal Saldo { get; set; }

    protected ContaBancaria(string titular, decimal saldoInicial)
    {
        Titular = titular;
        Saldo = saldoInicial;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do depósito deve ser positivo.");
        Saldo += valor;
        Console.WriteLine($"  Depósito de R$ {valor:F2} realizado. Novo saldo: R$ {Saldo:F2}");
    }

    public virtual void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do saque deve ser positivo.");
        if (valor > Saldo)
            throw new InvalidOperationException("Saldo insuficiente.");
        Saldo -= valor;
        Console.WriteLine($"  Saque de R$ {valor:F2} realizado. Novo saldo: R$ {Saldo:F2}");
    }

    public override string ToString() =>
        $"[{GetType().Name}] Titular: {Titular} | Saldo: R$ {Saldo:F2}";
}

class ContaCorrente : ContaBancaria
{
    private const decimal TaxaSaque = 2.50m;

    public ContaCorrente(string titular, decimal saldoInicial)
        : base(titular, saldoInicial) { }

    public override void Sacar(decimal valor)
    {
        decimal totalDebitado = valor + TaxaSaque;
        if (totalDebitado > Saldo)
            throw new InvalidOperationException("Saldo insuficiente (incluindo taxa de R$ 2,50).");
        Saldo -= totalDebitado;
        Console.WriteLine($"  Saque de R$ {valor:F2} + taxa R$ {TaxaSaque:F2}. Novo saldo: R$ {Saldo:F2}");
    }
}

class ContaPoupanca : ContaBancaria
{
    private const decimal TaxaRendimentoMensal = 0.005m; // 0,5% ao mês

    public ContaPoupanca(string titular, decimal saldoInicial)
        : base(titular, saldoInicial) { }

    public void AplicarRendimentoMensal()
    {
        decimal rendimento = Saldo * TaxaRendimentoMensal;
        Saldo += rendimento;
        Console.WriteLine($"  Rendimento de 0,5% aplicado: +R$ {rendimento:F2}. Novo saldo: R$ {Saldo:F2}");
    }
}
