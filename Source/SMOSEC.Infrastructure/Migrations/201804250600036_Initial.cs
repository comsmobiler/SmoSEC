namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssBorrowOrderRow",
                c => new
                    {
                        BOROWID = c.Int(nullable: false, identity: true),
                        BOID = c.String(nullable: false, maxLength: 10),
                        ASSID = c.String(nullable: false, maxLength: 20),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.BOROWID);
            
            CreateTable(
                "dbo.AssBorrowOrder",
                c => new
                    {
                        BOID = c.String(nullable: false, maxLength: 10),
                        BORROWER = c.String(nullable: false, maxLength: 20),
                        BORROWDATE = c.DateTime(nullable: false),
                        EPTRETURNDATE = c.DateTime(nullable: false),
                        BRHANDLEMAN = c.String(nullable: false, maxLength: 20),
                        LOCATIONID = c.String(nullable: false, maxLength: 4),
                        NOTE = c.String(maxLength: 200),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.BOID);
            
            CreateTable(
                "dbo.AssCollarOrderRow",
                c => new
                    {
                        COROWID = c.Int(nullable: false, identity: true),
                        COID = c.String(nullable: false, maxLength: 10),
                        ASSID = c.String(nullable: false, maxLength: 20),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.COROWID);
            
            CreateTable(
                "dbo.AssCollarOrder",
                c => new
                    {
                        COID = c.String(nullable: false, maxLength: 10),
                        USERID = c.String(nullable: false, maxLength: 20),
                        COLLARDATE = c.DateTime(nullable: false),
                        LOCATIONID = c.String(maxLength: 4),
                        INUSEDDEP = c.String(maxLength: 50),
                        PLACE = c.String(maxLength: 50),
                        EPTRESTOREDATE = c.DateTime(nullable: false),
                        HANDLEMAN = c.String(nullable: false, maxLength: 20),
                        NOTE = c.String(maxLength: 200),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.COID);
            
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        ASSID = c.String(nullable: false, maxLength: 20),
                        TYPEID = c.String(nullable: false, maxLength: 4),
                        NAME = c.String(nullable: false, maxLength: 50),
                        IMAGE = c.String(maxLength: 200),
                        SPECIFICATION = c.String(maxLength: 200),
                        SN = c.String(nullable: false, maxLength: 20),
                        UNIT = c.String(maxLength: 6),
                        PRICE = c.Decimal(precision: 18, scale: 2),
                        DEPARTMENTID = c.String(maxLength: 10),
                        BUYDATE = c.DateTime(nullable: false),
                        CURRENTUSER = c.String(maxLength: 20),
                        LOCATIONID = c.String(maxLength: 4),
                        PLACE = c.String(maxLength: 50),
                        EXPIRYDATE = c.DateTime(nullable: false),
                        VENDOR = c.String(maxLength: 10),
                        NOTE = c.String(maxLength: 200),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                        STATUS = c.Int(),
                    })
                .PrimaryKey(t => t.ASSID);
            
            CreateTable(
                "dbo.AssetsType",
                c => new
                    {
                        TYPEID = c.String(nullable: false, maxLength: 128),
                        NAME = c.String(),
                        TLEVEL = c.Int(),
                        EXPIRYDATE = c.Int(nullable: false),
                        EXPIRYDATEUNIT = c.Int(),
                        ISENABLE = c.Int(),
                        PARENTTYPEID = c.String(),
                        CREATEUSER = c.String(),
                    })
                .PrimaryKey(t => t.TYPEID);
            
            CreateTable(
                "dbo.AssLocation",
                c => new
                    {
                        LOCATIONID = c.String(nullable: false, maxLength: 128),
                        NAME = c.String(nullable: false),
                        MANAGER = c.String(nullable: false, maxLength: 20),
                        ISENABLE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LOCATIONID);
            
            CreateTable(
                "dbo.AssProcessRecord",
                c => new
                    {
                        PRID = c.Int(nullable: false, identity: true),
                        ASSID = c.String(maxLength: 20),
                        CID = c.String(maxLength: 20),
                        HANDLEDATE = c.DateTime(nullable: false),
                        HANDLEMAN = c.String(nullable: false, maxLength: 20),
                        PROCESSMODE = c.Int(nullable: false),
                        PROCESSCONTENT = c.String(),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                        QUANTITY = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PRID);
            
            CreateTable(
                "dbo.AssRepairOrderRow",
                c => new
                    {
                        ROROWID = c.String(nullable: false, maxLength: 128),
                        ROID = c.String(nullable: false, maxLength: 128),
                        IMAGE = c.String(),
                        LOCATIONID = c.String(),
                        ASSID = c.String(),
                        SN = c.String(),
                        WAITREPAIRQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        REPAIREDQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CURRENTDEP = c.String(),
                        CURRENTUSER = c.String(),
                        PLACE = c.String(),
                        STATUS = c.Int(),
                        CREATEUSER = c.String(),
                        CREATEDATE = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.ROROWID, t.ROID });
            
            CreateTable(
                "dbo.AssRepairOrder",
                c => new
                    {
                        ROID = c.String(nullable: false, maxLength: 128),
                        APPLYDATE = c.DateTime(nullable: false),
                        HANDLEMAN = c.String(),
                        COST = c.Decimal(precision: 18, scale: 2),
                        REPAIRCONTENT = c.String(),
                        STATUS = c.Int(nullable: false),
                        NOTE = c.String(),
                        CREATEUSER = c.String(),
                        CREATEDATE = c.DateTime(),
                        MODIFYDATE = c.DateTime(),
                        MODIFYUSER = c.String(),
                    })
                .PrimaryKey(t => t.ROID);
            
            CreateTable(
                "dbo.AssRestoreOrderRow",
                c => new
                    {
                        RSOROWID = c.Int(nullable: false, identity: true),
                        RSOID = c.String(nullable: false, maxLength: 10),
                        ASSID = c.String(nullable: false, maxLength: 20),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RSOROWID);
            
            CreateTable(
                "dbo.AssRestoreOrder",
                c => new
                    {
                        RSOID = c.String(nullable: false, maxLength: 10),
                        HANDLEMAN = c.String(nullable: false, maxLength: 20),
                        RESTOREDATE = c.DateTime(nullable: false),
                        LOCATIONID = c.String(maxLength: 4),
                        PLACE = c.String(maxLength: 50),
                        NOTE = c.String(maxLength: 200),
                        RESTORER = c.String(maxLength: 20),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RSOID);
            
            CreateTable(
                "dbo.AssReturnOrderRow",
                c => new
                    {
                        RTOROWID = c.Int(nullable: false, identity: true),
                        RTOID = c.String(nullable: false, maxLength: 10),
                        ASSID = c.String(nullable: false, maxLength: 20),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MoDIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RTOROWID);
            
            CreateTable(
                "dbo.AssReturnOrder",
                c => new
                    {
                        RTOID = c.String(nullable: false, maxLength: 10),
                        RETURNER = c.String(nullable: false, maxLength: 20),
                        RETURNDATE = c.DateTime(nullable: false),
                        LOCATIONID = c.String(nullable: false, maxLength: 4),
                        HANDLEMAN = c.String(nullable: false, maxLength: 20),
                        NOTE = c.String(maxLength: 200),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RTOID);
            
            CreateTable(
                "dbo.AssScrapOrderRow",
                c => new
                    {
                        SOROWID = c.String(nullable: false, maxLength: 128),
                        SOID = c.String(nullable: false, maxLength: 128),
                        LOCATIONID = c.String(),
                        IMAGE = c.String(),
                        ASSID = c.String(),
                        SN = c.String(),
                        SCRAPQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RETURNQTY = c.Decimal(precision: 18, scale: 2),
                        STATUS = c.Int(),
                        CURRENTDEP = c.String(),
                        CURRENTUSER = c.String(),
                        PLACE = c.String(),
                        CREATEUSER = c.String(),
                        CREATEDATE = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.SOROWID, t.SOID });
            
            CreateTable(
                "dbo.AssScrapOrder",
                c => new
                    {
                        SOID = c.String(nullable: false, maxLength: 128),
                        SCRAPDATE = c.DateTime(nullable: false),
                        SCRAPMAN = c.String(),
                        STATUS = c.Int(),
                        NOTE = c.String(),
                        CREATEUSER = c.String(),
                        CREATEDATE = c.DateTime(),
                        MODIFYDATE = c.DateTime(),
                        MODIFYUSER = c.String(),
                    })
                .PrimaryKey(t => t.SOID);
            
            CreateTable(
                "dbo.AssTemplate",
                c => new
                    {
                        TEMPLATEID = c.String(nullable: false, maxLength: 20),
                        NAME = c.String(nullable: false, maxLength: 50),
                        IMAGE = c.String(maxLength: 200),
                        SPECIFICATION = c.String(maxLength: 200),
                        UNIT = c.String(maxLength: 6),
                        PRICE = c.Decimal(precision: 18, scale: 2),
                        MANAGER = c.String(maxLength: 20),
                        VENDOR = c.String(maxLength: 10),
                        NOTE = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.TEMPLATEID);
            
            CreateTable(
                "dbo.AssTransferOrderRow",
                c => new
                    {
                        TOROWID = c.String(nullable: false, maxLength: 128),
                        TOID = c.String(nullable: false, maxLength: 128),
                        IMAGE = c.String(),
                        ASSID = c.String(),
                        SN = c.String(),
                        CID = c.String(),
                        LOCATIONID = c.String(),
                        INTRANSFERQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TRANSFEREDQTY = c.Decimal(precision: 18, scale: 2),
                        TRANSFERCANCELQTY = c.Decimal(precision: 18, scale: 2),
                        CURRENTDEP = c.String(),
                        CURRENTUSER = c.String(),
                        PLACE = c.String(),
                        STATUS = c.Int(),
                        CREATEUSER = c.String(),
                        CREATEDATE = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.TOROWID, t.TOID });
            
            CreateTable(
                "dbo.AssTransferOrder",
                c => new
                    {
                        TOID = c.String(nullable: false, maxLength: 128),
                        DESLOCATIONID = c.String(),
                        MANAGER = c.String(),
                        TRANSFERDATE = c.DateTime(),
                        HANDLEMAN = c.String(),
                        HANDLEDATE = c.DateTime(),
                        STATUS = c.Int(),
                        TYPE = c.Int(nullable: false),
                        NOTE = c.String(),
                        CREATEUSER = c.String(),
                        CREATEDATE = c.DateTime(),
                        MODIFYDATE = c.DateTime(),
                        MODIFYUSER = c.String(),
                    })
                .PrimaryKey(t => t.TOID);
            
            CreateTable(
                "dbo.ConQuant",
                c => new
                    {
                        QID = c.Int(nullable: false, identity: true),
                        CID = c.String(nullable: false, maxLength: 20),
                        LOCATIONID = c.String(nullable: false, maxLength: 10),
                        QUANTITY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.QID);
            
            CreateTable(
                "dbo.Consumables",
                c => new
                    {
                        CID = c.String(nullable: false, maxLength: 20),
                        NAME = c.String(nullable: false, maxLength: 50),
                        IMAGE = c.String(maxLength: 200),
                        SPECIFICATION = c.String(maxLength: 200),
                        UNIT = c.String(maxLength: 6),
                        NOTE = c.String(maxLength: 200),
                        SPQ = c.Int(),
                        SAFECEILING = c.Int(),
                        SAFEFLOOR = c.Int(),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.coreUser",
                c => new
                    {
                        USER_ID = c.String(nullable: false, maxLength: 128),
                        USER_NAME = c.String(),
                        USER_PASSWORD = c.String(),
                        USER_ROLE = c.String(),
                        USER_LANGUAGE = c.Int(),
                        USER_SEX = c.Int(),
                        USER_BIRTHDAY = c.DateTime(),
                        USER_ADDRESS = c.String(),
                        USER_PHONE = c.String(),
                        USER_EMAIL = c.String(),
                        USER_IMAGEID = c.String(),
                        USER_ISPHONEVALIDATED = c.Int(),
                        USER_ISEMAILVALIDATED = c.Int(),
                        USER_ISDEMO = c.Int(),
                        USER_DEMONAME = c.String(),
                    })
                .PrimaryKey(t => t.USER_ID);
            
            CreateTable(
                "dbo.OutboundOrderRow",
                c => new
                    {
                        OOROWID = c.Int(nullable: false, identity: true),
                        OOID = c.String(nullable: false, maxLength: 20),
                        CID = c.String(nullable: false, maxLength: 20),
                        QUANTITY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MONEY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NOTE = c.String(maxLength: 200),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.OOROWID);
            
            CreateTable(
                "dbo.OutboundOrder",
                c => new
                    {
                        OOID = c.String(nullable: false, maxLength: 20),
                        LOCATIONID = c.String(nullable: false),
                        TYPE = c.Int(nullable: false),
                        BUSINESSDATE = c.DateTime(nullable: false),
                        HANDLEMAN = c.String(nullable: false, maxLength: 20),
                        HANDLEDATE = c.DateTime(nullable: false),
                        NOTE = c.String(maxLength: 200),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.OOID);
            
            CreateTable(
                "dbo.ValidateCode",
                c => new
                    {
                        CODEID = c.Int(nullable: false, identity: true),
                        PHONENUMBER = c.String(),
                        EMAIL = c.String(),
                        VCODE = c.String(),
                        CREATEDATE = c.DateTime(),
                        DEVICEID = c.String(),
                    })
                .PrimaryKey(t => t.CODEID);
            
            CreateTable(
                "dbo.WareHourse",
                c => new
                    {
                        WAREID = c.String(nullable: false, maxLength: 10),
                        NAME = c.String(nullable: false),
                        ISENABLE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WAREID);
            
            CreateTable(
                "dbo.WarehouseReceiptRow",
                c => new
                    {
                        WRROWID = c.Int(nullable: false, identity: true),
                        WRID = c.String(nullable: false, maxLength: 20),
                        CID = c.String(nullable: false, maxLength: 20),
                        QUANTITY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MONEY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BATCH = c.String(maxLength: 20),
                        NOTE = c.String(maxLength: 200),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.WRROWID);
            
            CreateTable(
                "dbo.WarehouseReceipt",
                c => new
                    {
                        WRID = c.String(nullable: false, maxLength: 20),
                        LOCATIONID = c.String(nullable: false),
                        BUSINESSDATE = c.DateTime(nullable: false),
                        VENDOR = c.String(maxLength: 10),
                        HANDLEMAN = c.String(nullable: false, maxLength: 20),
                        HANDLEDATE = c.DateTime(nullable: false),
                        NOTE = c.String(maxLength: 200),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.WRID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WarehouseReceipt");
            DropTable("dbo.WarehouseReceiptRow");
            DropTable("dbo.WareHourse");
            DropTable("dbo.ValidateCode");
            DropTable("dbo.OutboundOrder");
            DropTable("dbo.OutboundOrderRow");
            DropTable("dbo.coreUser");
            DropTable("dbo.Consumables");
            DropTable("dbo.ConQuant");
            DropTable("dbo.AssTransferOrder");
            DropTable("dbo.AssTransferOrderRow");
            DropTable("dbo.AssTemplate");
            DropTable("dbo.AssScrapOrder");
            DropTable("dbo.AssScrapOrderRow");
            DropTable("dbo.AssReturnOrder");
            DropTable("dbo.AssReturnOrderRow");
            DropTable("dbo.AssRestoreOrder");
            DropTable("dbo.AssRestoreOrderRow");
            DropTable("dbo.AssRepairOrder");
            DropTable("dbo.AssRepairOrderRow");
            DropTable("dbo.AssProcessRecord");
            DropTable("dbo.AssLocation");
            DropTable("dbo.AssetsType");
            DropTable("dbo.Assets");
            DropTable("dbo.AssCollarOrder");
            DropTable("dbo.AssCollarOrderRow");
            DropTable("dbo.AssBorrowOrder");
            DropTable("dbo.AssBorrowOrderRow");
        }
    }
}
