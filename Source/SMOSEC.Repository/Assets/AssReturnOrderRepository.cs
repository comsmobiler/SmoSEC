using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{

    /// <summary>
    /// 归还单查询实现
    /// </summary>
    public class AssReturnOrderRepository : BaseRepository<AssReturnOrder>, IAssReturnOrderRepository
    {
        /// <summary>
        /// 归还单查询类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssReturnOrderRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// 得到对应的归还单列表
        /// <param name="RTOID">归还单编号</param>
        /// </summary>
        /// <returns></returns>
        public IQueryable<AssReturnOrder> GetByID(string RTOID)
        {
            return _entities.Where(a => a.RTOID == RTOID);
        }

        /// <summary>
        /// 根据用户编号返回归还单信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public IQueryable<AssReturnOrder> GetByUserID(string UserID)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(UserID))
            {
//                result = result.Where(a => a.RETURNER == UserID);
            }
            return result.AsNoTracking().OrderByDescending(a=>a.CREATEDATE);
        }

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxID()
        {
            return _entities.Select(e => e.RTOID).Max();
        }
    }
}