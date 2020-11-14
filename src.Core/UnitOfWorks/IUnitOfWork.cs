using src.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {

        //Best practise uygun olması açısından yapılmıştır.
        /// <summary>
        /// Product'a direk referance olarak oluşturuldu.
        /// </summary>
        IProductRepository Products { get; }

        /// <summary>
        /// Category'ye direk referance olarak oluşturuldu.
        /// </summary>
        ICategoryRepository Categories { get; }

        /// <summary>
        /// SaveChange() methodunu çağırır.
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
        void commit();
    }
}
