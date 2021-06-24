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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderHistory>()
                .HasOne(e => e.User)
                .WithOne(e => e.OrderHistory)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(e => e.User)
                .WithOne(e => e.Order)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Order>()
                .HasOne(e => e.OrderHistory)
                .WithMany(e => e.Orders)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(e => e.PersonalData)
                .WithOne(e=>e.Order)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(e => e.OrdersToCollect)
                .WithOne(e => e.Order)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Order>()
                .HasOne(e => e.OrdersToDelivery)
                .WithOne(e => e.Order)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderProductAccounting>()
                .HasOne(e => e.Order)
                .WithMany(e => e.OrderProuctAccountings)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderProductAccounting>()
                .HasOne(e => e.ProductContainer)
                .WithMany(e => e.OrderProuctAccountings)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Picture>()
                .HasOne(e => e.ProductPictures)
                .WithMany(e => e.Pictures)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
