using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Core.Models;

namespace src.Data.Seeds
{
    public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "ELma", Price = 11.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Armut", Price = 20.50m, Stock = 75, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Çilek", Price = 10.0m, Stock = 50, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Ayva", Price = 1.75m, Stock = 200, CategoryId = _ids[0] },
                new Product { Id = 5, Name = "Muz", Price = 110.0m, Stock = 10, CategoryId = _ids[0] },
                new Product { Id = 6, Name = "Bamya", Price = 30.50m, Stock = 25, CategoryId = _ids[1] },
                new Product { Id = 7, Name = "Pırasa", Price = 5.0m, Stock = 17, CategoryId = _ids[1] },
                new Product { Id = 8, Name = "Ispanak", Price = 20.0m, Stock = 88, CategoryId = _ids[1] },
                new Product { Id = 9, Name = "Brokoli", Price = 12.50m, Stock = 122, CategoryId = _ids[1] },
                new Product { Id = 10, Name = "Lahana", Price = 11.0m, Stock = 43, CategoryId = _ids[1] }
                );
        }
    }
}
