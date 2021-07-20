namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatsToShowing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Showings", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Showings", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Showings", name: "Movie_Id", newName: "MovieId");
            AddColumn("dbo.Showings", "numOfRows", c => c.Int(nullable: false));
            AddColumn("dbo.Showings", "numOfSeatsPerRow", c => c.Int(nullable: false));
            AlterColumn("dbo.Showings", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Showings", "MovieId");
            AddForeignKey("dbo.Showings", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Showings", "MovieId", "dbo.Movies");
            DropIndex("dbo.Showings", new[] { "MovieId" });
            AlterColumn("dbo.Showings", "MovieId", c => c.Int());
            DropColumn("dbo.Showings", "numOfSeatsPerRow");
            DropColumn("dbo.Showings", "numOfRows");
            RenameColumn(table: "dbo.Showings", name: "MovieId", newName: "Movie_Id");
            CreateIndex("dbo.Showings", "Movie_Id");
            AddForeignKey("dbo.Showings", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
