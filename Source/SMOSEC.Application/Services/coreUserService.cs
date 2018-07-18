using AutoMapper;
using SMOSEC.Application.IServices;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.OutputDTO;
using SMOSEC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SMOSEC.Application.Services
{
    /// <summary>
    /// 用户的接口实现
    /// </summary>
    public class coreUserService : IcoreUserService
    {
        /// <summary>
        /// 工作单元的接口
        /// </summary>
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// 资产信息的查询接口
        /// </summary>
        private IAssetsRepository _assetsRepository;
        /// <summary>
        /// 用户信息的查询接口
        /// </summary>
        private IcoreUserRepository _coreUserRepository;
        /// <summary>
        /// 部门信息的查询接口
        /// </summary>
        private IDepartmentRepository _DepartmentRepository;
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private SMOSECDbContext SMOSECDbContext;
        /// <summary>
        /// 成本中心服务实现的构造函数
        /// </summary>
        public coreUserService(IUnitOfWork unitOfWork,
            IAssetsRepository assetsRepository,
            IcoreUserRepository coreUserRepository,
            IDepartmentRepository DepartmentRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _assetsRepository = assetsRepository;
            _coreUserRepository = coreUserRepository;
            _DepartmentRepository = DepartmentRepository;
            SMOSECDbContext = (SMOSECDbContext)dbContext;
        }
        #region 查询
        /// <summary>
        /// 返回管理员信息
        /// </summary>
        /// <returns></returns>
        public List<coreUser> GetDealInAdmin()
        {
            return _coreUserRepository.GetDealInAdmin().AsNoTracking().ToList();
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<coreUser> GetAll()
        {
            return _coreUserRepository.GetAll().OrderBy(x=>x.USER_NAME).AsNoTracking().ToList();
        }
        /// <summary>
        /// 得到某个部门的所有用户
        /// </summary>
        /// <param name="DepartmentID"></param>
        /// <returns></returns>
        public List<coreUser> GetUserByDepID(String DepartmentID)
        {
            return _coreUserRepository.GetUserByDepID(DepartmentID).AsNoTracking().ToList();
        }
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public List<coreUser> GetUser()
        {
            return _coreUserRepository.GetUser().AsNoTracking().ToList();
        }
        /// <summary>
        /// 根据用户ID返回用户和部门信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        public UserDepDto GetUseDepByUserID(string UserID)
        {
            UserDepDto ud = Mapper.Map<coreUser, UserDepDto>(_coreUserRepository.GetByID(UserID).AsNoTracking().FirstOrDefault());
            if (ud != null)
            {
                if (!string.IsNullOrEmpty(ud.DEPARTMENTID))
                {
                    DepartmentDto d = Mapper.Map<Department, DepartmentDto>(_DepartmentRepository.GetByID(ud.DEPARTMENTID).AsNoTracking().FirstOrDefault());
                    if (d != null)
                    {
                        ud.DEPARTMENTNAME = d.NAME;
                    }
                }
            }
            return ud;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="Password">用户密码</param>
        public ReturnInfo Login(string UserID, String Password)
        {
            ReturnInfo RInfo = new ReturnInfo();
            try
            {
                if (string.IsNullOrEmpty(UserID))
                {
                    RInfo.IsSuccess = false;
                    throw new Exception("用户名为空;");
                }
                else
                {
                    coreUser User = _coreUserRepository.GetByID(UserID).AsNoTracking().FirstOrDefault();
                    if (User != null)
                    {
                        if (_coreUserRepository.Login(UserID, Password))
                        {
                            RInfo.IsSuccess = true;
                        }
                        else
                        {
                            RInfo.IsSuccess = false;
                            throw new Exception("密码错误");
                        }
                    }
                    else
                    {
                        RInfo.IsSuccess = false;
                        throw new Exception("该用户不存在");
                    }
                }
            }
            catch (Exception ex)
            {
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = ex.Message;
            }
            return RInfo;
        }
        /// <summary>
        /// 返回管理员信息
        /// </summary>
        /// <returns></returns>
        public List<coreUser> GetAdmin()
        {
            return _coreUserRepository.GetAdmin().AsNoTracking().ToList();
        }
        /// <summary>
        /// 根据用户编号返回用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public coreUser GetUserByID(String ID)
        {
            return _coreUserRepository.GetByID(ID).AsNoTracking().FirstOrDefault();
        }
        /// <summary>
        /// 判断手机号是否注册
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public Boolean PhoneIsExit(String Phone)
        {
            coreUser coreUser = _coreUserRepository.GetByPhone(Phone).FirstOrDefault();
            if (coreUser == null)  //如果查不到用户信息，则说明该手机号未被注册
                return false;
            else
                return true;
        }
        /// <summary>
        /// 判断邮箱是否注册
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Boolean EmailIsExit(String Email)
        {
            coreUser coreUser = _coreUserRepository.GetByEmail(Email).FirstOrDefault();
            if (coreUser == null)  //如果查不到用户信息，则说明该邮箱未被注册
                return false;
            else
                return true;
        }
        #endregion
        #region 操作
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnInfo AddUser(coreUser entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            coreUser coreUser = _coreUserRepository.GetByID(entity.USER_ID).FirstOrDefault();
            if (coreUser != null) throw new Exception("该用户已存在，请检查！");
            try
            {
                _unitOfWork.RegisterNew(entity);
                bool result = _unitOfWork.Commit();
                RInfo.IsSuccess = result;
                RInfo.ErrorInfo = "创建成功!";
                return RInfo;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = ex.Message;
                return RInfo;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="OldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public ReturnInfo ChangePwd(String UserID, String OldPwd, String newPwd)
        {
            ReturnInfo RInfo = new ReturnInfo();
            coreUser coreUser = _coreUserRepository.GetByID(UserID).FirstOrDefault();
            if (coreUser == null) throw new Exception("该用户不存在，请检查！");
            if (coreUser.USER_PASSWORD != OldPwd) throw new Exception("原密码错误，请重试!");
            try
            {
                coreUser.USER_PASSWORD = newPwd;
                _unitOfWork.RegisterDirty(coreUser);
                bool result = _unitOfWork.Commit();
                RInfo.IsSuccess = result;
                RInfo.ErrorInfo = "修改密码成功!";
                return RInfo;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = ex.Message;
                return RInfo;
            }
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public ReturnInfo UpdateUser(coreUser entity, EuserInfo Type)
        {
            ReturnInfo RInfo = new ReturnInfo();
            coreUser coreUser = _coreUserRepository.GetByID(entity.USER_ID).FirstOrDefault();
            if (coreUser == null) throw new Exception("该用户不存在，请检查！");
            try
            {
                switch (Type)
                {
                    case EuserInfo.修改地址:
                        coreUser.USER_ADDRESS = entity.USER_ADDRESS;
                        break;
                    case EuserInfo.修改头像:
                        coreUser.USER_IMAGEID = entity.USER_IMAGEID;
                        break;
                    case EuserInfo.修改性别:
                        coreUser.USER_SEX = entity.USER_SEX;
                        break;
                    case EuserInfo.修改昵称:
                        coreUser.USER_NAME = entity.USER_NAME;
                        break;
                    case EuserInfo.修改生日:
                        coreUser.USER_BIRTHDAY = entity.USER_BIRTHDAY;
                        break;
                    case EuserInfo.修改所属区域:                       
                        coreUser.USER_LOCATIONID = entity.USER_LOCATIONID;
                        break;
                }
                _unitOfWork.RegisterDirty(coreUser);
                if(Type== EuserInfo.修改所属区域)    //由于用户所在区域变更，用户所领用借用的资产区域也一起变更
                {
                    List<Assets> listAss = _assetsRepository.GetByUser(entity.USER_ID).ToList();
                    if (listAss.Count > 0)
                    {
                        foreach(Assets Row in listAss)
                        {
                            Row.LOCATIONID = coreUser.USER_LOCATIONID;
                            _unitOfWork.RegisterDirty(Row);
                        }
                    }
                }
                bool result = _unitOfWork.Commit();
                RInfo.IsSuccess = result;
                RInfo.ErrorInfo = "修改信息成功!";
                return RInfo;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = ex.Message;
                return RInfo;
            }
        }
        #endregion
    }
}
