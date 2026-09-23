namespace SistemaSuprimentos.Models;

public class Produto
{
    public int Id { get; }
    public string Nome { get; private set; }
    public string Unidade { get; private set; }
    public int EstoqueMinimo { get; private set; }
    public int QuantidadeEmEstoque { get; private set; }

    public bool EsotqueBaixo => QuantidadeEmEstoque <= EstoqueMinimo;

    public Produto(
        int id,
        string nome,
        string unidade,
        int estoqueMinimo)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do produto é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(unidade))
        {
            throw new ArgumentException("A unidade do grupo é obrigatória.");
        }

        if (estoqueMinimo < 0)
        {
            throw new ArgumentException("O estoque mínimo não pode ser negativo.");
        }

        Id = id;
        Nome = nome;
        Unidade = unidade;
        EstoqueMinimo = estoqueMinimo;
        QuantidadeEmEstoque = 0;
    }

    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        }

        QuantidadeEmEstoque += quantidade;
    }

    public void RemoverEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        if (quantidade > QuantidadeEmEstoque)
            throw new InvalidOperationException(
                "Estoque insuficiente para realizar a saída."
            );

        QuantidadeEmEstoque -= quantidade;
    }
}