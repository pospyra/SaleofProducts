﻿using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.IRepository
{
    public interface ICategoryRepository
    {
        Task<Category> FindById(Guid id);

        IQueryable<Category> GetAll();

        Task AddAsync(Category model);

        Task DeleteAsync(Category model);

        Task EditAdAsync(Category model);
    }
}
