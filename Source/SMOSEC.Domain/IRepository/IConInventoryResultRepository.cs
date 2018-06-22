using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 耗材盘点单结果行项的查询接口
    /// </summary>
    public interface IConInventoryResultRepository : IRepository<ConInventoryResult>
    {
        /// <summary>
        /// 根据盘点单编号得到结果行项信息
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <param name="Status">状态</param>
        /// <returns></returns>
        IQueryable<ConInventoryResult> GetResultsByStatus(string IID, int? Status);

        /// <summary>
        /// 查询是否已经有盘点单结果记录
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        bool IsExist(string IID);

        /// <summary>
        /// 根据盘点单编号得到结果行项信息
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        IQueryable<ConInventoryResult> GetResultsByCID(string IID, string CID);

        /// <summary>
        /// 根据盘点单编号得到需要盘点的资产列表
        /// </summary>
        /// <param name="IID"></param>
        /// <returns></returns>
        List<string> GetOrdinaryList(string IID);
    }
}
