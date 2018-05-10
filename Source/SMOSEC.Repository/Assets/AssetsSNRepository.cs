using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Repository.Assets
{
    /// <summary>
    /// 资产序列号的仓储实现，仅用于查询
    /// </summary>
    public class AssetsSNRepository : BaseRepository<AssetsSN>, IAssetsSNRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssetsSNRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据资产条码和区域编号，返回库存信息
        /// </summary>
        /// <param name="ASSID"></param>
        /// <param name="LOCATIONID"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetByID(string ASSID, string SN)
        {
            return _entities.Where(x => x.ASSID == ASSID && x.SN == SN);
        }
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        /// <returns></returns>
        public bool IsExist(string ASSID, string SN)
        {
            return _entities.Any(a => a.ASSID == ASSID && a.SN == SN);
        }

        //        public IQueryable<AssetsSN> GetByID(string ID)
        //        {
        //            return _entities.Where(a=>a.SN)
        //        }

        /// <summary>
        /// 根据区域和资产编号返回SN信息
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="AssID"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetSNByLocationAndASSID(string LocationID, string AssID)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(AssID))
            {
                result = result.Where(a => a.ASSID == AssID);
            }
            return result.AsNoTracking();
        }

        /// <summary>
        /// 根据区域和资产编号返回某资产闲置的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="AssID"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetUnUsedSNByLocationAndASSID(string LocationID, string AssID)
        {
            int status = (int)STATUS.闲置;
            var result = _entities.Where(a => a.STATUS == status);
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(AssID))
            {
                result = result.Where(a => a.ASSID == AssID);
            }
            return result.AsNoTracking();
        }

        /// <summary>
        /// 查询空闲的序列号数据(需要联合Assets)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetUnUsedAssSN(string LocationID, string Name)
        {
            int status = (int)STATUS.闲置;
            var result = _entities.Where(a => a.STATUS == status);
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                //                result = result.Where(a => a. == AssID);
            }
            return result.AsNoTracking();
        }

        /// <summary>
        /// 查询空闲的序列号数据(除调入区域外的)(需要联合Assets)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetUnUsedAssSNOther(string LocationID, string Name)
        {
            int status = (int)STATUS.闲置;
            var result = _entities.Where(a => a.STATUS == status);
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            //            if (!string.IsNullOrEmpty(AssID))
            //            {
            //                result = result.Where(a => a.ASSID == AssID);
            //            }
            return result.AsNoTracking();
        }

        /// <summary>
        /// 查询空闲的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetUnUsedAssSNEx(string LocationID, string ASSID, string SN)
        {
            int status = (int)STATUS.闲置;
            var result = _entities.Where(a => a.STATUS == status);
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(ASSID))
            {
                result = result.Where(a => a.ASSID == ASSID);
            }
            if (!string.IsNullOrEmpty(SN))
            {
                result = result.Where(a => a.SN == SN);
            }
            return result.AsNoTracking();
        }

        /// <summary>
        /// 查询在用的序列号数据(需联合AssCO)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetInUseAssSN(string LocationID, string Name, string UserID)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 查询在用的序列号数据(需联合AssCO)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetInUseAssSNEx(string LocationID, string ASSID, string SN, string UserID)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 查询借用的序列号数据(需联合AssBO)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetBorrowedAssSN(string LocationID, string Name, string UserID)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 查询借用的序列号数据(需联合AssBO)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IQueryable<AssetsSN> GetBorrowedAssSNEx(string LocationID, string ASSID, string SN, string UserID)
        {
            throw new System.NotImplementedException();
        }
    }
}
