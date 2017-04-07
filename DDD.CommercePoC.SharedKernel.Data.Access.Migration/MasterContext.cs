using System.Data.Entity;
using DDD.CommercePoC.Shop.Core.Model;

namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration
{
    public class MasterContext : DatabaseContext
    {
        public MasterContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MasterContext, Configuration.DbConfiguration>());
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Variant> Variants { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}