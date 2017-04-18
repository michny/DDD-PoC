namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoneyOnVariant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Variants", "Price_Currency", c => c.Int(nullable: false));
            AddColumn("dbo.Variants", "Price_Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Variants", "Price_Amount");
            DropColumn("dbo.Variants", "Price_Currency");
        }
    }
}
