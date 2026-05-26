using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartService.Application.Interfaces;
using CartService.Application.DTOs;
using CartService.Domain.Interfaces;
using CartService.Domain.Entities;

namespace CartService.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartDto?> ObterPorIdAsync(Guid id)
        {
            var cart = await _cartRepository.GetByUserIdAsync(id);
            throw new NotImplementedException();
        }


        public async Task<CartDto> CriarAsync(CriarCartDto dto)
        {
            var cartEntity = new Cart
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                Items = dto.Items.Select(Item => new CartItem
                {
                    Id = Guid.NewGuid(),
                    ProdutoId = Item.ProdutoId,
                    NomeProduto = Item.NomeProduto,
                    Preco = Item.Preco,
                    Quantidade = Item.Quantidade
                }).ToList()
            };

            var cartCriado = await _cartRepository.CriarAsync(cartEntity);

            return new CartDto(
                cartCriado.Id,
                cartCriado.UserId,
                cartCriado.Items.Select(item => new CartItemDto(
                    item.ProdutoId,
                    item.NomeProduto,
                    item.Preco,
                    item.Quantidade
                    )).ToList()
            );
        }

        public async Task AtualizarAsync(Guid id, AtualizarCartDto dto)
        {
            var cart = await _cartRepository.GetByUserIdAsync(id) ?? throw new Exception("Carrinho não encontrado");

            cart.Items = dto.Items.Select(item => new CartItem
            {
                Id = Guid.NewGuid(),
                ProdutoId = item.ProdutoId,
                NomeProduto = item.NomeProduto,
                Preco = item.Preco,
                Quantidade = item.Quantidade
            }).ToList();

            await _cartRepository.AtualizarAsync(cart);
        }

        public async Task RemoverAsync(Guid id)
        {
            if (!await _cartRepository.ExisteAsync(id))
                throw new Exception("Carrinho não encontrado");

            await _cartRepository.RemoverProdutoAsync(id, id);
        }
    }
}