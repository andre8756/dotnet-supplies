using SistemaSuprimentos.Models;
using SistemaSuprimentos.Services;

Estoque estoque = new();
Inventario inventario = new();

while (true)
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("     SISTEMA DE SUPRIMENTOS");
    Console.WriteLine("=================================");
    Console.WriteLine("1 - Cadastrar produto");
    Console.WriteLine("2 - Listar estoque");
    Console.WriteLine("3 - Registrar entrada");
    Console.WriteLine("4 - Registrar saída");
    Console.WriteLine("5 - Realizar inventário");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("=================================");

    Console.Write("Escolha uma opção: ");
    string? opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                CadastrarProduto(estoque);
                break;

            case "2":
                ListarEstoque(estoque);
                break;

            case "3":
                RegistrarEntrada(estoque);
                break;

            case "4":
                RegistrarSaida(estoque);
                break;

            case "5":
                RealizarInventario(estoque, inventario);
                break;

            case "0":
                Console.WriteLine("Encerrando sistema...");
                return;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"ERRO: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Pressione ENTER para continuar...");
    Console.ReadLine();
}

static void CadastrarProduto(Estoque estoque)
{
    Console.Clear();

    Console.WriteLine("=== CADASTRO DE PRODUTO ===");

    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? "";

    Console.Write("Unidade (UN, CX, KG...): ");
    string unidade = Console.ReadLine() ?? "";

    Console.Write("Estoque mínimo: ");
    int estoqueMinimo = int.Parse(Console.ReadLine() ?? "0");

    Produto produto = estoque.CadastrarProduto(
        nome,
        unidade,
        estoqueMinimo
    );

    Console.WriteLine();
    Console.WriteLine(
        $"Produto cadastrado com sucesso! ID: {produto.Id}"
    );
}

static void ListarEstoque(Estoque estoque)
{
    Console.Clear();

    Console.WriteLine("=== ESTOQUE ===");

    if (estoque.Produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    foreach (Produto produto in estoque.Produtos)
    {
        string status = produto.EstoqueBaixo
            ? "ESTOQUE BAIXO"
            : "OK";

        Console.WriteLine(
            $"ID: {produto.Id} | " +
            $"Produto: {produto.Nome} | " +
            $"Qtd: {produto.QuantidadeEmEstoque} {produto.Unidade} | " +
            $"Mínimo: {produto.EstoqueMinimo} | " +
            $"Status: {status}"
        );
    }
}

static void RegistrarEntrada(Estoque estoque)
{
    Console.Clear();

    Console.WriteLine("=== ENTRADA DE ESTOQUE ===");

    Console.Write("ID do produto: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Quantidade: ");
    int quantidade = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Observação: ");
    string observacao = Console.ReadLine() ?? "";

    estoque.RegistrarEntrada(
        id,
        quantidade,
        observacao
    );

    Console.WriteLine();
    Console.WriteLine("Entrada registrada com sucesso.");
}

static void RegistrarSaida(Estoque estoque)
{
    Console.Clear();

    Console.WriteLine("=== SAÍDA DE ESTOQUE ===");

    Console.Write("ID do produto: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Quantidade: ");
    int quantidade = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Observação: ");
    string observacao = Console.ReadLine() ?? "";

    estoque.RegistrarSaida(
        id,
        quantidade,
        observacao
    );

    Console.WriteLine();
    Console.WriteLine("Saída registrada com sucesso.");
}

static void RealizarInventario(
    Estoque estoque,
    Inventario inventario)
{
    Console.Clear();

    Console.WriteLine("=== INVENTÁRIO ===");

    if (estoque.Produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    foreach (Produto produto in estoque.Produtos)
    {
        Console.WriteLine();
        Console.WriteLine($"Produto: {produto.Nome}");
        Console.WriteLine(
            $"Quantidade no sistema: {produto.QuantidadeEmEstoque}"
        );

        Console.Write("Quantidade encontrada fisicamente: ");
        int quantidadeContada =
            int.Parse(Console.ReadLine() ?? "0");

        ResultadoInventario resultado =
            inventario.Conferir(
                produto,
                quantidadeContada
            );

        Console.WriteLine(
            $"Diferença: {resultado.Diferenca}"
        );

        if (resultado.PossuiDivergencia)
        {
            Console.WriteLine("ATENÇÃO: existe divergência.");
        }
        else
        {
            Console.WriteLine("OK: estoque conferido.");
        }
    }
}