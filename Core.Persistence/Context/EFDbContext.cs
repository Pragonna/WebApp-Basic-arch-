

using Core.Domain.Entities;
using Core.Persistence.Extensions;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Persistence.Context
{
    public class EFDbContext (IConfiguration configuration): DbContext
    {
        const string SQL = "Sql";
        public DbSet<Product>Products { get; set; }
        public DbSet<Order>Orders{ get; set; }
        public DbSet<OrderDetails>OrderDetails{ get; set; }
        public DbSet<Category>Categories{ get; set; }

        // Entities authentication
        public DbSet<User> Users{ get; set; }
        public DbSet<OperationClaim>OperationClaims { get; set; }
        public DbSet<UserOperationClaim>UserOperationClaims { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(SQL));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.DomainEntitiesModelBuilding();
            modelBuilder.AuthenticationModelBuilding(configuration);
        }
    }
}
