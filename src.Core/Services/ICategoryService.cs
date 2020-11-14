using src.Core.Models;
using System.Threading.Tasks;

namespace src.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        //Category'e özgü methodlar burada tanımlanacak.
        //Bussines kodlar 
        //Helperlar
        //Genel methodları category ıle ılgılıyse burada tanımlamasını yapacagız.
    }
}
