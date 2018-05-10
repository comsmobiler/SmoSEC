using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System;
using System.Linq;

namespace SMOSEC.Repository.Assets
{
    /// <summary>
    /// 固定资产的仓储实现，仅用于查询
    /// </summary>
    public class AssetsRepository : BaseRepository<Domain.Entity.Assets>, IAssetsRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssetsRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据资产条码和区域编号，返回库存信息
        /// </summary>
        /// <param name="ASSID"></param>
        /// <param name="LOCATIONID"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetByTypeID(string TypeID)
        {
            return _entities.Where(x => x.TYPEID  == TypeID);
        }
        /// <summary>
        /// 根据资产条码返回资产信息
        /// </summary>
        /// <param name="ASSID"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetByID(String ASSID)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(ASSID))
            {
                result = result.Where(a => a.ASSID == ASSID);
            }
            return result;
        }
        /// <summary>
         /// 根据序列号返回资产对象
         /// </summary>
         /// <param name="ASSID"></param>
         /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetBySN(String SN)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(SN))
            {
                result = result.Where(a => a.SN == SN);
            }
            return result;
        }
        /// <summary>
        /// 判断当前使用人是否有领用或借用资产
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetByUser(String UserID)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(UserID))
            {
                result = result.Where(a => a.CURRENTUSER == UserID && (a.STATUS == 2 || a.STATUS==5));
            }
            return result;
        }
        /// <summary>
        /// 查询对应状态的资产数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <param name="UserID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetAssByStatus(string LocationID, string Name, string UserID, int Status)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                result = result.Where(a => a.NAME.Contains(Name));
            }
            if (!string.IsNullOrEmpty(UserID))
            {
                result = result.Where(a => a.CURRENTUSER == UserID);
            }
            result = result.Where(a => a.STATUS == Status);
            return result;
        }

        /// <summary>
        /// 查询对应状态的资产数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="SN"></param>
        /// <param name="UserID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetAssByStatusEx(string LocationID, string SN, string UserID, int Status)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(SN))
            {
                result = result.Where(a => a.SN == SN);
            }
            if (!string.IsNullOrEmpty(UserID))
            {
                result = result.Where(a => a.CURRENTUSER == UserID);
            }
            result = result.Where(a => a.STATUS == Status);
            return result;
        }

        /// <summary>
        /// 查询空闲的资产数据(除调入区域外的)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetUnUsedAssOther(string LocationID, string Name)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                result = result.Where(a => a.NAME.Contains(Name));
            }

            result = result.Where(a => a.STATUS == 0);
            return result;
        }
        /// <summary>
        /// 查询即将失效的资产(需联合AssPR)
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetImminentAssets(int days)
        {
            DateTime targetDateTime = DateTime.Now.Date.AddDays(days);
            DateTime Now = DateTime.Now.Date;
            //            return _entities.Where(a => a.EXPIRYDATE >=Now && ASSIDs.Contains(a.ASSID)).AsNoTracking();
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 查询低于安全库存的资产(需联合AssQuant)
        /// </summary>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetLackOfStockAss()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Domain.Entity.Assets> QueryAssets(string SNOrName)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(SNOrName))
            {
                result = result.Where(a => a.SN.Contains(SNOrName) || a.NAME.Contains(SNOrName));
            }
            return result;
        }

        public IQueryable<Domain.Entity.Assets> GetAssetsBySN(string SN)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(SN))
            {
                result = result.Where(a => a.SN==SN);
            }
            return result;
        }

        public string GetMaxID()
        {
            return _entities.Select(e => e.ASSID).Max();
        }

        public bool SNIsExists(string SN)
        {
            return _entities.Any(a => a.SN == SN);
        }
    }
}
