using System.Collections.Generic;
using System.Data;
using System.Linq;
using SMOSEC.CommLib;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 耗材的服务接口
    /// </summary>
    public interface IConsumablesService
    {
        #region 查询
        /// <summary>
        /// 根据区域编号和耗材编号得到耗材库存
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        DataTable GetQuants(string LocationID, string CID);
        /// <summary>
        /// 根据耗材编号得到耗材信息
        /// </summary>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        ConsumablesOutputDto GetConsumablesByID(string CID);
        /// <summary>
        /// 得到耗材列表
        /// </summary>
        /// <returns></returns>
        DataTable GetConList();
        /// <summary>
        /// 根据出库单编号得到出库单信息
        /// </summary>
        /// <param name="id">出库单编号</param>
        /// <returns></returns>
        OutboundOrderOutputDto GetOutboundOrderById(string id);

        /// <summary>
        /// 根据用户编号得到出库单列表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        DataTable GetOOListByUserId(string userId, string LocationId);
        /// <summary>
        /// 根据入库单编号得到入库单信息
        /// </summary>
        /// <param name="id">入库单编号</param>
        /// <returns></returns>
        WarehouseReceiptOutputDto GetWarehouseReceiptById(string id);

        /// <summary>
        /// 根据用户编号得到入库单列表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        DataTable GetWRListByUserId(string userId, string LocationId);
        /// <summary>
        /// 根据出库单编号得到出库单行项列表
        /// </summary>
        /// <param name="OOId">出库单编号</param>
        /// <returns></returns>
        DataTable GetOORowListByOOId(string OOId);
        /// <summary>
        /// 根据入库单编号得到入库单行项列表
        /// </summary>
        /// <param name="WRId">入库单编号</param>
        /// <returns></returns>
        DataTable GetWRRowListByWRId(string WRId);
        /// <summary>
        /// 根据区域编号和耗材名称模糊查询耗材信息
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        /// <param name="Name">耗材名称</param>
        /// <returns></returns>
        DataTable GetConListByLocationAndName(string LocationId,string Name);
        /// <summary>
        /// 根据耗材名称得到耗材信息
        /// </summary>
        /// <param name="Name">耗材名称</param>
        /// <returns></returns>
        DataTable GetConListByName(string Name);

        #endregion

        #region 操作
        /// <summary>
        /// 添加耗材
        /// </summary>
        /// <param name="inputDto">耗材信息</param>
        /// <returns></returns>
        ReturnInfo AddConsumables(ConsumablesInputDto inputDto);
        /// <summary>
        /// 更新耗材
        /// </summary>
        /// <param name="inputDto">耗材信息</param>
        /// <returns></returns>
        ReturnInfo UpdateConsumables(ConsumablesInputDto inputDto);
        /// <summary>
        /// 删除耗材
        /// </summary>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        ReturnInfo DeleteConsumables(string CID);
        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="inputDto">入库单信息</param>
        /// <returns></returns>
        ReturnInfo AddWarehouseReceipt(WarehouseReceiptInputDto inputDto);
        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <param name="inputDto">出库单信息</param>
        /// <returns></returns>
        ReturnInfo AddOutboundOrder(OutboundOrderInputDto inputDto);

        #endregion
    }
}