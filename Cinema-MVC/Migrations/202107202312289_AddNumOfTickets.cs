namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumOfTickets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "numOfTickets", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "SeatsOrdered");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "SeatsOrdered", c => c.String());
            DropColumn("dbo.Tickets", "numOfTickets");
        }
    }
}
