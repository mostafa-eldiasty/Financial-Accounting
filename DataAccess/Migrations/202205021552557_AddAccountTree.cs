namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTree : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Branches", newName: "Branch");
            RenameTable(name: "dbo.Companies", newName: "Company");
            CreateTable(
                "dbo.AccountTree",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(nullable: false),
                        ParentId = c.Int(nullable: false),
                        HasChildren = c.Boolean(nullable: false),
                        IsGeneralAccount = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        AddedUserId = c.String(maxLength: 128),
                        UpdatedUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTree", t => t.ParentId)
                .Index(t => t.Code, unique: true, name: "Code")
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountTree", "ParentId", "dbo.AccountTree");
            DropIndex("dbo.AccountTree", new[] { "ParentId" });
            DropIndex("dbo.AccountTree", "Code");
            DropTable("dbo.AccountTree");
            RenameTable(name: "dbo.Company", newName: "Companies");
            RenameTable(name: "dbo.Branch", newName: "Branches");
        }
    }
}
