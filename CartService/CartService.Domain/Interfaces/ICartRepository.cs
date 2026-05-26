using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartService.Domain.Entities;

namespace CartService.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetByUserIdAsync(Guid userId);

        Task<Cart> CriarAsync(Cart cart);

        Task AtualizarAsync(Cart cart);

        Task RemoverProdutoAsync(Guid userId, Guid produtoId);

        Task<bool> ExisteAsync(Guid userId);
    }
}
