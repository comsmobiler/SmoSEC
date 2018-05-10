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
    /// 报废单的仓储实现，仅用于查询
    /// </summary>
    public  class AssScrapOrderRepository : BaseRepository<AssScrapOrder>, IAssScrapOrderRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssScrapOrderRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据报废单编号，返回报废单信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IQueryable<AssScrapOrder> GetByID(string ID)
        {
            return _entities.Where(x => x.SOID == ID);
        }
        /// <summary>
        /// 根据用户编号查询报废单信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IQueryable<AssScrapOrder> GetByUser(string UserID)
        {
            if (String.IsNullOrEmpty(UserID))
            {
                return _entities.AsNoTracking().OrderByDescending(a => a.CREATEDATE);
            }
            else
            {
                return _entities.Where(x => x.CREATEUSER == UserID).AsNoTracking().OrderByDescending(a => a.CREATEDATE);
            }
        }
        /// <summary>
        /// 得到最大的报废单ID
        /// </summary>
        /// <returns></returns>
        public string GetMaxID()
        {
            return _entities.Select(e => e.SOID).Max();
        }
    }
}
