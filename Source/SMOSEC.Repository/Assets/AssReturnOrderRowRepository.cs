using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{
    public class AssReturnOrderRowRepository : BaseRepository<AssReturnOrderRow>, IAssReturnOrderRowRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssReturnOrderRowRepository(IDbContext dbContext)
            : base(dbContext)
        { }

//        /// <summary>
//        /// 得到对应的归还单行项列表(待修改)
//        /// <param name="RTOID"></param>
//        /// <param name="ASSIDs"></param>
//        /// </summary>
//        /// <returns></returns>
//        public IQueryable<AssReturnOrderRow> GetRowsByRTOID(string RTOID, List<string> ASSIDs)
//        {
//            return _entities.Where(a => a.RTOID == RTOID&&ASSIDs.Contains(a.ASSID)).AsNoTracking();
//        }
    }
}