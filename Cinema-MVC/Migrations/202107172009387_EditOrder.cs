namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrder : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Users");
            DropForeignKey("dbo.Orders", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "MovieId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "User_Id");
            AlterColumn("dbo.Orders", "User_Id", c => c.Int());
            CreateIndex("dbo.Orders", "User_Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Orders", "MovieId");
            DropColumn("dbo.Orders", "NumOfTickets");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "NumOfTickets", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "MovieId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            AlterColumn("dbo.Orders", "User_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "CustomerId");
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.Orders", "MovieId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Users", newName: "Customers");
        }
    }
}
