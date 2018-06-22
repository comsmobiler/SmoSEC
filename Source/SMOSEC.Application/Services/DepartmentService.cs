using AutoMapper;
using SMOSEC.Application.IServices;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.InputDTO;
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
    /// 部门的服务实现
    /// </summary>
    public class DepartmentService: IDepartmentService
    {
        /// <summary>
        /// 工作单元的接口
        /// </summary>
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// 用户的仓储类的接口
        /// </summary>
        private IcoreUserRepository _coreUserRepository;
        /// <summary>
        /// 部门的仓储类的接口
        /// </summary>
        private IDepartmentRepository _departmentRepository;


        /// <summary>
        /// 部门服务实现的构造函数
        /// </summary>
        public DepartmentService(IUnitOfWork unitOfWork,
            IcoreUserRepository coreUserRepository,
            IDepartmentRepository departmentRepository)
        {
            _unitOfWork = unitOfWork;
            _coreUserRepository = coreUserRepository;
            _departmentRepository = departmentRepository;
        }

        #region 查询
        /// <summary>
        /// 根据部门ID返回部门对象
        /// </summary>
        /// <param name="ID">部门ID</param>
        public DepartmentDto GetDepartmentByDepID(string ID)
        {
            DepartmentDto d = Mapper.Map<Department, DepartmentDto>(_departmentRepository.GetByID(ID).AsNoTracking().FirstOrDefault());
            if (d != null)
            {
                coreUser u = _coreUserRepository.GetByID(d.MANAGER).AsNoTracking().FirstOrDefault();
                if (u != null)
                {
                    d.MANAGERNAME = u.USER_NAME;
                }
            }
            return d;
        }

        /// <summary>
        /// 得到所有部门
        /// </summary>
        public List<DepartmentDto> GetAllDepartment()
        {
            List<DepartmentDto> dtos = Mapper.Map<List<Department>, List<DepartmentDto>>(_departmentRepository.GetAll().OrderByDescending(o => o.DEPARTMENTID).AsNoTracking().ToList());
            if (dtos.Count > 0)
            {
                foreach (DepartmentDto dto in dtos)
                {
                    coreUser u = _coreUserRepository.GetByID(dto.MANAGER).AsNoTracking().FirstOrDefault();
                    if (u != null)
                    {
                        dto.MANAGERNAME = u.USER_NAME;
                    }
                }
            }
            return dtos;
        }

        /// <summary>
        /// 查询该用户是否已经是责任人
        /// </summary>
        public bool IsLeader(string UserID)
        {
            return _departmentRepository.IsLeader(UserID);
        }
        #endregion


        #region 操作
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="entity">部门对象</param>
        public ReturnInfo AddDepartment(DepInputDto entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string MaxID = _departmentRepository.GetMaxID();
            string NowID = Helper.GenerateDepID("D", MaxID);
            entity.DEPARTMENTID = NowID;
            string ValidateInfo = Helper.ValidateDepInputDto(entity);
            sb.Append(ValidateInfo);
            if (string.IsNullOrEmpty(ValidateInfo))
            {
                try
                {
                    Department d = Mapper.Map<DepInputDto, Department>(entity);
                    d.ISENABLE = (int)IsEnable.启用;
                    d.CREATEDATE = DateTime.Now;
                    d.MODIFYDATE = DateTime.Now;
                    string MaxID2 = _departmentRepository.GetMaxID();
                    string NowID2 = Helper.GenerateDepID("D", MaxID2);
                    d.DEPARTMENTID = NowID2;
                    _unitOfWork.RegisterNew(d);
                    foreach (string s in entity.UserIDs)
                    {
                        coreUser u = _coreUserRepository.GetByID(s).FirstOrDefault();
                        u.USER_DEPARTMENTID = NowID;
                        _unitOfWork.RegisterDirty(u);
                    }
                    bool result = _unitOfWork.Commit();
                    RInfo.IsSuccess = result;
                    RInfo.ErrorInfo = sb.ToString();
                    return RInfo;
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    sb.Append(ex.Message);
                    RInfo.IsSuccess = false;
                    RInfo.ErrorInfo = sb.ToString();
                    return RInfo;
                }
            }
            else
            {
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = sb.ToString();
                return RInfo;
            }
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="entity">部门对象</param>
        public ReturnInfo UpdateDepartment(DepInputDto entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string ValidateInfo = Helper.ValidateDepInputDto(entity);
            sb.Append(ValidateInfo);
            if (string.IsNullOrEmpty(ValidateInfo))
            {
                Department d = _departmentRepository.GetByID(entity.DEPARTMENTID).FirstOrDefault();
                if (d == null)
                {
                    RInfo.IsSuccess = false;
                    RInfo.ErrorInfo = "找不到该部门!";
                    return RInfo;
                }
                else
                {
                    try
                    {
                        #region 如果字段非空或0,则更新对应字段
                        if (entity.MANAGER != null)
                        {
                            d.MANAGER = entity.MANAGER;
                        }
                        if (entity.NAME != null)
                        {
                            d.NAME = entity.NAME;
                        }
                        d.MODIFYDATE = DateTime.Now;
                        if (entity.MODIFYUSER != null)
                        {
                            d.MODIFYUSER = entity.MODIFYUSER;
                        }
                        if (entity.IMAGEID != null)
                        {
                            d.IMAGEID = entity.IMAGEID;
                        }
                        #endregion
                        _unitOfWork.RegisterDirty(d);
                        List<string> OldIDs = GetUserByDepID(entity.DEPARTMENTID).Select(o => o.USER_ID).ToList();
                        List<string> Add = entity.UserIDs.Except(OldIDs).ToList();
                        List<string> Delete = OldIDs.Except(entity.UserIDs).ToList();
                        if (Add.Count > 0)
                        {
                            foreach (string addID in Add)
                            {
                                if (!string.IsNullOrEmpty(addID))
                                {
                                    coreUser u = _coreUserRepository.GetByID(addID).FirstOrDefault();
                                    u.USER_DEPARTMENTID = entity.DEPARTMENTID;
                                    _unitOfWork.RegisterDirty(u);
                                }
                                else
                                {
                                    RInfo.IsSuccess = false;
                                    RInfo.ErrorInfo = "不能存在空的用户ID!";
                                }
                            }
                        }
                        if (Delete.Count > 0)
                        {
                            foreach (string deleteID in Delete)
                            {
                                if (!string.IsNullOrEmpty(deleteID))
                                {
                                    coreUser u = _coreUserRepository.GetByID(deleteID).FirstOrDefault();
                                    u.USER_DEPARTMENTID = "";
                                    _unitOfWork.RegisterDirty(u);
                                }
                                else
                                {
                                    RInfo.IsSuccess = false;
                                    RInfo.ErrorInfo = "不能存在空的用户ID!";
                                }

                            }
                        }
                        bool result = _unitOfWork.Commit();
                        RInfo.IsSuccess = result;
                        RInfo.ErrorInfo = sb.ToString();
                        return RInfo;
                    }
                    catch (Exception ex)
                    {
                        _unitOfWork.RegisterClean(d);
                        _unitOfWork.Rollback();
                        sb.Append(ex.Message);
                        RInfo.IsSuccess = false;
                        RInfo.ErrorInfo = sb.ToString();
                        return RInfo;
                    }
                }

            }
            else
            {
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = sb.ToString();
                return RInfo;
            }
        }

        /// <summary>
        /// 分配人员
        /// </summary>
        /// <param name="UserIDs">用户ID列表</param>
        /// <param name="DepartmentID">部门ID</param>
        public ReturnInfo AssignUserToDepartment(List<string> UserIDs, string DepartmentID)
        {
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            if (UserIDs.Count > 0)
            {
                if (!string.IsNullOrEmpty(DepartmentID))
                {
                    try
                    {
                        List<string> OldIDs = GetUserByDepID(DepartmentID).Select(o => o.USER_ID).ToList();
                        List<string> Add = UserIDs.Except(OldIDs).ToList();
                        List<string> Delete = OldIDs.Except(UserIDs).ToList();
                        if (Add.Count > 0)
                        {
                            foreach (string addID in Add)
                            {
                                if (!string.IsNullOrEmpty(addID))
                                {
                                    coreUser entity = _coreUserRepository.GetByID(addID).FirstOrDefault();
                                    entity.USER_DEPARTMENTID = DepartmentID;
                                    _unitOfWork.RegisterDirty(entity);
                                }
                                else
                                {
                                    RInfo.IsSuccess = false;
                                    RInfo.ErrorInfo = "不能存在空的用户ID!";
                                }
                            }
                        }
                        if (Delete.Count > 0)
                        {
                            foreach (string deleteID in Delete)
                            {
                                if (!string.IsNullOrEmpty(deleteID))
                                {
                                    coreUser entity = _coreUserRepository.GetByID(deleteID).FirstOrDefault();
                                    entity.USER_DEPARTMENTID = "";
                                    _unitOfWork.RegisterDirty(entity);
                                }
                                else
                                {
                                    RInfo.IsSuccess = false;
                                    RInfo.ErrorInfo = "不能存在空的用户ID!";
                                }

                            }
                        }
                        bool result = _unitOfWork.Commit();
                        RInfo.IsSuccess = result;
                        RInfo.ErrorInfo = sb.ToString();

                    }
                    catch (Exception ex)
                    {
                        _unitOfWork.Rollback();
                        sb.Append(ex.Message);
                        RInfo.IsSuccess = false;
                        RInfo.ErrorInfo = sb.ToString();
                    }
                }
                else
                {
                    RInfo.IsSuccess = false;
                    sb.Append("部门ID不能为空!");
                }


                RInfo.ErrorInfo = sb.ToString();
                return RInfo;
            }
            else
            {
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = "至少需要一个用户!";
                return RInfo;
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="DepartmentID">部门对象ID</param>
        public ReturnInfo DeleteDepartment(string DepartmentID)
        {
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            Department dep = _departmentRepository.GetByID(DepartmentID).FirstOrDefault();
            if (dep != null)
            {
                List<coreUser> users = GetUserByDepID(DepartmentID);
                try
                {
                    foreach (coreUser u in users)
                    {
                        u.USER_DEPARTMENTID = "";
                        _unitOfWork.RegisterDirty(dep);
                    }
                    _unitOfWork.RegisterDeleted(dep);
                    bool result = _unitOfWork.Commit();
                    RInfo.IsSuccess = result;
                    RInfo.ErrorInfo = sb.ToString();
                }
                catch (Exception ex)
                {
                    foreach (coreUser u in users)
                    {
                        _unitOfWork.RegisterClean(u);
                    }
                    _unitOfWork.RegisterClean(dep);
                    _unitOfWork.Rollback();
                    sb.Append(ex.Message);
                    RInfo.IsSuccess = false;
                    RInfo.ErrorInfo = sb.ToString();
                }
            }
            else
            {
                RInfo.IsSuccess = false;
                sb.Append("不存在ID为" + DepartmentID + "的部门!");
            }

            return RInfo;
        }


        #endregion


        #region 用到的其他方法
        /// <summary>
        /// 得到某个部门的所有用户
        /// </summary>
        public List<coreUser> GetUserByDepID(string DepartmentID)
        {
            return _coreUserRepository.GetAll().Where(o => o.USER_DEPARTMENTID == DepartmentID).ToList();
        }
        #endregion
    }
}
