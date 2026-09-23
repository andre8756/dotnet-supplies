namespace SistemaSuprimentos.Models;

public class Movimentacao
{
    public int ProdutoId { get; }
    public string ProdutoNome { get; }
    public TipoMovimentacao Tipo { get; }
    public int Quantidade { get; }
    public DateTime Data { get; }
    public string Observacao { get; }

    public Movimentacao(
        int produtoId,
        string produtoNome,
        TipoMovimentacao tipo,
        int quantidade,
        string observacao)
    {
        ProdutoId = produtoId;
        ProdutoNome = produtoNome;
        Tipo = tipo;
        Quantidade = quantidade;
        Observacao = observacao;
        Data = DateTime.Now;
    }
}