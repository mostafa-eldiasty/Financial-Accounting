namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingAccountsCostCentersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountsCostCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        CostCenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTree", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.CostCenterTree", t => t.CostCenterId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.CostCenterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountsCostCenters", "CostCenterId", "dbo.CostCenterTree");
            DropForeignKey("dbo.AccountsCostCenters", "AccountId", "dbo.AccountTree");
            DropIndex("dbo.AccountsCostCenters", new[] { "CostCenterId" });
            DropIndex("dbo.AccountsCostCenters", new[] { "AccountId" });
            DropTable("dbo.AccountsCostCenters");
        }
    }
}
