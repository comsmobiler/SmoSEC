using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Consumables
{
    /// <summary>
    /// 入库单查询实现
    /// </summary>
    public class WarehouseReceiptRepository : BaseRepository<Domain.Entity.WarehouseReceipt>, IWarehouseReceiptRepository
    {
        /// <summary>
        /// 入库单查询类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public WarehouseReceiptRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// 根据编号得到入库单
        /// </summary>
        /// <param name="id">入库单编号</param>
        /// <returns></returns>
        public IQueryable<WarehouseReceipt> GetById(string id)
        {
            return _entities.Where(a => a.WRID == id);
        }

        /// <summary>
        /// 根据用户编号得到入库单
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public IQueryable<WarehouseReceipt> GetByUserId(string userId)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(userId))
            {
                result = result.Where(a => a.HANDLEMAN == userId);
            }
            return result;
        }

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxId()
        {
            return _entities.Select(e => e.WRID).Max();
        }
    }
}