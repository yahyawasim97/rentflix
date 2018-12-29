namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'59fd379a-4bc0-4856-9136-011933c3d262', N'guest@rentflix.com', 0, N'AFZZsMXG3NPzJsJGulmSScJt+5MefF2vez8pdnPMApcjH6wD7Dv1KJX2bRV8Qw8LQg==', N'249c7449-26ec-4784-a8cf-fd58835d5787', NULL, 0, 0, NULL, 1, 0, N'guest@rentflix.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'afcdb2d0-fce4-4d30-bf67-412f784aaf8b', N'admin@rentflix.com', 0, N'AFYVoTOvYw2i67TYN1kquNZxc5HRM0XWx6Ci+zM31hHi/zGKTkHZpSdXmYkCqH8iVA==', N'8f803ccd-f4db-42ca-aac3-aa9669c893df', NULL, 0, 0, NULL, 1, 0, N'admin@rentflix.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'786ead8b-bad6-4cfa-b3f1-c03a7f363097', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afcdb2d0-fce4-4d30-bf67-412f784aaf8b', N'786ead8b-bad6-4cfa-b3f1-c03a7f363097')
        ");
        }
        
        public override void Down()
        {
        }
    }
}
