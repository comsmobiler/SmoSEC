using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 资产类别的服务接口
    /// </summary>
    public interface IAssTypeService
    {
        #region 查询
        /// <summary>
        /// 返回所有资产类别信息
        /// </summary>
        /// <returns></returns>
        List<AssetsType> GetAll();
        /// <summary>
        /// 根据资产类别编号返回资产类别信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        AssetsType GetByID(String ID);
        /// <summary>
        /// 根据资产类别编号判断该分类下是否有相关资产数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Boolean HasAssets(String ID);
        /// <summary>
        /// 根据编号判断是否为父分类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Boolean IsParent(String ID);
        #endregion
        # region 操作
        /// <summary>
        /// 新增资产类别
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnInfo AddAssetsType(AssetsType entity);
        /// <summary>
        /// 更新资产类别
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnInfo UpdateAssetsType(AssetsType entity);
        /// <summary>
        /// 删除资产类别
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        ReturnInfo DeleteAssetsType(String  ID);
        #endregion   
    }
}
