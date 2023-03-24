using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.IRepository
{
    public interface IItemCartRepository
    {
        IQueryable<ItemShoppingCart> GetAll();

        Task Add(ItemShoppingCart model);

        Task DeleteAsync(ItemShoppingCart model);

        Task<ItemShoppingCart> FindByIdAsync(Guid id);
    }
}
