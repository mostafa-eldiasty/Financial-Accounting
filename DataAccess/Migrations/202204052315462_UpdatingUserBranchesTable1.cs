namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingUserBranchesTable1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UsersBranches", new[] { "Users_Id" });
            DropColumn("dbo.UsersBranches", "UserId");
            RenameColumn(table: "dbo.UsersBranches", name: "Users_Id", newName: "UserId");
            AlterColumn("dbo.UsersBranches", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UsersBranches", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UsersBranches", new[] { "UserId" });
            AlterColumn("dbo.UsersBranches", "UserId", c => c.String());
            RenameColumn(table: "dbo.UsersBranches", name: "UserId", newName: "Users_Id");
            AddColumn("dbo.UsersBranches", "UserId", c => c.String());
            CreateIndex("dbo.UsersBranches", "Users_Id");
        }
    }
}
