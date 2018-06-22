namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConInventoryResult", "TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ConInventoryResult", "REALAMOUNT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConInventoryResult", "REALAMOUNT", c => c.Int(nullable: false));
            AlterColumn("dbo.ConInventoryResult", "TOTAL", c => c.Int(nullable: false));
        }
    }
}
