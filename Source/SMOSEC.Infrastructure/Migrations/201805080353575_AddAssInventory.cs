using System.Data.Entity.Migrations;

namespace SMOSEC.Infrastructure.Migrations
{
    public partial class AddAssInventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssInventory",
                c => new
                    {
                        IID = c.String(nullable: false, maxLength: 20),
                        NAME = c.String(nullable: false, maxLength: 200),
                        HANDLEMAN = c.String(nullable: false, maxLength: 20),
                        LOCATIONID = c.String(nullable: false, maxLength: 128),
                        DEPARTMENTID = c.String(maxLength: 20),
                        TYPEID = c.String(maxLength: 10),
                        STATUS = c.Int(nullable: false),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IID);
            
            CreateTable(
                "dbo.AssInventoryResult",
                c => new
                    {
                        RROWID = c.Int(nullable: false, identity: true),
                        IID = c.String(nullable: false, maxLength: 20),
                        ASSID = c.String(nullable: false, maxLength: 20),
                        RESULT = c.Int(nullable: false),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RROWID);
            
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
            
            AddColumn("dbo.Department", "IMAGEID", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department", "IMAGEID");
            DropTable("dbo.AssInventoryRow");
            DropTable("dbo.AssInventoryResult");
            DropTable("dbo.AssInventory");
        }
    }
}
