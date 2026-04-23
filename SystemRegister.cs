//Questão: Crie um programa em C# que permita cadastrar funcionários, armazenando seus nomes e senhas. O programa deve permitir que os funcionários acessem o sistema, verificando se o nome e a senha correspondem aos dados cadastrados. Além disso, o programa deve salvar os dados dos funcionários em um arquivo de texto para persistência.

// ----------------------------------------------------------
// --> Sistema de cadastro de funcionários <--
// --> Sistema de controle de acesso para funcionários <--
// ----------------------------------------------------------

// bibliotecas necessárias
using System;
using System.Collections.Generic;
using System.IO;

// Listas para armazenar os nomes e senhas dos funcionários
List<string> nomeFuncionarios = new List<string>();
List<string> senhasDosFuncionarios = new List<string>();

// Cadastro de funcionários
Console.WriteLine("Bem-vindo ao sistema de cadastro de funcionários!");
Console.WriteLine("Digite o nome do funcionário:");
string nomeFuncionario = Console.ReadLine();
nomeFuncionarios.Add(nomeFuncionario);
Console.WriteLine("Digite a senha do funcionário:");
string senhaFuncionario = Console.ReadLine();
senhasDosFuncionarios.Add(senhaFuncionario);
Console.WriteLine("Funcionário cadastrado com sucesso!");

//Salvar os dados dos funcionários em um arquivo de texto
string caminhoArquivo = "funcionarios.txt";
StreamWriter escritor = new StreamWriter(caminhoArquivo);
for (int i = 0; i < nomeFuncionarios.Count; i++)
{
    escritor.WriteLine($"Usuário: {nomeFuncionarios[i]}, Senha: {senhasDosFuncionarios[i]}");
}
escritor.Close();

// Acesso ao sistema
Console.WriteLine("Digite o nome do funcionário para acessar o sistema:");
string nomeFuncionarioAcesso = Console.ReadLine();
Console.WriteLine("Digite a senha do funcionário para acessar o sistema:");
string senhaFuncionarioAcesso = Console.ReadLine();

// Verificar se o funcionário existe e a senha está correta
if (nomeFuncionarios.Contains(nomeFuncionarioAcesso))
{
    int index = nomeFuncionarios.IndexOf(nomeFuncionarioAcesso);
    if (senhasDosFuncionarios[index] == senhaFuncionarioAcesso)
    {
        Console.WriteLine("Acesso concedido! Bem-vindo, " + nomeFuncionarioAcesso + "!");
    }
    else
    {
        Console.WriteLine("Senha incorreta! Acesso negado.");
    }
}
else
{
    Console.WriteLine("Funcionário não encontrado! Acesso negado.");
}
