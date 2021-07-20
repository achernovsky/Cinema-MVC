namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderedSeats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "SeatsOrdered", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "SeatsOrdered");
        }
    }
}
