using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.DTOs
{
    public record CartItemDto
    (
        Guid ProdutoId,
        string NomeProduto,
        decimal Preco,
        int Quantidade
    );
}
