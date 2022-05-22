namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveHasChildrenFromAccountTree : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AccountTree", "HasChildren");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountTree", "HasChildren", c => c.Boolean(nullable: false));
        }
    }
}
