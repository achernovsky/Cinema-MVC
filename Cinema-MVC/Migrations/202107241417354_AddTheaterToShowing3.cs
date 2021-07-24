namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheaterToShowing3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Theater_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Theater_Id");
            AddForeignKey("dbo.Tickets", "Theater_Id", "dbo.Theaters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Theater_Id", "dbo.Theaters");
            DropIndex("dbo.Tickets", new[] { "Theater_Id" });
            DropColumn("dbo.Tickets", "Theater_Id");
        }
    }
}
