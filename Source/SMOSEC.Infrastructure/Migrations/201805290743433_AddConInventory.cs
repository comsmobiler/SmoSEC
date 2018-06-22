namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConInventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConInventory",
                c => new
                    {
                        IID = c.String(nullable: false, maxLength: 20),
                        NAME = c.String(nullable: false, maxLength: 200),
                        HANDLEMAN = c.String(nullable: false, maxLength: 20),
                        LOCATIONID = c.String(nullable: false, maxLength: 128),
                        STATUS = c.Int(nullable: false),
                        TOTAL = c.Int(nullable: false),
                        RESULTCOUNT = c.Int(nullable: false),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IID);
            
            CreateTable(
                "dbo.ConInventoryResult",
                c => new
                    {
                        RROWID = c.Int(nullable: false, identity: true),
                        IID = c.String(nullable: false, maxLength: 20),
                        CID = c.String(nullable: false, maxLength: 20),
                        TOTAL = c.Int(nullable: false),
                        RESULT = c.Int(nullable: false),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RROWID);
            
            AddColumn("dbo.ConQuant", "ISLOCKED", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConQuant", "ISLOCKED");
            DropTable("dbo.ConInventoryResult");
            DropTable("dbo.ConInventory");
        }
    }
}
