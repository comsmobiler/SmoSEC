using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{
    public class AssRestoreOrderRowRepository : BaseRepository<AssRestoreOrderRow>, IAssRestoreOrderRowRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssRestoreOrderRowRepository(IDbContext dbContext)
            : base(dbContext)
        { }

//        /// <summary>
//        /// 得到对应的退库单行项列表(待修改)
//        /// <param name="RSOID"></param>
//        /// <param name="ASSIDs"></param>
//        /// </summary>
//        /// <returns></returns>
//        public IQueryable<AssRestoreOrderRow> GetRowsByRSOID(string RSOID, List<string> ASSIDs)
//        {
//            return _entities.Where(a => a.RSOId == RSOID&&ASSIDs.Contains(a.ASSID)).AsNoTracking();
//        }
    }
}