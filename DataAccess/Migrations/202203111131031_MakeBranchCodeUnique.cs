namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBranchCodeUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Branches", "Code", unique: true, name: "Code");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Branches", "Code");
        }
    }
}
