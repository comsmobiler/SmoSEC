using SMOSEC.Domain.Entity;
using System.Linq;

namespace SMOSEC.Domain.IRepository
{
    public interface IAssRestoreOrderRepository:IRepository<AssRestoreOrder>
    {
//        /// <summary>
//        /// 得到对应的退库单列表
//        /// </summary>
//        /// <returns></returns>
//        IQueryable<AssRestoreOrder> GetListOrders();

        /// <summary>
        /// 得到对应的退库单列表
        /// <param name="RSOID"></param>
        /// </summary>
        /// <returns></returns>
        IQueryable<AssRestoreOrder> GetByID(string RSOID);

        /// <summary>
        /// 根据用户编号返回退库单信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<AssRestoreOrder> GetByUserID(string UserID);

        string GetMaxID();
    }
}