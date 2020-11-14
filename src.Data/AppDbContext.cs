using Microsoft.EntityFrameworkCore;
using src.Core.Models;
using src.Data.Configurations;
using src.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Tablolar oluşmadan çalışacak methodumuz.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Buradanda tanımlaya bilirdik ama buradaki kod satırlarını daha az tutabilmek ve
            //Best practices için configuration classı oluşturarak entity'nin property'lerini orada tanımladık.
            //modelBuilder.Entity<Product>().Property(x => x.Id).IsRequired();
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}
