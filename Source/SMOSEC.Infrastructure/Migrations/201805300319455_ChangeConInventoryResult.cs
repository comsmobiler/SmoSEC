namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeConInventoryResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConInventoryResult", "REALAMOUNT", c => c.Int(nullable: false));
            DropTable("dbo.AssInventoryRow");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AssInventoryRow",
                c => new
                    {
                        IROWID = c.Int(nullable: false, identity: true),
                        IID = c.String(nullable: false, maxLength: 20),
                        ASSID = c.String(nullable: false, maxLength: 20),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IROWID);
            
            DropColumn("dbo.ConInventoryResult", "REALAMOUNT");
        }
    }
}
