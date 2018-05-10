using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using AutoMapper;
using SMOSEC.Application.IServices;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;
using SMOSEC.Infrastructure;

namespace SMOSEC.Application.Services
{
    /// <summary>
    /// 主数据的服务实现
    /// </summary>
    public class SettingService : ISettingService
    {
        /// <summary>
        /// 工作单元的接口
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// 资产信息的查询接口
        /// </summary>
        private IAssetsRepository _AssetsRepository;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        private SMOSECDbContext SMOSECDbContext;

        /// <summary>
        /// 成本中心服务实现的构造函数
        /// </summary>
        public SettingService(IUnitOfWork unitOfWork,
            IAssetsRepository AssetsRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _AssetsRepository = AssetsRepository;
            SMOSECDbContext = (SMOSECDbContext)dbContext;
        }

        #region 查询


        public AssetsOutputDto GetAssetsByID(string ID)
        {
            var dto = from assetse in SMOSECDbContext.Assetss
                from user in SMOSECDbContext.coreUsers
                join type in SMOSECDbContext.AssetsTypes on assetse.TYPEID equals type.TYPEID
                join location in SMOSECDbContext.AssLocations on assetse.LOCATIONID equals location.LOCATIONID
//                join user in SMOSECDbContext.coreUsers on assetse.MANAGER equals user.USER_ID
                where assetse.ASSID==ID&&user.USER_ID==location.MANAGER
                select new AssetsOutputDto
                {
                   AssId = assetse.ASSID,
                   BuyDate = assetse.BUYDATE,
                   CurrentUser = assetse.CURRENTUSER,
                   DepartmentId = assetse.DEPARTMENTID,
                   ExpiryDate = assetse.EXPIRYDATE,
                   Image = assetse.IMAGE,
                   LocationId = assetse.LOCATIONID,
                   LocationName = location.NAME,
//                   Manager = assetse.MANAGER,
                   ManagerName = user.USER_NAME,
                   Name = assetse.NAME,
                   Note = assetse.NOTE,
                   Place = assetse.PLACE,
                   Price = assetse.PRICE,
                   SN = assetse.SN,
                   Specification = assetse.SPECIFICATION,
                   TypeId = assetse.TYPEID,
                   TypeName = type.NAME,
                   Vendor = assetse.VENDOR,
                   Unit = assetse.UNIT
                };
            if (dto.FirstOrDefault() != null)
            {
                string CID = dto.FirstOrDefault().CurrentUser;
                if (!string.IsNullOrEmpty(CID))
                {
                    var name = from user in SMOSECDbContext.coreUsers
                        where user.USER_ID == CID
                        select user.USER_NAME;
                    dto.FirstOrDefault().CurrentUserName = name.FirstOrDefault();
                }
            }
            return dto.AsNoTracking().FirstOrDefault();
        }

        public DataTable GetAllAss()
        {
            return LINQToDataTable.ToDataTable(_AssetsRepository.GetAll().OrderByDescending(a=>a.CREATEDATE).AsNoTracking());
        }

        /// <summary>
        /// 查询借用的资产数据,资产选择时用到
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable GetBorrowedAss(string LocationID, string Name, string UserID)
        {
            int status = (int)STATUS.借用中;
            var result = _AssetsRepository.GetAssByStatus(LocationID, Name, UserID, status);
            var dtos=Mapper.Map<List<Assets>,List<AssSelectOutputDto>> (result.ToList());
            foreach (var dto in dtos)
            {
                dto.IsChecked = false;
            }
            return LINQToDataTable.ToDataTable(dtos);            
        }

