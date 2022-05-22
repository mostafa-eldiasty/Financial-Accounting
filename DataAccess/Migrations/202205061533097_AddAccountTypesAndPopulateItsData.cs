namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTypesAndPopulateItsData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql(@"SET IDENTITY_INSERT [dbo].[AccountTypes] ON 
                    INSERT [dbo].[AccountTypes] ([Id], [Code], [ArabicName], [EnglishName]) VALUES (1, 1, N' قائمة التشغيل ', N'Operation list')
                    INSERT [dbo].[AccountTypes] ([Id], [Code], [ArabicName], [EnglishName]) VALUES (2, 2, N'قائمة حساب متاجرة', N'Trading account list')
                    INSERT [dbo].[AccountTypes] ([Id], [Code], [ArabicName], [EnglishName]) VALUES (3, 3, N'قائمة ارباح وخسائر ', N'Profit and loss list')
                    INSERT [dbo].[AccountTypes] ([Id], [Code], [ArabicName], [EnglishName]) VALUES (4, 4, N'قائمة الدخل ', N'Income list')
                    INSERT [dbo].[AccountTypes] ([Id], [Code], [ArabicName], [EnglishName]) VALUES (5, 5, N'قائمة ميزانية ', N'budget list')
                    INSERT [dbo].[AccountTypes] ([Id], [Code], [ArabicName], [EnglishName]) VALUES (6, 10, N'حسابات اخرى', N'Other accounts')
                    SET IDENTITY_INSERT [dbo].[AccountTypes] OFF");
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountTypes");
        }
    }
}
