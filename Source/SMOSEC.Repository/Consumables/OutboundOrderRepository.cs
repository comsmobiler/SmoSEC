using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Consumables
{
    /// <summary>
    /// 出库单的查询实现
    /// </summary>
    public class OutboundOrderRepository : BaseRepository<Domain.Entity.OutboundOrder>, IOutboundOrderRepository
    {
        /// <summary>
        /// 出库单查询类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public OutboundOrderRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// 根据编号得到出库单信息
        /// </summary>
        /// <param name="id">出库单编号</param>
        /// <returns></returns>
        public IQueryable<OutboundOrder> GetById(string id)
        {
            return _entities.Where(a => a.OOID == id);
        }

        /// <summary>
        /// 根据用户编号，得到出库单列表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public IQueryable<OutboundOrder> GetByUserId(string userId)
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
            return _entities.Select(e => e.OOID).Max();
        }
    }
}