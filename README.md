# Exercicios-CSharp

Exercícios realizados para reforçar a prática e a lógica em C#.  
O repositório reúne questões acadêmicas resolvidas e serve como portfólio para recrutadores e material de estudo para quem está aprendendo a linguagem.

---

## 📂 Estrutura

| Pasta | Tema | Conceitos |
|---|---|---|
| `Exercicio1_CalculadoraSimples` | Calculadora Simples | Entrada/saída, `switch`, tipos numéricos |
| `Exercicio2_ParOuImpar` | Par ou Ímpar | Laços `while`, operador módulo `%`, validação de entrada |
| `Exercicio3_Fibonacci` | Sequência de Fibonacci | Laço `for`, variáveis auxiliares |
| `Exercicio4_Fatorial` | Fatorial | Recursão, laço iterativo, `long` |
| `Exercicio5_BubbleSort` | Bubble Sort | Arrays, algoritmo de ordenação, otimização |
| `Exercicio6_OrientacaoObjetos` | Sistema Bancário (POO) | Classes, herança, encapsulamento, polimorfismo |
| `Exercicio7_CalculadoraDeFrete` | Calculadora de Frete | Padrão `switch`, tarifas por faixa, multiplicadores, validação |

---

## 🚀 Como executar

Pré-requisito: [.NET SDK](https://dotnet.microsoft.com/download) instalado.

```bash
# Clone o repositório
git clone https://github.com/Devzinh/Exercicios-CSharp.git
cd Exercicios-CSharp

# Execute um exercício específico
dotnet run --project Exercicio1_CalculadoraSimples

# Ou compile toda a solução de uma vez
dotnet build ExerciciosCSharp.slnx
```

---

## 📝 Exercícios

### 1 – Calculadora Simples
Lê dois números e uma operação (`+`, `-`, `*`, `/`) e exibe o resultado.  
Trata divisão por zero e operações inválidas.

### 2 – Par ou Ímpar
Verifica repetidamente se o número digitado é par ou ímpar.  
Encerra quando o usuário digita `0`.

### 3 – Sequência de Fibonacci
Exibe os **N** primeiros termos da sequência: `0, 1, 1, 2, 3, 5, 8, 13, ...`

### 4 – Fatorial
Calcula o fatorial de N de duas formas:
- **Recursiva** – chamada recursiva até o caso base.
- **Iterativa** – laço `for` acumulador.

### 5 – Bubble Sort
Ordena um vetor de N inteiros em ordem crescente usando Bubble Sort com otimização de parada antecipada.

### 6 – Orientação a Objetos: Sistema Bancário
Modela contas bancárias com herança e polimorfismo:
- **`ContaBancaria`** (abstrata) – depósito, saque, saldo encapsulado.
- **`ContaCorrente`** – cobra taxa de R$ 2,50 por saque.
- **`ContaPoupanca`** – aplica rendimento mensal de 0,5%.

### 7 – Calculadora de Frete
Calcula o valor do frete com base na cidade de origem e destino, utilizando geolocalização via Nominatim e cálculo de rota via OSRM.  
Também considera o tipo de veículo e a forma de pagamento:

- **Tipos de veículo e preço por km:**
  - Carro → R$ 0,50/km
  - Moto → R$ 0,30/km
  - Caminhão → R$ 1,00/km
- **Pagamento com desconto:**
  - PIX ou dinheiro → 10% de desconto
- **Cálculo:** Tarifa final = (Preço por km × distância) - desconto
