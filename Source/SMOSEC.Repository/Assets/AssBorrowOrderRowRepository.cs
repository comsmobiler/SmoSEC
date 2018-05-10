using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.Infrastructure;

namespace SMOSEC.Repository.Assets
{
    public class AssBorrowOrderRowRepository : BaseRepository<AssBorrowOrderRow>, IAssBorrowOrderRowRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssBorrowOrderRowRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        //        /// <summary>
        //        /// 根据借用单编号返回借用单行项信息
        //        /// </summary>
        //        /// <param name="BOID"></param>
        //        /// <returns></returns>
        //        public IQueryable<AssBorrowOrderRow> GetByBOID(string BOID)
        //        {
        //            return _entities.Where(a => a.BOID == BOID).AsNoTracking().OrderByDescending(a=>a.CREATEDATE);
        //        }
        //
        //        /// <summary>
        //        /// 根据借用单行项编号返回借用单行项信息
        //        /// </summary>
        //        /// <param name="ID"></param>
        //        /// <returns></returns>
        //        public IQueryable<AssBorrowOrderRow> GetByID(string ID)
        //        {
        //            return _entities.Where(a => a.BOROWID == ID);
        //        }

        /// <summary>
        /// 得到对应的借用单行项列表(待修改)
        /// <param name="boid"></param>
        /// <param name="assiDs"></param>
        /// </summary>
        /// <returns></returns>
        public IQueryable<AssBorrowOrderRow> GetRowsByBoid(string boid, List<string> assiDs)
        {
            return _entities.Where(a => a.BOID == boid&&assiDs.Contains(a.ASSID)).AsNoTracking();
        }
    }
}