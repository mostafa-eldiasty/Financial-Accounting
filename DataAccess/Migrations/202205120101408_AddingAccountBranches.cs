namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAccountBranches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountBranches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(),
                        AccountTreeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTree", t => t.AccountTreeId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId)
                .Index(t => t.AccountTreeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountBranches", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.AccountBranches", "AccountTreeId", "dbo.AccountTree");
            DropIndex("dbo.AccountBranches", new[] { "AccountTreeId" });
            DropIndex("dbo.AccountBranches", new[] { "BranchId" });
            DropTable("dbo.AccountBranches");
        }
    }
}
