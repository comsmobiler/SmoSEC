using System;
using System.Collections.Generic;
using System.Data;
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
    /// 资产盘点单服务实现
    /// </summary>
    public class AssInventoryService : IAssInventoryService
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
        /// 数据库上下文
        /// </summary>
        private SMOSECDbContext _SMOSECDbContext;

        /// <summary>
        /// 资产盘点单的查询接口
        /// </summary>
        private IAssInventoryRepository _assInventoryRepository;

        /// <summary>
        /// 资产盘点结果行项的查询接口
        /// </summary>
        private IAssInventoryResultRepository _assInventoryResultRepository;
        /// <summary>
        /// 资产盘点的服务实现的构造函数
        /// </summary>
        public AssInventoryService(IUnitOfWork unitOfWork,
            IAssetsRepository assetsRepository,
            IAssInventoryRepository assInventoryRepository,
            IAssInventoryResultRepository assInventoryResultRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _assetsRepository = assetsRepository;
            _assInventoryRepository = assInventoryRepository;
            _assInventoryResultRepository = assInventoryResultRepository;
            _SMOSECDbContext = (SMOSECDbContext)dbContext;
        }

        #region 查询

        /// <summary>
        /// 根据盘点单编号得到盘点单详情
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public AssInventoryOutputDto GetAssInventoryById(string IID)
        {
            try
            {
                var assInventory = _assInventoryRepository.GetAssInventoryByID(IID);
                if (assInventory != null)
                {
                    var list = from Inventory in assInventory
                        join user in _SMOSECDbContext.coreUsers on Inventory.HANDLEMAN equals user.USER_ID
                        join location in _SMOSECDbContext.AssLocations on Inventory.LOCATIONID equals location.LOCATIONID
                        select new AssInventoryOutputDto()
                        {
                            NAME = Inventory.NAME,
                            CREATEDATE = Inventory.CREATEDATE,
                            DEPARTMENTID = Inventory.DEPARTMENTID,
                            DEPARTMENTNAME = "",
                            HANDLEMAN = Inventory.HANDLEMAN,
                            HANDLEMANNAME = user.USER_NAME,
                            IID = Inventory.IID,
                            LOCATIONID = Inventory.LOCATIONID,
                            LOCATIONNAME = location.NAME,
                            STATUS = Inventory.STATUS,
                            STATUSNAME = "",
                            TYPEID = Inventory.TYPEID,
                            TYPENAME = "",
                            TOTAL = Inventory.TOTAL
                        };
                    var result = list.FirstOrDefault();
                    string departmentId= result.DEPARTMENTID;
                    if (!string.IsNullOrEmpty(departmentId))
                    {
                        var depart = from department in _SMOSECDbContext.Departments
                            where department.DEPARTMENTID == departmentId
                            select department.NAME;
                        result.DEPARTMENTNAME = depart.FirstOrDefault();
                    }
                    string typeId = result.TYPEID;
                    if (!string.IsNullOrEmpty(typeId))
                    {
                        var typeName = from type in _SMOSECDbContext.AssetsTypes
                            where type.TYPEID == typeId
                            select type.NAME;
                        result.TYPENAME = typeName.FirstOrDefault();
                    }
                    result.STATUSNAME= Enum.GetName(typeof(InventoryStatus), result.STATUS);
                    return result;
                }
                else
                {
                    throw  new Exception("未找到该盘点");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到盘点单列表
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetAssInventoryList(string UserId, string LocationId)
        {
            var area = _assInventoryRepository.GetAll();
            if (!string.IsNullOrEmpty(LocationId))
            {
                area = area.Where(a => a.LOCATIONID == LocationId);
            }
            if (!string.IsNullOrEmpty(UserId))
            {
                area = area.Where(a => a.HANDLEMAN == UserId);
            }
            var list = from assInventory in area
                join user in _SMOSECDbContext.coreUsers on assInventory.HANDLEMAN equals user.USER_ID 
                orderby assInventory.CREATEDATE descending 


                select new AssInventoryListOutputDto()
                {
                    IID = assInventory.IID,
                    NAME= assInventory.NAME,
                    CREATEDATE= assInventory.CREATEDATE,
                    CREATEUSER= user.USER_NAME,
                    TOTAL= assInventory.TOTAL,
                    RESULTCOUNT= assInventory.RESULTCOUNT,
                    STATUS = assInventory.STATUS,
                    STATUSNAME = "",
                    CanStart = "",
                    CanEdit = "",
                    CanDelete = "",
                    Time=""
                };
            var temTable = LINQToDataTable.ToDataTable(list);
            foreach (DataRow row in temTable.Rows)
            {
                int status = int.Parse(row["STATUS"].ToString());
                row["STATUSNAME"]= Enum.GetName(typeof(InventoryStatus), status);
                switch (status)
                {
                    case (int)InventoryStatus.盘点未开始:
                        row["CanStart"] = "开始盘点";
                        row["CanDelete"] = "删除";
                        row["CanEdit"] = "编辑";
                        break;
                    case (int)InventoryStatus.盘点中:
                        row["CanStart"]= "开始盘点";
                        break;
                }
                row["Time"] = DateTime.Parse(row["CREATEDATE"].ToString()).ToShortDateString();
            }
            return temTable;
        }

        /// <summary>
        /// 根据盘点单编号得到结果行项信息
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public DataTable GetAssInventoryResultsByIID(string IID, ResultStatus Status)
        {
            int status = (int) Status;
            var list = _assInventoryResultRepository.GetResultsByStatus(IID,status);
            var results = from inventoryResult in list
                join assetse in _SMOSECDbContext.Assetss on inventoryResult.ASSID equals assetse.ASSID
                from type in _SMOSECDbContext.AssetsTypes
                from location in _SMOSECDbContext.AssLocations
                where assetse.TYPEID==type.TYPEID && assetse.LOCATIONID==location.LOCATIONID
                select new AssInventoryResultOutputDto()
                {
                    ASSID = inventoryResult.ASSID,
                    RESULT = inventoryResult.RESULT,
                    RESULTNAME = "",
                    Image = assetse.IMAGE,
                    LocationId = assetse.LOCATIONID,
                    LocationName = location.NAME,
                    Name = assetse.NAME,
                    Place = assetse.PLACE,
                    Price = assetse.PRICE,
                    SN = assetse.SN,
                    TypeId = assetse.TYPEID,
                    TypeName = type.NAME,
                    Specification = assetse.SPECIFICATION,
                    Unit = assetse.UNIT
                };
            DataTable tempTable= LINQToDataTable.ToDataTable(results);

            foreach (DataRow row in tempTable.Rows)
            {
                if(int.Parse(row["RESULT"].ToString())!= (int)ResultStatus.存在)
                {
                    row["RESULTNAME"] = Enum.GetName(typeof(ResultStatus), int.Parse(row["RESULT"].ToString()));
                }
                
            }
            return tempTable;
        }

        /// <summary>
        /// 查询是否已经有盘点单结果记录
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public bool IsExist(string IID)
        {
            return _assInventoryResultRepository.IsExist(IID);
        }
        /// <summary>
        /// 根据区域编号,类型和部门编号,得到盘点清单
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        /// <param name="typeId">类型编号</param>
        /// <param name="DepartmentId">部门编号</param>
        /// <returns></returns>
        public DataTable GetInventoryAssList(string LocationId, string typeId, string DepartmentId)
        {
            var asslist = _assetsRepository.GetInventoryAssetses(LocationId, typeId, DepartmentId);
            var results = from assetse in asslist
                from type in _SMOSECDbContext.AssetsTypes
                from location in _SMOSECDbContext.AssLocations
                where assetse.TYPEID == type.TYPEID && assetse.LOCATIONID == location.LOCATIONID
                select new AssInventoryResultOutputDto()
                {
                    ASSID = assetse.ASSID,
                    RESULT = 0,
                    RESULTNAME = "待盘点",
                    Image = assetse.IMAGE,
                    LocationId = assetse.LOCATIONID,
                    LocationName = location.NAME,
                    Name = assetse.NAME,
                    Place = assetse.PLACE,
                    Price = assetse.PRICE,
                    SN = assetse.SN,
                    TypeId = assetse.TYPEID,
                    TypeName = type.NAME,
                    Specification = assetse.SPECIFICATION,
                    Unit = assetse.UNIT
                };
            return LINQToDataTable.ToDataTable(results);
        }

        /// <summary>
        /// 得到盘点单待盘点列表
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <param name="typeId">类型编号</param>
        /// <param name="DepartmentId">部门编号</param>
        /// <returns></returns>
        public DataTable GetPendingInventoryTable(string IID,string LocationId,string typeId,string DepartmentId)
        {
            bool isExist = IsExist(IID);
            if (isExist)
            {
                //存在记录,则从盘点单结果取数据
                return GetAssInventoryResultsByIID(IID, ResultStatus.待盘点);
            }
            else
            {
                //不存在,则连表查询出结果
                return GetInventoryAssList(LocationId, typeId, DepartmentId);
            }
        }

        /// <summary>
        /// 得到盘点单需要盘点的列表
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public List<string> GetPendingInventoryList(string IID)
        {
            return _assInventoryResultRepository.GetOrdinaryList(IID);
        }

        /// <summary>
        /// 得到盘点单结果行项的结果字典
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public Dictionary<string, int> GetResultDictionary(string IID)
        {
            Dictionary<string,int> assDictionary=new Dictionary<string, int>();
            var results = _assInventoryResultRepository.GetResultsByAssId(IID, "");
            foreach (var result in results)
            {
                assDictionary.Add(result.ASSID,result.RESULT);
            }
            return assDictionary;
        }


        #endregion

        #region 操作
        /// <summary>
        /// 添加盘点单
        /// </summary>
        /// <param name="inputDto">盘点单信息</param>
        /// <returns></returns>
        public ReturnInfo AddAssInventory(AssInventoryInputDto inputDto)
        {
            //验证
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _assInventoryRepository.GetMaxId();
            string IId = Helper.GenerateIDEx("AI", maxId);
            inputDto.IID = IId;
            sb.Append(Helper.BasicValidate(inputDto).ToString());
            if (sb.Length == 0)
            {
                var assbo = Mapper.Map<AssInventoryInputDto, AssInventory>(inputDto);
                assbo.STATUS = (int) InventoryStatus.盘点未开始;
                assbo.CREATEDATE = DateTime.Now;
                assbo.MODIFYDATE = DateTime.Now;
                try
                {
                    _unitOfWork.RegisterNew(assbo);

                    
                    bool result = _unitOfWork.Commit();
                    rInfo.IsSuccess = result;
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    sb.Append(ex.Message);
                    rInfo.IsSuccess = false;
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
            }
            else
            {
                rInfo.IsSuccess = false;
                rInfo.ErrorInfo = sb.ToString();
                return rInfo;
            }
        }

        /// <summary>
        /// 删除盘点单
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public ReturnInfo DeleteInventory(string IID)
        {
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            var inventory = _assInventoryRepository.GetAssInventoryByID(IID).FirstOrDefault();
            if (inventory == null)
            {
                sb.Append("未找到该编号的盘点单.");
                rInfo.IsSuccess = false;
                rInfo.ErrorInfo = sb.ToString();
                return rInfo;
            }
            else
            {
                //根据盘点单状态，已开始盘点就不能删除了
                if (inventory.STATUS == (int) InventoryStatus.盘点未开始)
                {
                    //可以删除
                    try
                    {
                        _unitOfWork.RegisterDeleted(inventory);
                        _unitOfWork.Commit();
                        rInfo.IsSuccess = true;
                        rInfo.ErrorInfo = sb.ToString();
                        return rInfo;
                    }
                    catch (Exception ex)
                    {
                        _unitOfWork.Rollback();
                        sb.Append(ex.Message);
                        rInfo.IsSuccess = false;
                        rInfo.ErrorInfo = sb.ToString();
                        return rInfo;
                    }

                }
                else
                {
                    rInfo.IsSuccess = false;
                    sb.Append("已经开始盘点,无法删除盘点单.");
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
            }
        }

        /// <summary>
        /// 更新盘点单
        /// </summary>
        /// <param name="inputDto">盘点单信息</param>
        /// <returns></returns>
        public ReturnInfo UpdateInventory(AssInventoryInputDto inputDto)
        {
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            var inventory = _assInventoryRepository.GetAssInventoryByID(inputDto.IID).FirstOrDefault();
            if (inventory == null)
            {
                sb.Append("未找到该编号的盘点单.");
                rInfo.IsSuccess = false;
                rInfo.ErrorInfo = sb.ToString();
                return rInfo;
            }
            else
            {
                if (inventory.STATUS == (int) InventoryStatus.盘点结束)
                {
                    sb.Append("该盘点单已经盘点结束.");
                    rInfo.IsSuccess = false;
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
                try
                {
                    List<string> assList = _assInventoryResultRepository.GetResultsByStatus(inputDto.IID, null).Select(a => a.ASSID).ToList();
                    int count = inputDto.AssDictionary.Count;
                    //更新盘点单结果行项
                    foreach (var key in inputDto.AssDictionary.Keys)
                    {
                        if (assList.Contains(key))
                        {
                            //更新
                            var inventoryresult = _assInventoryResultRepository.GetResultsByAssId(inputDto.IID, key)
                                .FirstOrDefault();
                            if (inventoryresult != null)
                            {
                                inventoryresult.RESULT = inputDto.AssDictionary[key];
                                if (inventoryresult.RESULT == (int) ResultStatus.待盘点)
                                {
                                    count--;
                                }
                            }
                            
                            _unitOfWork.RegisterDirty(inventoryresult);
                        }
                        else
                        {
                            //添加
                            AssInventoryResult result = new AssInventoryResult
                            {
                                IID = inputDto.IID,
                                ASSID = key,
                                RESULT = inputDto.AssDictionary[key],
                                CREATEDATE = DateTime.Now,
                                MODIFYDATE = DateTime.Now,
                                CREATEUSER = inputDto.MODIFYUSER,
                                MODIFYUSER = inputDto.MODIFYUSER
                            };
                            _unitOfWork.RegisterNew(result);

                        }
                        if (inputDto.IsEnd)
                        {
                            //如果盘点结束，就更新资产状态为非锁定
                            var assets = _assetsRepository.GetByID(key).FirstOrDefault();
                            if (assets != null)
                            {
                                assets.ISLOCKED = 0;
                                _unitOfWork.RegisterDirty(assets);
                            }
                        }
                    }
                    //如果盘点结束，就更新盘点单状态
                    inventory.MODIFYUSER = inputDto.MODIFYUSER;
                    inventory.MODIFYDATE = DateTime.Now;
                    inventory.RESULTCOUNT = count;
                    if (inputDto.IsEnd)
                    {
                        inventory.STATUS = (int) InventoryStatus.盘点结束;
                    }
                    _unitOfWork.RegisterDirty(inventory);

                    _unitOfWork.Commit();
                    rInfo.IsSuccess = true;
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    sb.Append(ex.Message);
                    rInfo.IsSuccess = false;
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
            }

        }

        /// <summary>
        /// 只更新盘点单表头
        /// </summary>
        /// <param name="inputDto">所需数据</param>
        /// <returns></returns>
        public ReturnInfo UpdateInventoryOnly(AddAIResultInputDto inputDto)
        {
            //验证
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            if (sb.Length == 0)
            {
                var assInventory = _assInventoryRepository.GetAssInventoryByID(inputDto.IID).FirstOrDefault();
                if (assInventory != null)
                {
                    assInventory.NAME = inputDto.Name;
                    assInventory.MODIFYDATE = DateTime.Now;
                    assInventory.HANDLEMAN = inputDto.HANDLEMAN;
                    assInventory.DEPARTMENTID = inputDto.DepartmentId;
                    assInventory.LOCATIONID = inputDto.LocationId;
                    assInventory.TYPEID = inputDto.typeId;
                    try
                    {
                        _unitOfWork.RegisterDirty(assInventory);


                        bool result = _unitOfWork.Commit();
                        rInfo.IsSuccess = result;
                        rInfo.ErrorInfo = sb.ToString();
                        return rInfo;
                    }
                    catch (Exception ex)
                    {
                        _unitOfWork.Rollback();
                        sb.Append(ex.Message);
                        rInfo.IsSuccess = false;
                        rInfo.ErrorInfo = sb.ToString();
                        return rInfo;
                    }
                }
                else
                {
                    rInfo.IsSuccess = false;
                    sb.Append("未找到该盘点单.");
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
            }
            else
            {
                rInfo.IsSuccess = false;
                rInfo.ErrorInfo = sb.ToString();
                return rInfo;
            }
        }

        /// <summary>
        /// 开始盘点
        /// </summary>
        /// <param name="inputDto">开始盘点时,传给后台的数据</param>
        /// <returns></returns>
        public ReturnInfo AddAssInventoryResult(AddAIResultInputDto inputDto)
        {
            ReturnInfo RInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            if (IsExist(inputDto.IID))
            {
                RInfo.IsSuccess = true;
                RInfo.ErrorInfo = sb.ToString();
                return RInfo;
            }
            else
            {
                try
                {
                    //更新盘点单状态为盘点中
                    var inventory = _assInventoryRepository.GetAssInventoryByID(inputDto.IID).FirstOrDefault();
                    if (inventory != null)
                    {

                        //添加当前的盘点单行项
                        List<string> assList = _assetsRepository.GetInventoryAssetses(inventory.LOCATIONID, inventory.TYPEID, inventory.DEPARTMENTID).Select(a => a.ASSID).ToList();
                        inventory.STATUS = (int) InventoryStatus.盘点中;
                        inventory.TOTAL = assList.Count;
                        inventory.RESULTCOUNT = 0;
                        _unitOfWork.RegisterDirty(inventory);

                        foreach (var asset in assList)
                        {
                            AssInventoryResult result = new AssInventoryResult
                            {
                                IID = inputDto.IID,
                                ASSID = asset,
                                RESULT = 0,
                                CREATEDATE = DateTime.Now,
                                CREATEUSER = inputDto.UserId,
                                MODIFYDATE = DateTime.Now,
                                MODIFYUSER = inputDto.UserId
                            };
                            _unitOfWork.RegisterNew(result);

                            //更新盘点的物品状态为锁定
                            var assets = _assetsRepository.GetByID(asset).FirstOrDefault();
                            if (assets != null)
                            {
                                assets.ISLOCKED = 1;
                                _unitOfWork.RegisterDirty(assets);
                            }
                        }

                    }               
                    _unitOfWork.Commit();
                    RInfo.IsSuccess = true;
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
        }
        #endregion
    }
}