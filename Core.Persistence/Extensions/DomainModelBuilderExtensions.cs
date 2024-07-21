using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Extensions
{
    public static class DomainModelBuilderExtensions
    {
        public static ModelBuilder DomainEntitiesModelBuilding(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(c => c.Id);
                p.HasOne(c => c.Category).WithMany(c=>c.Products);
            });

            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(o => o.Id);
                c.HasMany(o => o.Products).WithOne(o=>o.Category);
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(c => c.Id);
                o.HasOne(c => c.OrderDetails).WithOne(c=>c.Order);
                o.HasMany(c => c.Products);
            });

            modelBuilder.Entity<OrderDetails>(o =>
            {
                o.HasKey(c => c.Id);
            });
            
            // Seed Data . . . 

            return modelBuilder;
        }
    }
}
