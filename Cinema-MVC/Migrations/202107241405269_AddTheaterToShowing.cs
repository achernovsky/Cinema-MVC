namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheaterToShowing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Theaters", "TheaterNum", c => c.Int(nullable: false));
            DropColumn("dbo.Showings", "numOfRows");
            DropColumn("dbo.Showings", "numOfSeatsPerRow");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "numOfSeatsPerRow", c => c.Int(nullable: false));
            AddColumn("dbo.Showings", "numOfRows", c => c.Int(nullable: false));
            DropColumn("dbo.Theaters", "TheaterNum");
        }
    }
}
