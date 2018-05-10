using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Consumables
{
    public class ConsumablesRepository : BaseRepository<Domain.Entity.Consumables>, IConsumablesRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public ConsumablesRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        public IQueryable<Domain.Entity.Consumables> GetByID(string CID)
        {
            return _entities.Where(a => a.CID == CID);
        }

        public IQueryable<Domain.Entity.Consumables> GetByName(string Name)
        {
            var list = _entities;
            if (!string.IsNullOrEmpty(Name))
            {
                list = list.Where(a => a.NAME.Contains(Name));
            }
            return list;
        }

        public string GetMaxID()
        {
            return _entities.Select(e => e.CID).Max();
        }
    }
}