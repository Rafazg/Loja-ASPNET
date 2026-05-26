using AutoMapper;
using CartService.Application.DTOs;
using CartService.Domain.Entities;

namespace CartService.Application.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            // Entity -> DTO
            CreateMap<Cart, CartDto>();
            CreateMap<CartItem, CartItemDto>();

            // DTO -> Entity
            CreateMap<CartItemDto, CartItem>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<CriarCartDto, Cart>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<AtualizarCartDto, Cart>();
        }
    }
}