namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingJournalDetailsCostCentersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JournalDetailsCostCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CostCenterId = c.Int(nullable: false),
                        JournalDetailsId = c.Int(nullable: false),
                        Ratio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CostCenterTree", "JournalDetailsCostCenters_Id", c => c.Int());
            AddColumn("dbo.JournalDetails", "JournalDetailsCostCenters_Id", c => c.Int());
            CreateIndex("dbo.CostCenterTree", "JournalDetailsCostCenters_Id");
            CreateIndex("dbo.JournalDetails", "JournalDetailsCostCenters_Id");
            AddForeignKey("dbo.CostCenterTree", "JournalDetailsCostCenters_Id", "dbo.JournalDetailsCostCenters", "Id");
            AddForeignKey("dbo.JournalDetails", "JournalDetailsCostCenters_Id", "dbo.JournalDetailsCostCenters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JournalDetails", "JournalDetailsCostCenters_Id", "dbo.JournalDetailsCostCenters");
            DropForeignKey("dbo.CostCenterTree", "JournalDetailsCostCenters_Id", "dbo.JournalDetailsCostCenters");
            DropIndex("dbo.JournalDetails", new[] { "JournalDetailsCostCenters_Id" });
            DropIndex("dbo.CostCenterTree", new[] { "JournalDetailsCostCenters_Id" });
            DropColumn("dbo.JournalDetails", "JournalDetailsCostCenters_Id");
            DropColumn("dbo.CostCenterTree", "JournalDetailsCostCenters_Id");
            DropTable("dbo.JournalDetailsCostCenters");
        }
    }
}
