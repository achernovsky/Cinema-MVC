namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheaterIdToTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Theater_Id", "dbo.Theaters");
            DropIndex("dbo.Tickets", new[] { "Theater_Id" });
            RenameColumn(table: "dbo.Tickets", name: "Theater_Id", newName: "TheaterId");
            AlterColumn("dbo.Tickets", "TheaterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "TheaterId");
            AddForeignKey("dbo.Tickets", "TheaterId", "dbo.Theaters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TheaterId", "dbo.Theaters");
            DropIndex("dbo.Tickets", new[] { "TheaterId" });
            AlterColumn("dbo.Tickets", "TheaterId", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "TheaterId", newName: "Theater_Id");
            CreateIndex("dbo.Tickets", "Theater_Id");
            AddForeignKey("dbo.Tickets", "Theater_Id", "dbo.Theaters", "Id");
        }
    }
}
