namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJournalDetailsForeignKeysToAccptNULL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JournalDetails", "AccountId", "dbo.AccountTree");
            DropForeignKey("dbo.JournalDetails", "CostCenterId", "dbo.CostCenterTree");
            DropIndex("dbo.JournalDetails", new[] { "AccountId" });
            DropIndex("dbo.JournalDetails", new[] { "CostCenterId" });
            AlterColumn("dbo.JournalDetails", "AccountId", c => c.Int());
            AlterColumn("dbo.JournalDetails", "CostCenterId", c => c.Int());
            CreateIndex("dbo.JournalDetails", "AccountId");
            CreateIndex("dbo.JournalDetails", "CostCenterId");
            AddForeignKey("dbo.JournalDetails", "AccountId", "dbo.AccountTree", "Id");
            AddForeignKey("dbo.JournalDetails", "CostCenterId", "dbo.CostCenterTree", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JournalDetails", "CostCenterId", "dbo.CostCenterTree");
            DropForeignKey("dbo.JournalDetails", "AccountId", "dbo.AccountTree");
            DropIndex("dbo.JournalDetails", new[] { "CostCenterId" });
            DropIndex("dbo.JournalDetails", new[] { "AccountId" });
            AlterColumn("dbo.JournalDetails", "CostCenterId", c => c.Int(nullable: false));
            AlterColumn("dbo.JournalDetails", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.JournalDetails", "CostCenterId");
            CreateIndex("dbo.JournalDetails", "AccountId");
            AddForeignKey("dbo.JournalDetails", "CostCenterId", "dbo.CostCenterTree", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JournalDetails", "AccountId", "dbo.AccountTree", "Id", cascadeDelete: true);
        }
    }
}
