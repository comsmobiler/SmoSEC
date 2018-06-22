using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{
    /// <summary>
    /// 借用单查询实现
    /// </summary>
    public class AssBorrowOrderRepository : BaseRepository<AssBorrowOrder>, IAssBorrowOrderRepository
    {
        /// <summary>
        /// 借用单查询类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssBorrowOrderRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// 根据借用单编号返回借用单信息
        /// </summary>
        /// <param name="id">借用单编号</param>
        /// <returns></returns>
        public IQueryable<AssBorrowOrder> GetById(string id)
        {
            return _entities.Where(a => a.BOID == id);
        }

        /// <summary>
        /// 根据用户编号返回借用单信息
        /// </summary>
        /// <param name="userId">用户编号</param>
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

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxId()
        {
            return _entities.Select(e => e.BOID).Max();
        }
    }
}