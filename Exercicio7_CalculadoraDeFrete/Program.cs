// Desafio: Uma empresa de transporte tem 3 tipos de veículos: carro, moto e caminhão. O preço do frete é calculado com base no tipo de veículo e na distância percorrida. O preço por km para cada tipo de veículo é o seguinte: carro - R$ 0,50, moto - R$ 0,30, caminhão - R$ 1,00. Escreva um programa em C# que solicite ao usuário o tipo de veículo e a distância percorrida, e então calcule e exiba o preço do frete.

// Lógica de programação que foi usada para aplicar nesse desafio:
// 1. Solicitar ao usuário a cidade de origem e destino.
// 2. Usar uma API de geolocalização (como Nominatim) para obter as coordenadas de origem e destino.
// 3. Usar uma API de roteamento (como OSRM) para calcular a distância dirigindo entre as coordenadas.
// 4. Solicitar ao usuário o tipo de veículo e a forma de pagamento. (PIX, cartão, dinheiro)
// 5. Calcular o preço do frete com base na distância e no tipo de veículo, aplicando um desconto de 10% para pagamentos via PIX ou dinheiro.
// 6. Exibir o preço do frete calculado.

using System;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

class FreteCalculator
{
    static async Task Main(string[] args)
    {
        var veiculoDisponivel = new string[] { "carro", "moto", "caminhão" };
        var precoPorKm = new double[] { 0.50, 0.30, 1.00 };

        Console.WriteLine("Qual é a cidade de origem? (Ex: São Paulo)");
        var origem = Console.ReadLine();

        Console.WriteLine("Qual é a cidade de destino? (Ex: Rio de Janeiro)");
        var destino = Console.ReadLine();

        Console.WriteLine("\nCalculando distância na internet... Por favor, aguarde.");
        
        double distanciaKm = await CalcularDistanciaApi(origem, destino);
        
        if (distanciaKm == 0)
        {
            Console.WriteLine("Não foi possível calcular a rota. Verifique os nomes das cidades ou a conexão.");
            return;
        }

        Console.WriteLine($"A distância percorrida será de aproximadamente {distanciaKm:F2} km.\n");

        Console.WriteLine("Qual é o tipo de veículo? (carro, moto, caminhão)");
        var tipoVeiculo = Console.ReadLine();
        
        var indexVeiculo = Array.IndexOf(veiculoDisponivel, tipoVeiculo);
        if (indexVeiculo == -1)
        {
            Console.WriteLine("Tipo de veículo inválido.");
            return;
        }

        Console.WriteLine("Qual a forma de pagamento? (PIX, cartão, dinheiro)");
        var formaPagamento = Console.ReadLine();

        double precoFrete = precoPorKm[indexVeiculo] * distanciaKm;

        if (formaPagamento == "PIX" || formaPagamento == "dinheiro" || formaPagamento == "Dinheiro")
        {
            Console.WriteLine("O pagamento via PIX ou dinheiro tem um desconto de 10%.");
            precoFrete -= precoFrete * 0.10;
        }

        Console.WriteLine($"\nO preço final do frete é: R$ {precoFrete:F2}");
    }

    /// Essa função consulta a API do Nominatim para obter as coordenadas de origem e destino, e depois usa a API do OSRM para calcular a distância dirigindo entre esses pontos
    static async Task<double> CalcularDistanciaApi(string origem, string destino)
    {
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "FreteApp/1.0 (Estudo C#)");

            // 1. Busca coordenadas da Origem (Nominatim)
            var urlOrigem = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(origem)}&format=json&limit=1";
            var jsonOrigemStr = await client.GetStringAsync(urlOrigem);
            var jsonOrigem = JsonNode.Parse(jsonOrigemStr);
            
            if (jsonOrigem == null || jsonOrigem.AsArray().Count == 0) return 0;
            var lonOrigem = jsonOrigem[0]["lon"].ToString();
            var latOrigem = jsonOrigem[0]["lat"].ToString();

            await Task.Delay(1000);
            
            // 2. Busca coordenadas do Destino (Nominatim)
            var urlDestino = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(destino)}&format=json&limit=1";
            var jsonDestinoStr = await client.GetStringAsync(urlDestino);
            var jsonDestino = JsonNode.Parse(jsonDestinoStr);
            
            if (jsonDestino == null || jsonDestino.AsArray().Count == 0) return 0;
            var lonDestino = jsonDestino[0]["lon"].ToString();
            var latDestino = jsonDestino[0]["lat"].ToString();

            // 3. Calcula a rota e distância entre as coordenadas (OSRM)
            var urlRota = $"https://router.project-osrm.org/route/v1/driving/{lonOrigem},{latOrigem};{lonDestino},{latDestino}?overview=false";
            var jsonRotaStr = await client.GetStringAsync(urlRota);
            var jsonRota = JsonNode.Parse(jsonRotaStr);

            if (jsonRota != null && jsonRota["routes"] != null && jsonRota["routes"].AsArray().Count > 0) // Calcula da distância em metros e convertendo para km
            {
                var distanciaMetros = (double)jsonRota["routes"][0]["distance"];
                return distanciaMetros / 1000.0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro ao tentar acessar a API: {ex.Message}");
        }

        return 0;
    }
}
