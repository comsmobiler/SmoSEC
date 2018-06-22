using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.OutputDTO;
using System;
using System.Collections.Generic;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 单据的服务接口
    /// 各种单据通用的查询
    /// </summary>
    public interface IOrderCommonService
    {
        #region  查询
        /// <summary>
        /// 根据资产条码查询资产对象 
        /// </summary>
        /// <param name="ASSID"></param>
        /// <returns></returns>
        Assets GetAssetsByID(String ASSID);
        /// <summary>
        /// 根据序列号查询资产对象 
        /// </summary>
        /// <param name="ASSID"></param>
        /// <returns></returns>
        Assets GetUnusedAssetsBySN(String SN);
        /// <summary>
        /// 根据耗材名称返回耗材信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Consumables GetConsByName(String Name);
        /// <summary>
        /// 根据耗材编号返回耗材信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Consumables GetConsByID(String ID);
        /// <summary>
        /// 获取资产使用数据
        /// </summary>
        /// <param name="Mode"></param>
        /// <param name="Level1"></param>
        /// <returns></returns>
        List<AssProRecordOutputDto> GetUseAnalyse(string Mode);
        /// <summary>
        /// 获取除选择区域外的空闲耗材库存信息
        /// </summary>
        /// <param name="LocaitionID"></param>
        /// <param name="CID"></param>
        /// <returns></returns>
        List<ConQuant> GetUnUseCon(string LocaitionID,string CID);
        /// <summary>
        /// 根据耗材编号和区域编号获取耗材库存信息
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        ConQuant GetUnUseConByCID(string CID,string LocationID);
        #endregion
    }
}
