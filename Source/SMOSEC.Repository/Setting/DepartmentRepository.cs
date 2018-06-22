using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMOSEC.Repository.Setting
{
    /// <summary>
    /// 部门的仓储接口,仅用于查询
    /// </summary>
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public DepartmentRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据部门ID返回部门对象
        /// </summary>
        /// <param name="ID">部门ID</param>
        public IQueryable<Department> GetByID(string ID)
        {
            return _entities.Where(x => x.DEPARTMENTID == ID);
        }
        /// <summary>
        /// 查询该用户是否已经是责任人
        /// </summary>
        public bool IsLeader(string UserID)
        {
            return _entities.Any(x => x.MANAGER == UserID);
        }
        /// <summary>
        /// 得到最大的部门ID
        /// </summary>
        public string GetMaxID()
        {
            return _entities.Select(e => e.DEPARTMENTID).Max();
        }
    }
}
