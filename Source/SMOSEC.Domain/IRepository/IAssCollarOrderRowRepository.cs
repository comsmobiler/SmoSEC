using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    public interface IAssCollarOrderRowRepository:IRepository<AssCollarOrderRow>
    {
        //        /// <summary>
        //        /// 根据领用单编号返回领用单行项信息
        //        /// </summary>
        //        /// <param name="ID"></param>
        //        /// <returns></returns>
        //        IQueryable<AssCollarOrderRow> GetByID(string ID);
        //
        //        /// <summary>
        //        /// 根据领用单编号返回领用单行项信息
        //        /// </summary>
        //        /// <param name="COID"></param>
        //        /// <returns></returns>
        //        IQueryable<AssCollarOrderRow> GetByCOID(string COID);

//        /// <summary>
//        /// 得到对应的领用单行项列表
//        /// <param name="COID"></param>
//        /// <param name="ASSIDs"></param>
//        /// </summary>
//        /// <returns></returns>
//        IQueryable<AssCollarOrderRow> GetRowsByCOID(string COID, List<string> ASSIDs);
    }
}