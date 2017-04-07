using System.Data.Entity;
using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.Shop.Core.Model;

namespace DDD.CommercePoC.Shop.Data.Access
{
    public class ShopContext : DatabaseContext
    {
        public ShopContext() : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Variant> Variants { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
    }
}
