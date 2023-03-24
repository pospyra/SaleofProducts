using Otiva.AppServeces.IRepository;
using Otiva.Domain;
using Otiva.Infrastructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.DataAccess.Repository
{
    public class ItemCartRepository : IItemCartRepository
    {
        public readonly IBaseRepository<ItemShoppingCart> _baseRepository;

        public ItemCartRepository(IBaseRepository<ItemShoppingCart> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Task Add(ItemShoppingCart model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(ItemShoppingCart model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task<ItemShoppingCart> FindByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<ItemShoppingCart> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
