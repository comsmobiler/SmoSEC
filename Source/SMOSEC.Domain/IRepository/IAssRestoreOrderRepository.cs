using SMOSEC.Domain.Entity;
using System.Linq;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 退库单查询接口
    /// </summary>
    public interface IAssRestoreOrderRepository:IRepository<AssRestoreOrder>
    {

        /// <summary>
        /// 得到对应的退库单列表
        /// <param name="RSOID">退库单编号</param>
        /// </summary>
        /// <returns></returns>
        IQueryable<AssRestoreOrder> GetByID(string RSOID);

        /// <summary>
        /// 根据用户编号返回退库单信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        IQueryable<AssRestoreOrder> GetByUserID(string UserID);

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        string GetMaxID();
    }
}