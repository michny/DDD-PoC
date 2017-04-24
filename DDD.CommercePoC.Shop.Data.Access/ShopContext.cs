using System.Data.Entity;
using System.Linq;
using Castle.Core.Internal;
using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.SharedKernel.Enums;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Model;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.OrderAggregate;
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

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Money>();
            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //Ensures that all elements of type ITrackable that have been marked as deleted via the TrackingState property are deleted.
            var deletedEntries = ChangeTracker.Entries().Where(e => e.Entity is ITrackable trackable && trackable.TrackingState == TrackingState.Deleted);
            deletedEntries.ForEach(entry => entry.State = EntityState.Deleted);

            return base.SaveChanges();
        }
    }
}
