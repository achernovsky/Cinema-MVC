namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerToOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "OrderId", "dbo.Orders");
            DropIndex("dbo.Customers", new[] { "OrderId" });
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "OrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropColumn("dbo.Orders", "CustomerId");
            CreateIndex("dbo.Customers", "OrderId");
            AddForeignKey("dbo.Customers", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
