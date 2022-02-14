namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingCompanyAndBranches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(nullable: false),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        TaxRegistrationNumber = c.String(),
                        Logo = c.Binary(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        AddedUserId = c.Int(nullable: false),
                        UpdatedUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Companies");
            DropTable("dbo.Branches");
        }
    }
}
