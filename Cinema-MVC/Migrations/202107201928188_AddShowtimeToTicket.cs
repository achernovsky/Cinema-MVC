namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowtimeToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Showtime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Showtime");
        }
    }
}
