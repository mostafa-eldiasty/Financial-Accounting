namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUserTableWithAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6942c587-6152-4264-afb5-af0167a53f93', N'sysadmin', 0, N'AAVtE9qutu2suQfvDvmsat33utRYRMfZSC9Wc0JglRvBalOipAzFaF3xMlpv6k+dOA==', N'8f0078b3-cd97-408e-8fb9-69713bcaf760', NULL, 0, 0, NULL, 1, 0, N'sysadmin')");
        }
        
        public override void Down()
        {
            Sql("delete [dbo].[AspNetUsers]");
        }
    }
}
