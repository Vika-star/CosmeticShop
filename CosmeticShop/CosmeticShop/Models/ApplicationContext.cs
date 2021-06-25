using CosmeticShop.Models.AuxiliaryEntities;
using CosmeticShop.Models.Products;
using CosmeticShop.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<ProductContainer> ProductContainers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductPictures> ProductPictures { get; set; }
        public DbSet<OrderProductAccounting> OrderProuctAccountings { get; set; }

        public DbSet<OrderToCollect> OrdersToCollect { get; set; }
        public DbSet<OrderToDelivery> OrdersToDelivery { get; set; }



        public ApplicationContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
        
    }
}
