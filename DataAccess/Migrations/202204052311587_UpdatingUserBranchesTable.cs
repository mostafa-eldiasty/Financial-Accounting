namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingUserBranchesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersBranches", "BranchId", c => c.Int(nullable: false));
            AddColumn("dbo.UsersBranches", "Users_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UsersBranches", "BranchId");
            CreateIndex("dbo.UsersBranches", "Users_Id");
            AddForeignKey("dbo.UsersBranches", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersBranches", "Users_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersBranches", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersBranches", "BranchId", "dbo.Branches");
            DropIndex("dbo.UsersBranches", new[] { "Users_Id" });
            DropIndex("dbo.UsersBranches", new[] { "BranchId" });
            DropColumn("dbo.UsersBranches", "Users_Id");
            DropColumn("dbo.UsersBranches", "BranchId");
        }
    }
}
