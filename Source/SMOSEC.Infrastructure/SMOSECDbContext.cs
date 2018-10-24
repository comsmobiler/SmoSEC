using SMOSEC.Domain.Entity;
using SMOSEC.Infrastructure.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SMOSEC.Infrastructure
{
    public class SMOSECDbContext : DbContext, IDbContext
    {
        #region 构造函数

        /// <summary>
        ///     初始化一个 使用连接名称为“default”的数据访问上下文类 的新实例
        /// </summary>
        public SMOSECDbContext()
            : base("default")
        {
            //手动创建了数据库和表,不用产生系统表
            //if (!Database.Exists("default"))
            //{
            //    Database.SetInitializer<SMOSECDbContext>(
            //            new DropCreateDatabaseIfModelChanges<SMOSECDbContext>());
            //}
            //自动创建更新数据库和表,产生系统表
            //Database.SetInitializer<SMOSECDbContext>(null);
            Database.SetInitializer<SMOSECDbContext>(
                    new DropCreateDatabaseIfModelChanges<SMOSECDbContext>());
            this.Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// 初始化一个 使用指定数据连接名称或连接串 的数据访问上下文类 的新实例
        /// </summary>
        public SMOSECDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        #endregion

        #region 属性

        /// <summary>
        /// 申明所需要映射的所有类
        /// </summary>
        public DbSet<AssLocation> AssLocations { get; set; }
        public DbSet<Assets> Assetss { get; set; }
//        public DbSet<AssetsSN> AssetsSNs { get; set; }
        public DbSet<AssetsType> AssetsTypes { get; set; }
        public DbSet<AssRepairOrder> AssRepairOrders { get; set; }
        public DbSet<AssRepairOrderRow> AssRepairOrderRows { get; set; }
        public DbSet<AssScrapOrder> AssScrapOrders { get; set; }
        public DbSet<AssScrapOrderRow> AssScrapOrderRows { get; set; }
        public DbSet<AssTransferOrder> AssTransferOrders { get; set; }
        public DbSet<AssTransferOrderRow> AssTransferOrderRows { get; set; }
        public DbSet<AssBorrowOrder> AssBorrowOrders { get; set; }
        public DbSet<AssBorrowOrderRow> AssBorrowOrderRows { get; set; }
        public DbSet<AssCollarOrder> AssCollarOrders { get; set; }
        public DbSet<AssCollarOrderRow> AssCollarOrderRows { get; set; }
        public DbSet<AssRestoreOrder> AssRestoreOrders { get; set; }
        public DbSet<AssRestoreOrderRow> AssRestoreOrderRows { get; set; }
        public DbSet<AssReturnOrder> AssReturnOrders { get; set; }
        public DbSet<AssReturnOrderRow> AssReturnOrderRows { get; set; }
        public DbSet<coreUser> coreUsers { get; set; }
        public DbSet<ValidateCode> ValidateCodes { get; set; }

        public DbSet<AssProcessRecord> AssProcessRecords { get; set; }
        public DbSet<AssTemplate> AssTemplates { get; set; }
        public DbSet<Consumables> Consumableses { get; set; }
        public DbSet<WareHourse> WareHourses { get; set; }
        public DbSet<WarehouseReceipt> WarehouseReceipts { get; set; }
        public DbSet<WarehouseReceiptRow> WarehouseReceiptRows { get; set; }
        public DbSet<OutboundOrder> OutboundOrders { get; set; }
        public DbSet<OutboundOrderRow> OutboundOrderRows { get; set; }
        public DbSet<ConQuant> ConQuants { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<AssInventory> AssInventories { get; set; }
        public DbSet<AssInventoryResult> AssInventoryResults { get; set; }
        public DbSet<ConInventory> ConInventories { get; set; }
        public DbSet<ConInventoryResult> ConInventoryResults { get; set; }

        #endregion

        /// <summary>
        /// 数据库模型产生时执行
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //比较基础的映射配置,在Domain的Entity文件夹下已经配置了(通过Data Annotations)
            //配置需要额外映射的属性（通过Fluent API）
            modelBuilder.Configurations.Add(new AssLocationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
