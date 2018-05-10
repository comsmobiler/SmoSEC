using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System;
using System.Linq;

namespace SMOSEC.Repository.Assets
{
    /// <summary>
    /// 区域的仓储实现，仅用于查询
    /// </summary>
    public class AssLocationRepository : BaseRepository<AssLocation>, IAssLocationRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssLocationRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据区域编号返回区域对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IQueryable<AssLocation> GetByID(string LOCATIONID)
        {
            return _entities.Where(x => x.LOCATIONID == LOCATIONID);
        }
        /// <summary>
        /// 得到所有已启用的区域信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<AssLocation> GetEnableAll()
        {
            return _entities.Where(x => x.ISENABLE == 1);
        }
        /// <summary>
        /// 根据区域管理员返回区域信息
        /// </summary>
        /// <param name="Manager"></param>
        /// <returns></returns>
        public IQueryable<AssLocation> GetByManager(String Manager)
        {
            return _entities.Where(x => x.MANAGER == Manager);
        }
    }
}
