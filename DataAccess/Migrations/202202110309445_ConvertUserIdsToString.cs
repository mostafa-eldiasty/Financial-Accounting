namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertUserIdsToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "AddedUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Companies", "UpdatedUserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "UpdatedUserId", c => c.Int());
            AlterColumn("dbo.Companies", "AddedUserId", c => c.Int(nullable: false));
        }
    }
}
