namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrlOnVariants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Variants", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Variants", "ImageUrl");
        }
    }
}
