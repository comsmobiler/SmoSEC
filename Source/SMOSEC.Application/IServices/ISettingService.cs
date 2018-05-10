using System.Collections.Generic;
using System.Data;
using System.Linq;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 主数据的服务接口
    /// </summary>
    public interface ISettingService
    {
        #region 查询
        /// <summary>
        /// 根据资产编号返回资产信息
        /// </summary>
        /// <param name="ID">资产编号</param>
        /// <returns></returns>
        AssetsOutputDto  GetAssetsByID(string ID);

        /// <summary>
        /// 得到所有的固定资产
        /// </summary>
        /// <returns></returns>
        DataTable GetAllAss();

        /// <summary>
        /// 查询空闲的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
        /// <returns></returns>
        DataTable GetUnUsedAss(string LocationID, string Name);

        /// <summary>
        /// 查询空闲的资产数据(除调入区域外的)
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
        /// <returns></returns>
        DataTable GetUnUsedAssOther(string LocationID, string Name);

        /// <summary>
        /// 查询空闲的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="SN">资产编号</param>
        /// <returns></returns>
        DataTable GetUnUsedAssEx(string LocationID, string SN);

        /// <summary>
        /// 查询在用的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
        /// <param name="UserID">当前所有者</param>
        /// <returns></returns>
        DataTable GetInUseAss(string LocationID, string Name, string UserID);

        /// <summary>
        /// 查询在用的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="SN">资产编号</param>
        /// <param name="UserID">当前所有者</param>
        /// <returns></returns>
        DataTable GetInUseAssEx(string LocationID, string SN, string UserID);

        /// <summary>
        /// 查询借用的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
        /// <param name="UserID">当前所有者</param>
        /// <returns></returns>
        DataTable GetBorrowedAss(string LocationID, string Name, string UserID);

        /// <summary>
        /// 查询借用的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="SN">资产编号</param>
        /// <param name="UserID">当前所有者</param>
        /// <returns></returns>
        DataTable GetBorrowedAssEx(string LocationID, string SN, string UserID);

        /// <summary>
        /// 查询即将失效的资产
        /// </summary>
        /// <param name="days">距离现在的天数</param>
        /// <returns></returns>
        DataTable GetImminentAssets(int days);

        /// <summary>
        /// 查询低于安全库存的资产
        /// </summary>
        /// <returns></returns>
        DataTable GetLackOfStockAss();

        /// <summary>
        /// 查询处理记录
        /// </summary>
        /// <param name="ASSID">资产编号</param>
        /// <returns></returns>
        DataTable GetRecords(string ASSID);

        /// <summary>
        /// 根据区域和资产编号返回库存信息
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="AssID">资产编号</param>
        /// <returns></returns>
        IQueryable<AssQuant> GetQuants(string LocationID, string AssID);

        DataTable QueryAssets(string SNOrName);

        DataTable GetAssetsBySN(string SN);
        #endregion

        #region 操作
        /// <summary>
        /// 新增资产
        /// </summary>
        /// <param name="entity">资产信息</param>
        /// <returns></returns>
        ReturnInfo AddAssets(AssetsInputDto entity);

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="entity">资产信息</param>
        /// <returns></returns>
        ReturnInfo UpdateAssets(AssetsInputDto entity);       

        #endregion

    }
}