namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeAccountBranchesColsNotAcceptNULL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccountBranches", "AccountTreeId", "dbo.AccountTree");
            DropForeignKey("dbo.AccountBranches", "BranchId", "dbo.Branch");
            DropIndex("dbo.AccountBranches", new[] { "BranchId" });
            DropIndex("dbo.AccountBranches", new[] { "AccountTreeId" });
            AlterColumn("dbo.AccountBranches", "BranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.AccountBranches", "AccountTreeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AccountBranches", "BranchId");
            CreateIndex("dbo.AccountBranches", "AccountTreeId");
            AddForeignKey("dbo.AccountBranches", "AccountTreeId", "dbo.AccountTree", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AccountBranches", "BranchId", "dbo.Branch", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountBranches", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.AccountBranches", "AccountTreeId", "dbo.AccountTree");
            DropIndex("dbo.AccountBranches", new[] { "AccountTreeId" });
            DropIndex("dbo.AccountBranches", new[] { "BranchId" });
            AlterColumn("dbo.AccountBranches", "AccountTreeId", c => c.Int());
            AlterColumn("dbo.AccountBranches", "BranchId", c => c.Int());
            CreateIndex("dbo.AccountBranches", "AccountTreeId");
            CreateIndex("dbo.AccountBranches", "BranchId");
            AddForeignKey("dbo.AccountBranches", "BranchId", "dbo.Branch", "Id");
            AddForeignKey("dbo.AccountBranches", "AccountTreeId", "dbo.AccountTree", "Id");
        }
    }
}
