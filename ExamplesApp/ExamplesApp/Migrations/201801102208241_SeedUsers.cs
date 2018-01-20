namespace ExamplesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'27f40cd9-5131-4f9d-a140-bd63a21ce8fd', N'admin@gmail.com', 0, N'ALR092CqaXWeB5K/5hZ5MhjY+VD4g/5rscaouflnAnw5ij6l++PKnHcLoTyATqBxyQ==', N'e31feb03-7a53-42b8-86b2-82edfbcc7332', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69ee55ff-c6d1-4b5c-b37a-81e0a63eb36d', N'deneme@gmail.com', 0, N'ACR3smo0AcGxsfvkG5PHCYUnxtb3Q72JpqE7FTJYQcup9QGy/AS7RJ+YqCbkAzEytw==', N'8cd9701d-5fe5-4c08-8ecf-ff2154bb079c', NULL, 0, 0, NULL, 1, 0, N'deneme@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9d236875-3830-4f20-8e06-4037a1a1534e', N'misafir@gmail.com', 0, N'ABVhfgof7wKM7Wdoy0m496H9SxZlkJeXixbHlv8/3JlYMJsxTOm4Ks/MMkubIOyZAA==', N'316ab0d4-c53b-4bf5-a533-44f8c77c451a', NULL, 0, 0, NULL, 1, 0, N'misafir@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e39ee855-ef80-4a81-b95f-ca495a7894eb', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'27f40cd9-5131-4f9d-a140-bd63a21ce8fd', N'e39ee855-ef80-4a81-b95f-ca495a7894eb')
");
        }
        
        public override void Down()
        {
        }
    }
}
