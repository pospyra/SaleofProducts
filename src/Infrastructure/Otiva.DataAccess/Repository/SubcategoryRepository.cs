﻿using Otiva.AppServeces.IRepository;
using Otiva.Domain;
using Otiva.Infrastructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.DataAccess.Repository
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        public readonly IBaseRepository<Subcategory> _baseRepository;

        public SubcategoryRepository(IBaseRepository<Subcategory> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Task Add(Subcategory model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(Subcategory del)
        {
            await _baseRepository.DeleteAsync(del);
        }

        public async Task EditSubcategoryAsync(Subcategory edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<Subcategory> FindByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<Subcategory> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}

