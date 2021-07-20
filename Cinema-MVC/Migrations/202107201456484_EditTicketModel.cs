namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTicketModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Showing_Id", "dbo.Showings");
            DropIndex("dbo.Tickets", new[] { "Showing_Id" });
            AddColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Tickets", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "rowNum", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "seatNum", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "MovieId");
            AddForeignKey("dbo.Tickets", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            DropColumn("dbo.Tickets", "Seat");
            DropColumn("dbo.Tickets", "Price");
            DropColumn("dbo.Tickets", "Showing_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Showing_Id", c => c.Int());
            AddColumn("dbo.Tickets", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Tickets", "Seat", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "MovieId", "dbo.Movies");
            DropIndex("dbo.Tickets", new[] { "MovieId" });
            DropColumn("dbo.Tickets", "seatNum");
            DropColumn("dbo.Tickets", "rowNum");
            DropColumn("dbo.Tickets", "MovieId");
            DropColumn("dbo.Orders", "TotalPrice");
            CreateIndex("dbo.Tickets", "Showing_Id");
            AddForeignKey("dbo.Tickets", "Showing_Id", "dbo.Showings", "Id");
        }
    }
}
