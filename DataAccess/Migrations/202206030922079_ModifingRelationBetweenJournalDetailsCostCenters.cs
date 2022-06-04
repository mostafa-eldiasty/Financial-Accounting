namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifingRelationBetweenJournalDetailsCostCenters : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JournalDetails", "JournalDetailsCostCenters_Id", "dbo.JournalDetailsCostCenters");
            DropIndex("dbo.JournalDetails", new[] { "JournalDetailsCostCenters_Id" });
            CreateIndex("dbo.JournalDetailsCostCenters", "JournalDetailsId");
            AddForeignKey("dbo.JournalDetailsCostCenters", "JournalDetailsId", "dbo.JournalDetails", "Id", cascadeDelete: true);
            DropColumn("dbo.JournalDetails", "JournalDetailsCostCenters_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JournalDetails", "JournalDetailsCostCenters_Id", c => c.Int());
            DropForeignKey("dbo.JournalDetailsCostCenters", "JournalDetailsId", "dbo.JournalDetails");
            DropIndex("dbo.JournalDetailsCostCenters", new[] { "JournalDetailsId" });
            CreateIndex("dbo.JournalDetails", "JournalDetailsCostCenters_Id");
            AddForeignKey("dbo.JournalDetails", "JournalDetailsCostCenters_Id", "dbo.JournalDetailsCostCenters", "Id");
        }
    }
}
