namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeParentIdAllowNullInAccountTreeTbl : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountTree", new[] { "ParentId" });
            AlterColumn("dbo.AccountTree", "ParentId", c => c.Int());
            CreateIndex("dbo.AccountTree", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AccountTree", new[] { "ParentId" });
            AlterColumn("dbo.AccountTree", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AccountTree", "ParentId");
        }
    }
}
