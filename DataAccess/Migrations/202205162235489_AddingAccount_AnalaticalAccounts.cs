namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAccount_AnalaticalAccounts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account_AnalaticalAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnalaticalAccountId = c.Int(nullable: false),
                        AccountTreeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTree", t => t.AccountTreeId, cascadeDelete: true)
                .ForeignKey("dbo.AnalaticalAccounts", t => t.AnalaticalAccountId, cascadeDelete: true)
                .Index(t => t.AnalaticalAccountId)
                .Index(t => t.AccountTreeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account_AnalaticalAccounts", "AnalaticalAccountId", "dbo.AnalaticalAccounts");
            DropForeignKey("dbo.Account_AnalaticalAccounts", "AccountTreeId", "dbo.AccountTree");
            DropIndex("dbo.Account_AnalaticalAccounts", new[] { "AccountTreeId" });
            DropIndex("dbo.Account_AnalaticalAccounts", new[] { "AnalaticalAccountId" });
            DropTable("dbo.Account_AnalaticalAccounts");
        }
    }
}
