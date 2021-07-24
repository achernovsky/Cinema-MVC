namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheater2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Theaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumOfRows = c.Int(nullable: false),
                        NumOfSeatsPerRow = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Theaters");
        }
    }
}
