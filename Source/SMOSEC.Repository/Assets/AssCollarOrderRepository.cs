using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{
    public class AssCollarOrderRepository : BaseRepository<AssCollarOrder>, IAssCollarOrderRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssCollarOrderRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        //        /// <summary>
        //        /// 得到对应的领用单列表(待修改)
        //        /// </summary>
        //        /// <returns></returns>
        //        public IQueryable<AssCollarOrder> GetListOrders()
        //        {
        //            return _entities;
        //        }

        /// <summary>
        /// 根据借用单编号返回领用单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<AssCollarOrder> GetById(string id)
        {
            return _entities.Where(a => a.COID == id).AsNoTracking();
        }

        /// <summary>
        /// 根据用户编号返回领用单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<AssCollarOrder> GetByUserId(string userId)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(userId))
            {
                result = result.Where(a => a.USERID == userId);
            }
            return result.AsNoTracking().OrderByDescending(a => a.CREATEDATE);
        }

        public string GetMaxId()
        {
            return _entities.Select(e => e.COID).Max();
        }
    }
}