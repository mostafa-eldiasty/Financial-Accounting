namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnalaticalAccounts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnalaticalAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        AddedUserId = c.String(maxLength: 128),
                        UpdatedUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true, name: "Code");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AnalaticalAccounts", "Code");
            DropTable("dbo.AnalaticalAccounts");
        }
    }
}
