using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{
    public class AssCollarOrderRowRepository : BaseRepository<AssCollarOrderRow>, IAssCollarOrderRowRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssCollarOrderRowRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        //        /// <summary>
        //        /// 根据领用单编号返回领用单行项信息
        //        /// </summary>
        //        /// <param name="COID"></param>
        //        /// <returns></returns>
        //        public IQueryable<AssCollarOrderRow> GetByCOID(string COID)
        //        {
        //            return _entities.Where(a => a.COID == COID).AsNoTracking();
        //        }
        //
        //        /// <summary>
        //        /// 根据领用单编号返回领用单行项信息
        //        /// </summary>
        //        /// <param name="ID"></param>
        //        /// <returns></returns>
        //        public IQueryable<AssCollarOrderRow> GetByID(string ID)
        //        {
        //            return _entities.Where(a => a.COROWID == ID).AsNoTracking();
        //        }

//        /// <summary>
//        /// 得到对应的领用单行项列表(待修改)
//        /// <param name="COID"></param>
//        /// <param name="ASSIDs"></param>
//        /// </summary>
//        /// <returns></returns>
//        public IQueryable<AssCollarOrderRow> GetRowsByCOID(string COID, List<string> ASSIDs)
//        {
//            return _entities.Where(a => a.COID == COID&&ASSIDs.Contains(a.ASSID)).AsNoTracking();
//        }
    }
}