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
using System.Data;
using System.Linq;
using System.Text;

namespace SMOSEC.Application.Services
{
    /// <summary>
    /// 耗材盘点单服务实现
    /// </summary>
    public class ConInventoryService : IConInventoryService
    {
        /// <summary>
        /// 工作单元的接口
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// 耗材信息的查询接口
        /// </summary>
        private IConsumablesRepository _conRepository;

        /// <summary>
        /// 耗材库存的查询接口
        /// </summary>
        private IConQuantRepository _conQuantRepository;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        private SMOSECDbContext _SMOSECDbContext;
        /// <summary>
        /// 区域的查询接口
        /// </summary>
        private IAssLocationRepository _assLocationRepository;
        /// <summary>
        /// 耗材盘点单的查询接口
        /// </summary>
        private IConInventoryRepository _conInventoryRepository;

        /// <summary>
        /// 耗材盘点结果行项的查询接口
        /// </summary>
        private IConInventoryResultRepository _conInventoryResultRepository;
        /// <summary>
        /// 耗材盘点的服务实现的构造函数
        /// </summary>
        public ConInventoryService(IUnitOfWork unitOfWork,
            IConsumablesRepository conRepository,
            IConQuantRepository conQuantRepository,
            IAssLocationRepository assLocationRepository,
            IConInventoryRepository conInventoryRepository,
            IConInventoryResultRepository conInventoryResultRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _conRepository = conRepository;
            _conQuantRepository = conQuantRepository;
            _assLocationRepository = assLocationRepository;
            _conInventoryRepository = conInventoryRepository;
            _conInventoryResultRepository = conInventoryResultRepository;
            _SMOSECDbContext = (SMOSECDbContext)dbContext;
        }

        #region 查询

