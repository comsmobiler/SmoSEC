using SMOSEC.Domain.Entity;

namespace SMOSEC.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SMOSEC.Infrastructure.SMOSECDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SMOSEC.Infrastructure.SMOSECDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.coreUsers.AddOrUpdate(
                new coreUser{USER_ID = "12345678912",USER_ADDRESS = "嘉兴",USER_BIRTHDAY = DateTime.Now,USER_NAME = "张三",USER_ROLE = "ADMIN", USER_PASSWORD="123456",USER_LOCATIONID = "01"},
                new coreUser{USER_ID = "12345678913",USER_ADDRESS = "上海",USER_BIRTHDAY = DateTime.Now,USER_NAME = "李四",USER_ROLE = "SMOSECAdmin", USER_PASSWORD = "123456", USER_LOCATIONID = "02" },
                new coreUser{USER_ID = "12345678914",USER_ADDRESS = "郑州",USER_BIRTHDAY = DateTime.Now,USER_NAME = "王五",USER_ROLE = "SMOSECAdmin", USER_PASSWORD = "123456", USER_LOCATIONID = "03" },
                new coreUser{USER_ID = "12345678915",USER_ADDRESS = "嘉兴",USER_BIRTHDAY = DateTime.Now,USER_NAME = "赵二",USER_ROLE = "ADMIN", USER_PASSWORD = "123456", USER_LOCATIONID = "01" },
                new coreUser{USER_ID = "12345678916",USER_ADDRESS = "上海",USER_BIRTHDAY = DateTime.Now,USER_NAME = "老钱",USER_ROLE = "SMOSECUser", USER_PASSWORD = "123456", USER_LOCATIONID = "02" },
                new coreUser{USER_ID = "12345678917",USER_ADDRESS = "嘉兴",USER_BIRTHDAY = DateTime.Now,USER_NAME = "李狗蛋",USER_ROLE = "SMOSECUser", USER_PASSWORD = "123456", USER_LOCATIONID = "01" }
                );
            context.AssetsTypes.AddOrUpdate(
                new AssetsType {TYPEID="01",EXPIRYDATE = 8,EXPIRYDATEUNIT = 1,ISENABLE = 1,NAME = "电脑",TLEVEL = 1, CREATEUSER = "12345678912"},
                new AssetsType {TYPEID="02",EXPIRYDATE = 9,EXPIRYDATEUNIT = 1,ISENABLE = 1,NAME = "汽车",TLEVEL = 1, CREATEUSER = "12345678912" },
                new AssetsType {TYPEID="03",EXPIRYDATE = 10,EXPIRYDATEUNIT = 1,ISENABLE = 1,NAME = "显示器",TLEVEL = 2,PARENTTYPEID = "01", CREATEUSER = "12345678912" },
                new AssetsType {TYPEID="04",EXPIRYDATE = 11,EXPIRYDATEUNIT = 1,ISENABLE = 1,NAME = "饮料",TLEVEL = 2, PARENTTYPEID = "01", CREATEUSER = "12345678912" },
                new AssetsType {TYPEID="05",EXPIRYDATE = 12,EXPIRYDATEUNIT = 1,ISENABLE = 1,NAME = "鼠标",TLEVEL = 3, PARENTTYPEID = "03", CREATEUSER = "12345678912" },
                new AssetsType {TYPEID="06",EXPIRYDATE = 13,EXPIRYDATEUNIT = 1,ISENABLE = 1,NAME = "空调",TLEVEL = 3, PARENTTYPEID = "03", CREATEUSER = "12345678912" }
                );
            context.AssLocations.AddOrUpdate(
                new AssLocation{LOCATIONID = "01",NAME = "嘉兴",ISENABLE = 1,MANAGER = "12345678912"},
                new AssLocation{LOCATIONID = "02",NAME = "上海",ISENABLE = 1, MANAGER = "12345678913" },
                new AssLocation{LOCATIONID = "03",NAME = "郑州",ISENABLE = 1, MANAGER = "12345678914" }
                );
            context.Assetss.AddOrUpdate(
                new Assets { ASSID = "AS2018041101",BUYDATE = DateTime.Now,CURRENTUSER = "",EXPIRYDATE = DateTime.Now.AddYears(2),IMAGE = "2014",LOCATIONID = "01",CREATEDATE =DateTime.Now,CREATEUSER = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",TYPEID="01",STATUS = 0,NAME = "联想E999",UNIT = "台",PRICE = 5000,SN = "2001"},
                new Assets { ASSID = "AS2018041102",BUYDATE = DateTime.Now,CURRENTUSER = "",EXPIRYDATE = DateTime.Now.AddYears(2),IMAGE = "2014",LOCATIONID = "02",CREATEDATE =DateTime.Now,CREATEUSER = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",TYPEID="01",STATUS = 0,NAME = "联想E998",UNIT = "台",PRICE = 5100,SN = "2002" },
                new Assets { ASSID = "AS2018041103",BUYDATE = DateTime.Now,CURRENTUSER = "",EXPIRYDATE = DateTime.Now.AddYears(2),IMAGE = "2014",LOCATIONID = "03",CREATEDATE =DateTime.Now,CREATEUSER = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",TYPEID="01",STATUS = 0,NAME = "联想E997",UNIT = "台",PRICE = 5200, SN = "2003" },
                new Assets { ASSID = "AS2018041104",BUYDATE = DateTime.Now,CURRENTUSER = "",EXPIRYDATE = DateTime.Now.AddYears(2),IMAGE = "2014",LOCATIONID = "01",CREATEDATE =DateTime.Now,CREATEUSER = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",TYPEID="01",STATUS = 0,NAME = "联想E996",UNIT = "台",PRICE = 5300, SN = "2004" },
                new Assets { ASSID = "AS2018041105",BUYDATE = DateTime.Now,CURRENTUSER = "",EXPIRYDATE = DateTime.Now.AddYears(2),IMAGE = "2014",LOCATIONID = "02",CREATEDATE =DateTime.Now,CREATEUSER = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",TYPEID="01",STATUS = 0,NAME = "联想E995",UNIT = "台",PRICE = 5400, SN = "2005" },
                new Assets { ASSID = "AS2018041106",BUYDATE = DateTime.Now,CURRENTUSER = "",EXPIRYDATE = DateTime.Now.AddYears(2),IMAGE = "2014",LOCATIONID = "01",CREATEDATE =DateTime.Now,CREATEUSER = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",TYPEID="01",STATUS = 0,NAME = "联想E994",UNIT = "台",PRICE = 5500, SN = "2006" }
                );
            context.AssTemplates.AddOrUpdate(
                new AssTemplate { TEMPLATEID = "AT20180401",IMAGE = "2014",MANAGER = "12345678912",NAME = "电脑",NOTE = "备注",PRICE = 5000,SPECIFICATION = "50*40",UNIT = "台"},
                new AssTemplate { TEMPLATEID = "AT20180402",IMAGE = "2015",MANAGER = "12345678913",NAME = "显示器",NOTE = "备注",PRICE = 2000,SPECIFICATION = "50*40",UNIT = "台"},
                new AssTemplate { TEMPLATEID = "AT20180403",IMAGE = "2016",MANAGER = "12345678914",NAME = "手机",NOTE = "备注",PRICE = 4000,SPECIFICATION = "50*40",UNIT = "台"}
                );
            context.AssProcessRecords.AddOrUpdate(
                new AssProcessRecord{ASSID = "AS2018041101",CREATEDATE = DateTime.Now,CREATEUSER = "12345678912",HANDLEDATE = DateTime.Now,HANDLEMAN = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",PRID = 1,PROCESSCONTENT = "入库",PROCESSMODE = 8,QUANTITY = 1},
                new AssProcessRecord{ASSID = "AS2018041102",CREATEDATE = DateTime.Now,CREATEUSER = "12345678912",HANDLEDATE = DateTime.Now,HANDLEMAN = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",PRID = 1,PROCESSCONTENT = "入库",PROCESSMODE = 8,QUANTITY = 1},
                new AssProcessRecord{ASSID = "AS2018041103",CREATEDATE = DateTime.Now,CREATEUSER = "12345678912",HANDLEDATE = DateTime.Now,HANDLEMAN = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",PRID = 1,PROCESSCONTENT = "入库",PROCESSMODE = 8,QUANTITY = 1},
                new AssProcessRecord{ASSID = "AS2018041104",CREATEDATE = DateTime.Now,CREATEUSER = "12345678912",HANDLEDATE = DateTime.Now,HANDLEMAN = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",PRID = 1,PROCESSCONTENT = "入库",PROCESSMODE = 8,QUANTITY = 1},
                new AssProcessRecord{ASSID = "AS2018041105",CREATEDATE = DateTime.Now,CREATEUSER = "12345678912",HANDLEDATE = DateTime.Now,HANDLEMAN = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",PRID = 1,PROCESSCONTENT = "入库",PROCESSMODE = 8,QUANTITY = 1},
                new AssProcessRecord{ASSID = "AS2018041106",CREATEDATE = DateTime.Now,CREATEUSER = "12345678912",HANDLEDATE = DateTime.Now,HANDLEMAN = "12345678912",MODIFYDATE = DateTime.Now,MODIFYUSER = "12345678912",PRID = 1,PROCESSCONTENT = "入库",PROCESSMODE = 8,QUANTITY = 1}
                
                );
        }
    }
}
