using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 报废单的仓储接口，仅用于查询
    /// </summary>
    public interface IAssScrapOrderRowRepository : IRepository<AssScrapOrderRow>
    {
        /// <summary>
        /// 根据报废单行项编号返回报废单行项信息
        /// </summary>
        /// <param name="SOID"></param>
        /// <param name="SOROWID"></param>
        /// <returns></returns>
        IQueryable<AssScrapOrderRow> GetByID(String SOID, String SOROWID);
        /// <summary>
        /// 根据报废单编号返回报废单行项信息
        /// </summary>
        /// <param name="SOID"></param>
        /// <returns></returns>
        IQueryable<AssScrapOrderRow> GetBySOID(String SOID);
        /// <summary>
        /// 根据报废单编号返回报废单未还原行项信息
        /// </summary>
        /// <param name="SOID"></param>
        /// <returns></returns>
        IQueryable<AssScrapOrderRow> GetScrapBySOID(String SOID);
    }
}
