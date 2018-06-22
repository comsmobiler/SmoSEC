using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.OutputDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.Application.IServices
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IcoreUserService
    {
        #region 查询
        /// <summary>
        /// 获取调入管理员数据
        /// </summary>
        /// <returns></returns>
        List<coreUser> GetDealInAdmin();
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        List<coreUser> GetAll();
        /// <summary>
        /// 得到某个部门的所有用户
        /// </summary>
        /// <param name="DepartmentID"></param>
        /// <returns></returns>
        List<coreUser> GetUserByDepID(String DepartmentID);
        /// <summary>
        /// 根据用户ID返回用户和部门信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        UserDepDto GetUseDepByUserID(string UserID);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="Password">加密后的用户密码</param>
        ReturnInfo Login(string UserID, String Password);
        ///// <summary>
        ///// 用户通过验证码登录
        ///// </summary>
        ///// <param name="PhoneNumber">电话号码</param>
        ///// <param name="VCode">验证码</param>
        //ReturnInfo LoginByVCode(string PhoneNumber, String VCode);
        /// <summary>
        /// 获取管理员数据
        /// </summary>
        /// <returns></returns>
        List<coreUser> GetAdmin();
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        List<coreUser> GetUser();
        /// <summary>
        /// 根据用户编号返回用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        coreUser GetUserByID(String ID);
        /// <summary>
        /// 判断手机号是否注册
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        Boolean PhoneIsExit(String Phone);
        /// <summary>
        /// 判断邮箱是否注册
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        Boolean EmailIsExit(String Email);
        #endregion
        #region
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnInfo AddUser(coreUser entity);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="OldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        ReturnInfo ChangePwd(String UserID, String OldPwd, String newPwd);
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        ReturnInfo UpdateUser(coreUser entity, EuserInfo Type);
        ///// <summary>
        ///// 加密密码
        ///// </summary>
        ///// <param name="Pwd">密码</param>
        //string Encrypt(string Pwd);
        #endregion
    }
}
