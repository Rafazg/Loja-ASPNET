namespace MinhaApi.Application.DTOs;

public record ProdutoDto(
    Guid Id,
    string Nome,
    string Descricao,
    decimal Preco,
    int QuantidadeEstoque,
    DateTime DataCriacao,
    bool Ativo
);

public record CriarProdutoDto(
    string Nome,
    string Descricao,
    decimal Preco,
    int QuantidadeEstoque
);

public record AtualizarProdutoDto(
    string Nome,
    string Descricao,
    decimal Preco,
    int QuantidadeEstoque
);