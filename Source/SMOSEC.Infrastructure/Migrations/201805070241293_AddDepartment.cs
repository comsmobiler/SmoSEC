namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DEPARTMENTID = c.String(nullable: false, maxLength: 10),
                        NAME = c.String(nullable: false, maxLength: 20),
                        MANAGER = c.String(maxLength: 20),
                        ISENABLE = c.Int(nullable: false),
                        CREATEDATE = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 20),
                        MODIFYDATE = c.DateTime(nullable: false),
                        MODIFYUSER = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.DEPARTMENTID);
            
            AddColumn("dbo.coreUser", "USER_DEPARTMENTID", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.coreUser", "USER_DEPARTMENTID");
            DropTable("dbo.Department");
        }
    }
}
