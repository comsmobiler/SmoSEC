using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 出库单查询接口
    /// </summary>
    public interface IOutboundOrderRepository : IRepository<OutboundOrder>
    {
        /// <summary>
        /// 根据出库单编号返回出库单信息
        /// </summary>
        /// <param name="id">出库单编号</param>
        /// <returns></returns>
        IQueryable<OutboundOrder> GetById(string id);

        /// <summary>
        /// 根据用户编号返回出库单信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        IQueryable<OutboundOrder> GetByUserId(string userId);

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        string GetMaxId();
    }
}