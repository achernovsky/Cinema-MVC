namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheaterToShowing2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "Theater_Id", c => c.Int());
            CreateIndex("dbo.Showings", "Theater_Id");
            AddForeignKey("dbo.Showings", "Theater_Id", "dbo.Theaters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Showings", "Theater_Id", "dbo.Theaters");
            DropIndex("dbo.Showings", new[] { "Theater_Id" });
            DropColumn("dbo.Showings", "Theater_Id");
        }
    }
}
