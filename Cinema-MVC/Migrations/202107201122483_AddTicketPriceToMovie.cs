namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketPriceToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ticketPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ticketPrice");
        }
    }
}
