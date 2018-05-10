using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
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
        /// <param name="QID"></param>
        /// <returns></returns>
        IQueryable<ConQuant> GetByID(int QID);
        /// <summary>
        /// 根据耗材编号和区域编号查询库存信息
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        IQueryable<ConQuant> GetByCID(string  CID, string LocationID);
        /// <summary>
        /// 查询除选择区域外的空闲的耗材信息
        /// </summary>
        /// <returns></returns>
        IQueryable<ConQuant> GetUnUserCon(string LocationID,string CID);

    }
}