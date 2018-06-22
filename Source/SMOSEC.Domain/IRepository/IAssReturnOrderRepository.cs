using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 归还单查询接口
    /// </summary>
    public interface IAssReturnOrderRepository:IRepository<AssReturnOrder>
    {
        /// <summary>
        /// 得到对应的归还单列表
        /// </summary>
        /// <param name="RTOID">归还单编号</param>
        /// <returns></returns>
        IQueryable<AssReturnOrder> GetByID(string RTOID);

        /// <summary>
        /// 根据用户编号返回归还单信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        IQueryable<AssReturnOrder> GetByUserID(string UserID);

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        string GetMaxID();
    }
}