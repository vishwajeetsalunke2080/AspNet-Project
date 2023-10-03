namespace EF_first_approach_demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidationSchema1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime());
        }
    }
}
