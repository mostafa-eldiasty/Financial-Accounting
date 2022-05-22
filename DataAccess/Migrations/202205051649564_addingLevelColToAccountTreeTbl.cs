namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingLevelColToAccountTreeTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountTree", "Level", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountTree", "Level");
        }
    }
}
