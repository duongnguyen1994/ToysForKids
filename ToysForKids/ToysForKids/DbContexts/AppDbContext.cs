using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.Entities;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.DbContexts
{
    public class AppDbContext : IdentityDbContext<AppIdentityUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public IEnumerable<UserViewModel> AppIdentityUser { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
            builder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Tank"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Car"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Aircraft"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Destroyer"
                });
            builder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "M1917",
                    Description = "USA-World War 1",
                    QuantityPerUnit = 20,
                    UnitInStock = 20,
                    UnitPrice = 120000,
                    FileAvatarName = "M1917.jpg"
                },
                new Product()
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "M1918",
                    Description = "USA-World War 1",
                    QuantityPerUnit = 20,
                    UnitInStock = 20,
                    UnitPrice = 150000,
                    FileAvatarName = "M1918.jpg"
                },
                new Product()
                {
                    ProductId = 3,
                    CategoryId = 2,
                    ProductName = "RADCLO RC Car 2.4Ghz 1/20",
                    Description = "Made in China",
                    QuantityPerUnit = 20,
                    UnitInStock = 20,
                    UnitPrice = 120000,
                    FileAvatarName = "RADCLO_RC_Car.jpg"
                },
                new Product()
                {
                    ProductId = 4,
                    CategoryId = 3,
                    ProductName = "Airforce 1",
                    Description = "USA",
                    QuantityPerUnit = 20,
                    UnitInStock = 20,
                    UnitPrice = 220000,
                    FileAvatarName = "Airforce 1.jpg"
                });
        }
    }
}
