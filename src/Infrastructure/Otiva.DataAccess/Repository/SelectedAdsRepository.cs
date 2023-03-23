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
    public class SelectedAdsRepository : ISelectedAdsRepository
    {
        public readonly IBaseRepository<ShoppingCart> _baseRepository;

        public SelectedAdsRepository(IBaseRepository<ShoppingCart> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Task Add(ShoppingCart model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(ShoppingCart model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task<ShoppingCart> FindByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<ShoppingCart> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
