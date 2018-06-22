using System.Data.Entity.Migrations;

namespace SMOSEC.Infrastructure.Migrations
{
    public partial class AddIsLockedToAssets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "ISLOCKED", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "ISLOCKED");
        }
    }
}
