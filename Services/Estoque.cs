using SistemaSuprimentos.Models;

namespace SistemaSuprimentos.Services;

public class Estoque
{
    private readonly List<Produto> _produtos = new();
    private readonly List<Movimentacao> _movimentacoes = new();

    private int _proximoId = 1;

    public IReadOnlyList<Produto> Produtos => _produtos;
    public IReadOnlyList<Movimentacao> Movimentacoes => _movimentacoes;

    public Produto CadastrarProduto(
        string nome,
        string unidade,
        int estoqueMinimo)
    {
        Produto produto = new Produto(
            _proximoId,
            nome,
            unidade,
            estoqueMinimo
        );

        _produtos.Add(produto);

        _proximoId++;

        return produto;
    }

    public Produto BuscarProduto(int id)
    {
        Produto? produto = _produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
            throw new InvalidOperationException(
                "Produto não encontrado."
            );

        return produto;
    }

    public void RegistrarEntrada(
        int produtoId,
        int quantidade,
        string observacao)
    {
        Produto produto = BuscarProduto(produtoId);

        produto.AdicionarEstoque(quantidade);

        Movimentacao movimentacao = new Movimentacao(
            produto.Id,
            produto.Nome,
            TipoMovimentacao.Entrada,
            quantidade,
            observacao
        );

        _movimentacoes.Add(movimentacao);
    }

    public void RegistrarSaida(
        int produtoId,
        int quantidade,
        string observacao)
    {
        Produto produto = BuscarProduto(produtoId);

        produto.RemoverEstoque(quantidade);

        Movimentacao movimentacao = new Movimentacao(
            produto.Id,
            produto.Nome,
            TipoMovimentacao.Saida,
            quantidade,
            observacao
        );

        _movimentacoes.Add(movimentacao);
    }
}