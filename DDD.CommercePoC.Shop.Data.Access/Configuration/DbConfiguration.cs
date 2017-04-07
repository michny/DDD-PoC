using System.Data.Entity.Migrations;
using DDD.CommercePoC.Shop.Core.Model;

namespace DDD.CommercePoC.Shop.Data.Access.Configuration
{
    public class DbConfiguration : DbMigrationsConfiguration<ShopContext>
    {
        public DbConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopContext context)
        {
            //context.Customers.AddOrUpdate(new Customer());

            //context.Orders.AddOrUpdate(new Order());
        }
    }
}