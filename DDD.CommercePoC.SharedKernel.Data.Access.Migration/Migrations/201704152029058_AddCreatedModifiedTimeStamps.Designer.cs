// <auto-generated />
namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class AddCreatedModifiedTimeStamps : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddCreatedModifiedTimeStamps));
        
        string IMigrationMetadata.Id
        {
            get { return "201704152029058_AddCreatedModifiedTimeStamps"; }
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