using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 固定资产的仓储接口，仅用于查询
    /// </summary>
    public interface IAssetsRepository : IRepository<Assets>
    {
        /// <summary>
        ///  根据类型编号返回资产对象
        /// </summary>
        /// <param name="TypeID"></param>
        /// <returns></returns>
        IQueryable<Assets> GetByTypeID(String TypeID);
        /// <summary>
        /// 根据资产条码返回资产对象
        /// </summary>
        /// <param name="ASSID"></param>
        /// <returns></returns>
        IQueryable<Assets> GetByID(String ASSID);
		/// <summary>
        /// 根据序列号返回资产对象
        /// </summary>
        /// <param name="ASSID"></param>
        /// <returns></returns>
        IQueryable<Assets> GetBySN(String SN);
        /// <summary>
        /// 判断当前使用人是否有领用或借用资产
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IQueryable<Assets> GetByUser(String UserID);
        /// <summary>
        /// 查询对应状态的资产数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <param name="UserID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        IQueryable<Assets> GetAssByStatus(string LocationID, string Name, string UserID, int Status);

        /// <summary>
        /// 查询对应状态的资产数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ID"></param>
        /// <param name="UserID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        IQueryable<Assets> GetAssByStatusEx(string LocationID, string ID, string UserID, int Status);
        /// <summary>
        /// 查询空闲的资产数据(除调入区域外的)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        IQueryable<Assets> GetUnUsedAssOther(string LocationID, string Name);
        /// <summary>
        /// 查询即将失效的资产
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        IQueryable<Assets> GetImminentAssets(int days);

        /// <summary>
        /// 查询低于安全库存的资产
        /// </summary>
        /// <returns></returns>
        IQueryable<Assets> GetLackOfStockAss();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="SNOrName"></param>
        /// <returns></returns>
        IQueryable<Assets> QueryAssets(string SNOrName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        IQueryable<Assets> GetAssetsBySN(string SN);
        bool SNIsExists(string SN);
        string GetMaxID();
    }
}
