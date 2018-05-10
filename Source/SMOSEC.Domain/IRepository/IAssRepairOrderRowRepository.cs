using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 报修单行项的仓储接口，仅用于查询信息
    /// </summary>
    public interface IAssRepairOrderRowRepository : IRepository<AssRepairOrderRow>
    {
        /// <summary>
        /// 根据报修单行项编号返回报修单行项信息
        /// </summary>
        /// <param name="ROID"></param>
        /// <param name="RPOROWID"></param>
        /// <returns></returns>
        IQueryable<AssRepairOrderRow> GetByID(String ROID,String RPOROWID);
        /// <summary>
        /// 根据报修单编号返回报修单行项信息
        /// </summary>
        /// <param name="ROID"></param>
        /// <returns></returns>
        IQueryable<AssRepairOrderRow> GetByROID(String ROID);
        /// <summary>
        /// 根据报修单编号返回报修单未维修行项信息
        /// </summary>
        /// <param name="ROID"></param>
        /// <returns></returns>
        IQueryable<AssRepairOrderRow> GetUnRepairByROID(String ROID);
    }
}
