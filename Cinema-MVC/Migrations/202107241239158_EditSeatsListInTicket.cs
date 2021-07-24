namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditSeatsListInTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "SeatsList", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "SeatsList");
        }
    }
}
