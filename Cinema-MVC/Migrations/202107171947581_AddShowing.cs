namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Showings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Showtime = c.DateTime(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            DropColumn("dbo.Movies", "Showtime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Showtime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Showings", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Showings", new[] { "Movie_Id" });
            DropTable("dbo.Showings");
        }
    }
}