        /// <summary>
        /// 根据盘点单编号得到盘点单详情
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public ConInventoryOutputDto GetConInventoryById(string IID)
        {
            try
            {
                var conInventory = _conInventoryRepository.GetConInventoryByID(IID);
                if (conInventory != null)
                {
                    var list = from Inventory in conInventory
                               join user in _SMOSECDbContext.coreUsers on Inventory.HANDLEMAN equals user.USER_ID
                               join location in _SMOSECDbContext.AssLocations on Inventory.LOCATIONID equals location.LOCATIONID
                               select new ConInventoryOutputDto()
                               {
                                   NAME = Inventory.NAME,
                                   CREATEDATE = Inventory.CREATEDATE,
                                   HANDLEMAN = Inventory.HANDLEMAN,
                                   HANDLEMANNAME = user.USER_NAME,
                                   IID = Inventory.IID,
                                   LOCATIONID = Inventory.LOCATIONID,
                                   LOCATIONNAME = location.NAME,
                                   STATUS = Inventory.STATUS,
                                   STATUSNAME = "",
                                   TOTAL = Inventory.TOTAL
                               };
                    var result = list.FirstOrDefault();
                    result.STATUSNAME = Enum.GetName(typeof(InventoryStatus), result.STATUS);
                    return result;
                }
                else
                {
                    throw new Exception("未找到该盘点");
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
        public DataTable GetConInventoryList(string UserId, string LocationId)
        {
            var area = _conInventoryRepository.GetAll();
            if (!string.IsNullOrEmpty(LocationId))
            {
                area = area.Where(a => a.LOCATIONID == LocationId);
            }
            if (!string.IsNullOrEmpty(UserId))
            {
                area = area.Where(a => a.HANDLEMAN == UserId);
            }
            var list = from conInventory in area
                       join user in _SMOSECDbContext.coreUsers on conInventory.HANDLEMAN equals user.USER_ID
                       orderby conInventory.CREATEDATE descending


                       select new ConInventoryListOutputDto()
                       {
                           IID = conInventory.IID,
                           NAME = conInventory.NAME,
                           CREATEDATE = conInventory.CREATEDATE,
                           CREATEUSER = user.USER_NAME,
                           TOTAL = conInventory.TOTAL,
                           RESULTCOUNT = conInventory.RESULTCOUNT,
                           STATUS = conInventory.STATUS,
                           STATUSNAME = "",
                           CanStart = "",
                           CanEdit = "",
                           CanDelete = "",
                           Time = ""
                       };
            var temTable = LINQToDataTable.ToDataTable(list);
            foreach (DataRow row in temTable.Rows)
            {
                int status = int.Parse(row["STATUS"].ToString());
                row["STATUSNAME"] = Enum.GetName(typeof(InventoryStatus), status);
                switch (status)
                {
                    case (int)InventoryStatus.盘点未开始:
                        row["CanStart"] = "开始盘点";
                        row["CanDelete"] = "删除";
                        row["CanEdit"] = "编辑";
                        break;
                    case (int)InventoryStatus.盘点中:
                        row["CanStart"] = "开始盘点";
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
        public DataTable GetConInventoryResultsByIID(string IID, ResultStatus Status)
        {
            int status = (int)Status;
            var list = _conInventoryResultRepository.GetResultsByStatus(IID, status);
            var results = from invR in list
                          join cons in _SMOSECDbContext.Consumableses on invR.CID equals cons.CID
                          join invs in _SMOSECDbContext.ConInventories on invR.IID equals invs.IID                      
                          select new ConInventoryResultOutputDto()
                          {
                              CID = invR.CID,
                              RESULT = invR.RESULT,
                              RESULTNAME = "",
                              Image = cons.IMAGE,
                              Name = cons.NAME,
                              Specification = cons.SPECIFICATION,
                              Unit = cons.UNIT,
                              Total=invR.TOTAL,
                              RealAmount=invR.REALAMOUNT
                          };
            DataTable tempTable = LINQToDataTable.ToDataTable(results);

            foreach (DataRow row in tempTable.Rows)
            {
                row["RESULTNAME"] = Enum.GetName(typeof(ResultStatus), int.Parse(row["RESULT"].ToString()));
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
            return _conInventoryResultRepository.IsExist(IID);
        }
        /// <summary>
        /// 根据区域编号,得到盘点清单
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetInventoryConList(string LocationId)
        {
            var conqlist = _conQuantRepository.GetInventoryCons(LocationId);
            var results = from conq in conqlist
                          join con in _SMOSECDbContext.Consumableses on conq.CID equals con.CID
                          select new ConInventoryResultOutputDto()
                          {
                              CID = con.CID,
                              RESULT = 0,
                              RESULTNAME = "待盘点",
                              Image = con.IMAGE,
                              Name = con.NAME,
                              Specification = con.SPECIFICATION,
                              Unit = con.UNIT,
                              Total=conq.QUANTITY
                              
                          };
            return LINQToDataTable.ToDataTable(results);
        }

        /// <summary>
        /// 得到盘点单待盘点列表
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetPendingInventoryTable(string IID, string LocationId)
        {
            bool isExist = IsExist(IID);
            if (isExist)
            {
                //存在记录,则从盘点单结果取数据
                return GetConInventoryResultsByIID(IID, ResultStatus.待盘点);
            }
            else
            {
                //不存在,则连表查询出结果
                return GetInventoryConList(LocationId);
            }
        }

        /// <summary>
        /// 得到盘点单需要盘点的列表
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public List<string> GetPendingInventoryList(string IID)
        {
            return _conInventoryResultRepository.GetOrdinaryList(IID);
        }

        /// <summary>
        /// 得到盘点单结果行项的结果字典
        /// </summary>
        /// <param name="IID">盘点单编号</param>
        /// <returns></returns>
        public Dictionary<string, List<Decimal>> GetResultDictionary(string IID)
        {
            Dictionary<string, List<Decimal>> assDictionary = new Dictionary<string, List<Decimal>>();
            var results = _conInventoryResultRepository.GetResultsByCID(IID, "");
            foreach (var result in results)
            {
                List<decimal> list = new List<decimal>();                
                list.Add(result.REALAMOUNT);
                list.Add(result.RESULT);
                assDictionary.Add(result.CID, list);
            }
            return assDictionary;
        }
        /// <summary>
        /// 根据盘点单号和耗材编号查询盘点行项
        /// </summary>
        /// <param name="IID"></param>
        /// <param name="CID"></param>
        /// <returns></returns>
        public ConInventoryResult GetResultByCID(string IID, string CID)
        {
            return _conInventoryResultRepository.GetResultsByCID(IID, CID).FirstOrDefault();
        }
        #endregion

        #region 操作
        /// <summary>
        /// 添加盘点单
        /// </summary>
        /// <param name="inputDto">盘点单信息</param>
        /// <returns></returns>
        public ReturnInfo AddConInventory(ConInventoryInputDto inputDto)
        {
            //验证
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _conInventoryRepository.GetMaxId();
            string IId = Helper.GenerateIDEx("CI", maxId);
            inputDto.IID = IId;
            sb.Append(Helper.BasicValidate(inputDto).ToString());
            if (sb.Length == 0)
            {
                var assbo = Mapper.Map<ConInventoryInputDto, ConInventory>(inputDto);
                assbo.STATUS = (int)InventoryStatus.盘点未开始;
                assbo.CREATEDATE = DateTime.Now;
                assbo.MODIFYDATE = DateTime.Now;

                AssLocation loc = _assLocationRepository.GetByID(inputDto.LOCATIONID).FirstOrDefault();
                if (loc.ISLOCKED == 1) throw new Exception("该区域已锁定,无法创建新的盘点单!");              
                try
                {
                    _unitOfWork.RegisterNew(assbo);

                    loc.ISLOCKED = 1;
                    _unitOfWork.RegisterDirty(loc);        //锁定区域

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
            var inventory = _conInventoryRepository.GetConInventoryByID(IID).FirstOrDefault();
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
                if (inventory.STATUS == (int)InventoryStatus.盘点未开始)
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
        public ReturnInfo UpdateInventory(ConInventoryInputDto inputDto)
        {
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            var inventory = _conInventoryRepository.GetConInventoryByID(inputDto.IID).FirstOrDefault();
            if (inventory == null)
            {
                sb.Append("未找到该编号的盘点单.");
                rInfo.IsSuccess = false;
                rInfo.ErrorInfo = sb.ToString();
                return rInfo;
            }
            else
            {
                if (inventory.STATUS == (int)InventoryStatus.盘点结束)
                {
                    sb.Append("该盘点单已经盘点结束.");
                    rInfo.IsSuccess = false;
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
                try
                {
                    List<string> assList = _conInventoryResultRepository.GetResultsByStatus(inputDto.IID, null).Select(a => a.CID).ToList();
                    int count = inputDto.ConDictionary.Count;
                    //更新盘点单结果行项
                    foreach (var key in inputDto.ConDictionary.Keys)
                    {
                        if (assList.Contains(key))
                        {
                            //更新
                            var inventoryresult = _conInventoryResultRepository.GetResultsByCID(inputDto.IID, key)
                                .FirstOrDefault();
                            if (inventoryresult != null)
                            {
                                inventoryresult.RESULT = Convert.ToInt32(inputDto.ConDictionary[key][1]);
                                inventoryresult.REALAMOUNT = inputDto.ConDictionary[key][0];
                                if (inventoryresult.RESULT == (int)ResultStatus.待盘点)
                                {
                                    count--;
                                }
                            }

                            _unitOfWork.RegisterDirty(inventoryresult);
                        }
                        else
                        {
                            //添加
                            ConInventoryResult result = new ConInventoryResult
                            {
                                IID = inputDto.IID,
                                CID = key,
                                REALAMOUNT= inputDto.ConDictionary[key][0],
                                RESULT = Convert.ToInt32(inputDto.ConDictionary[key][1]),
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
                            var conqs = _conQuantRepository.GetQuants(inputDto.LOCATIONID,key).FirstOrDefault();
                            if (conqs != null)
                            {
                                conqs.ISLOCKED = 0;
                                _unitOfWork.RegisterDirty(conqs);
                            }

                            AssLocation loc = _assLocationRepository.GetByID(inputDto.LOCATIONID).FirstOrDefault();
                            if(loc != null)
                            {
                                loc.ISLOCKED = 0;
                                _unitOfWork.RegisterDirty(loc);
                            }
                        }
                    }
                    //如果盘点结束，就更新盘点单状态
                    inventory.MODIFYUSER = inputDto.MODIFYUSER;
                    inventory.MODIFYDATE = DateTime.Now;
                    inventory.RESULTCOUNT = count;
                    if (inputDto.IsEnd)
                    {
                        inventory.STATUS = (int)InventoryStatus.盘点结束;
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
        public ReturnInfo UpdateInventoryOnly(AddCIResultInputDto inputDto)
        {
            //验证
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            if (sb.Length == 0)
            {
                var assInventory = _conInventoryRepository.GetConInventoryByID(inputDto.IID).FirstOrDefault();
                if (assInventory != null)
                {
                    assInventory.NAME = inputDto.Name;
                    assInventory.MODIFYDATE = DateTime.Now;
                    assInventory.HANDLEMAN = inputDto.HANDLEMAN;
                    assInventory.LOCATIONID = inputDto.LocationId;
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
        public ReturnInfo AddConInventoryResult(AddCIResultInputDto inputDto)
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
                    var inventory = _conInventoryRepository.GetConInventoryByID(inputDto.IID).FirstOrDefault();
                    if (inventory != null)
                    {
                        //添加当前的盘点单行项
                        List<string> conList = _conQuantRepository.GetInventoryCons(inventory.LOCATIONID).Select(a => a.CID).ToList();
                        inventory.STATUS = (int)InventoryStatus.盘点中;
                        inventory.TOTAL = conList.Count;
                        inventory.RESULTCOUNT = 0;
                        _unitOfWork.RegisterDirty(inventory);

                        foreach (var con in conList)
                        {
                            ConQuant conQuant= _conQuantRepository.GetByCID(con, inventory.LOCATIONID).FirstOrDefault();
                            ConInventoryResult result = new ConInventoryResult
                            {
                                IID = inputDto.IID,
                                CID = con,
                                RESULT = 0,
                                TOTAL = conQuant.QUANTITY,
                                CREATEDATE = DateTime.Now,
                                CREATEUSER = inputDto.UserId,
                                MODIFYDATE = DateTime.Now,
                                MODIFYUSER = inputDto.UserId
                            };
                            _unitOfWork.RegisterNew(result);

                            //更新盘点的物品状态为锁定
                            var conq = _conQuantRepository.GetQuants(inputDto.LocationId,con).FirstOrDefault();
                            if (conq != null)
                            {
                                conq.ISLOCKED = 1;
                                _unitOfWork.RegisterDirty(conq);
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
