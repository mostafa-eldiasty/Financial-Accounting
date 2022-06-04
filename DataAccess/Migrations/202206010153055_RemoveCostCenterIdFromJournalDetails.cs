namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCostCenterIdFromJournalDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JournalDetails", "CostCenterId", "dbo.CostCenterTree");
            DropIndex("dbo.JournalDetails", new[] { "CostCenterId" });
            DropColumn("dbo.JournalDetails", "CostCenterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JournalDetails", "CostCenterId", c => c.Int());
            CreateIndex("dbo.JournalDetails", "CostCenterId");
            AddForeignKey("dbo.JournalDetails", "CostCenterId", "dbo.CostCenterTree", "Id");
        }
    }
}
