using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMOSEC.Domain.IRepository
{
    /// <summary>
    /// 部门的仓储接口,仅用于查询
    /// </summary>
    public interface IDepartmentRepository : IRepository<Department>
    {
        /// <summary>
        /// 根据部门ID返回部门对象
        /// </summary>
        /// <param name="ID">部门ID</param>
        IQueryable<Department> GetByID(string ID);

        /// <summary>
        /// 得到最大的部门ID
        /// </summary>
        string GetMaxID();

        /// <summary>
        /// 查询该用户是否已经是责任人
        /// </summary>
        bool IsLeader(string UserID);
    }
}
