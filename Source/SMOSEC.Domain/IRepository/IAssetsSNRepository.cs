using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 资产序列号的仓储接口，仅用于查询
    /// </summary>
    public interface IAssetsSNRepository : IRepository<AssetsSN>
    {
        /// <summary>
        /// 根据资产条码和序列号返回资产序列号对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetByID(String ASSID,String SN);
        /// <summary>
        /// 查询是否存在
        /// </summary>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        /// <returns></returns>
        bool IsExist(string ASSID, string SN);

        //        /// <summary>
        //        /// 根据SN编号返回SN信息
        //        /// </summary>
        //        /// <param name="ID"></param>
        //        /// <returns></returns>
        //        IQueryable<AssetsSN> GetByID(string ID);

        /// <summary>
        /// 根据区域和资产编号返回SN信息
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="AssID"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetSNByLocationAndASSID(string LocationID, string AssID);

        /// <summary>
        /// 根据区域和资产编号返回某资产闲置的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="AssID"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetUnUsedSNByLocationAndASSID(string LocationID, string AssID);

        /// <summary>
        /// 查询空闲的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetUnUsedAssSN(string LocationID, string Name);

        /// <summary>
        /// 查询空闲的序列号数据(除调入区域外的)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetUnUsedAssSNOther(string LocationID, string Name);

        /// <summary>
        /// 查询空闲的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetUnUsedAssSNEx(string LocationID, string ASSID, string SN);

        /// <summary>
        /// 查询在用的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetInUseAssSN(string LocationID, string Name, string UserID);

        /// <summary>
        /// 查询在用的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetInUseAssSNEx(string LocationID, string ASSID, string SN, string UserID);

        /// <summary>
        /// 查询借用的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetBorrowedAssSN(string LocationID, string Name, string UserID);

        /// <summary>
        /// 查询借用的序列号数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ASSID"></param>
        /// <param name="SN"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<AssetsSN> GetBorrowedAssSNEx(string LocationID, string ASSID, string SN, string UserID);
    }
}
