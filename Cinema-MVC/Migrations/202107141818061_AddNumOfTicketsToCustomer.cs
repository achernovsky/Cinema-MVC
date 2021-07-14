namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumOfTicketsToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "NumOfTickets", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "NumOfTickets");
        }
    }
}
