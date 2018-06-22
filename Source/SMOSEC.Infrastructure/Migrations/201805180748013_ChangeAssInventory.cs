namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAssInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssInventory", "TOTAL", c => c.Int(nullable: false));
            AddColumn("dbo.AssInventory", "RESULTCOUNT", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssInventory", "RESULTCOUNT");
            DropColumn("dbo.AssInventory", "TOTAL");
        }
    }
}
