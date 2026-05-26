using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Domain.Entities
{
     public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Construtor público para EF
        public Cart() { }
        public Cart(Guid id, Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Items = new List<CartItem>();
        }
    }

}
