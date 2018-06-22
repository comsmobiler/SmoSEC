using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMOSEC.Repository.Consumables
{
    /// <summary>
    /// 耗材盘点单结果行项查询实现
    /// </summary>
    public class ConInventoryResultRepository : BaseRepository<ConInventoryResult>, IConInventoryResultRepository
    {
        /// <summary>
        /// 盘点单结果行项查询类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public ConInventoryResultRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// 根据耗材盘点单编号得到结果行项信息
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public IQueryable<ConInventoryResult> GetResultsByStatus(string IID, int? Status)
        {
            var result = _entities.Where(a => a.IID == IID);
            if (Status != null)
            {
                if (Status == (int)ResultStatus.待盘点)
                {
                    result = result.Where(a => a.RESULT == Status);
                }
                else
                {
                    result = result.Where(a => a.RESULT == 1 || a.RESULT == 2 || a.RESULT == 3);
                }

            }
            return result;
        }

        /// <summary>
        /// 查询是否已经有盘点单结果记录
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public bool IsExist(string IID)
        {
            return _entities.Any(a => a.IID == IID);
        }
        /// <summary>
        /// 根据盘点单编号得到结果行项信息
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        public IQueryable<ConInventoryResult> GetResultsByCID(string IID, string CID)
        {
            var result = _entities.Where(a => a.IID == IID);
            if (!string.IsNullOrEmpty(CID))
            {
                result = result.Where(a => a.CID == CID);
            }
            return result;
        }

        /// <summary>
        /// 根据盘点单编号得到需要盘点的资产列表
        /// </summary>
        /// <param name="IID"></param>
        /// <returns></returns>
        public List<string> GetOrdinaryList(string IID)
        {
            int no = (int)ResultStatus.盘盈;
            var result = _entities.Where(a => a.IID == IID && a.RESULT != no).Select(a => a.CID);
            return result.ToList();
        }
    }
}
