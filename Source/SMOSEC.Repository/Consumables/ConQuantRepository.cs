using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System;

namespace SMOSEC.Repository.Consumables
{
    public class ConQuantRepository : BaseRepository<Domain.Entity.ConQuant>, IConQuantRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public ConQuantRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        public IQueryable<ConQuant> GetQuants(string LocationID, string CID)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(CID))
            {
                result = result.Where(a => a.CID == CID);
            }
            return result;
        }

        public bool IsExist(string LocationID, string CID)
        {
            return _entities.Any(x => x.LOCATIONID == LocationID && x.CID == CID);
        }
        /// <summary>
        /// 根据编号查询库存信息
        /// </summary>
        /// <param name="QID"></param>
        /// <returns></returns>
        public IQueryable<ConQuant> GetByID(int QID)
        {
            return _entities.Where(x => x.QID == QID);
        }
        /// <summary>
        /// 获取除选择区域外的空闲的耗材信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<ConQuant> GetUnUserCon(string LocationID, string CID)
        {
            if (String.IsNullOrEmpty(CID))
                return _entities.Where(x => x.QUANTITY > 0 && x.LOCATIONID != LocationID);
            else
                return _entities.Where(x => x.QUANTITY > 0 && x.CID == CID && x.LOCATIONID != LocationID);
        }
        /// <summary>
        /// 根据耗材编号和区域编号查询库存信息
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public IQueryable<ConQuant> GetByCID(string CID, string LocationID)
        {
            return _entities.Where(x => x.CID == CID && x.LOCATIONID == LocationID);
        }
    }
}