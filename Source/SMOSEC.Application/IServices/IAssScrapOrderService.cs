using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.InputDTO;
using System;
using System.Collections.Generic;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 报修单的服务接口
    /// </summary>
    public interface IAssScrapOrderService
    {
        #region 查询
        /// <summary>
        /// 根据报废单编号返回报废单信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        SOInputDto GetByID(string ID);
        /// <summary>
        /// 根据用户编号，返回报废单
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        List<AssScrapOrder> GetByUser(String UserID);
        #endregion

        #region 操作
        /// <summary>
        /// 新增报废单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnInfo AddAssScrapOrder(SOInputDto entity);
        /// <summary>
        /// 更新报废单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnInfo UpdateAssScrapOrder(SOInputDto entity);
        #endregion
    }
}
