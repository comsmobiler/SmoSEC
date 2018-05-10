using System.Linq;
using SMOSEC.Domain.Entity;

namespace SMOSEC.Domain.IRepository
{
    public interface IWarehouseReceiptRepository : IRepository<WarehouseReceipt>
    {
        //        /// <summary>
        //        /// 得到对应的借用单列表
        //        /// </summary>
        //        /// <returns></returns>
        //        IQueryable<AssBorrowOrder> GetListOrders();

        /// <summary>
        /// 根据出库单编号返回入库单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<WarehouseReceipt> GetById(string id);

        /// <summary>
        /// 根据用户编号返回入库单信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IQueryable<WarehouseReceipt> GetByUserId(string userId);

        string GetMaxId();
    }
}