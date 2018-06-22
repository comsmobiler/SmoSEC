using AutoMapper;
using SMOSEC.Application.IServices;
using SMOSEC.CommLib;
using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.Enum;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMOSEC.Application.Services
{
    /// <summary>
    /// 报修单的接口实现
    /// </summary>
    public class AssScrapOrderService : IAssScrapOrderService
    {
        /// <summary>
        /// 工作单元的接口
        /// </summary>
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// 报废单的查询接口
        /// </summary>
        private IAssScrapOrderRepository _AssScrapOrderRepository;
        /// <summary>
        /// 报废单行项的查询接口
        /// </summary>
        private IAssScrapOrderRowRepository _AssScrapOrderRowRepository;
        /// <summary>
        /// 资产的查询接口
        /// </summary>
        private IAssetsRepository _AssetsRepository;
        /// <summary>
        /// 资产序列号的查询接口
        /// </summary>
        private IAssetsSNRepository _AssetsSNRepository;
        /// <summary>
        /// 处理记录的查询接口
        /// </summary>
        private IAssProcessRecordRepository _AssProcessRecordRepository;
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private SMOSECDbContext SMOSECDbContext;

        /// <summary>
        /// 成本中心服务实现的构造函数
        /// </summary>
        public AssScrapOrderService(IUnitOfWork unitOfWork,
            IAssScrapOrderRepository AssScrapOrderRepository,
            IAssScrapOrderRowRepository AssScrapOrderRowRepository,
            IAssetsRepository AssetsRepository,
            IAssetsSNRepository AssetsSNRepository,
            IcoreUserRepository coreUserRepository,
            IAssProcessRecordRepository AssProcessRecordRepository,
            IAssLocationRepository AssLocationRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _AssScrapOrderRepository = AssScrapOrderRepository;
            _AssScrapOrderRowRepository = AssScrapOrderRowRepository;
            _AssetsRepository = AssetsRepository;
            _AssetsSNRepository = AssetsSNRepository;
            _AssProcessRecordRepository = AssProcessRecordRepository;
            SMOSECDbContext = (SMOSECDbContext)dbContext;
        }
        #region 查询
        /// <summary>
        /// 根据用户编号返回报废单信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<AssScrapOrder> GetByUser(String UserID)
        {
            return _AssScrapOrderRepository.GetByUser(UserID).AsNoTracking().ToList();
        }
        /// <summary>
        /// 根据报修单编号返回报废单信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SOInputDto GetByID(string ID)
        {
            SOInputDto ro = Mapper.Map<AssScrapOrder, SOInputDto>(_AssScrapOrderRepository.GetByID(ID).AsNoTracking().FirstOrDefault());
            ro.Rows = _AssScrapOrderRowRepository.GetBySOID(ID).AsNoTracking().ToList();
            return ro;
        }
        /// <summary>
        /// 根据报修行项编号返回报废单行项信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public AssScrapOrderRow GetRowByRowID(String SOID, String SOROWID)
        {
            return _AssScrapOrderRowRepository.GetByID(SOID, SOROWID).AsNoTracking().FirstOrDefault();
        }
        #endregion
        #region 操作
        /// <summary>
        /// 新增报废单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnInfo AddAssScrapOrder(SOInputDto entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            if (String.IsNullOrEmpty(entity.SCRAPMAN)) throw new Exception("报废人不能为空");
            if (String.IsNullOrEmpty(entity.SCRAPDATE.ToString())) throw new Exception("报废日期不能为空");
            String MaxID = _AssScrapOrderRepository.GetMaxID();        //获取当前最大报修单编号
            String NowID = Helper.GeneratePRID("S", MaxID);                //生成最新的报修单编号
            entity.SOID = NowID;
            try
            {
                AssScrapOrder OrderData = new AssScrapOrder();
                OrderData.SOID = NowID;
                OrderData.SCRAPMAN = entity.SCRAPMAN;
                OrderData.SCRAPDATE = entity.SCRAPDATE;
                OrderData.NOTE = entity.NOTE;
                OrderData.STATUS = entity.STATUS;
                OrderData.CREATEDATE = entity.CREATEDATE;
                OrderData.CREATEUSER = entity.CREATEUSER;
                _unitOfWork.RegisterNew(OrderData);
                AddAssScrapOrderRow(entity);


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
        /// 更新报废单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnInfo UpdateAssScrapOrder(SOInputDto entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            try
            {
                if (String.IsNullOrEmpty(entity.SOID)) throw new Exception("报废单编号不能为空");

                AssScrapOrder aro = _AssScrapOrderRepository.GetByID(entity.SOID).FirstOrDefault();
                if (aro != null)
                {
                    if (aro.STATUS == 1)
                    {
                        throw new Exception("只有已报废的的才能还原");
                    }
                    else
                    {
                        List<AssScrapOrderRow> Rows = _AssScrapOrderRowRepository.GetScrapBySOID(aro.SOID).AsNoTracking().ToList();
                        if (Rows.Count == entity.Rows.Count)
                            aro.STATUS = 1;
                        //更新报修单行项
                        aro.MODIFYDATE = entity.MODIFYDATE;
                        aro.MODIFYUSER = entity.MODIFYUSER;
                        _unitOfWork.RegisterDirty(aro);
                        UpdateAssScrapOrderRow(entity);

                        bool result = _unitOfWork.Commit();
                        RInfo.IsSuccess = result;
                        RInfo.ErrorInfo = "修改成功!";
                        return RInfo;
                    }
                }
                else
                {
                    throw new Exception("报修单不存在!");
                }
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
        /// 新增报废单行项
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnInfo AddAssScrapOrderRow(SOInputDto entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            try
            {
                String SOROWID = "0";
                if (entity.Rows != null)
                {
                    foreach (AssScrapOrderRow Row in entity.Rows)
                    {
                        SOROWID = (int.Parse(SOROWID) + 1).ToString();
                        Row.SOID = entity.SOID;
                        Row.SOROWID = SOROWID;
                        if (GetRowByRowID(Row.SOID, Row.SOROWID) != null)
                            throw new Exception("报废单行项号已存在!");
                        _unitOfWork.RegisterNew(Row);
                        //往AssProcessRecord表添加数据
                        CreateSR(entity, Row, PROCESSMODE.清理报废);

                        Assets assetsSN = _AssetsRepository.GetByID(Row.ASSID).FirstOrDefault();
                        if (assetsSN == null)
                            throw new Exception("不存在条码为:" + Row.ASSID + "的资产!");

                        assetsSN.STATUS = (Int32)STATUS.报废;
                        _unitOfWork.RegisterDirty(assetsSN);
                    }
                    RInfo.IsSuccess = true;
                    RInfo.ErrorInfo = "维修单行项创建成功！";
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = ex.Message;
            }
            return RInfo;
        }
        /// <summary>
        /// 更新报废单行项
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnInfo UpdateAssScrapOrderRow(SOInputDto entity)
        {
            ReturnInfo RInfo = new ReturnInfo();
            try
            {
                AssScrapOrderRow assROR = new AssScrapOrderRow();
                foreach (AssScrapOrderRow Row in entity.Rows)
                {
                    assROR = _AssScrapOrderRowRepository.GetByID(entity.SOID, Row.SOROWID).FirstOrDefault();
                    if (assROR == null) throw new Exception("报废单行项：" + Row.SOROWID + "不存在！");
                    assROR.SCRAPQTY = assROR.SCRAPQTY - Convert.ToDecimal(Row.RETURNQTY);     //报废数量
                    if (Row.SCRAPQTY < 0) throw new Exception("还原数量不能超过报废总数");
                    assROR.RETURNQTY = Convert.ToDecimal(assROR.RETURNQTY) + Row.RETURNQTY;
                    if (assROR.SCRAPQTY == 0)       //如果全部维修完毕，则修改行项状态
                        assROR.STATUS = 1;

                    //更新OrderRow数据
                    _unitOfWork.RegisterDirty(assROR);
                    //往AssProcessRecord表添加数据
                    CreateSR(entity, Row, PROCESSMODE.报废还原);

                    Assets assetsSN = _AssetsRepository.GetByID(Row.ASSID).FirstOrDefault();
                    if (assetsSN == null)
                        throw new Exception("不存在条码为:" + Row.ASSID + "的资产!");

                    assetsSN.STATUS = (Int32)STATUS.闲置;
                    _unitOfWork.RegisterDirty(assetsSN);
                }
                RInfo.IsSuccess = true;
                RInfo.ErrorInfo = "维修单行项更新成功！";
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                RInfo.IsSuccess = false;
                RInfo.ErrorInfo = ex.Message;
            }
            return RInfo;
        }
        /// <summary>
        /// 创建ProcessRecorder表数据
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="RowData"></param>
        /// <param name="Type"></param>
        public void CreateSR(SOInputDto Data, AssScrapOrderRow RowData, PROCESSMODE Type)
        {
            AssProcessRecord assProcessRecord = new AssProcessRecord
            {
                ASSID = RowData.ASSID,          //资产条码
                CREATEDATE = DateTime.Now,      //创建时间
                CREATEUSER = Data.CREATEUSER,   //创建用户
                HANDLEDATE = DateTime.Now,      //处理时间
                MODIFYDATE = DateTime.Now,      //修改时间
                MODIFYUSER = Data.MODIFYUSER,   //修改用户
            };
            switch (Type)
            {
                case PROCESSMODE.清理报废:
                    assProcessRecord.QUANTITY = RowData.SCRAPQTY;
                    assProcessRecord.PROCESSMODE = (Int32)PROCESSMODE.清理报废;
                    assProcessRecord.HANDLEMAN = Data.CREATEUSER;
                    break;
                case PROCESSMODE.报废还原:
                    assProcessRecord.QUANTITY = RowData.SCRAPQTY;
                    assProcessRecord.PROCESSMODE = (Int32)PROCESSMODE.报废还原;
                    assProcessRecord.HANDLEMAN = Data.MODIFYUSER;
                    break;
            }
            assProcessRecord.ASSID = RowData.ASSID;
            switch (Type)         //根据操作模式，输入操作内容
            {
                case PROCESSMODE.清理报废:
                    assProcessRecord.PROCESSCONTENT = Data.CREATEUSER + "报废了物品编号为" + RowData.ASSID + "的资产";
                    break;
                case PROCESSMODE.报废还原:
                    assProcessRecord.PROCESSCONTENT = Data.CREATEUSER + "还原了物品编号为" + RowData.ASSID + "的资产";
                    break;
            }
            _unitOfWork.RegisterNew(assProcessRecord);
        }
        #endregion
    }
}
