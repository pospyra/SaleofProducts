using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.IRepository
{
    public interface ISelectedAdsRepository
    {
        IQueryable<ShoppingCart> GetAll();

        Task Add(ShoppingCart model);

        Task DeleteAsync(ShoppingCart model);

        Task<ShoppingCart> FindByIdAsync(Guid id);
    }
}
