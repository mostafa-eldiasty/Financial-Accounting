namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJournalDetailsForeignKeysToAcceptNULL : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JournalDetails", "Debit", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.JournalDetails", "Credit", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JournalDetails", "Credit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.JournalDetails", "Debit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
