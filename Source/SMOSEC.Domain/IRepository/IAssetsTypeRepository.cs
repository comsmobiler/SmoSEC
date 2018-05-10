using SMOSEC.Domain.Entity;
using System;
using System.Linq;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 资产类别的仓储接口，仅用于查询
    /// </summary>
    public interface IAssetsTypeRepository:IRepository<AssetsType>
    {
        /// <summary>
        /// 根据资产类别编号返回资产类别对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<AssetsType> GetByID(String ID);
        /// <summary>
        /// 判断是否为父分类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<AssetsType> IsParent(String ID);
    }
}
