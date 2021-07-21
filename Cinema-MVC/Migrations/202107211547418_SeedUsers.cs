namespace Cinema_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8636634d-2c6a-4782-b449-c822b400eaae', N'admin@admin.com', 0, N'ACYr7c4Chmvss7APb6trt+dBJ7kor/JdReAcm34aRFaQdhra6lIJJf2nnZq1FiJU7Q==', N'4fb4fb43-7cb6-40f8-807a-340a6dee0633', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d9d4dd8-0161-4724-ba6e-2825c888e942', N'guest@guest.com', 0, N'AGRkcqY2+QmMACVmXVEXYdkJFY517muB3wlJFEMw65SMRtNaG8HaS6rpqeEFnr4gzw==', N'506dc848-3679-4668-9d5e-f3a5fb6d1b28', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'addbb038-3fa0-4233-b0a0-fd3280d3c253', N'test@test.com', 0, N'AIDRdKVFJ6SsNuveBnxhezBvDba54d9M9cGKAUTOF+Y3Q4h+AJLpRfi4P9k4O5AowQ==', N'a92931c8-94d2-43c2-a87d-43b14f9ee096', NULL, 0, 0, NULL, 1, 0, N'test@test.com')
            
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ef6ea23f-8cef-4d13-b434-761f33b525d4', N'Admin')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8636634d-2c6a-4782-b449-c822b400eaae', N'ef6ea23f-8cef-4d13-b434-761f33b525d4')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
