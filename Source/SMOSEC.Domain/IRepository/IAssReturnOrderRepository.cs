using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    public interface IAssReturnOrderRepository:IRepository<AssReturnOrder>
    {
//        /// <summary>
//        /// 得到对应的归还单列表
//        /// </summary>
//        /// <returns></returns>
//        IQueryable<AssReturnOrder> GetListOrders();

        /// <summary>
        ///     得到对应的归还单列表
        ///     <param name="RTOID"></param>
        /// </summary>
        /// <returns></returns>
        IQueryable<AssReturnOrder> GetByID(string RTOID);

        /// <summary>
        /// 根据用户编号返回归还单信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<AssReturnOrder> GetByUserID(string UserID);

        string GetMaxID();
    }
}