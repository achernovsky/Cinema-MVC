namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatsToOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "Order_Id" });
            DropColumn("dbo.Tickets", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Order_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Order_Id");
            AddForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
