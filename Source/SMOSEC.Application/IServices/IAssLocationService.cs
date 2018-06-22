using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;
using System;
using System.Collections.Generic;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 区域的服务接口
    /// </summary>
    public interface IAssLocationService
    {
        #region 查询
        /// <summary>
        /// 根据区域编号返回区域信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        AssLocation GetByID(string ID);
        /// <summary>
        /// 根据区域管理员返回区域信息
        /// </summary>
        /// <param name="Manager"></param>
        /// <returns></returns>
        AssLocation GetByManager(string Manager);
        /// <summary>
        /// 返回所有区域信息
        /// </summary>
        /// <returns></returns>
        List<AssLocation> GetAll();
        /// <summary>
        /// 返回所有启用的区域信息
        /// </summary>
        /// <returns></returns>
        List<AssLocation> GetEnableAll();
        #endregion
        # region 操作
        /// <summary>
        /// 新增区域
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnInfo AddAssLocation(AssLocation entity);
        /// <summary>
        /// 更新区域信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="OldManager"></param>
        /// <returns></returns>
        ReturnInfo UpdateAssLocation(AssLocation entity,String OldManager);
        /// <summary>
        /// 删除区域信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        ReturnInfo DeleteAssLocation(String ID);
        /// <summary>
        /// 更改区域启用状态
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        ReturnInfo ChangeEnable(String LocationID, IsEnable status);
        #endregion
    }
}
