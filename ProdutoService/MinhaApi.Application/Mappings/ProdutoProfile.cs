using AutoMapper;
using MinhaApi.Application.DTOs;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Application.Mappings;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto, ProdutoDto>();
    }
}