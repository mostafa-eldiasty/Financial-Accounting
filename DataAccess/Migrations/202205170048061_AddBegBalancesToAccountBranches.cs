namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBegBalancesToAccountBranches : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountBranches", "DebitBegBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AccountBranches", "CreditBegBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountBranches", "CreditBegBalance");
            DropColumn("dbo.AccountBranches", "DebitBegBalance");
        }
    }
}
