using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using AutoMapper;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.DTOs.OutputDTO;
using SMOSEC.Infrastructure;
using SMOSEC.Application.IServices;

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
        /// 用户查询接口
        /// </summary>
        private IcoreUserRepository _coreUserRepository;
        /// <summary>
        /// 资产记录查询接口
        /// </summary>
        private IAssProcessRecordRepository _AssProcessRecordRepository;
        /// <summary>
        /// 资产分类查询接口
        /// </summary>
        private IAssetsTypeRepository _assetsTypeRepository;
        /// <summary>
        /// 部门的查询接口
        /// </summary>
        private IDepartmentRepository _departmentRepository;
        /// <summary>
        /// 主数据服务实现的构造函数
        /// </summary>
        public SettingService(IUnitOfWork unitOfWork,
            IAssetsRepository AssetsRepository,
            IAssProcessRecordRepository AssProcessRecordRepository,
            IDepartmentRepository departmentRepository,
            IcoreUserRepository coreUserRepository,
            IAssetsTypeRepository assetsTypeRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _AssetsRepository = AssetsRepository;
            _AssProcessRecordRepository = AssProcessRecordRepository;
            _departmentRepository = departmentRepository;
            _coreUserRepository = coreUserRepository;
            _assetsTypeRepository = assetsTypeRepository;
            SMOSECDbContext = (SMOSECDbContext)dbContext;
        }

        #region 查询

        /// <summary>
        /// 根据资产编号返回资产信息
        /// </summary>
        /// <param name="ID">资产编号</param>
        /// <returns></returns>
        public AssetsOutputDto GetAssetsByID(string ID)
        {
            var dto = from assetse in SMOSECDbContext.Assetss
                from user in SMOSECDbContext.coreUsers
                join type in SMOSECDbContext.AssetsTypes on assetse.TYPEID equals type.TYPEID
                join location in SMOSECDbContext.AssLocations on assetse.LOCATIONID equals location.LOCATIONID
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
                   Unit = assetse.UNIT,
                   Status=assetse.STATUS
                };
            var assdto = dto.AsNoTracking().FirstOrDefault();

            if (assdto != null)
            {
                string CID = assdto.CurrentUser;
                if (!string.IsNullOrEmpty(CID))
                {
                    var name = from user in SMOSECDbContext.coreUsers
                        where user.USER_ID == CID
                        select user.USER_NAME;
                    assdto.CurrentUserName = name.FirstOrDefault();
                }
                if ( !string.IsNullOrEmpty(assdto.DepartmentId))
                {
                    var department = _departmentRepository.GetByID(assdto.DepartmentId);

                    var firstOrDefault = department.FirstOrDefault();
                    if (firstOrDefault != null)
                        assdto.DepartmentName = firstOrDefault.NAME;
                }
            }
            return assdto;
