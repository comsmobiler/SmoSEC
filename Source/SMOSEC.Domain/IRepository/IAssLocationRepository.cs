using SMOSEC.Domain.Entity;
using System;
using System.Linq;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 区域信息的仓储接口，近用于查询
    /// </summary>
    public interface IAssLocationRepository: IRepository<AssLocation>
    {
        /// <summary>
        /// 根据区域编号返回区域信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<AssLocation> GetByID(String ID);
        /// <summary>
        /// 得到所有已启用的区域信息
        /// </summary>
        /// <returns></returns>
        IQueryable<AssLocation> GetEnableAll();
        /// <summary>
        /// 根据区域管理员返回区域信息
        /// </summary>
        /// <param name="Manager"></param>
        /// <returns></returns>
        IQueryable<AssLocation> GetByManager(String Manager);
    }
}
