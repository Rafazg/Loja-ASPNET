using MinhaApi.Application.DTOs;

namespace MinhaApi.Application.Interfaces;

public interface IProdutoService
{
    Task<ProdutoDto?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<ProdutoDto>> ObterTodosAsync();
    Task<ProdutoDto> CriarAsync(CriarProdutoDto dto);
    Task AtualizarAsync(Guid id, AtualizarProdutoDto dto);
    Task RemoverAsync(Guid id);
}