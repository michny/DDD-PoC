using System;
using System.Data.Entity.Migrations;
using DDD.CommercePoC.Shop.Core.Model;

namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    public class DbConfiguration : DbMigrationsConfiguration<MasterContext>
    {
        public DbConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MasterContext context)
        {
            context.Customers.AddOrUpdate(new Customer(new Guid("11111111-1111-1111-1111-111111111111")));

            context.Products.AddOrUpdate(new Product(new Guid("22222222-2222-2222-2222-222222222222"), "My Test product"));

            context.Variants.AddOrUpdate(new Variant("My-Test-product-variation-1", new Guid("22222222-2222-2222-2222-222222222222"), "testname"));

            context.SaveChanges();
            //base.Seed(context);
        }
    }
}