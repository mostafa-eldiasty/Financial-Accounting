namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserBranchesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersBranches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsersBranches");
        }
    }
}
