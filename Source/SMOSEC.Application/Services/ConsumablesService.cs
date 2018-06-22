using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// 耗材的服务实现
    /// </summary>
    public class ConsumablesService : IConsumablesService
    {
        /// <summary>
        /// 工作单元的接口
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// 耗材库存信息的查询接口
        /// </summary>
        private IConQuantRepository _conQuantRepository;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        private SMOSECDbContext _SMOSECDbContext;

        /// <summary>
        /// 耗材的查询接口
        /// </summary>
        private IConsumablesRepository _consumablesRepository;
        /// <summary>
        /// 入库单的查询接口
        /// </summary>
        private IWarehouseReceiptRepository _warehouseReceiptRepository;

        /// <summary>
        /// 退库单的查询接口
        /// </summary>
        private IOutboundOrderRepository _outboundOrderRepository;

        /// <summary>
        /// 耗材的服务实现的构造函数
        /// </summary>
        public ConsumablesService(IUnitOfWork unitOfWork,
            IConQuantRepository conQuantRepository,
            IConsumablesRepository consumablesRepository,
            IWarehouseReceiptRepository warehouseReceiptRepository,
            IOutboundOrderRepository outboundOrderRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _conQuantRepository = conQuantRepository;
            _consumablesRepository = consumablesRepository;
            _warehouseReceiptRepository = warehouseReceiptRepository;
            _outboundOrderRepository = outboundOrderRepository;
            _SMOSECDbContext = (SMOSECDbContext)dbContext;
        }

        #region 查询
        /// <summary>
        /// 根据耗材编号得到耗材信息
        /// </summary>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        public ConsumablesOutputDto GetConsumablesByID(string CID)
        {
            var dto = Mapper.Map<Consumables, ConsumablesOutputDto>(_consumablesRepository.GetByID(CID).AsNoTracking().FirstOrDefault());
            return dto;
        }

        /// <summary>
        /// 根据用户编号得到出库单列表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetOOListByUserId(string userId, string LocationId)
        {
            var list = _outboundOrderRepository.GetByUserId(userId).AsNoTracking();
            if (!string.IsNullOrEmpty(LocationId))
            {
                list = list.Where(a => a.LOCATIONID == LocationId);
            }
            var result = from outboundOrder in list
                join user in _SMOSECDbContext.coreUsers on outboundOrder.HANDLEMAN equals user.USER_ID
                join location in _SMOSECDbContext.AssLocations on outboundOrder.LOCATIONID equals location.LOCATIONID
                select new
                {
                    HANDLEMAN = user.USER_ID,
                    HANDLEMANNAME= user.USER_NAME,
                    OOID = outboundOrder.OOID,
                    BUSINESSDATE = outboundOrder.BUSINESSDATE,
                    LOCATIONNAME = location.NAME,
                    HANDLEDATE=outboundOrder.HANDLEDATE,
                    NOTE=outboundOrder.NOTE
                };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 得到耗材列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetConList()
        {
            var list = _consumablesRepository.GetAll().AsNoTracking();
            return LINQToDataTable.ToDataTable(list);
        }

        /// <summary>
        /// 根据出库单编号得到出库单信息
        /// </summary>
        /// <param name="id">出库单编号</param>
        /// <returns></returns>
        public OutboundOrderOutputDto GetOutboundOrderById(string id)
        {
            var result = from outboundOrder in _SMOSECDbContext.OutboundOrders
                join user in _SMOSECDbContext.coreUsers on outboundOrder.HANDLEMAN equals user.USER_ID
                join location in _SMOSECDbContext.AssLocations on outboundOrder.LOCATIONID equals location.LOCATIONID
                where outboundOrder.OOID==id
                select new OutboundOrderOutputDto
                {
                    HANDLEMAN = outboundOrder.HANDLEMAN,
                    HANDLEMANNAME = user.USER_NAME,
                    OOID = outboundOrder.OOID,
                    BUSINESSDATE = outboundOrder.BUSINESSDATE,
                    LOCATIONID = outboundOrder.LOCATIONID,
                    LOCATIONNAME = location.NAME,
                    HANDLEDATE = outboundOrder.HANDLEDATE,
                    NOTE = outboundOrder.NOTE,
                    TYPE = outboundOrder.TYPE
                };
            OutboundOrderOutputDto dto = result.FirstOrDefault();
            if (dto!= null)
            {
                dto.TYPENAME = "";
            }
            return dto;
        }

        /// <summary>
        /// 根据区域编号和耗材编号得到耗材库存
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        public DataTable GetQuants(string LocationID, string CID)
        {
            var list = _conQuantRepository.GetQuants(LocationID,CID).AsNoTracking();
            var result = from conQuant in list
                join consumablese in _SMOSECDbContext.Consumableses on conQuant.CID equals consumablese.CID 
                join location in _SMOSECDbContext.AssLocations on conQuant.LOCATIONID equals location.LOCATIONID
                select new
                {
                    CID=conQuant.CID,
                    NAME=consumablese.NAME,
                    LOCATIONNAME = location.NAME,
                    QUANTITY=conQuant.QUANTITY
                };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 根据入库单编号得到入库单信息
        /// </summary>
        /// <param name="id">入库单编号</param>
        /// <returns></returns>
        public WarehouseReceiptOutputDto GetWarehouseReceiptById(string id)
        {
            var result = from warehouseReceipt in _SMOSECDbContext.WarehouseReceipts
                join user in _SMOSECDbContext.coreUsers on warehouseReceipt.HANDLEMAN equals user.USER_ID
                join location in _SMOSECDbContext.AssLocations on warehouseReceipt.LOCATIONID equals location.LOCATIONID
                where warehouseReceipt.WRID == id
                select new WarehouseReceiptOutputDto
                {
                    HANDLEMAN = warehouseReceipt.HANDLEMAN,
                    HANDLEMANNAME = user.USER_NAME,
                    WRID = warehouseReceipt.WRID,
                    BUSINESSDATE = warehouseReceipt.BUSINESSDATE,
                    LOCATIONID = warehouseReceipt.LOCATIONID,
                    LOCATIONNAME = location.NAME,
                    HANDLEDATE = warehouseReceipt.HANDLEDATE,
                    NOTE = warehouseReceipt.NOTE,
                    VENDOR =warehouseReceipt.VENDOR
                };
            return result.FirstOrDefault();
        }

        /// <summary>
        /// 根据用户编号得到入库单列表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetWRListByUserId(string userId, string LocationId)
        {
            var list = _warehouseReceiptRepository.GetByUserId(userId).AsNoTracking();
            if (!string.IsNullOrEmpty(LocationId))
            {
                list = list.Where(a => a.LOCATIONID == LocationId);
            }
            var result = from warehouseReceipt in list
                join user in _SMOSECDbContext.coreUsers on warehouseReceipt.HANDLEMAN equals user.USER_ID
                join location in _SMOSECDbContext.AssLocations on warehouseReceipt.LOCATIONID equals location.LOCATIONID
                select new WarehouseReceiptOutputDto
                {                   
                    HANDLEMANNAME = user.USER_NAME,
                    WRID = warehouseReceipt.WRID,
                    BUSINESSDATE = warehouseReceipt.BUSINESSDATE,
                    LOCATIONNAME = location.NAME,
                    HANDLEDATE = warehouseReceipt.HANDLEDATE,
                    NOTE = warehouseReceipt.NOTE,
                    VENDOR = warehouseReceipt.VENDOR
                };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 根据区域编号和耗材名称模糊查询耗材信息
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        /// <param name="Name">耗材名称</param>
        /// <returns></returns>
        public DataTable GetConListByLocationAndName(string LocationId, string Name)
        {
            var list = _consumablesRepository.GetByName(Name);
            var result = from conQuant in _SMOSECDbContext.ConQuants
                join consumablese in list on conQuant.CID equals consumablese.CID
                where conQuant.LOCATIONID == LocationId && conQuant.QUANTITY>0
                select new
                {
                    CID = conQuant.CID,
                    NAME = consumablese.NAME,
                    IsChecked=false,
                    IMAGE=consumablese.IMAGE,
                    QUANT= conQuant.QUANTITY,
                    QUANTITY = 0,
                    MONEY = 0
                };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 根据耗材名称得到耗材信息
        /// </summary>
        /// <param name="Name">耗材名称</param>
        /// <returns></returns>
        public DataTable GetConListByName(string Name)
        {
            var list = _consumablesRepository.GetByName(Name);
            var result = from  consumablese in list
                select new
                {
                    CID = consumablese.CID,
                    NAME = consumablese.NAME,
                    IsChecked = false,
                    IMAGE = consumablese.IMAGE,
                    QUANTITY=0,
                    MONEY=0
                };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 根据出库单编号得到出库单行项列表
        /// </summary>
        /// <param name="OOId">出库单编号</param>
        /// <returns></returns>
        public DataTable GetOORowListByOOId(string OOId)
        {
            var result = from row in _SMOSECDbContext.OutboundOrderRows
                join consumablese in _SMOSECDbContext.Consumableses on row.CID equals consumablese.CID
                where row.OOID == OOId
                select new
                {
                    IMAGE = consumablese.IMAGE,
                    CID = row.CID,
                    NAME = consumablese.NAME,
                    QUANTITY = row.QUANTITY,
                    MONEY = row.MONEY,
                    NOTE = row.NOTE
                };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 根据入库单编号得到入库单行项列表
        /// </summary>
        /// <param name="WRId">入库单编号</param>
        /// <returns></returns>
        public DataTable GetWRRowListByWRId(string WRId)
        {
            var result = from row in _SMOSECDbContext.WarehouseReceiptRows
                join consumablese in _SMOSECDbContext.Consumableses on row.CID equals consumablese.CID
                where row.WRID == WRId
                select new
                {
                    IMAGE = consumablese.IMAGE,
                    CID = row.CID,
                    NAME = consumablese.NAME,
                    QUANTITY = row.QUANTITY,
                    MONEY = row.MONEY,
                    NOTE = row.NOTE
                };
            return LINQToDataTable.ToDataTable(result);
        }

        #endregion

        #region 操作
        /// <summary>
        /// 添加耗材
        /// </summary>
        /// <param name="inputDto">耗材信息</param>
        /// <returns></returns>
        public ReturnInfo AddConsumables(ConsumablesInputDto inputDto)
        {
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _consumablesRepository.GetMaxID();
            string CId = Helper.GenerateIDEx("C", maxId);
            inputDto.CID = CId;
            sb.Append(Helper.BasicValidate(inputDto).ToString());
            if (sb.Length == 0)
            {
                var consumable = Mapper.Map<ConsumablesInputDto, Consumables>(inputDto);
                consumable.CREATEDATE = DateTime.Now;
                consumable.MODIFYDATE = DateTime.Now;
                try
                {
                    _unitOfWork.RegisterNew(consumable);                   
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
        /// 更新耗材
        /// </summary>
        /// <param name="inputDto">耗材信息</param>
        /// <returns></returns>
        public ReturnInfo UpdateConsumables(ConsumablesInputDto inputDto)
        {
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(Helper.BasicValidate(inputDto).ToString());
            if (sb.Length == 0)
            {
                try
                {
                    Consumables consumable = _consumablesRepository.GetByID(inputDto.CID).FirstOrDefault();
                    if (consumable != null)
                    {
                        consumable.MODIFYDATE = DateTime.Now;
                        consumable.IMAGE = inputDto.IMAGE;
                        consumable.MODIFYUSER = inputDto.MODIFYUSER;
                        consumable.NAME = inputDto.NAME;
                        consumable.NOTE = inputDto.NOTE;
                        consumable.SAFECEILING = inputDto.SAFECEILING;
                        consumable.SAFEFLOOR = inputDto.SAFEFLOOR;
                        consumable.SPECIFICATION = inputDto.SPECIFICATION;
                        consumable.SPQ = inputDto.SPQ;
                        consumable.UNIT = inputDto.UNIT;
                        _unitOfWork.RegisterDirty(consumable);

                    }
                    
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
        /// 添加出库单
        /// </summary>
        /// <param name="inputDto">出库单信息</param>
        /// <returns></returns>
        public ReturnInfo AddOutboundOrder(OutboundOrderInputDto inputDto)
        {
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _outboundOrderRepository.GetMaxId();
            string OoId = Helper.GenerateIDEx("OO", maxId);
            inputDto.OOID = OoId;
            sb.Append(Helper.BasicValidate(inputDto).ToString());
            if (sb.Length == 0)
            {
                var outbound = Mapper.Map<OutboundOrderInputDto, OutboundOrder>(inputDto);
                outbound.CREATEDATE = DateTime.Now;
                outbound.MODIFYDATE = DateTime.Now;
                try
                {
                    _unitOfWork.RegisterNew(outbound);

                    foreach (var rowInput in inputDto.RowInputDtos)
                    {
                        OutboundOrderRow row = new OutboundOrderRow
                        {
                            CID = rowInput.CID,
                            MONEY = rowInput.MONEY,
                            CREATEUSER = inputDto.CREATEUSER,
                            CREATEDATE = DateTime.Now,
                            MODIFYUSER = inputDto.MODIFYUSER,
                            MODIFYDATE = DateTime.Now,
                            NOTE = rowInput.NOTE,
                            OOID = OoId,
                            QUANTITY = rowInput.QUANTITY
                        };
                        _unitOfWork.RegisterNew(row);

                        //修改库存
                        ConQuant quant = _conQuantRepository.GetQuants(inputDto.LOCATIONID, rowInput.CID)
                            .FirstOrDefault();
                        if (quant != null)
                        {
                            quant.QUANTITY = quant.QUANTITY - rowInput.QUANTITY;
                            quant.MODIFYDATE=DateTime.Now;
                            quant.MODIFYUSER = inputDto.MODIFYUSER;
                            _unitOfWork.RegisterDirty(quant);
                        }
                        //添加处理记录
                        var pr = new AssProcessRecord
                        {
                            ASSID = "",                            
                            CID = rowInput.CID,                            
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = inputDto.CREATEUSER,
                            HANDLEDATE = DateTime.Now,
                            HANDLEMAN = inputDto.HANDLEMAN,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = inputDto.MODIFYUSER,
                            PROCESSCONTENT = inputDto.CREATEUSER + "出库了"+row.CID+",数量为"+rowInput.QUANTITY,
                            PROCESSMODE = (int)PROCESSMODE.出库,
                            QUANTITY = rowInput.QUANTITY
                        };
                        _unitOfWork.RegisterNew(pr);
                    }

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
        /// 添加入库单
        /// </summary>
        /// <param name="inputDto">入库单信息</param>
        /// <returns></returns>
        public ReturnInfo AddWarehouseReceipt(WarehouseReceiptInputDto inputDto)
        {
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _warehouseReceiptRepository.GetMaxId();
            string WRId = Helper.GenerateIDEx("WR", maxId);
            inputDto.WRID = WRId;
            sb.Append(Helper.BasicValidate(inputDto).ToString());
            if (sb.Length == 0)
            {
                var warehouseReceipt = Mapper.Map<WarehouseReceiptInputDto, WarehouseReceipt>(inputDto);
                warehouseReceipt.CREATEDATE = DateTime.Now;
                warehouseReceipt.MODIFYDATE = DateTime.Now;
                try
                {
                    _unitOfWork.RegisterNew(warehouseReceipt);

                    foreach (var rowInput in inputDto.RowInputDtos)
                    {
                        WarehouseReceiptRow row = new WarehouseReceiptRow
                        {
                            CID = rowInput.CID,
                            MONEY = rowInput.MONEY,
                            CREATEUSER = inputDto.CREATEUSER,
                            CREATEDATE = DateTime.Now,
                            MODIFYUSER = inputDto.MODIFYUSER,
                            MODIFYDATE = DateTime.Now,
                            NOTE = rowInput.NOTE,
                            WRID = WRId,
                            QUANTITY = rowInput.QUANTITY
                        };
                        _unitOfWork.RegisterNew(row);

                        //修改库存
                        ConQuant quant = _conQuantRepository.GetQuants(inputDto.LOCATIONID, rowInput.CID)
                            .FirstOrDefault();
                        if (quant != null)
                        {
                            quant.QUANTITY = quant.QUANTITY - rowInput.QUANTITY;
                            quant.MODIFYDATE = DateTime.Now;
                            quant.MODIFYUSER = inputDto.MODIFYUSER;
                            _unitOfWork.RegisterDirty(quant);
                        }
                        else
                        {
                            ConQuant Quant = new ConQuant
                            {
                                QUANTITY = rowInput.QUANTITY,
                                MODIFYDATE = DateTime.Now,
                                MODIFYUSER = inputDto.MODIFYUSER,
                                CID = rowInput.CID,
                                CREATEUSER = inputDto.CREATEUSER,
                                CREATEDATE = DateTime.Now,
                                LOCATIONID = inputDto.LOCATIONID
                            };
                            _unitOfWork.RegisterNew(Quant);
                        }
                        //添加处理记录
                        var pr = new AssProcessRecord
                        {
                            ASSID = "",
                            CID = rowInput.CID,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = inputDto.CREATEUSER,
                            HANDLEDATE = DateTime.Now,
                            HANDLEMAN = inputDto.HANDLEMAN,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = inputDto.MODIFYUSER,
                            PROCESSCONTENT = inputDto.CREATEUSER + "入库了" + row.CID + ",数量为" + rowInput.QUANTITY,
                            PROCESSMODE = (int) PROCESSMODE.入库,
                            QUANTITY = rowInput.QUANTITY
                        };
                        _unitOfWork.RegisterNew(pr);
                    }

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
        /// 删除耗材
        /// </summary>
        /// <param name="CID">耗材编号</param>
        /// <returns></returns>
        public ReturnInfo DeleteConsumables(string CID)
        {
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            var consumable = _consumablesRepository.GetByID(CID).FirstOrDefault();
            if (consumable == null)
            {
                sb.Append("未找到该编号的耗材.");
                rInfo.IsSuccess = false;
                rInfo.ErrorInfo = sb.ToString();
                return rInfo;
            }
            else
            {
                var quant = _conQuantRepository.GetQuants("", CID);
                if (quant == null||quant.ToList().Count==0)
                {
                    try
                    {
                        _unitOfWork.RegisterDeleted(consumable);
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
                    sb.Append("存在入库记录,故无法删除。");
                    rInfo.IsSuccess = false;
                    rInfo.ErrorInfo = sb.ToString();
                    return rInfo;
                }
            }
//            return rInfo;
        }



        #endregion

    }
}