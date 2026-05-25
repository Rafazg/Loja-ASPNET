using Microsoft.AspNetCore.Mvc;
using MinhaApi.Application.DTOs;
using MinhaApi.Application.Interfaces;
using MinhaApi.Domain.Exceptions;

namespace MinhaApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> ObterTodos()
    {
        var produtos = await _produtoService.ObterTodosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProdutoDto>> ObterPorId(Guid id)
    {
        var produto = await _produtoService.ObterPorIdAsync(id);
        return produto == null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoDto>> Criar([FromBody] CriarProdutoDto dto)
    {
        try
        {
            var produto = await _produtoService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = produto.Id }, produto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarProdutoDto dto)
    {
        try
        {
            await _produtoService.AtualizarAsync(id, dto);
            return NoContent();
        }
        catch (DomainException ex)
        {
            return NotFound(new { erro = ex.Message });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        try
        {
            await _produtoService.RemoverAsync(id);
            return NoContent();
        }
        catch (DomainException ex)
        {
            return NotFound(new { erro = ex.Message });
        }
    }
}