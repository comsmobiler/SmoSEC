using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Repository.Assets
{
    /// <summary>
    /// 报废单行项的仓储实现，仅用于查询
    /// </summary>
    public class AssScrapOrderRowRepository : BaseRepository<AssScrapOrderRow>, IAssScrapOrderRowRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssScrapOrderRowRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据报废单行项ID返回报废单行项对象
        /// </summary>
        /// <param name="SOID"></param>
        /// <param name="SOROWID"></param>
        /// <returns></returns>
        public IQueryable<AssScrapOrderRow> GetByID(string SOID, string SOROWID)
        {
            return _entities.Where(x => x.SOID == SOID && x.SOROWID == SOROWID);
        }
        /// <summary>
        /// 根据报废单ID返回报废单行项对象
        /// </summary>
        /// <param name="SOID"></param>
        /// <returns></returns>
        public IQueryable<AssScrapOrderRow> GetBySOID(string SOID)
        {
            return _entities.Where(x => x.SOID == SOID).OrderByDescending(o => o.SOROWID).AsNoTracking();
        }
        /// <summary>
        /// 根据报废单行项返回报废单未还原行项
        /// </summary>
        /// <param name="SOID"></param>
        /// <returns></returns>
        public IQueryable<AssScrapOrderRow> GetScrapBySOID(string SOID)
        {
            return _entities.Where(x => x.SOID == SOID && x.STATUS == 0);
        }
    }
}
