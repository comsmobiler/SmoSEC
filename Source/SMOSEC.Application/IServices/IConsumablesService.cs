using System.Collections.Generic;
using System.Data;
using System.Linq;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.Application.IServices
{
    public interface IConsumablesService
    {
        #region 查询

        DataTable GetQuants(string LocationID, string CID);
//        bool QuantIsExist(string LocationID, string CID);
        ConsumablesOutputDto GetConsumablesByID(string CID);
        DataTable GetConList();
        OutboundOrderOutputDto GetOutboundOrderById(string id);
        DataTable GetOOListByUserId(string userId);
        WarehouseReceiptOutputDto GetWarehouseReceiptById(string id);
        DataTable GetWRListByUserId(string userId);
        DataTable GetOORowListByOOId(string OOId);
        DataTable GetWRRowListByWRId(string WRId);
        DataTable GetConListByLocationAndName(string LocationId,string Name);
        DataTable GetConListByName(string Name);

        #endregion

        #region 操作

        ReturnInfo AddConsumables(ConsumablesInputDto inputDto);
        ReturnInfo UpdateConsumables(ConsumablesInputDto inputDto);
        ReturnInfo DeleteConsumables(string CID);
        ReturnInfo AddWarehouseReceipt(WarehouseReceiptInputDto inputDto);
        ReturnInfo AddOutboundOrder(OutboundOrderInputDto inputDto);

        #endregion
    }
}