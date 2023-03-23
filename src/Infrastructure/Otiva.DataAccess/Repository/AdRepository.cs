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
    public class AdRepository : IAdRepository
    {
        public readonly IBaseRepository<Product> _baseRepository;

        public AdRepository(IBaseRepository<Product> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<Product> FindWhere(Expression<Func<Product, bool>> predicate)
        {
            var data = _baseRepository.GetAllFiltered(predicate);

            return await data.Where(predicate).FirstOrDefaultAsync();
        }

        public Task Add(Product model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(Product ad)
        {
            await _baseRepository.DeleteAsync(ad);
        }

        public async Task EditAdAsync(Product edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<Product> FindByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<Product> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
