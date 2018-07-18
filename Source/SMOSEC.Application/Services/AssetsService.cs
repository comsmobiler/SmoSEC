using System;
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
    /// 资产操作(借用,归还,领用,退库)的服务实现
    /// </summary>
    public class AssetsService : IAssetsService
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
        /// 借用单的查询接口
        /// </summary>
        private IAssBorrowOrderRepository _assBorrowOrderRepository;

        /// <summary>
        /// 领用单的查询接口
        /// </summary>
        private IAssCollarOrderRepository _assCollarOrderRepository;

        /// <summary>
        /// 退库单的查询接口
        /// </summary>
        private IAssRestoreOrderRepository _assRestoreOrderRepository;

        /// <summary>
        /// 归还单的查询接口
        /// </summary>
        private IAssReturnOrderRepository _assReturnOrderRepository;

        /// <summary>
        /// 部门的查询接口
        /// </summary>
        private IDepartmentRepository _departmentRepository;
        /// <summary>
        /// 资产操作(借用,归还,领用,退库)的服务实现的构造函数
        /// </summary>
        public AssetsService(IUnitOfWork unitOfWork,
            IAssetsRepository assetsRepository,
            IAssBorrowOrderRepository assBorrowOrderRepository,
            IAssCollarOrderRepository assCollarOrderRepository,
            IAssRestoreOrderRepository assRestoreOrderRepository,
            IAssReturnOrderRepository assReturnOrderRepository,
            IDepartmentRepository departmentRepository,
            IDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _assetsRepository = assetsRepository;
            _assBorrowOrderRepository = assBorrowOrderRepository;
            _assCollarOrderRepository = assCollarOrderRepository;
            _assRestoreOrderRepository = assRestoreOrderRepository;
            _assReturnOrderRepository = assReturnOrderRepository;
            _departmentRepository = departmentRepository;
            _SMOSECDbContext = (SMOSECDbContext)dbContext;
        }

        #region 查询
        /// <summary>
        /// 根据借用单编号返回借用单信息
        /// </summary>
        /// <param name="id">借用单编号</param>
        /// <returns></returns>
        public AssBorrowOrderOutputDto GetBobyId(string id)
        {
            var dto = from assBorrowOrder in _SMOSECDbContext.AssBorrowOrders
                      join user in _SMOSECDbContext.coreUsers on assBorrowOrder.BORROWER equals user.USER_ID
                      join user2 in _SMOSECDbContext.coreUsers on assBorrowOrder.BRHANDLEMAN equals user2.USER_ID
                      join location in _SMOSECDbContext.AssLocations on assBorrowOrder.LOCATIONID equals location.LOCATIONID
                      where assBorrowOrder.BOID == id
                      select new AssBorrowOrderOutputDto()
                      {
                          Boid = assBorrowOrder.BOID,
                          Borrowdate = assBorrowOrder.BORROWDATE,
                          Borrower = user.USER_NAME,
                          Brhandleman = user2.USER_NAME,
                          Eptreturndate = assBorrowOrder.EPTRETURNDATE,
                          Locationid = location.NAME,
                          Note = assBorrowOrder.NOTE

                      };
            return dto.FirstOrDefault();
        }

        /// <summary>
        /// 根据用户编号返回借用单信息,用户编号为空则返回全部
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetBoByUserId(string userId, string LocationId)
        {
            var list = _assBorrowOrderRepository.GetByUserId(userId).AsNoTracking();
            if (!string.IsNullOrEmpty(LocationId))
            {
                list = list.Where(a => a.LOCATIONID == LocationId);
            }
            var result = from borrowOrder in list
                         join user in _SMOSECDbContext.coreUsers on borrowOrder.BORROWER equals user.USER_ID
                         join location in _SMOSECDbContext.AssLocations on borrowOrder.LOCATIONID equals location.LOCATIONID
                         select new
                         {
                             BORROWER = user.USER_NAME,
                             BOID = borrowOrder.BOID,
                             BORROWDATE = borrowOrder.BORROWDATE,
                             LOCATIONNAME = location.NAME
                         };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 得到对应的借用单行项列表
        /// <param name="boid">借用单编号</param>
        /// </summary>
        /// <returns></returns>
        public DataTable GetRowsByBoid(string boid)
        {
            var result = from ass in _SMOSECDbContext.Assetss
                         from bo in _SMOSECDbContext.AssBorrowOrders
                         from row in _SMOSECDbContext.AssBorrowOrderRows
                         where ass.ASSID == row.ASSID && bo.BOID == boid && bo.BOID == row.BOID
                         select new OperDetailSnOutputDto()
                         {
                             Assid = ass.ASSID,
                             Image = ass.IMAGE,
                             Name = ass.NAME,
                             Sn = ass.SN
                         };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 根据领用单编号返回领用单信息
        /// </summary>
        /// <param name="id">领用单编号</param>
        /// <returns></returns>
        public AssCollarOrderOutputDto GetCobyId(string id)
        {
            var dto = from assCollarOrder in _SMOSECDbContext.AssCollarOrders
                      join user in _SMOSECDbContext.coreUsers on assCollarOrder.USERID equals user.USER_ID
                      join user2 in _SMOSECDbContext.coreUsers on assCollarOrder.HANDLEMAN equals user2.USER_ID
                      join location in _SMOSECDbContext.AssLocations on assCollarOrder.LOCATIONID equals location.LOCATIONID
                      where assCollarOrder.COID == id
                      select new AssCollarOrderOutputDto()
                      {
                          Coid = assCollarOrder.COID,
                          Collardate = assCollarOrder.COLLARDATE,
                          Userid = user.USER_NAME,
                          Handleman = user2.USER_NAME,
                          Eptrestoredate = assCollarOrder.EPTRESTOREDATE,
                          Locationid = location.NAME,
                          Note = assCollarOrder.NOTE,
                          Place = assCollarOrder.PLACE,
                          Inusedep = assCollarOrder.INUSEDDEP
                      };
            var assCollarOrderOutputDto = dto.FirstOrDefault();
            if (assCollarOrderOutputDto != null && !string.IsNullOrEmpty(assCollarOrderOutputDto.Inusedep))
            {
                var department = _departmentRepository.GetByID(assCollarOrderOutputDto.Inusedep);

                var firstOrDefault = department.FirstOrDefault();
                if (firstOrDefault != null)
                    assCollarOrderOutputDto.Inusedep = firstOrDefault.NAME;
            }
            return assCollarOrderOutputDto;
        }

        /// <summary>
        /// 根据用户编号返回领用单信息,用户编号为空则返回全部
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetCoByUserId(string userId, string LocationId)
        {
            var list = _assCollarOrderRepository.GetByUserId(userId).AsNoTracking();
            if (!string.IsNullOrEmpty(LocationId))
            {
                list = list.Where(a => a.LOCATIONID == LocationId);
            }
            var result = from collarOrder in list
                         join user in _SMOSECDbContext.coreUsers on collarOrder.USERID equals user.USER_ID
                         join location in _SMOSECDbContext.AssLocations on collarOrder.LOCATIONID equals location.LOCATIONID
                         select new
                         {
                             Userid = user.USER_NAME,
                             CoId = collarOrder.COID,
                             LocationName = location.NAME,
                             Collardate = collarOrder.COLLARDATE,
                             InUsedDep = collarOrder.INUSEDDEP,
                             Place = collarOrder.PLACE
                         };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 得到对应的领用单行项列表
        /// <param name="coid">领用单编号</param>
        /// </summary>
        /// <returns></returns>
        public DataTable GetRowsByCoid(string coid)
        {
            var result = from ass in _SMOSECDbContext.Assetss
                         from co in _SMOSECDbContext.AssCollarOrders
                         from row in _SMOSECDbContext.AssCollarOrderRows
                         where ass.ASSID == row.ASSID && co.COID == coid && co.COID == row.COID
                         select new OperDetailSnOutputDto()
                         {
                             Assid = ass.ASSID,
                             Image = ass.IMAGE,
                             Name = ass.NAME,
                             Sn = ass.SN
                         };
            return LINQToDataTable.ToDataTable(result);

        }

        /// <summary>
        /// 得到对应的退库单信息
        /// <param name="rsoid">退库单编号</param>
        /// </summary>
        /// <returns></returns>
        public AssRestoreOrderOutputDto GetRsobyId(string rsoid)
        {
            var dto = from assRestoreOrder in _SMOSECDbContext.AssRestoreOrders
                      join user2 in _SMOSECDbContext.coreUsers on assRestoreOrder.HANDLEMAN equals user2.USER_ID
                      join location in _SMOSECDbContext.AssLocations on assRestoreOrder.LOCATIONID equals location.LOCATIONID
                      where assRestoreOrder.RSOID == rsoid
                      select new AssRestoreOrderOutputDto()
                      {
                          Rsoid = assRestoreOrder.RSOID,
                          Restoredate = assRestoreOrder.RESTOREDATE,
                          Handleman = user2.USER_NAME,
                          LocationName = location.NAME,
                          Note = assRestoreOrder.NOTE,
                          Place = assRestoreOrder.PLACE

                      };
            return dto.FirstOrDefault();
        }

        /// <summary>
        /// 根据用户编号返回退库单信息,用户编号为空则返回全部
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetRsoByUserId(string userId, string LocationId)
        {
            var list = _assRestoreOrderRepository.GetByUserID(userId).AsNoTracking();
            if (!string.IsNullOrEmpty(LocationId))
            {
                list = list.Where(a => a.LOCATIONID == LocationId);
            }
            var result = from restoreOrder in list
                         join user in _SMOSECDbContext.coreUsers on restoreOrder.HANDLEMAN equals user.USER_ID
                         join location in _SMOSECDbContext.AssLocations on restoreOrder.LOCATIONID equals location.LOCATIONID
                         select new
                         {
                             HandleMan = user.USER_NAME,
                             Rsoid = restoreOrder.RSOID,
                             LocationName = location.NAME,
                             Restoredate = restoreOrder.RESTOREDATE,
                         };

            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 得到对应的退库单行项列表
        /// <param name="rsoid">退库单编号</param>
        /// </summary>
        /// <returns></returns>
        public DataTable GetRowsByRsoid(string rsoid)
        {
            var result = from ass in _SMOSECDbContext.Assetss
                         from rso in _SMOSECDbContext.AssRestoreOrders
                         from row in _SMOSECDbContext.AssRestoreOrderRows
                         where ass.ASSID == row.ASSID && rso.RSOID == rsoid && rso.RSOID == row.RSOID
                         select new OperDetailSnOutputDto()
                         {
                             Assid = ass.ASSID,
                             Image = ass.IMAGE,
                             Name = ass.NAME,
                             Sn = ass.SN
                         };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 得到对应的归还单列表
        /// <param name="rtoid">归还单编号</param>
        /// </summary>
        /// <returns></returns>
        public AssReturnOrderOutputDto GetRtobyId(string rtoid)
        {
            var dto = from assReturnOrder in _SMOSECDbContext.AssReturnOrders
                      join user2 in _SMOSECDbContext.coreUsers on assReturnOrder.HANDLEMAN equals user2.USER_ID
                      join location in _SMOSECDbContext.AssLocations on assReturnOrder.LOCATIONID equals location.LOCATIONID
                      where assReturnOrder.RTOID == rtoid
                      select new AssReturnOrderOutputDto()
                      {
                          Rtoid = assReturnOrder.RTOID,
                          Returndate = assReturnOrder.RETURNDATE,
                          Handleman = user2.USER_NAME,
                          Locationid = location.NAME,
                          Note = assReturnOrder.NOTE

                      };
            return dto.FirstOrDefault();
        }

        /// <summary>
        /// 根据用户编号返回归还单信息,用户编号为空则返回全部
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="LocationId">区域编号</param>
        /// <returns></returns>
        public DataTable GetRtoByUserId(string userId, string LocationId)
        {
            var list = _assReturnOrderRepository.GetByUserID(userId).AsNoTracking();
            if (!string.IsNullOrEmpty(LocationId))
            {
                list = list.Where(a => a.LOCATIONID == LocationId);
            }
            var result = from returnOrder in list
                         join user in _SMOSECDbContext.coreUsers on returnOrder.HANDLEMAN equals user.USER_ID
                         join location in _SMOSECDbContext.AssLocations on returnOrder.LOCATIONID equals location.LOCATIONID
                         select new
                         {
                             Rtoid = returnOrder.RTOID,
                             LocationName = location.NAME,
                             Returndate = returnOrder.RETURNDATE,
                             HandleMan=user.USER_NAME
                         };
            return LINQToDataTable.ToDataTable(result);
        }

        /// <summary>
        /// 得到对应的归还单行项列表
        /// <param name="rtoid">归还单编号</param>
        /// </summary>
        /// <returns></returns>
        public DataTable GetRowsByRtoid(string rtoid)
        {
            var result = from ass in _SMOSECDbContext.Assetss
                         from rto in _SMOSECDbContext.AssReturnOrders
                         from row in _SMOSECDbContext.AssReturnOrderRows
                         where ass.ASSID == row.ASSID && rto.RTOID == rtoid && rto.RTOID == row.RTOID
                         select new OperDetailSnOutputDto()
                         {
                             Assid = ass.ASSID,
                             Image = ass.IMAGE,
                             Name = ass.NAME,
                             Sn = ass.SN
                         };
            return LINQToDataTable.ToDataTable(result);
        }


        #endregion

        #region 操作
        /// <summary>
        /// 更换使用者
        /// </summary>
        /// <param name="ASSID">资产编号</param>
        /// <param name="CurrentUser">当前使用者</param>
        /// <param name="UserID">操作用户</param>
        /// <returns></returns>
        public ReturnInfo ChangeUser(String ASSID, String CurrentUser, String UserID)
        {
            ReturnInfo RInfo = new ReturnInfo();
            Assets assets = _assetsRepository.GetByID(ASSID).FirstOrDefault();
            if (assets != null)
            {
                String LastUser = assets.CURRENTUSER;
                assets.CURRENTUSER = CurrentUser;
                try
                {
                    _unitOfWork.RegisterDirty(assets);

                    AssProcessRecord assRecord = new AssProcessRecord
                    {
                        ASSID = ASSID,
                        HANDLEDATE = DateTime.Now,
                        HANDLEMAN = UserID,
                        PROCESSMODE = (int)PROCESSMODE.使用人变更,
                        PROCESSCONTENT = "变更资产" + ASSID + "的使用者:" + LastUser + "为" + CurrentUser,
                        CREATEDATE = DateTime.Now,
                        CREATEUSER = UserID,
                        MODIFYDATE = DateTime.Now,
                        MODIFYUSER = UserID,
                        QUANTITY = 1,
                    };
                    _unitOfWork.RegisterNew(assRecord);
                    bool result = _unitOfWork.Commit();
                    RInfo.IsSuccess = result;
                    RInfo.ErrorInfo = "变更使用人成功";
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
            else
            {
                throw new Exception("不存在该资产");
            }
        }
        /// <summary>
        /// 添加借用单
        /// </summary>
        /// <param name="borrowOrderInput">借用单信息</param>
        /// <returns></returns>
        public ReturnInfo AddAssBorrowOrder(AssBorrowOrderInputDto borrowOrderInput)
        {
            //验证
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _assBorrowOrderRepository.GetMaxId();
            string boId = Helper.GenerateIDEx("BO", maxId);
            borrowOrderInput.BOID = boId;
            sb.Append(Helper.BasicValidate(borrowOrderInput).ToString());
            if (sb.Length == 0)
            {
                var assbo = Mapper.Map<AssBorrowOrderInputDto, AssBorrowOrder>(borrowOrderInput);
                assbo.CREATEDATE = DateTime.Now;
                assbo.MODIFYDATE = DateTime.Now;
                try
                {
                    _unitOfWork.RegisterNew(assbo);

                    foreach (var assId in borrowOrderInput.AssIds)
                    {

                        //修改Asset的状态
                        Assets assets = _assetsRepository.GetByID(assId).FirstOrDefault();
                        if (assets != null)
                        {
                            assets.STATUS = (int)STATUS.借用中;
                            assets.CURRENTUSER = borrowOrderInput.BORROWER;

                            //得到借用人的区域，并修改资产的区域为借用人的区域                           
                            var User = _SMOSECDbContext.coreUsers.Where(a => a.USER_ID == assbo.BORROWER)
                                .AsNoTracking().FirstOrDefault();
                            if (User != null)
                            {
                                assets.LOCATIONID = User.USER_LOCATIONID;
                                assets.DEPARTMENTID = User.USER_DEPARTMENTID;
                            }
                            else
                            {
                                
                                throw new Exception("该用户不存在。");
                            }
                            _unitOfWork.RegisterDirty(assets);
                        }
                        //添加行项
                        var corow = new AssBorrowOrderRow
                        {
                            ASSID = assId,
                            BOID = boId,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = borrowOrderInput.CREATEUSER,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = borrowOrderInput.MODIFYUSER
                        };
                        _unitOfWork.RegisterNew(corow);

                        //添加处理记录
                        var pr = new AssProcessRecord
                        {
                            ASSID = assId,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = borrowOrderInput.CREATEUSER,
                            HANDLEDATE = DateTime.Now,
                            HANDLEMAN = borrowOrderInput.BRHANDLEMAN,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = borrowOrderInput.MODIFYUSER,
                            PROCESSCONTENT = borrowOrderInput.BORROWER + "借用了" + assId,
                            PROCESSMODE = (int)PROCESSMODE.借用,
                            QUANTITY = 1
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
        /// 添加领用单
        /// </summary>
        /// <param name="collarOrderInput">领用单信息</param>
        /// <returns></returns>
        public ReturnInfo AddAssCollarOrder(AssCollarOrderInputDto collarOrderInput)
        {
            //验证
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _assCollarOrderRepository.GetMaxId();
            string coId = Helper.GenerateIDEx("CO", maxId);
            collarOrderInput.COID = coId;
            sb.Append(Helper.BasicValidate(collarOrderInput).ToString());
            if (sb.Length == 0)
            {
                var assco = Mapper.Map<AssCollarOrderInputDto, AssCollarOrder>(collarOrderInput);
                assco.CREATEDATE = DateTime.Now;
                assco.MODIFYDATE = DateTime.Now;
                try
                {
                    _unitOfWork.RegisterNew(assco);

                    foreach (var assId in collarOrderInput.AssIds)
                    {
                        //修改Asset的状态
                        Assets assets = _assetsRepository.GetByID(assId).FirstOrDefault();
                        if (assets != null)
                        {
                            assets.STATUS = (int)STATUS.使用中;
                            assets.CURRENTUSER = collarOrderInput.USERID;

                            var User = _SMOSECDbContext.coreUsers.Where(a => a.USER_ID == assco.USERID)
                                .AsNoTracking().FirstOrDefault();
                            if (User != null)
                            {
                                assets.LOCATIONID = User.USER_LOCATIONID;
                                assets.DEPARTMENTID = User.USER_DEPARTMENTID;
                            }
                            else
                            {
                                throw new Exception("该用户不存在。");
                            }
                            _unitOfWork.RegisterDirty(assets);
                        }
                        //添加行项
                        var corow = new AssCollarOrderRow
                        {
                            ASSID = assId,
                            COID = coId,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = collarOrderInput.CREATEUSER,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = collarOrderInput.MODIFYUSER
                        };
                        _unitOfWork.RegisterNew(corow);

                        //添加处理记录
                        var pr = new AssProcessRecord
                        {
                            ASSID = assId,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = collarOrderInput.CREATEUSER,
                            HANDLEDATE = DateTime.Now,
                            HANDLEMAN = collarOrderInput.HANDLEMAN,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = collarOrderInput.MODIFYUSER,
                            PROCESSCONTENT = collarOrderInput.USERID + "领用了" + assId,
                            PROCESSMODE = (int)PROCESSMODE.领用,
                            QUANTITY = 1
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
        /// 添加归还单
        /// </summary>
        /// <param name="returnOrderInput">归还单信息</param>
        /// <returns></returns>
        public ReturnInfo AddAssReturnOrder(AssReturnOrderInputDto returnOrderInput)
        {
            //验证
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _assReturnOrderRepository.GetMaxID();
            string rtoId = Helper.GenerateIDEx("RT", maxId);
            returnOrderInput.RTOID = rtoId;
            sb.Append(Helper.BasicValidate(returnOrderInput).ToString());
            if (sb.Length == 0)
            {
                var assrto = Mapper.Map<AssReturnOrderInputDto, AssReturnOrder>(returnOrderInput);
                assrto.CREATEDATE = DateTime.Now;
                assrto.MODIFYDATE = DateTime.Now;
                try
                {
                    _unitOfWork.RegisterNew(assrto);

                    foreach (var assId in returnOrderInput.AssIds)
                    {
                        //修改Asset的状态
                        Assets assets = _assetsRepository.GetByID(assId).FirstOrDefault();
                        if (assets != null)
                        {
                            assets.STATUS = (int)STATUS.闲置;
                            assets.CURRENTUSER = "";
                            _unitOfWork.RegisterDirty(assets);
                        }
                        //添加行项
                        var corow = new AssReturnOrderRow
                        {
                            ASSID = assId,
                            RTOID = rtoId,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = returnOrderInput.CREATEUSER,
                            MODIFYDATE = DateTime.Now,
                            MoDIFYUSER = returnOrderInput.MODIFYUSER
                        };
                        _unitOfWork.RegisterNew(corow);

                        //添加处理记录
                        var pr = new AssProcessRecord
                        {
                            ASSID = assId,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = returnOrderInput.CREATEUSER,
                            HANDLEDATE = DateTime.Now,
                            HANDLEMAN = returnOrderInput.HANDLEMAN,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = returnOrderInput.MODIFYUSER,
                            PROCESSCONTENT = returnOrderInput.HANDLEMAN + "归还了" + assId,
                            PROCESSMODE = (int)PROCESSMODE.归还,
                            QUANTITY = 1
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
        /// 添加退库单
        /// </summary>
        /// <param name="restoreOrderInput">退库单信息</param>
        /// <returns></returns>
        public ReturnInfo AddAssRestoreOrder(AssRestoreOrderInputDto restoreOrderInput)
        {
            //验证
            ReturnInfo rInfo = new ReturnInfo();
            StringBuilder sb = new StringBuilder();
            string maxId = _assRestoreOrderRepository.GetMaxID();
            string rsoId = Helper.GenerateIDEx("RS", maxId);
            restoreOrderInput.RSOID = rsoId;
            sb.Append(Helper.BasicValidate(restoreOrderInput).ToString());
            if (sb.Length == 0)
            {
                var assrso = Mapper.Map<AssRestoreOrderInputDto, AssRestoreOrder>(restoreOrderInput);
                assrso.CREATEDATE = DateTime.Now;
                assrso.MODIFYDATE = DateTime.Now;
                try
                {
                    _unitOfWork.RegisterNew(assrso);

                    foreach (var assId in restoreOrderInput.AssIds)
                    {
                        //修改Asset的状态
                        Assets assets = _assetsRepository.GetByID(assId).FirstOrDefault();
                        if (assets != null)
                        {
                            assets.STATUS = (int)STATUS.闲置;
                            assets.CURRENTUSER = "";
                            _unitOfWork.RegisterDirty(assets);
                        }
                        //添加行项
                        var corow = new AssRestoreOrderRow
                        {
                            ASSID = assId,
                            RSOID = rsoId,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = restoreOrderInput.CREATEUSER,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = restoreOrderInput.MODIFYUSER
                        };
                        _unitOfWork.RegisterNew(corow);

                        //添加处理记录
                        var pr = new AssProcessRecord
                        {
                            ASSID = assId,
                            CREATEDATE = DateTime.Now,
                            CREATEUSER = restoreOrderInput.CREATEUSER,
                            HANDLEDATE = DateTime.Now,
                            HANDLEMAN = restoreOrderInput.HANDLEMAN,
                            MODIFYDATE = DateTime.Now,
                            MODIFYUSER = restoreOrderInput.MODIFYUSER,
                            PROCESSCONTENT = restoreOrderInput.HANDLEMAN + "退库了" + assId,
                            PROCESSMODE = (int)PROCESSMODE.退库,
                            QUANTITY = 1
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
        #endregion
    }
}