namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostCenterTreeAndCostCenterBranches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CostCenterBranches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        CostCenterTreeId = c.Int(nullable: false),
                        DebitBegBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditBegBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.CostCenterTree", t => t.CostCenterTreeId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.CostCenterTreeId);
            
            CreateTable(
                "dbo.CostCenterTree",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(nullable: false),
                        ParentId = c.Int(),
                        Level = c.Int(),
                        IsGeneralCostCenter = c.Boolean(nullable: false),
                        Notes = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        AddedUserId = c.String(maxLength: 128),
                        UpdatedUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CostCenterTree", t => t.ParentId)
                .Index(t => t.Code, unique: true, name: "Code")
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CostCenterBranches", "CostCenterTreeId", "dbo.CostCenterTree");
            DropForeignKey("dbo.CostCenterTree", "ParentId", "dbo.CostCenterTree");
            DropForeignKey("dbo.CostCenterBranches", "BranchId", "dbo.Branch");
            DropIndex("dbo.CostCenterTree", new[] { "ParentId" });
            DropIndex("dbo.CostCenterTree", "Code");
            DropIndex("dbo.CostCenterBranches", new[] { "CostCenterTreeId" });
            DropIndex("dbo.CostCenterBranches", new[] { "BranchId" });
            DropTable("dbo.CostCenterTree");
            DropTable("dbo.CostCenterBranches");
        }
    }
}
