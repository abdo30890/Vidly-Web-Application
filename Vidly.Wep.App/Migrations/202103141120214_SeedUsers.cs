namespace Vidly.Wep.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'034d14ad-5638-4c95-bbb9-fae782e94177', N'admin@vidly.com', 0, N'AMQu+Wbn3LwdDXDLHNJGsdMRZeDEN0MJ9ExfZV42ZYXJ7YSgEIIPDNZEFE2gDkFIIA==', N'0c2544c4-e09b-4f71-87fe-b750f156263f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7aab7fc7-62a3-4aae-8ae9-8b6e361a80e2', N'guest@vidly.com', 0, N'AHvHBBqofSj9kojZjdm4a/4dDJkLimQZ6bq3SEk8Qa3DEAEMe5xgfDLtRaoxTkT7gw==', N'0099803d-9010-4416-a6b2-444079f5d216', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'68a68a7b-ec5c-4c02-8ed9-a6d974757bac', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'034d14ad-5638-4c95-bbb9-fae782e94177', N'68a68a7b-ec5c-4c02-8ed9-a6d974757bac')

");
        }
        
        public override void Down()
        {
        }
    }
}
