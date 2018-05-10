namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLocatin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.coreUser", "USER_LOCATIONID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.coreUser", "USER_LOCATIONID");
        }
    }
}
