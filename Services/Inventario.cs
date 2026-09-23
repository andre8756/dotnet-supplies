using SistemaSuprimentos.Models;

namespace SistemaSuprimentos.Services;

public class Inventario
{
    public ResultadoInventario Conferir(
        Produto produto,
        int quantidadeContada)
    {
        if (quantidadeContada < 0)
            throw new ArgumentException(
                "A quantidade contada não pode ser negativa."
            );

        return new ResultadoInventario(
            produto,
            quantidadeContada
        );
    }
}