using SMOSEC.Domain.Entity;
using System.Linq;

namespace SMOSEC.Domain.IRepository
{
    public interface IAssCollarOrderRepository:IRepository<AssCollarOrder>
    {
//        /// <summary>
//        /// 得到对应的领用单列表
//        /// </summary>
//        /// <returns></returns>
//        IQueryable<AssCollarOrder> GetListOrders();

        /// <summary>
        /// 根据借用单编号返回领用单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<AssCollarOrder> GetById(string id);

        /// <summary>
        /// 根据用户编号返回领用单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IQueryable<AssCollarOrder> GetByUserId(string userId);

        string GetMaxId();
    }
}