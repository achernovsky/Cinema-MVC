namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheaterIdToShowing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Showings", "Theater_Id", "dbo.Theaters");
            DropIndex("dbo.Showings", new[] { "Theater_Id" });
            RenameColumn(table: "dbo.Showings", name: "Theater_Id", newName: "TheaterId");
            AlterColumn("dbo.Showings", "TheaterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Showings", "TheaterId");
            AddForeignKey("dbo.Showings", "TheaterId", "dbo.Theaters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Showings", "TheaterId", "dbo.Theaters");
            DropIndex("dbo.Showings", new[] { "TheaterId" });
            AlterColumn("dbo.Showings", "TheaterId", c => c.Int());
            RenameColumn(table: "dbo.Showings", name: "TheaterId", newName: "Theater_Id");
            CreateIndex("dbo.Showings", "Theater_Id");
            AddForeignKey("dbo.Showings", "Theater_Id", "dbo.Theaters", "Id");
        }
    }
}
