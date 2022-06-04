namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingJournalHeaderAndDetailsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JournalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalHeaderId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CostCenterId = c.Int(nullable: false),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTree", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.CostCenterTree", t => t.CostCenterId, cascadeDelete: true)
                .ForeignKey("dbo.JournalHeader", t => t.JournalHeaderId, cascadeDelete: true)
                .Index(t => t.JournalHeaderId)
                .Index(t => t.AccountId)
                .Index(t => t.CostCenterId);
            
            CreateTable(
                "dbo.JournalHeader",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        JournalId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        BranchId = c.Int(nullable: false),
                        CurrencyId = c.Int(),
                        Factor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        AddedUserId = c.String(maxLength: 128),
                        UpdatedUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .ForeignKey("dbo.JournalTypes", t => t.JournalId, cascadeDelete: true)
                .Index(t => t.Number, unique: true, name: "Number")
                .Index(t => t.JournalId)
                .Index(t => t.BranchId)
                .Index(t => t.CurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JournalDetails", "JournalHeaderId", "dbo.JournalHeader");
            DropForeignKey("dbo.JournalHeader", "JournalId", "dbo.JournalTypes");
            DropForeignKey("dbo.JournalHeader", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.JournalHeader", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.JournalDetails", "CostCenterId", "dbo.CostCenterTree");
            DropForeignKey("dbo.JournalDetails", "AccountId", "dbo.AccountTree");
            DropIndex("dbo.JournalHeader", new[] { "CurrencyId" });
            DropIndex("dbo.JournalHeader", new[] { "BranchId" });
            DropIndex("dbo.JournalHeader", new[] { "JournalId" });
            DropIndex("dbo.JournalHeader", "Number");
            DropIndex("dbo.JournalDetails", new[] { "CostCenterId" });
            DropIndex("dbo.JournalDetails", new[] { "AccountId" });
            DropIndex("dbo.JournalDetails", new[] { "JournalHeaderId" });
            DropTable("dbo.JournalHeader");
            DropTable("dbo.JournalDetails");
        }
    }
}
