namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBranchTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Branches", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Branches", "AddedUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Branches", "UpdatedUserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Branches", "UpdatedUserId");
            DropColumn("dbo.Branches", "AddedUserId");
            DropColumn("dbo.Branches", "UpdatedDate");
            DropColumn("dbo.Branches", "AddedDate");
        }
    }
}
