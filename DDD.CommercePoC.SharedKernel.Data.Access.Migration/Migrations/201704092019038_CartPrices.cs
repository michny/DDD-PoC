namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartPrices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartLineItems", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.CartLineItems", new[] { "Cart_Id" });
            RenameColumn(table: "dbo.CartLineItems", name: "Cart_Id", newName: "CartId");
            AddColumn("dbo.CartLineItems", "LineTotal_Currency", c => c.Int(nullable: false));
            AddColumn("dbo.CartLineItems", "LineTotal_Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CartLineItems", "CartId", c => c.Guid(nullable: false));
            CreateIndex("dbo.CartLineItems", "CartId");
            AddForeignKey("dbo.CartLineItems", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
            DropColumn("dbo.CartLineItems", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartLineItems", "OrderId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.CartLineItems", "CartId", "dbo.Carts");
            DropIndex("dbo.CartLineItems", new[] { "CartId" });
            AlterColumn("dbo.CartLineItems", "CartId", c => c.Guid());
            DropColumn("dbo.CartLineItems", "LineTotal_Amount");
            DropColumn("dbo.CartLineItems", "LineTotal_Currency");
            RenameColumn(table: "dbo.CartLineItems", name: "CartId", newName: "Cart_Id");
            CreateIndex("dbo.CartLineItems", "Cart_Id");
            AddForeignKey("dbo.CartLineItems", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
