using Microsoft.EntityFrameworkCore;
using Otiva.AppServeces.IRepository;
using Otiva.Domain;
using Otiva.Infrastructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.DataAccess.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public readonly IBaseRepository<ShoppingCart> _baseRepository;

        public ShoppingCartRepository(IBaseRepository<ShoppingCart> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task CreateShoppingCart(Guid UserId)
        {
            await _baseRepository.AddAsync(new ShoppingCart {  UserId = UserId });
        }

        public async Task<ShoppingCart> FindWhere(Expression<Func<ShoppingCart, bool>> predicate)
        {
            var data = _baseRepository.GetAllFiltered(predicate);

            return await data.Where(predicate).FirstOrDefaultAsync();
        }
    }
}
