using System;
using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    public interface IConsumablesRepository : IRepository<Consumables>
    {
//        /// <summary>
//        ///  根据类型编号返回资产对象
//        /// </summary>
//        /// <param name="TypeID"></param>
//        /// <returns></returns>
//        IQueryable<Assets> GetByTypeID(String TypeID);
        /// <summary>
        /// 根据耗材条码返回耗材对象
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        IQueryable<Consumables> GetByID(String CID);

        /// <summary>
        /// 根据耗材名称返回耗材对象
        /// </summary>
        /// <param name="Name">耗材名称</param>
        /// <returns></returns>
        IQueryable<Consumables> GetByName(String Name);
        //        /// <summary>
        //        /// 查询对应状态的资产数据
        //        /// </summary>
        //        /// <param name="LocationID"></param>
        //        /// <param name="Name"></param>
        //        /// <param name="UserID"></param>
        //        /// <param name="Status"></param>
        //        /// <returns></returns>
        //        IQueryable<Assets> GetAssByStatus(string LocationID, string Name, string UserID, int Status);

        //        /// <summary>
        //        /// 查询对应状态的资产数据
        //        /// </summary>
        //        /// <param name="LocationID"></param>
        //        /// <param name="ID"></param>
        //        /// <param name="UserID"></param>
        //        /// <param name="Status"></param>
        //        /// <returns></returns>
        //        IQueryable<Assets> GetAssByStatusEx(string LocationID, string ID, string UserID, int Status);

        //        /// <summary>
        //        /// 查询空闲的资产数据(除调入区域外的)
        //        /// </summary>
        //        /// <param name="LocationID"></param>
        //        /// <param name="Name"></param>
        //        /// <returns></returns>
        //        IQueryable<Assets> GetUnUsedAssOther(string LocationID, string Name);
        //        /// <summary>
        //        /// 查询即将失效的资产
        //        /// </summary>
        //        /// <param name="days"></param>
        //        /// <returns></returns>
        //        IQueryable<Assets> GetImminentAssets(int days);
        //
        //        /// <summary>
        //        /// 查询低于安全库存的资产
        //        /// </summary>
        //        /// <returns></returns>
        //        IQueryable<Assets> GetLackOfStockAss();

        string GetMaxID();
    }
}