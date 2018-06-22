using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 借用单查询接口
    /// </summary>
    public interface IAssBorrowOrderRepository : IRepository<AssBorrowOrder>
    {
        /// <summary>
        /// 根据借用单编号返回借用单信息
        /// </summary>
        /// <param name="id">借用单编号</param>
        /// <returns></returns>
        IQueryable<AssBorrowOrder> GetById(string id);

        /// <summary>
        /// 根据用户编号返回借用单信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        IQueryable<AssBorrowOrder> GetByUserId(string userId);

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        string GetMaxId();
    }
}