namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderLineItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VariantId = c.String(nullable:false),
                        Count = c.Int(nullable: false),
                        LineTotal_Currency = c.Int(nullable: false),
                        LineTotal_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Order_Id = c.Guid(nullable:false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Total_Currency = c.Int(nullable: false),
                        Total_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StateName = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLineItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderLineItems", new[] { "Order_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLineItems");
        }
    }
}
