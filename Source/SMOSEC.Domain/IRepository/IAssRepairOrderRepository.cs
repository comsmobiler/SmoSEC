using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 报修单的仓储接口，仅用于查询信息
    /// </summary>
    public interface IAssRepairOrderRepository:IRepository<AssRepairOrder>
    {
        /// <summary>
        /// 根据报修单编号，返回报修单信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<AssRepairOrder> GetByID(string ID);
        /// <summary>
        /// 根据用户编号查询报修单信息
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<AssRepairOrder> GetByUser(String UserID);
        /// <summary>
        /// 得到最大的报修单ID
        /// </summary>
        /// <returns></returns>
        String GetMaxID();
    }
}
