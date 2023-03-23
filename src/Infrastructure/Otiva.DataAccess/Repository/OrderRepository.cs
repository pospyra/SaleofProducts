using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public class OrderRepository : IOrderRepository
    {
        public readonly IBaseRepository<Order> _baseRepository;

        public OrderRepository(IBaseRepository<Order> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<Order> FindWhere(Expression<Func<Order, bool>> predicate)
        {
            var data = _baseRepository.GetAllFiltered(predicate);

            return await data.Where(predicate).FirstOrDefaultAsync();
        }

        public Task Add(Order model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(Order ad)
        {
            await _baseRepository.DeleteAsync(ad);
        }

        public async Task EditAdAsync(Order edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<Order> FindByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<Order> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
