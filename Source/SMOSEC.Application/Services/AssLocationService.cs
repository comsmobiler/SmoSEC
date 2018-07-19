using System.Collections.Generic;
using SMOSEC.Application.IServices;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using System.Linq;
using SMOSEC.CommLib;
using System.Data.Entity;
using SMOSEC.Infrastructure;
using AutoMapper;
using System;
using SMOSEC.DTOs.Enum;

namespace SMOSEC.Application.Services
{
    public class AssLocationService : IAssLocationService
    {
        /// <summary>
        /// 工作单元的接口
        /// </summary>
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// 区域信息的查询接口
        /// </summary>
        private IAssLocationRepository _AssLocationRepository;
        /// <summary>
        /// 用户信息的查询接口
        /// </summary>
        private IcoreUserRepository _coreUserRepository;
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private SMOSECDbContext SMOSECDbContext;

        /// <summary>
        /// 成本中心服务实现的构造函数
        /// </summary>
        public AssLocationService(IUnitOfWork unitOfWork,
            IAssLocationRepository AssLocationRepository,
            IcoreUserRepository coreUserRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _AssLocationRepository = AssLocationRepository;
            _coreUserRepository = coreUserRepository;
            SMOSECDbContext = (SMOSECDbContext)dbContext;
        }
        #region 查询
        /// <summary>
        /// 根据区域编号返回区域信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public AssLocation GetByID(string ID)
        {
            return _AssLocationRepository.GetByID(ID).AsNoTracking().FirstOrDefault();
        }
        /// <summary>
        /// 根据区域管理员返回区域信息
        /// </summary>
        /// <param name="Manager"></param>
        /// <returns></returns>
        public AssLocation GetByManager(string Manager)
        {
            return _AssLocationRepository.GetByManager(Manager).AsNoTracking().FirstOrDefault();
        }
        /// <summary>
        /// 返回所有区域信息
        /// </summary>
        /// <returns></returns>
        public List<AssLocation> GetAll()
        {
            return _AssLocationRepository.GetAll().AsNoTracking().ToList();
        }
        /// <summary>
        /// 返回所有启用的区域信息
        /// </summary>
        /// <returns></returns>
        public List<AssLocation> GetEnableAll()
        {
            return _AssLocationRepository.GetEnableAll().AsNoTracking().ToList();
        }
        #endregion
        #region   操作
        /// <summary>
        /// 新增区域
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnInfo AddAssLocation(AssLocation entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            if (String.IsNullOrEmpty(entity.LOCATIONID))
                throw new Exception("区域编号不能为空");
            if (String.IsNullOrEmpty(entity.NAME))
                throw new Exception("区域名称不能为空");
            AssLocation al = _AssLocationRepository.GetByID(entity.LOCATIONID).AsNoTracking().FirstOrDefault();
            if (al != null)
                throw new Exception("区域编号已存在!");

            coreUser coreUser = _coreUserRepository.GetByID(entity.MANAGER).FirstOrDefault();          
            entity.ISENABLE = 1;
            try
            {
                if (coreUser.USER_ROLE == "SMOSECUser")
                {
                    coreUser.USER_ROLE = "SMOSECAdmin";
                    _unitOfWork.RegisterDirty(coreUser);
                }
                _unitOfWork.RegisterNew(entity);
                bool result = _unitOfWork.Commit();
                RInfo.IsSuccess = result;
                RInfo.ErrorInfo = "创建成功!";
                return RInfo;
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback();
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = ex.Message;
                return RInfo;
            }
        }
        /// <summary>
        /// 更新区域信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="OldManager"></param>
        /// <returns></returns>
        public ReturnInfo UpdateAssLocation(AssLocation entity, String OldManager)
        {
            ReturnInfo RInfo = new ReturnInfo();
            try
            {
                if (String.IsNullOrEmpty(entity.LOCATIONID))
                    throw new Exception("区域编号不能为空");
                AssLocation al = _AssLocationRepository.GetByID(entity.LOCATIONID).AsNoTracking().FirstOrDefault();
                if (al == null)
                    throw new Exception("区域编号不存在，请检查!");
                
                if(OldManager != entity.MANAGER)
                {
                    coreUser OldUser = _coreUserRepository.GetByID(OldManager).FirstOrDefault();
                    if(OldUser.USER_ROLE== "SMOSECAdmin")
                    {
                        OldUser.USER_ROLE = "SMOSECUser";
                        _unitOfWork.RegisterDirty(OldUser);
                    }
                    coreUser coreUser = _coreUserRepository.GetByID(entity.MANAGER).FirstOrDefault();
                    if (coreUser.USER_ROLE == "SMOSECUser")
                    {
                        coreUser.USER_ROLE = "SMOSECAdmin";
                        _unitOfWork.RegisterDirty(coreUser);
                    }
                }
                _unitOfWork.RegisterDirty(entity);
                bool result = _unitOfWork.Commit();
                RInfo.IsSuccess = result;
                RInfo.ErrorInfo = "更新区域成功!";
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
        /// 删除区域信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnInfo DeleteAssLocation(String ID)
        {
            ReturnInfo RInfo = new ReturnInfo();
            if (String.IsNullOrEmpty(ID))
                throw new Exception("区域编号不能为空");
            AssLocation al = _AssLocationRepository.GetByID(ID).FirstOrDefault();
            if (al == null)
                throw new Exception("区域编号不存在，请检查!");
            try
            {
                _unitOfWork.RegisterDeleted(al);
                _unitOfWork.Commit();
                RInfo.IsSuccess = true;
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
        /// 更改区域启用状态
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ReturnInfo ChangeEnable(String LocationID, IsEnable status)
        {
            ReturnInfo RInfo = new ReturnInfo();
            if (String.IsNullOrEmpty(LocationID))
                throw new Exception("区域编号不能为空");
            AssLocation al = _AssLocationRepository.GetByID(LocationID).FirstOrDefault();
            if (al == null)
                throw new Exception("区域编号不存在，请检查!");
            try
            {
                al.ISENABLE = (int)status;
                _unitOfWork.RegisterDirty(al);
                 _unitOfWork.Commit();
                RInfo.IsSuccess = true;
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
