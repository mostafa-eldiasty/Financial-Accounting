namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeUserIdRequiredInUsersBranches : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersBranches", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersBranches", new[] { "UserId" });
            AlterColumn("dbo.UsersBranches", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UsersBranches", "UserId");
            AddForeignKey("dbo.UsersBranches", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersBranches", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersBranches", new[] { "UserId" });
            AlterColumn("dbo.UsersBranches", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UsersBranches", "UserId");
            AddForeignKey("dbo.UsersBranches", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
