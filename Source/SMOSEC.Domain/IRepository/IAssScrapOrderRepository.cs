using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 报废单的仓储接口，仅用于查询信息
    /// </summary>
    public interface IAssScrapOrderRepository:IRepository<AssScrapOrder>
    {
        /// <summary>
        /// 根据报废单编号，返回报废单信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<AssScrapOrder> GetByID(string ID);
        /// <summary>
        /// 根据用户编号查询报废单信息
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<AssScrapOrder> GetByUser(String UserID);
        /// <summary>
        /// 得到最大的报废单ID
        /// </summary>
        /// <returns></returns>
        String GetMaxID();
    }
}
