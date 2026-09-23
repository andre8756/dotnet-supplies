namespace SistemaSuprimentos.Models;

public class ResultadoInventario
{
    public Produto Produto { get; }
    public int QuantidadeSistema { get; }
    public int QuantidadeContada { get; }

    public int Diferenca =>
        QuantidadeContada - QuantidadeSistema;

    public bool PossuiDivergencia =>
        Diferenca != 0;

    public ResultadoInventario(
        Produto produto,
        int quantidadeContada)
    {
        Produto = produto;
        QuantidadeSistema = produto.QuantidadeEmEstoque;
        QuantidadeContada = quantidadeContada;
    }
}