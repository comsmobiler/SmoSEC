using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Consumables
{
    public class WarehouseReceiptRepository : BaseRepository<Domain.Entity.WarehouseReceipt>, IWarehouseReceiptRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public WarehouseReceiptRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        public IQueryable<WarehouseReceipt> GetById(string id)
        {
            return _entities.Where(a => a.WRID == id);
        }

        public IQueryable<WarehouseReceipt> GetByUserId(string userId)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(userId))
            {
                result = result.Where(a => a.HANDLEMAN == userId);
            }
            return result;
        }

        public string GetMaxId()
        {
            return _entities.Select(e => e.WRID).Max();
        }
    }
}