        /// <summary>
        /// 查询借用的资产信息,通过扫码添加时用到
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable GetBorrowedAssEx(string LocationID, string ID, string UserID)
        {
            int status = (int)STATUS.借用中;
            var result = _AssetsRepository.GetAssByStatusEx(LocationID, ID, UserID, status);
            var dtos = Mapper.Map<List<Assets>, List<AssSelectOutputDto>>(result.ToList());
            foreach (var dto in dtos)
            {
                dto.IsChecked = false;
            }
            return LINQToDataTable.ToDataTable(dtos);
        }

      
        public DataTable GetRecords(string ASSID)
        {
            var result = from processRecord in SMOSECDbContext.AssProcessRecords
                join assetse in SMOSECDbContext.Assetss on processRecord.ASSID equals assetse.ASSID 
                join user in SMOSECDbContext.coreUsers on processRecord.HANDLEMAN equals user.USER_ID
                where processRecord.ASSID == ASSID
                select new
                {
                    PrId = processRecord.PRID,
                    ProcessMode = processRecord.PROCESSMODE,
                    ProcessContent = processRecord.PROCESSCONTENT,
                    AssId = processRecord.ASSID,
                    HandleDate = processRecord.HANDLEDATE,
                    ProcessModeName ="",
                    HandleMan = user.USER_NAME,
                    SN=assetse.SN
                };        
            DataTable tempTable = LINQToDataTable.ToDataTable(result);
            foreach (DataRow row in tempTable.Rows)
            {
                row["ProcessModeName"]= Enum.GetName(typeof(PROCESSMODE), int.Parse(row["ProcessMode"].ToString()));
            }
            return tempTable;
        }

