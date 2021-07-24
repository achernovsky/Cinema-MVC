namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTicket : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "numOfTickets");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "numOfTickets", c => c.Int(nullable: false));
        }
    }
}
