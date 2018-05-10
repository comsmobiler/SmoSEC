using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    public interface IAssBorrowOrderRepository : IRepository<AssBorrowOrder>
    {
//        /// <summary>
//        /// 得到对应的借用单列表
//        /// </summary>
//        /// <returns></returns>
//        IQueryable<AssBorrowOrder> GetListOrders();

        /// <summary>
        /// 根据借用单编号返回借用单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<AssBorrowOrder> GetById(string id);

        /// <summary>
        /// 根据用户编号返回借用单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IQueryable<AssBorrowOrder> GetByUserId(string userId);

        string GetMaxId();
    }
}