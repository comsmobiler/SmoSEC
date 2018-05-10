using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System.Data.Entity;
using System;

namespace SMOSEC.Repository.Assets
{
    /// <summary>
    /// 报修单行项仓储的实现，仅用于查询
    /// </summary>
    public class AssRepairOrderRowRepository : BaseRepository<AssRepairOrderRow>, IAssRepairOrderRowRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssRepairOrderRowRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据报修单行项ID返回报修单行项对象
        /// </summary>
        /// <param name="ROID"></param>
        /// <param name="ROROWID"></param>
        /// <returns></returns>
        public IQueryable<AssRepairOrderRow> GetByID(String ROID,String ROROWID)
        {
            return _entities.Where(x=>x.ROID == ROID && x.ROROWID==ROROWID);
        }
        /// <summary>
        /// 根据报修单编号返回报修单行项信息
        /// </summary>
        /// <param name="ROID"></param>
        /// <returns></returns>
        public IQueryable<AssRepairOrderRow> GetByROID(String ROID)
        {
            return _entities.Where(x => x.ROID == ROID).OrderByDescending(o => o.ROROWID).AsNoTracking();
        }
        /// <summary>
        /// 根据报修单编号返回报修单未维修行项信息
        /// </summary>
        /// <param name="ROID"></param>
        /// <returns></returns>
        public IQueryable<AssRepairOrderRow> GetUnRepairByROID(String ROID)
        {
            return _entities.Where(x => x.ROID == ROID && x.STATUS==0);
        }
    }
}
