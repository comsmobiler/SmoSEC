using AutoMapper;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.UI
{
    /// <summary>
    /// AutoMapper配置类
    /// </summary>
    public static class AutomapperConfig
    {
        public static void Init()
        {
            //映射InputDto到Entity
//            Mapper.CreateMap<AssRepairOrder, ROInputDto>();
//            Mapper.CreateMap<AssScrapOrder, SOInputDto>();
//            Mapper.CreateMap<AssTransferOrder, TOInputDto>();
            //映射InputDto到Entity
            Mapper.Initialize(x =>
            {
                //映射InputDto到Entity
                x.CreateMap<AssetsInputDto, Assets>();
                x.CreateMap<AssBorrowOrderInputDto, AssBorrowOrder>();
                //x.CreateMap<AssBorrowOrderRowInputDto, AssBorrowOrder>();
                x.CreateMap<AssCollarOrderInputDto, AssCollarOrder>();
                //x.CreateMap<AssCollarOrderRowInputDto, AssCollarOrderRow>();
                x.CreateMap<AssProcessRecordInputDto, AssProcessRecord>();
                x.CreateMap<AssRestoreOrderInputDto, AssRestoreOrder>();
                // x.CreateMap<AssRestoreOrderRowInputDto, AssRestoreOrderRow>();
                x.CreateMap<AssReturnOrderInputDto, AssReturnOrder>();
                // x.CreateMap<AssReturnOrderRowInputDto, AssReturnOrderRow>();
                x.CreateMap<ConsumablesInputDto, Domain.Entity.Consumables>();
                x.CreateMap<OutboundOrderInputDto, OutboundOrder>();
                x.CreateMap<WarehouseReceiptInputDto, WarehouseReceipt>();


                //映射Entity到查询用的Dto
                x.CreateMap<AssBorrowOrder, AssBorrowOrderOutputDto>();
                x.CreateMap<AssCollarOrder, AssCollarOrderOutputDto>();
                x.CreateMap<Assets, AssetsOutputDto>();
                x.CreateMap<Assets, AssSelectOutputDto>();
                x.CreateMap<AssRestoreOrder, AssRestoreOrderOutputDto>();
                x.CreateMap<AssReturnOrder, AssRestoreOrderOutputDto>();
                x.CreateMap<AssRepairOrder, ROInputDto>();
                x.CreateMap<AssScrapOrder, SOInputDto>();
                x.CreateMap<AssTransferOrder, TOInputDto>();

                x.CreateMap<Domain.Entity.Consumables, ConsumablesOutputDto>();
                x.CreateMap<WarehouseReceipt, WarehouseReceiptOutputDto>();
                x.CreateMap<OutboundOrder, OutboundOrderOutputDto>();

            });
        }
    }
}
