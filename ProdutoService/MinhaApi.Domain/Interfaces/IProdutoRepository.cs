using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<Produto?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task<Produto> AdicionarAsync(Produto produto);
    Task AtualizarAsync(Produto produto);
    Task RemoverAsync(Guid id);
    Task<bool> ExisteAsync(Guid id);
}