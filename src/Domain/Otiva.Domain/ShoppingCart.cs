﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public List<ItemShoppingCart> ItemShoppingCarts { get; set; } = new List<ItemShoppingCart>();

        public User User { get; set; }
    }
}
