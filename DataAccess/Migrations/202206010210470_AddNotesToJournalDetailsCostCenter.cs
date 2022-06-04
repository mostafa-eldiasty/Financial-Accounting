namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotesToJournalDetailsCostCenter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JournalDetailsCostCenters", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JournalDetailsCostCenters", "Notes");
        }
    }
}
