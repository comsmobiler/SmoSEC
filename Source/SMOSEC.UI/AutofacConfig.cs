using Autofac;
using SMOSEC.Application.IServices;
using SMOSEC.Application.Services;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using SMOSEC.Repository.Assets;
using SMOSEC.Repository.Consumables;
using SMOSEC.Repository.Setting;

namespace SMOSEC.UI
{
    /// <summary>
    /// Autofac配置类
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 区域相关服务接口
        /// </summary>
        public IAssLocationService assLocationService;
        /// <summary>
        /// 资产分类相关服务接口
        /// </summary>
        public IAssTypeService assTypeService;
        /// <summary>
        /// 报修单相关服务接口
        /// </summary>
        public IAssRepairOrderService assRepairOrderService;
        /// <summary>
        /// 资产相关服务接口
        /// </summary>
        public IAssetsService AssetsService;
        /// <summary>
        /// 报废单相关服务接口
        /// </summary>
        public IAssScrapOrderService assScrapOrderService;
        /// <summary>
        /// 各种单据的服务接口，具体啥，自己去看
        /// </summary>
        public ISettingService SettingService;
        /// <summary>
        /// 调拨单相关服务接口
        /// </summary>
        public IAssTransferOrderService assTransferOrderService;
        /// <summary>
        /// 单据通用服务接口
        /// </summary>
        public IOrderCommonService orderCommonService;
        /// <summary>
        /// 用户服务接口
        /// </summary>
        public IcoreUserService coreUserService;
        /// <summary>
        /// 验证表服务接口
        /// </summary>
        public IValidateCodeService ValidateCodeService;

        /// <summary>
        /// 耗材服务接口
        /// </summary>
        public IConsumablesService ConsumablesService;

        /// <summary>
        /// Ioc容器
        /// </summary>
        private ContainerBuilder containerBuilder;

        /// <summary>
        /// 资产盘点单服务接口
        /// </summary>
        public IAssInventoryService AssInventoryService;
        /// <summary>
        /// 耗材盘点单服务接口
        /// </summary>
        public IConInventoryService ConInventoryService;

        /// <summary>
        /// 部门服务接口
        /// </summary>
        public IDepartmentService DepartmentService;
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<SMOSECDbContext>().As<IDbContext>().SingleInstance();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //
            containerBuilder.RegisterType<AssLocationRepository>().As<IAssLocationRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssetsRepository>().As<IAssetsRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AssetsTypeRepository>().As<IAssetsTypeRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssRepairOrderRepository>().As<IAssRepairOrderRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssRepairOrderRowRepository>().As<IAssRepairOrderRowRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssScrapOrderRepository>().As<IAssScrapOrderRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssScrapOrderRowRepository>().As<IAssScrapOrderRowRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssTransferOrderRepository>().As<IAssTransferOrderRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssTransferOrderRowRepository>().As<IAssTransferOrderRowRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssBorrowOrderRepository>().As<IAssBorrowOrderRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssCollarOrderRepository>().As<IAssCollarOrderRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssProcessRecordRepository>().As<IAssProcessRecordRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssRestoreOrderRepository>().As<IAssRestoreOrderRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssReturnOrderRepository>().As<IAssReturnOrderRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssetsSNRepository>().As<IAssetsSNRepository>().InstancePerDependency();
            containerBuilder.RegisterType<coreUserRepository>().As<IcoreUserRepository>().InstancePerDependency();
            containerBuilder.RegisterType<ValidateCodeRepository>().As<IValidateCodeRepository>().InstancePerDependency();
            containerBuilder.RegisterType<AssProcessRecordRepository>().As<IAssProcessRecordRepository>().InstancePerDependency();

            containerBuilder.RegisterType<ConQuantRepository>().As<IConQuantRepository>().InstancePerDependency();
            containerBuilder.RegisterType<ConsumablesRepository>().As<IConsumablesRepository>().InstancePerDependency();
            containerBuilder.RegisterType<OutboundOrderRepository>().As<IOutboundOrderRepository>().InstancePerDependency();
            containerBuilder.RegisterType<WarehouseReceiptRepository>().As<IWarehouseReceiptRepository>().InstancePerDependency();

            containerBuilder.RegisterType<AssInventoryRepository>().As<IAssInventoryRepository>()
                .InstancePerDependency();
            containerBuilder.RegisterType<AssInventoryResultRepository>().As<IAssInventoryResultRepository>()
                .InstancePerDependency();
            containerBuilder.RegisterType<ConInventoryRepository>().As<IConInventoryRepository>()
                .InstancePerDependency();
            containerBuilder.RegisterType<ConInventoryResultRepository>().As<IConInventoryResultRepository>()
                .InstancePerDependency();
            containerBuilder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>()
                .InstancePerDependency();


            containerBuilder.RegisterType<AssLocationService>().As<IAssLocationService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AssetsService>().As<IAssetsService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AssTypeService>().As<IAssTypeService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SettingService>().As<ISettingService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<coreUserService>().As<IcoreUserService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidateCodeService>().As<IValidateCodeService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<OrderCommonService>().As<IOrderCommonService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AssRepairOrderService>().As<IAssRepairOrderService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AssScrapOrderService>().As<IAssScrapOrderService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AssTransferOrderService>().As<IAssTransferOrderService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ConsumablesService>().As<IConsumablesService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AssInventoryService>().As<IAssInventoryService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ConInventoryService>().As<IConInventoryService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();

        }

        /// <summary>
        /// 构造函数,最终得到新的服务实例
        /// </summary>
        public AutofacConfig()
        {
            if (this.containerBuilder == null)
            {
                Init();
            }
            IContainer container = this.containerBuilder.Build();
            IDbContext db = container.Resolve<IDbContext>();
            this.AssetsService = container.Resolve<IAssetsService>();
            this.assLocationService = container.Resolve<IAssLocationService>();
            this.coreUserService = container.Resolve<IcoreUserService>();
            this.ValidateCodeService = container.Resolve<IValidateCodeService>();
            this.assTypeService = container.Resolve<IAssTypeService>();
            this.orderCommonService = container.Resolve<IOrderCommonService>();
            this.assRepairOrderService = container.Resolve<IAssRepairOrderService>();
            this.assScrapOrderService = container.Resolve<IAssScrapOrderService>();
            this.assTransferOrderService = container.Resolve<IAssTransferOrderService>();
            this.SettingService = container.Resolve<ISettingService>();

            this.ConsumablesService = container.Resolve<IConsumablesService>();
            this.AssInventoryService = container.Resolve<IAssInventoryService>();
            this.ConInventoryService = container.Resolve<IConInventoryService>();
            this.DepartmentService = container.Resolve<IDepartmentService>();
        }
    }
}
