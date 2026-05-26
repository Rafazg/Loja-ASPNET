using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartService.Application.DTOs;

namespace CartService.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartDto?> ObterPorIdAsync(Guid id);
        Task<CartDto> CriarAsync(CriarCartDto dto);
        Task AtualizarAsync(Guid id, AtualizarCartDto dto);
        Task RemoverAsync(Guid id);
    }
}
