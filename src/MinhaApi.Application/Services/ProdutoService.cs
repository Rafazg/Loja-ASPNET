using AutoMapper;
using MinhaApi.Application.DTOs;
using MinhaApi.Application.Interfaces;
using MinhaApi.Domain.Entities;
using MinhaApi.Domain.Exceptions;
using MinhaApi.Domain.Interfaces;

namespace MinhaApi.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public async Task<ProdutoDto?> ObterPorIdAsync(Guid id)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);
        return produto == null ? null : _mapper.Map<ProdutoDto>(produto);
    }

    public async Task<IEnumerable<ProdutoDto>> ObterTodosAsync()
    {
        var produtos = await _produtoRepository.ObterTodosAsync();
        return _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
    }

    public async Task<ProdutoDto> CriarAsync(CriarProdutoDto dto)
    {
        var produto = new Produto(dto.Nome, dto.Descricao, dto.Preco, dto.QuantidadeEstoque);
        await _produtoRepository.AdicionarAsync(produto);
        return _mapper.Map<ProdutoDto>(produto);
    }

    public async Task AtualizarAsync(Guid id, AtualizarProdutoDto dto)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id)
            ?? throw new DomainException("Produto não encontrado");

        produto.Atualizar(dto.Nome, dto.Descricao, dto.Preco, dto.QuantidadeEstoque);
        await _produtoRepository.AtualizarAsync(produto);
    }

    public async Task RemoverAsync(Guid id)
    {
        if (!await _produtoRepository.ExisteAsync(id))
            throw new DomainException("Produto não encontrado");

        await _produtoRepository.RemoverAsync(id);
    }
}