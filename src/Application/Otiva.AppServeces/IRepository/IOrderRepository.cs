using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> FindByIdAsync(Guid id);

        IQueryable<Order> GetAll();

        Task Add(Order model);

        Task DeleteAsync(Order ad);

        Task EditAdAsync(Order edit);

        public Task<Order> FindWhere(Expression<Func<Order, bool>> predicate);

    }
}
