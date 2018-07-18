namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRSOandRTO : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssRestoreOrder", "RESTORER");
            DropColumn("dbo.AssReturnOrder", "RETURNER");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssReturnOrder", "RETURNER", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AssRestoreOrder", "RESTORER", c => c.String(maxLength: 20));
        }
    }
}