//            return dto.AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// 得到某区域所有的固定资产
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetAllAss(string LocationId)
        {
            var list = _AssetsRepository.GetAll().Where(x=>x.STATUS !=6);
            if (!string.IsNullOrEmpty(LocationId))
            {
                list = list.Where(a => a.LOCATIONID == LocationId);
            }
            list = list.OrderByDescending(a => a.CREATEDATE);
            var result = from assetse in list
                         join location in SMOSECDbContext.AssLocations on assetse.LOCATIONID equals location.LOCATIONID
                         join type in SMOSECDbContext.AssetsTypes on assetse.TYPEID equals type.TYPEID
                         select new
                         {
                             ASSID = assetse.ASSID,
                             Image = assetse.IMAGE,
                             DEPARTMENTID = assetse.DEPARTMENTID,
                             DepName = "",
                             Status = assetse.STATUS,
                             StatusName = "",
                             LocationName = location.NAME,
                             Name = assetse.NAME,
                             Price = assetse.PRICE,
                             SN = assetse.SN,
                             TypeName = type.NAME,
                             Specification = assetse.SPECIFICATION
                         };
            DataTable table = LINQToDataTable.ToDataTable(result);
            foreach (DataRow row in table.Rows)
            {
                Department dep = _departmentRepository.GetByID(row["DEPARTMENTID"].ToString()).FirstOrDefault();
                row["StatusName"] = Enum.GetName(typeof(STATUS), row["Status"]);
                if (dep != null)
                {
                    row["DepName"] = dep.NAME;
                }
            }
            return table;
        }

        /// <summary>
        /// 查询借用的资产数据,资产选择时用到
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">名称</param>
        /// <param name="UserID">用户编号</param>
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
        /// <param name="LocationID">区域编号</param>
        /// <param name="SN">序列号</param>
        /// <param name="UserID">用户名称</param>
        /// <returns></returns>
        public DataTable GetBorrowedAssEx(string LocationID, string SN, string UserID)
        {
            int status = (int)STATUS.借用中;
            var result = _AssetsRepository.GetAssByStatusEx(LocationID, SN, UserID, status);
            var ass = from assetse in result
                      join user in SMOSECDbContext.coreUsers on assetse.CURRENTUSER equals user.USER_ID
                      select new AssSelectOutputDto()
                      {
                          IsChecked = false,
                          IMAGE = assetse.IMAGE,
                          NAME = assetse.IMAGE,
                          ASSID = assetse.ASSID,
                          SN = assetse.SN,
                          USERNAME = user.USER_NAME

                      };
            return LINQToDataTable.ToDataTable(ass);
        }


        /// <summary>
        /// 查询处理记录
        /// </summary>
        /// <param name="ASSID">资产编号</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        public DataTable GetRecords(string ASSID,string CID)
        {
            if (!string.IsNullOrEmpty(ASSID))
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
                        ProcessModeName = "",
                        HandleMan = user.USER_NAME,
                        SN = assetse.SN
                    };
                DataTable tempTable = LINQToDataTable.ToDataTable(result);
                foreach (DataRow row in tempTable.Rows)
                {
                    row["ProcessModeName"] = Enum.GetName(typeof(PROCESSMODE), int.Parse(row["ProcessMode"].ToString()));
                }
                return tempTable;
            }
            else
            {
                var result = from processRecord in SMOSECDbContext.AssProcessRecords
                    join comConsumablese in SMOSECDbContext.Consumableses on processRecord.CID equals comConsumablese.CID
                    join user in SMOSECDbContext.coreUsers on processRecord.HANDLEMAN equals user.USER_ID
                    where processRecord.CID == CID
                    select new
                    {
                        PrId = processRecord.PRID,
                        ProcessMode = processRecord.PROCESSMODE,
                        ProcessContent = processRecord.PROCESSCONTENT,
                        CId = processRecord.CID,
                        HandleDate = processRecord.HANDLEDATE,
                        ProcessModeName = "",
                        HandleMan = user.USER_NAME
                    };
                DataTable tempTable = LINQToDataTable.ToDataTable(result);
                foreach (DataRow row in tempTable.Rows)
                {
                    row["ProcessModeName"] = Enum.GetName(typeof(PROCESSMODE), int.Parse(row["ProcessMode"].ToString()));
                }
                return tempTable;
            }
        }

        /// <summary>
        /// 查询即将失效的资产
        /// </summary>
        /// <param name="days">距离现在的天数</param>
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
        /// 查询在用的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
        /// <param name="UserID">当前所有者</param>
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
        /// <param name="LocationID">区域编号</param>
        /// <param name="SN">序列号</param>
        /// <param name="UserID">用户名称</param>
        /// <returns></returns>
        public DataTable GetInUseAssEx(string LocationID, string SN, string UserID)
        {
            int status = (int)STATUS.使用中;
            var result = _AssetsRepository.GetAssByStatusEx(LocationID, SN, UserID, status);
            var ass = from assetse in result
                      join user in SMOSECDbContext.coreUsers on assetse.CURRENTUSER equals user.USER_ID
                      select new AssSelectOutputDto()
                      {
                          IsChecked = false,
                          IMAGE = assetse.IMAGE,
                          NAME = assetse.IMAGE,
                          ASSID = assetse.ASSID,
                          SN = assetse.SN,
                          USERNAME = user.USER_NAME
                      };
            return LINQToDataTable.ToDataTable(ass);
        }

        /// <summary>
        /// 查询低于安全库存的资产(待修改)
        /// </summary>
        /// <returns></returns>
        public DataTable GetLackOfStockAss()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 查询空闲的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
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
        /// <param name="LocationID">区域编号</param>
        /// <param name="SN">资产编号</param>
        /// <returns></returns>
        public DataTable GetUnUsedAssEx(string LocationID, string SN)
        {
            int status = (int)STATUS.闲置;
            var result = _AssetsRepository.GetAssByStatusEx(LocationID, SN, null, status);
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 查询空闲的资产数据(除调入区域外的)
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
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

        /// <summary>
        /// 根据SN或者名称或者部门或者状态查询资产
        /// </summary>
        /// <param name="SNOrName">SN或者名称</param>
        /// <param name="LocationId">区域</param>
        /// <param name="DepId">部门编号</param>
        /// <param name="Status">资产状态</param>
        /// <param name="Type">资产类型</param>
        /// <returns></returns>
        public DataTable QueryAssets(string SNOrName, string LocationId, string DepId, string Status, string Type)
        {
            List<String> Types = new List<string>();
            if (String.IsNullOrEmpty(Type) == false)
            {
                Types.Add(Type);
                List<AssetsType> listType = _assetsTypeRepository.GetByParentTypeID(Type).AsNoTracking().ToList();
                foreach (AssetsType Row in listType)
                {
                    List<AssetsType> LastlistType = _assetsTypeRepository.GetByParentTypeID(Row.TYPEID).AsNoTracking().ToList();
                    foreach (AssetsType LastRow in LastlistType)
                    {
                        Types.Add(LastRow.TYPEID);
                    }
                    Types.Add(Row.TYPEID);
                }
            }

            coreUser coreUser = _coreUserRepository.GetUser(SNOrName).FirstOrDefault();
            if (coreUser != null && String.IsNullOrEmpty(SNOrName) == false)
            {
                var result = _AssetsRepository.QueryAssets(coreUser.USER_ID, Types).AsNoTracking();
                if (!string.IsNullOrEmpty(LocationId))
                {
                    result = result.Where(a => a.LOCATIONID == LocationId);
                }
                if (!string.IsNullOrEmpty(Status))
                {
                    int statusId = Convert.ToInt32(Status);
                    result = result.Where(a => a.STATUS == statusId);
                }
                if (!string.IsNullOrEmpty(DepId))
                {
                    result = result.Where(a => a.DEPARTMENTID == DepId);
                }
                DataTable table = LINQToDataTable.ToDataTable(result);
                table.Columns.Add("StatusName");
                table.Columns.Add("DepName");
                foreach (DataRow row in table.Rows)
                {
                    Department dep = _departmentRepository.GetByID(row["DEPARTMENTID"].ToString()).FirstOrDefault();
                    row["StatusName"] = Enum.GetName(typeof(STATUS), row["Status"]);
                    if (dep != null)
                    {
                        row["DepName"] = dep.NAME;
                    }
                }
                return table;
            }
            else
            {
                var result = _AssetsRepository.QueryAssets(SNOrName, Types).AsNoTracking();
                if (!string.IsNullOrEmpty(LocationId))
                {
                    result = result.Where(a => a.LOCATIONID == LocationId);
                }
                if (!string.IsNullOrEmpty(Status))
                {
                    int statusId = Convert.ToInt32(Status);
                    result = result.Where(a => a.STATUS == statusId);
                }
                if (!string.IsNullOrEmpty(DepId))
                {
                    result = result.Where(a => a.DEPARTMENTID == DepId);
                }
                DataTable table = LINQToDataTable.ToDataTable(result);
                table.Columns.Add("StatusName");
                table.Columns.Add("DepName");
                foreach (DataRow row in table.Rows)
                {
                    Department dep = _departmentRepository.GetByID(row["DEPARTMENTID"].ToString()).FirstOrDefault();
                    row["StatusName"] = Enum.GetName(typeof(STATUS), row["Status"]);
                    if (dep != null)
                    {
                        row["DepName"] = dep.NAME;
                    }
                }
                return table;
            }
        }

        /// <summary>
        /// 根据SN得到资产信息
        /// </summary>
        /// <param name="SN">SN编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetAssetsBySN(string SN, string LocationId)
        {
            var result = _AssetsRepository.GetAssetsBySN(SN).AsNoTracking();
            if (!string.IsNullOrEmpty(LocationId))
            {
                result = result.Where(a => a.LOCATIONID == LocationId);
            }
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 得到所有的Sn
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllSns()
        {
            var lists=new List<string>();
            lists = _AssetsRepository.GetAll().Select(a => a.SN).ToList();
            return lists;
        }

        /// <summary>
        /// 根据SN列表得到资产数据
        /// </summary>
        /// <param name="Sns">资产列表</param>
        /// <returns></returns>
        public DataTable GetBySnList(List<string> Sns)
        {
            if (Sns.Count > 0)
            {
                var list = _AssetsRepository.GetAll().Where(a => Sns.Contains(a.SN));
                var result = from assetse in list
                    join location in SMOSECDbContext.AssLocations on assetse.LOCATIONID equals location.LOCATIONID
                    join type in SMOSECDbContext.AssetsTypes on assetse.TYPEID equals type.TYPEID
                    select new
                    {
                        ASSID = assetse.ASSID,
                        Image = assetse.IMAGE,
                        LocationName = location.NAME,
                        Name = assetse.NAME,
                        Price = assetse.PRICE,
                        SN = assetse.SN,
                        TypeName = type.NAME,
                        Specification = assetse.SPECIFICATION,
                        RESULTNAME=""
                    };
                return LINQToDataTable.ToDataTable(result);
            }
            else
            {
                return new DataTable();
            }
            throw new NotImplementedException();
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
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(entity.AssId))
            {
                string MaxId = _AssetsRepository.GetMaxID();
                string AssId = Helper.GenerateID("ASS", MaxId);
                //产生资产编号
                entity.AssId = AssId;
            }
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

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="entity">资产信息</param>
        /// <returns></returns>
        public ReturnInfo UpdateAssets(AssetsInputDto entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            //产生资产编号
            string ValidateInfo = Helper.BasicValidate(entity).ToString();
            sb.Append(ValidateInfo);
            if (sb.Length == 0)
            {
                try
                {
                    Assets assets = _AssetsRepository.GetByID(entity.AssId).FirstOrDefault();
                    var originAss = Mapper.Map<Assets, AssetsOutputDto>(assets);
                    if (assets != null)
                    {
                        assets.BUYDATE = entity.BuyDate;
                        assets.CREATEUSER = entity.CreateUser;
                        assets.DEPARTMENTID = entity.DepartmentId;
                        assets.EXPIRYDATE = entity.ExpiryDate;
                        assets.IMAGE = entity.Image;
                        assets.LOCATIONID = entity.LocationId;
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
                    pr.PROCESSCONTENT = "修改资产"+entity.AssId+"。修改前数据:"+originAss.BuyDate
                        +","+originAss.DepartmentId+","+originAss.ExpiryDate+","+originAss.Image
                        +","+originAss.Name+","+originAss.Note+","+originAss.Place+","+originAss.Price
                        +","+originAss.SN+","+originAss.Specification+","+originAss.TypeId
                        +","+originAss.Unit+","+originAss.Vendor+"  修改后数据：" + assets.BUYDATE
                        + "," + assets.DEPARTMENTID + "," + assets.EXPIRYDATE + "," + assets.IMAGE
                        + "," + assets.NAME + "," + assets.NOTE + "," + assets.PLACE + "," + assets.PRICE
                        + "," + assets.SN + "," + assets.SPECIFICATION + "," + assets.TYPEID
                        + "," + assets.UNIT + "," + assets.VENDOR;
                    pr.PROCESSMODE = (int)PROCESSMODE.修改内容;
                    _unitOfWork.RegisterNew(pr);

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
        /// 删除资产(修改资产状态为已删除)
        /// </summary>
        /// <param name="assid"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ReturnInfo DeleteAssets(string assid,string userId)
        {
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            Assets assets = _AssetsRepository.GetByID(assid).FirstOrDefault();
            if(assets != null)
            {
                assets.STATUS = (int)STATUS.已删除;
                assets.MODIFYDATE = DateTime.Now;
                assets.MODIFYUSER = userId;
                _unitOfWork.RegisterDirty(assets);
                _unitOfWork.Commit();
                RInfo.IsSuccess = true;
                return RInfo;
            }
            else
            {
                sb.Append("该资产不存在，请检查!");
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = sb.ToString();
                return RInfo;
            }
        }
        #endregion
    }
}