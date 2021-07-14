namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        NumOfTickets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            AddColumn("dbo.Customers", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "OrderId");
            AddForeignKey("dbo.Customers", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "NumOfTickets");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "NumOfTickets", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "MovieId", "dbo.Movies");
            DropIndex("dbo.Orders", new[] { "MovieId" });
            DropIndex("dbo.Customers", new[] { "OrderId" });
            DropColumn("dbo.Customers", "OrderId");
            DropTable("dbo.Orders");
        }
    }
}
