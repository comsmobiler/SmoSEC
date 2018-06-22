using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System;

namespace SMOSEC.Repository.Consumables
{
    /// <summary>
    /// 耗材库存查询实现
    /// </summary>
    public class ConQuantRepository : BaseRepository<Domain.Entity.ConQuant>, IConQuantRepository
    {
        /// <summary>
        /// 耗材库存查询类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public ConQuantRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// 根据区域和耗材编号得到库存信息
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
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

        /// <summary>
        /// 查询耗材在某区域是否存在库存
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        public bool IsExist(string LocationID, string CID)
        {
            return _entities.Any(x => x.LOCATIONID == LocationID && x.CID == CID);
        }
        /// <summary>
        /// 根据编号查询库存信息
        /// </summary>
        /// <param name="QID">库存编号</param>
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
        /// <param name="CID">耗材编号</param>
        /// <param name="LocationID">区域编号</param>
        /// <returns></returns>
        public IQueryable<ConQuant> GetByCID(string CID, string LocationID)
        {
            return _entities.Where(x => x.CID == CID && x.LOCATIONID == LocationID);
        }
        /// <summary>
        /// 根据区域编号,得到盘点清单
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        public IQueryable<ConQuant> GetInventoryCons(string LocationId)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationId))
            {
                result = result.Where(a => a.LOCATIONID == LocationId);
            }
            return result;
        }

    }
}