using System;
using System.Data;
using SMOSEC.CommLib;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 资产操作(借用,归还,领用,退库)的服务接口
    /// </summary>
    public interface IAssetsService
    {
        #region 查询
        /// <summary>
        /// 根据借用单编号返回借用单信息
        /// </summary>
        /// <param name="id">借用单编号</param>
        /// <returns></returns>
        AssBorrowOrderOutputDto GetBobyId(string id);

        /// <summary>
        /// 根据用户编号返回借用单信息,用户编号为空则返回全部
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        DataTable GetBoByUserId(string userId,string LocationId);

        /// <summary>
        /// 得到对应的借用单行项列表
        /// <param name="boid">借用单编号</param>
        /// </summary>
        /// <returns></returns>
        DataTable GetRowsByBoid(string boid);

        /// <summary>
        /// 根据领用单编号返回领用单信息
        /// </summary>
        /// <param name="id">领用单编号</param>
        /// <returns></returns>
        AssCollarOrderOutputDto GetCobyId(string id);

        /// <summary>
        /// 根据用户编号返回领用单信息,用户编号为空则返回全部
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        DataTable GetCoByUserId(string userId, string LocationId);

        /// <summary>
        /// 得到对应的领用单行项列表
        /// <param name="coid">领用单编号</param>
        /// </summary>
        /// <returns></returns>
        DataTable GetRowsByCoid(string coid);

        /// <summary>
        /// 得到对应的退库单信息
        /// <param name="rsoid">退库单编号</param>
        /// </summary>
        /// <returns></returns>
        AssRestoreOrderOutputDto GetRsobyId(string rsoid);

        /// <summary>
        /// 根据用户编号返回退库单信息,用户编号为空则返回全部
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        DataTable GetRsoByUserId(string userId, string LocationId);

        /// <summary>
        /// 得到对应的退库单行项列表
        /// <param name="rsoid">退库单编号</param>
        /// </summary>
        /// <returns></returns>
        DataTable GetRowsByRsoid(string rsoid);

        /// <summary>
        /// 得到对应的归还单列表
        /// <param name="rtoid">归还单编号</param>
        /// </summary>
        /// <returns></returns>
        AssReturnOrderOutputDto GetRtobyId(string rtoid);

        /// <summary>
        /// 根据用户编号返回归还单信息,用户编号为空则返回全部
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        DataTable GetRtoByUserId(string userId, string LocationId);

        /// <summary>
        /// 得到对应的归还单行项列表
        /// <param name="rtoid">归还单编号</param>
        /// </summary>
        /// <returns></returns>
        DataTable GetRowsByRtoid(string rtoid);
        #endregion

        #region 操作
        /// <summary>
        /// 添加借用单
        /// </summary>
        /// <param name="borrowOrderInput">借用单信息</param>
        /// <returns></returns>
        ReturnInfo AddAssBorrowOrder(AssBorrowOrderInputDto borrowOrderInput);

        /// <summary>
        /// 添加领用单
        /// </summary>
        /// <param name="collarOrderInput">领用单信息</param>
        /// <returns></returns>
        ReturnInfo AddAssCollarOrder(AssCollarOrderInputDto collarOrderInput);

        /// <summary>
        /// 添加归还单
        /// </summary>
        /// <param name="returnOrderInput">归还单信息</param>
        /// <returns></returns>
        ReturnInfo AddAssReturnOrder(AssReturnOrderInputDto returnOrderInput);

        /// <summary>
        /// 添加退库单
        /// </summary>
        /// <param name="restoreOrderInput">退库单信息</param>
        /// <returns></returns>
        ReturnInfo AddAssRestoreOrder(AssRestoreOrderInputDto restoreOrderInput);
        /// <summary>
        /// 更换使用者
        /// </summary>
        /// <param name="ASSID">资产编号</param>
        /// <param name="CurrentUser">当前使用者</param>
        /// <param name="UserID">操作用户</param>
        /// <returns></returns>
        ReturnInfo ChangeUser(String ASSID, String CurrentUser, String UserID);

        #endregion
    }
}