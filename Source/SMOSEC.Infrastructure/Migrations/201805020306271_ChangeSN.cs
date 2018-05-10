namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSN : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assets", "SN", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Assets", "SN", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
