namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBranchDto : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BranchDtoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BranchDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        Email = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        AddedUserId = c.String(maxLength: 128),
                        UpdatedUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
