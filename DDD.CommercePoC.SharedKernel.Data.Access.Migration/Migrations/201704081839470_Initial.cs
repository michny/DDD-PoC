namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartLineItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        VariantId = c.String(nullable: false, maxLength: 128),
                        Count = c.Int(nullable: false),
                        Cart_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Variants", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.VariantId)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartLineItems", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.Variants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartLineItems", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Variants", new[] { "ProductId" });
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            DropIndex("dbo.CartLineItems", new[] { "Cart_Id" });
            DropIndex("dbo.CartLineItems", new[] { "VariantId" });
            DropTable("dbo.Products");
            DropTable("dbo.Variants");
            DropTable("dbo.Carts");
            DropTable("dbo.CartLineItems");
            DropTable("dbo.Customers");
        }
    }
}
