// <auto-generated />
namespace DataAccess.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class MakeParentIdAllowNullInAccountTreeTbl : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(MakeParentIdAllowNullInAccountTreeTbl));
        
        string IMigrationMetadata.Id
        {
            get { return "202205021753283_MakeParentIdAllowNullInAccountTreeTbl"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
