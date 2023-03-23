using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.IRepository
{
    public interface IAdRepository
    {
        /// <summary>
        /// Найти объявление по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> FindByIdAsync(Guid id);

        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <returns></returns>
        IQueryable<Product> GetAll();

        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="model">Модель объявления</param>
        /// <returns></returns>
        Task Add(Product model);

        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="ad">Модель объявления</param>
        /// <returns></returns>
        Task DeleteAsync(Product ad);

        /// <summary>
        /// Редактировать объявление
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        Task EditAdAsync(Product edit);
        public Task<Product> FindWhere(Expression<Func<Product, bool>> predicate);

    }
}
