namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToAccountTree : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountTree", "AccountTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.AccountTree", "CurrencyId", c => c.Int(nullable: false));
            AddColumn("dbo.AccountTree", "IsDebit", c => c.Boolean(nullable: false));
            AddColumn("dbo.AccountTree", "Notes", c => c.String());
            CreateIndex("dbo.AccountTree", "AccountTypeId");
            CreateIndex("dbo.AccountTree", "CurrencyId");
            AddForeignKey("dbo.AccountTree", "AccountTypeId", "dbo.AccountTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AccountTree", "CurrencyId", "dbo.Currencies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountTree", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.AccountTree", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.AccountTree", new[] { "CurrencyId" });
            DropIndex("dbo.AccountTree", new[] { "AccountTypeId" });
            DropColumn("dbo.AccountTree", "Notes");
            DropColumn("dbo.AccountTree", "IsDebit");
            DropColumn("dbo.AccountTree", "CurrencyId");
            DropColumn("dbo.AccountTree", "AccountTypeId");
        }
    }
}
