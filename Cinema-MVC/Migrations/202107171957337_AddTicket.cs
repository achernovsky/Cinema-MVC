namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seat = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Order_Id = c.Int(),
                        Showing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Showings", t => t.Showing_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Showing_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Showing_Id", "dbo.Showings");
            DropForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "Showing_Id" });
            DropIndex("dbo.Tickets", new[] { "Order_Id" });
            DropTable("dbo.Tickets");
        }
    }
}
