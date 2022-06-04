namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameJournalIdToJournalTypeId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JournalHeader", name: "JournalId", newName: "JournalTypeId");
            RenameIndex(table: "dbo.JournalHeader", name: "IX_JournalId", newName: "IX_JournalTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JournalHeader", name: "IX_JournalTypeId", newName: "IX_JournalId");
            RenameColumn(table: "dbo.JournalHeader", name: "JournalTypeId", newName: "JournalId");
        }
    }
}
