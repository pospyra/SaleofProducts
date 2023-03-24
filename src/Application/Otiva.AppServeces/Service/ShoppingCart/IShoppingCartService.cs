using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.Service.ShoppingCart
{
    public interface IShoppingCartService
    {
        public Task<Guid> GetCartByCurrentUser(CancellationToken cancellationToken);
    }
}
