using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace src.Core.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        /// <summary>
        /// Id ile Ürün listeleme.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Bütün ürünleri siteleme.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Ürünün Id 'sini bulma.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        //category.SingleOrDefaultAsync(x => x.name = "name") bir tane donecek yada ilk olan sorguyu geri donderecek bize.
        /// <summary>
        /// Bulunan sorgudaki ilk yada bir tane dönderilmesi.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Tek kayıt ekleme.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Çoklu kayıt ekleme.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Tekli silme işlemi.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Çoklu silme işlemi.
        /// </summary>
        /// <param name="entity"></param>
        void RemoveRange(IEnumerable<TEntity> entity);

        /// <summary>
        /// Güncelleme işlemi.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);
    }
}
