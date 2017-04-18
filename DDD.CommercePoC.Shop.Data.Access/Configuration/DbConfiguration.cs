using System.Data.Entity.Migrations;

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
        }
    }
}