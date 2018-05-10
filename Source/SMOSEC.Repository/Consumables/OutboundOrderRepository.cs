using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Consumables
{
    public class OutboundOrderRepository : BaseRepository<Domain.Entity.OutboundOrder>, IOutboundOrderRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public OutboundOrderRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        public IQueryable<OutboundOrder> GetById(string id)
        {
            return _entities.Where(a => a.OOID == id);
        }

        public IQueryable<OutboundOrder> GetByUserId(string userId)
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
            return _entities.Select(e => e.OOID).Max();
        }
    }
}