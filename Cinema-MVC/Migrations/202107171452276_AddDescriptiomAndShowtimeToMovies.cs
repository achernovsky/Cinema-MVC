namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptiomAndShowtimeToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Description", c => c.String());
            AddColumn("dbo.Movies", "Showtime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Showtime");
            DropColumn("dbo.Movies", "Description");
        }
    }
}
