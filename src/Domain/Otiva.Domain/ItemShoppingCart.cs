using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.Domain
{
    public class ItemShoppingCart
    {
        public Guid Id { get; set; }

        public Guid ShoppingCartId { get; set; }

        public Guid ProductId { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public Guid? OrderId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
