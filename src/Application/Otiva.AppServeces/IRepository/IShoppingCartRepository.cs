using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.IRepository
{
    public interface IShoppingCartRepository
    {
        public Task<ShoppingCart> FindWhere(Expression<Func<ShoppingCart, bool>> predicate);

        public Task CreateShoppingCart(Guid UserId);
    }
}