        public bool IsExist(string ASSID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AssQuant> GetQuants(string LocationID, string AssID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询即将失效的资产(待修改)
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public DataTable GetImminentAssets(int days)
        {
            DateTime targetDateTime = DateTime.Now.Date.AddDays(days);
            DateTime Now = DateTime.Now.Date;
            var result = from ass in SMOSECDbContext.Assetss 
                where ass.EXPIRYDATE >= Now && ass.EXPIRYDATE <= targetDateTime
                select new
                {

                };

            return LINQToDataTable.ToDataTable(_AssetsRepository.GetImminentAssets(days));
        }

        /// <summary>
        /// 查询在用的资产数据,资产选择时使用
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable GetInUseAss(string LocationID, string Name, string UserID)
        {
            int status = (int)STATUS.使用中;
            var result = _AssetsRepository.GetAssByStatus(LocationID, Name, null, status);
            var dtos = Mapper.Map<List<Assets>, List<AssSelectOutputDto>>(result.ToList());
            foreach (var dto in dtos)
            {
                dto.IsChecked = false;
            }
            return LINQToDataTable.ToDataTable(dtos);            
        }

        /// <summary>
        /// 查询在用的资产数据,扫码添加时使用
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable GetInUseAssEx(string LocationID, string ID, string UserID)
        {
            int status = (int)STATUS.使用中;
            var result = _AssetsRepository.GetAssByStatusEx(LocationID, ID, UserID, status);
            var dtos = Mapper.Map<List<Assets>, List<AssSelectOutputDto>>(result.ToList());
            foreach (var dto in dtos)
            {
                dto.IsChecked = false;
            }
            return LINQToDataTable.ToDataTable(dtos);            
        }

        /// <summary>
        /// 查询低于安全库存的资产(待修改)
        /// </summary>
        /// <returns></returns>
        public DataTable GetLackOfStockAss()
        {
//            var result = from ass in SMOSECDbContext.Assetss
//                from quant in SMOSECDbContext.AssQuants
//                where ass.ASSID == quant.ASSID
//                select new
//                {
//
//                };
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 查询空闲的资产数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnUsedAss(string LocationID, string Name)
        {
            int status = (int)STATUS.闲置;
            var result = _AssetsRepository.GetAssByStatus(LocationID, Name, null, status);
            var dtos = Mapper.Map<List<Assets>, List<AssSelectOutputDto>>(result.ToList());
            foreach (var dto in dtos)
            {
                dto.IsChecked = false;
            }
            return LINQToDataTable.ToDataTable(dtos);
        }

        /// <summary>
        /// 查询空闲的资产数据
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetUnUsedAssEx(string LocationID, string ID)
        {
            int status = (int)STATUS.闲置;
            var result = _AssetsRepository.GetAssByStatusEx(LocationID, ID, null, status);
//            var dtos = Mapper.Map<List<Assets>, List<AssSelectOutputDto>>(result.ToList());
//            foreach (var dto in dtos)
//            {
//                dto.IsChecked = false;
//            }

//            return LINQToDataTable.ToDataTable(dtos);
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 查询空闲的资产数据(除调入区域外的)
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public DataTable GetUnUsedAssOther(string LocationID, string Name)
        {
            var result = _AssetsRepository.GetUnUsedAssOther(LocationID, Name);
            var dtos = Mapper.Map<List<Assets>, List<AssSelectOutputDto>>(result.ToList());
            foreach (var dto in dtos)
            {
                dto.IsChecked = false;
            }
            return LINQToDataTable.ToDataTable(dtos);
        }

        public DataTable QueryAssets(string SNOrName)
        {
            var result = _AssetsRepository.QueryAssets(SNOrName).AsNoTracking();
            return LINQToDataTable.ToDataTable(result);

        }

        public DataTable GetAssetsBySN(string SN)
        {
            var result = _AssetsRepository.GetAssetsBySN(SN).AsNoTracking();
            return LINQToDataTable.ToDataTable(result);
        }

        #endregion

        #region 操作
        /// <summary>
        /// 添加资产
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnInfo AddAssets(AssetsInputDto entity)
        {
            //            decimal quantity;
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(entity.AssId))
            {
                string MaxId = _AssetsRepository.GetMaxID();
                string AssId = Helper.GenerateID("ASS", MaxId);
                //产生资产编号
                entity.AssId = AssId;
            }
            
//            string ValidateInfo = Helper.BasicValidate(entity).ToString();
            string ValidateInfo = Helper.ValidateAssets(entity).ToString();
            sb.Append(ValidateInfo);
            if (sb.Length == 0)
            {
                try
                {
                    Assets assets = Mapper.Map<AssetsInputDto, Assets>(entity);
                    assets.STATUS = (int)STATUS.闲置;
                    assets.CREATEDATE=DateTime.Now;
                    assets.MODIFYDATE=DateTime.Now;
                    _unitOfWork.RegisterNew(assets);
                    var pr = new AssProcessRecord
                    {
                        ASSID = entity.AssId,
                        CREATEDATE = DateTime.Now,
                        CREATEUSER = entity.CreateUser,
                        HANDLEDATE = DateTime.Now,
                        HANDLEMAN = entity.CreateUser,
                        MODIFYDATE = DateTime.Now,
                        MODIFYUSER = entity.ModifyUser,
                        PROCESSCONTENT = entity.CreateUser + "入库了" + entity.AssId + ",数量为1",
                        PROCESSMODE = (int) PROCESSMODE.入库,
                        QUANTITY = 1
                    };
                    _unitOfWork.RegisterNew(pr);

                    bool result = _unitOfWork.Commit();
                    RInfo.IsSuccess = result;
                    RInfo.ErrorInfo = entity.AssId;
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

//        /// <summary>
//        /// 添加序列号
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public ReturnInfo AddAssetsSN(AssetsSNInputDto entity)
//        {
//
//            throw new System.NotImplementedException();
//        }

//        /// <summary>
//        /// 删除资产
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public ReturnInfo DeleteAssets(AssetsInputDto entity)
//        {
//            throw new System.NotImplementedException();
//        }

//        /// <summary>
//        /// 删除序列号
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        public ReturnInfo DeleteAssetsSN(AssetsSNInputDto entity)
//        {
//            throw new System.NotImplementedException();
//        }

//        /// <summary>
//        /// 入库
//        /// </summary>
//        /// <param name="inStorage"></param>
//        /// <returns></returns>
//        public ReturnInfo InStorage(AssetsInStorageInputDto inStorage)
//        {
//            throw new NotImplementedException();
//        }
//
//        /// <summary>
//        /// 冲销
//        /// </summary>
//        /// <param name="writeOff"></param>
//        /// <returns></returns>
//        public ReturnInfo WriteOff(AssetsWriteOffInputDto writeOff)
//        {
//            throw new NotImplementedException();
//        }


        public ReturnInfo UpdateAssets(AssetsInputDto entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            //            if (inStorageInput.Quantity<0)
            //            {
            //                sb.Append("请输入正确的数量。");
            //            }
            //产生资产编号
            string ValidateInfo = Helper.BasicValidate(entity).ToString();
            sb.Append(ValidateInfo);
            if (sb.Length == 0)
            {
                try
                {
                    Assets assets = _AssetsRepository.GetByID(entity.AssId).FirstOrDefault();

//                    Assets assets = Mapper.Map<AssetsInputDto, Assets>(entity);
//                    assets = Mapper.Map<AssetsInputDto, Assets>(entity);

//                    assets.CreateDate = DateTime.Now;
                    if (assets != null)
                    {
                        assets.BUYDATE = entity.BuyDate;
                        assets.CREATEUSER = entity.CreateUser;
//                    assets.CURRENTUSER = entity.CurrentUser;
                        assets.DEPARTMENTID = entity.DepartmentId;
                        assets.EXPIRYDATE = entity.ExpiryDate;
                        assets.IMAGE = entity.Image;
                        assets.LOCATIONID = entity.LocationId;
//                        assets.MANAGER = entity.Manager;
                        assets.MODIFYUSER = entity.ModifyUser;
                        assets.NAME = entity.Name;
                        assets.NOTE = entity.Note;
                        assets.PLACE = entity.Place;
                        assets.PRICE = entity.Price;
                        assets.SN = entity.SN;
                        assets.SPECIFICATION = entity.Specification;
                        assets.TYPEID = entity.TypeId;
                        assets.UNIT = entity.Unit;
                        assets.VENDOR = entity.Vendor;
                        assets.MODIFYDATE = DateTime.Now;
                        assets.CREATEDATE = assets.CREATEDATE;
                        _unitOfWork.RegisterDirty(assets);
                    }

                    var pr = new AssProcessRecord
                    {
                        ASSID = entity.AssId,
                        CREATEDATE = DateTime.Now,
                        CREATEUSER = entity.CreateUser,
                        HANDLEDATE = DateTime.Now,
                        HANDLEMAN = entity.CreateUser,
                        MODIFYDATE = DateTime.Now,
                        MODIFYUSER = entity.ModifyUser,
                        PROCESSCONTENT = entity.CreateUser + "修改了" + entity.AssId
                    };
                    //                    pr.HANDLEMAN = "18875878973";
                    //                    pr.PRId = "";
                    ;
                    pr.PROCESSMODE = (int)PROCESSMODE.修改内容;
                    _unitOfWork.RegisterNew(pr);

                    bool result = _unitOfWork.Commit();
                    RInfo.IsSuccess = result;
                    RInfo.ErrorInfo = sb.ToString();
                    return RInfo;

                    //                    if (inStorageInput.Quantity>0)
                    //                    {
                    //                        RInfo = InStorage(inStorageInput);
                    //                        return RInfo;
                    //                    }
                    //                    else
                    //                    {
                    //                        bool result = _unitOfWork.Commit();
                    //                        RInfo.IsSuccess = result;
                    //                        RInfo.ErrorInfo = sb.ToString();
                    //                        return RInfo;
                    //                    }

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


        //        public ReturnInfo UpdateAssetsSN(AssetsSNInputDto entity)
        //        {
        //            throw new System.NotImplementedException();
        //        }
        #endregion





    }
}