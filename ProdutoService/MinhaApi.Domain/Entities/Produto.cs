namespace MinhaApi.Domain.Entities;

public class Produto
{
    public Guid Id { get; private set; }
    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public decimal? Preco { get; private set; }
    public int? QuantidadeEstoque { get; private set; }
    public DateTime? DataCriacao { get; private set; }
    public bool Ativo { get; private set; }

    // Construtor protegido para EF
    protected Produto() { }

    public Produto(string nome, string descricao, decimal preco, int quantidadeEstoque)
    {
        Id = Guid.NewGuid();
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
        Preco = preco > 0 ? preco : throw new ArgumentException("Preço deve ser maior que zero");
        QuantidadeEstoque = quantidadeEstoque >= 0 ? quantidadeEstoque : throw new ArgumentException("Estoque não pode ser negativo");
        DataCriacao = DateTime.UtcNow;
        Ativo = true;
    }

    public void Atualizar(string nome, string descricao, decimal preco, int quantidadeEstoque)
    {
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
        Preco = preco > 0 ? preco : throw new ArgumentException("Preço deve ser maior que zero");
        QuantidadeEstoque = quantidadeEstoque >= 0 ? quantidadeEstoque : throw new ArgumentException("Estoque não pode ser negativo");
    }

    public void Desativar() => Ativo = false;
    public void Ativar() => Ativo = true;
}