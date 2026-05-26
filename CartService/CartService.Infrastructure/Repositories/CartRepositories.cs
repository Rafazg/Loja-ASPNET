using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartService.Domain.Interfaces;

namespace CartService.Infrastructure.Repositories
{
    private readonly AppDbContext _context;
    internal class CartRepositories : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepositories(AppDbContext context)
        {
            _context = context;
        }
    }
}
