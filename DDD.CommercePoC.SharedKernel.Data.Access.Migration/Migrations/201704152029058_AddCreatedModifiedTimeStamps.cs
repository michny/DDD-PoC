namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedModifiedTimeStamps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Created", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.Customers", "LastModified", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.CartLineItems", "Created", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.CartLineItems", "LastModified", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.Carts", "Created", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.Carts", "LastModified", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.Variants", "Created", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.Variants", "LastModified", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.Products", "Created", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.Products", "LastModified", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "LastModified");
            DropColumn("dbo.Products", "Created");
            DropColumn("dbo.Variants", "LastModified");
            DropColumn("dbo.Variants", "Created");
            DropColumn("dbo.Carts", "LastModified");
            DropColumn("dbo.Carts", "Created");
            DropColumn("dbo.CartLineItems", "LastModified");
            DropColumn("dbo.CartLineItems", "Created");
            DropColumn("dbo.Customers", "LastModified");
            DropColumn("dbo.Customers", "Created");
        }
    }
}
