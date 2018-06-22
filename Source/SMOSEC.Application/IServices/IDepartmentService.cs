using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 部门的服务接口
    /// </summary>
    public interface IDepartmentService
    {
        #region 查询
        /// <summary>
        /// 根据部门ID返回部门对象
        /// </summary>
        /// <param name="ID">部门ID</param>
        DepartmentDto GetDepartmentByDepID(string ID);

        /// <summary>
        /// 得到所有部门
        /// </summary>
        List<DepartmentDto> GetAllDepartment();

        /// <summary>
        /// 查询该用户是否已经是责任人
        /// </summary>
        bool IsLeader(string UserID);

        #endregion

        #region 操作
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="entity">部门对象</param>
        ReturnInfo AddDepartment(DepInputDto entity);

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="entity">部门对象</param>
        ReturnInfo UpdateDepartment(DepInputDto entity);

        /// <summary>
        /// 分配人员
        /// </summary>
        /// <param name="UserIDs">用户ID列表</param>
        /// <param name="DepartmentID">部门ID</param>
        ReturnInfo AssignUserToDepartment(List<string> UserIDs, string DepartmentID);

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="DepartmentID">部门对象ID</param>
        ReturnInfo DeleteDepartment(string DepartmentID);
        #endregion
    }
}
