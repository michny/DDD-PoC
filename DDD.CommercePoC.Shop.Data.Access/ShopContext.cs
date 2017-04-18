using System.Data.Entity;
using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.Shop.Core.Model;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;

namespace DDD.CommercePoC.Shop.Data.Access
{
    public class ShopContext : DatabaseContext
    {
        public ShopContext() : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartLineItem> CartLineItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Variant> Variants { get; set; }
        
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Money>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
