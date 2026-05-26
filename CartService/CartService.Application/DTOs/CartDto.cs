using CartService.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CartService.Application.DTOs
{
    public record CartDto(
        Guid Id,
        Guid UserId,
        List<CartItemDto> Items
    );

    public record CriarCartDto(
        Guid UserId,
        List<CartItemDto> Items
    );

    public record AtualizarCartDto(
        List<CartItemDto> Items
    );
}
