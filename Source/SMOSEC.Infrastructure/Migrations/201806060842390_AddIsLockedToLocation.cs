namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsLockedToLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssLocation", "ISLOCKED", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssLocation", "ISLOCKED");
        }
    }
}
