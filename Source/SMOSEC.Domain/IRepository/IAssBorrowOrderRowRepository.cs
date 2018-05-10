using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    public interface IAssBorrowOrderRowRepository:IRepository<AssBorrowOrderRow>
    {
        //        /// <summary>
        //        /// 根据借用单行项编号返回借用单行项信息
        //        /// </summary>
        //        /// <param name="ID"></param>
        //        /// <returns></returns>
        //        IQueryable<AssBorrowOrderRow> GetByID(string ID);
        //
        //        /// <summary>
        //        /// 根据借用单编号返回借用单行项信息
        //        /// </summary>
        //        /// <param name="BOID"></param>
        //        /// <returns></returns>
        //        IQueryable<AssBorrowOrderRow> GetByBOID(string BOID);

//        /// <summary>
//        /// 得到对应的借用单行项列表
//        /// <param name="BOID"></param>
//        /// <param name="ASSIDs"></param>
//        /// </summary>
//        /// <returns></returns>
//        IQueryable<AssBorrowOrderRow> GetRowsByBOID(string BOID, List<string> ASSIDs);
    }
}