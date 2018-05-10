using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{
    public class AssBorrowOrderRepository : BaseRepository<AssBorrowOrder>, IAssBorrowOrderRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssBorrowOrderRepository(IDbContext dbContext)
            : base(dbContext)
        { }

//        /// <summary>
//        /// 得到对应的借用单列表(待修改)
//        /// </summary>
//        /// <returns></returns>
//        public IQueryable<AssBorrowOrder> GetListOrders()
//        {
//            return _entities;
//        }

        /// <summary>
        /// 根据借用单编号返回借用单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<AssBorrowOrder> GetById(string id)
        {
            return _entities.Where(a => a.BOID == id);
        }

        /// <summary>
        /// 根据用户编号返回借用单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<AssBorrowOrder> GetByUserId(string userId)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(userId))
            {
                result = result.Where(a => a.BORROWER == userId);
            }
            return result.AsNoTracking().OrderByDescending(a=>a.CREATEDATE);
        }

        public string GetMaxId()
        {
            return _entities.Select(e => e.BOID).Max();
        }
    }
}