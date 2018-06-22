using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 耗材库存查询接口
    /// </summary>
    public interface IConQuantRepository : IRepository<ConQuant>
    {
        /// <summary>
        /// 是否存在库存
        /// </summary>
        /// <param name="LocationID">区域</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        bool IsExist(string LocationID, string CID);

        /// <summary>
        /// 根据区域和资产编号返回库存信息
        /// </summary>
        /// <param name="LocationID">区域</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        IQueryable<ConQuant> GetQuants(string LocationID, string CID);
	/// <summary>
        /// 根据编号查询库存信息
        /// </summary>
        /// <param name="QID">库存编号</param>
        /// <returns></returns>
        IQueryable<ConQuant> GetByID(int QID);

        /// <summary>
        /// 根据耗材编号和区域编号查询库存信息
        /// </summary>
        /// <param name="CID">耗材编号</param>
        /// <param name="LocationID">区域编号</param>
        /// <returns></returns>
        IQueryable<ConQuant> GetByCID(string  CID, string LocationID);

        /// <summary>
        /// 查询除选择区域外的空闲的耗材信息
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        IQueryable<ConQuant> GetUnUserCon(string LocationID,string CID);
        /// <summary>
        /// 根据区域编号,得到盘点清单
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        IQueryable<ConQuant> GetInventoryCons(string LocationId);


    }
}