namespace EF_first_approach_demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Brands", name: "BrandID", newName: "Brand ID");
            RenameColumn(table: "dbo.Brands", name: "BrandName", newName: "Brand Name");
            RenameColumn(table: "dbo.Categories", name: "CategoryID", newName: "Category ID");
            RenameColumn(table: "dbo.Categories", name: "CategoryName", newName: "Category Name");
            RenameColumn(table: "dbo.Products", name: "ProductID", newName: "Product ID");
            RenameColumn(table: "dbo.Products", name: "ProductName", newName: "Product Name");
            RenameColumn(table: "dbo.Products", name: "DateOfPurchase", newName: "Invoice Date");
            RenameColumn(table: "dbo.Products", name: "AvailabilityStatus", newName: "Availability Status");
            RenameColumn(table: "dbo.Products", name: "BrandID", newName: "Brand ID");
            RenameColumn(table: "dbo.Products", name: "CategoryID", newName: "Category ID");
            RenameIndex(table: "dbo.Products", name: "IX_BrandID", newName: "IX_Brand ID");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryID", newName: "IX_Category ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_Category ID", newName: "IX_CategoryID");
            RenameIndex(table: "dbo.Products", name: "IX_Brand ID", newName: "IX_BrandID");
            RenameColumn(table: "dbo.Products", name: "Category ID", newName: "CategoryID");
            RenameColumn(table: "dbo.Products", name: "Brand ID", newName: "BrandID");
            RenameColumn(table: "dbo.Products", name: "Availability Status", newName: "AvailabilityStatus");
            RenameColumn(table: "dbo.Products", name: "Invoice Date", newName: "DateOfPurchase");
            RenameColumn(table: "dbo.Products", name: "Product Name", newName: "ProductName");
            RenameColumn(table: "dbo.Products", name: "Product ID", newName: "ProductID");
            RenameColumn(table: "dbo.Categories", name: "Category Name", newName: "CategoryName");
            RenameColumn(table: "dbo.Categories", name: "Category ID", newName: "CategoryID");
            RenameColumn(table: "dbo.Brands", name: "Brand Name", newName: "BrandName");
            RenameColumn(table: "dbo.Brands", name: "Brand ID", newName: "BrandID");
        }
    }
}
