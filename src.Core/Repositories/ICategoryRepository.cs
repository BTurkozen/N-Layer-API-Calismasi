using src.Core.Models;
using System.Threading.Tasks;

namespace src.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        /// <summary>
        /// Alınan id'nin sahip olduğu kategory hemde o kategory'e bağlı ürünler dizi şeklinde döner.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
