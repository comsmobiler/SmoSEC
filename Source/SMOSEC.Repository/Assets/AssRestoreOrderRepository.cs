using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{
    public class AssRestoreOrderRepository : BaseRepository<AssRestoreOrder>, IAssRestoreOrderRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssRestoreOrderRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        //        public IQueryable<AssRestoreOrder> GetListOrders()
        //        {
        //            throw new System.NotImplementedException();
        //        }

        /// <summary>
        /// 得到对应的退库单列表
        /// <param name="RSOID"></param>
        /// </summary>
        /// <returns></returns>
        public IQueryable<AssRestoreOrder> GetByID(string RSOID)
        {
            return _entities.Where(a => a.RSOID == RSOID).AsNoTracking();
        }

        /// <summary>
        /// 根据用户编号返回退库单信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IQueryable<AssRestoreOrder> GetByUserID(string UserID)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(UserID))
            {
                result = result.Where(a => a.RESTORER == UserID);
            }
            return result.AsNoTracking().OrderByDescending(a => a.CREATEDATE);
        }

        public string GetMaxID()
        {
            return _entities.Select(e => e.RSOID).Max();
        }
    }
}