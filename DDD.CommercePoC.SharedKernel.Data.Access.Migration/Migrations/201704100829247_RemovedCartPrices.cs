namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCartPrices : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartLineItems", "LineTotal_Currency");
            DropColumn("dbo.CartLineItems", "LineTotal_Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartLineItems", "LineTotal_Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CartLineItems", "LineTotal_Currency", c => c.Int(nullable: false));
        }
    }
}
