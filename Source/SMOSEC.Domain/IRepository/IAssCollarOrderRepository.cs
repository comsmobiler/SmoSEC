using SMOSEC.Domain.Entity;
using System.Linq;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 领用单查询接口
    /// </summary>
    public interface IAssCollarOrderRepository:IRepository<AssCollarOrder>
    {
        /// <summary>
        /// 根据借用单编号返回领用单信息
        /// </summary>
        /// <param name="id">领用单编号</param>
        /// <returns></returns>
        IQueryable<AssCollarOrder> GetById(string id);

        /// <summary>
        /// 根据用户编号返回领用单信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        IQueryable<AssCollarOrder> GetByUserId(string userId);

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        string GetMaxId();
    }
}