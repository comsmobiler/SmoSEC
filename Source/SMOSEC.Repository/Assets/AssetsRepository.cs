using System;
using System.Linq;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System.Collections.Generic;

namespace SMOSEC.Repository.Assets
{
    /// <summary>
    /// 固定资产的仓储实现，仅用于查询
    /// </summary>
    public class AssetsRepository : BaseRepository<SMOSEC.Domain.Entity.Assets>, IAssetsRepository
    {
        /// <summary>
        /// 固定资产类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssetsRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据资产条码和区域编号，返回库存信息
        /// </summary>
        /// <param name="ASSID">资产编号</param>
        /// <param name="LOCATIONID">区域编号</param>
        /// <returns></returns>
        public IQueryable<SMOSEC.Domain.Entity.Assets> GetByTypeID(string TypeID)
        {
            return _entities.Where(x => x.TYPEID  == TypeID && x.STATUS !=6);
        }
        /// <summary>
        /// 根据资产条码返回资产信息
        /// </summary>
        /// <param name="ASSID">资产编号</param>
        /// <returns></returns>
        public IQueryable<SMOSEC.Domain.Entity.Assets> GetByID(String ASSID)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(ASSID))
            {
                result = result.Where(a => a.ASSID == ASSID);
            }
            return result;
        }
        /// <summary>
        /// 根据序列号返回闲置资产对象
        /// </summary>
        /// <param name="SN">序列号</param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetUnusedBySN(String SN)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(SN))
            {
                result = result.Where(a => a.SN == SN && a.STATUS==0 && a.ISLOCKED==0);
            }
            return result;
        }
        /// <summary>
        /// 判断当前使用人是否有领用或借用资产
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetByUser(String UserID)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(UserID))
            {
                result = result.Where(a => a.CURRENTUSER == UserID && (a.STATUS == 2 || a.STATUS==5));
            }
            return result;
        }
        /// <summary>
        /// 查询对应状态的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
        /// <param name="UserID">用户名称</param>
        /// <param name="Status">状态</param>
        /// <returns></returns>
        public IQueryable<SMOSEC.Domain.Entity.Assets> GetAssByStatus(string LocationID, string Name, string UserID, int Status)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                result = result.Where(a => a.NAME.Contains(Name));
            }
            if (!string.IsNullOrEmpty(UserID))
            {
                result = result.Where(a => a.CURRENTUSER == UserID);
            }
            result = result.Where(a => a.STATUS == Status);
            return result;
        }

        /// <summary>
        /// 查询对应状态的资产数据
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="SN">序列号</param>
        /// <param name="UserID">用户名</param>
        /// <param name="Status">状态</param>
        /// <returns></returns>
        public IQueryable<SMOSEC.Domain.Entity.Assets> GetAssByStatusEx(string LocationID, string SN, string UserID, int Status)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(SN))
            {
                result = result.Where(a => a.SN == SN);
            }
            if (!string.IsNullOrEmpty(UserID))
            {
                result = result.Where(a => a.CURRENTUSER == UserID);
            }
            result = result.Where(a => a.STATUS == Status&&a.ISLOCKED==0);
            return result;
        }
        /// <summary>
        /// 根据序列号或者名称查询资产
        /// </summary>
        /// <param name="SNOrName">序列号或者名称</param>
        /// <param name="types"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> QueryAssets(string SNOrName, List<String> types)
        {
            var result = _entities;
            result = result.Where(a=>a.STATUS !=6);
            if (types.Count > 0)
            {
                result = result.Where(a => types.Contains(a.TYPEID));
            }
            if (!string.IsNullOrEmpty(SNOrName))
            {
                result = result.Where(a => a.SN.Contains(SNOrName) || a.NAME.Contains(SNOrName) || a.CURRENTUSER.Contains(SNOrName));
            }
            return result;
        }
        /// <summary>
        /// 查询空闲的资产数据(除调入区域外的)
        /// </summary>
        /// <param name="LocationID">区域编号</param>
        /// <param name="Name">资产名称</param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetUnUsedAssOther(string LocationID, string Name)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationID))
            {
                result = result.Where(a => a.LOCATIONID == LocationID);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                result = result.Where(a => a.NAME.Contains(Name));
            }

            result = result.Where(a => a.STATUS == 0&&a.ISLOCKED==0);
            return result;
        }
        /// <summary>
        /// 查询即将失效的资产(需联合AssPR)
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public IQueryable<Domain.Entity.Assets> GetImminentAssets(int days)
        {
            DateTime targetDateTime = DateTime.Now.Date.AddDays(days);
            DateTime Now = DateTime.Now.Date;
            //            return _entities.Where(a => a.EXPIRYDATE >=Now && ASSIDs.Contains(a.ASSID)).AsNoTracking();
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询低于安全库存的资产(需联合AssQuant)
        /// </summary>
        /// <returns></returns>
        public IQueryable<SMOSEC.Domain.Entity.Assets> GetLackOfStockAss()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据序列号或者名称查询资产
        /// </summary>
        /// <param name="SNOrName">序列号或者名称</param>
        /// <returns></returns>
        public IQueryable<SMOSEC.Domain.Entity.Assets> QueryAssets(string SNOrName)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(SNOrName))
            {
                result = result.Where(a => a.SN.Contains(SNOrName) || a.NAME.Contains(SNOrName));
            }
            return result;
        }

        /// <summary>
        /// 根据序列号得到资产
        /// </summary>
        /// <param name="SN">序列号</param>
        /// <returns></returns>
        public IQueryable<SMOSEC.Domain.Entity.Assets> GetAssetsBySN(string SN)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(SN))
            {
                result = result.Where(a => a.SN==SN);
            }
            return result;
        }

        /// <summary>
        /// 得到最大编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxID()
        {
            return _entities.Select(e => e.ASSID).Max();
        }

        /// <summary>
        /// 根据区域编号,类型和部门编号,得到盘点清单
        /// </summary>
        /// <param name="LocationId">区域编号</param>
        /// <param name="typeId">类型编号</param>
        /// <param name="DepartmentId">部门编号</param>
        public IQueryable<Domain.Entity.Assets> GetInventoryAssetses(string LocationId, string typeId, string DepartmentId)
        {
            var result = _entities;
            if (!string.IsNullOrEmpty(LocationId))
            {
                result = result.Where(a => a.LOCATIONID == LocationId);
            }
            if (!string.IsNullOrEmpty(typeId))
            {
                result = result.Where(a => a.TYPEID == typeId);
            }
            if (!string.IsNullOrEmpty(DepartmentId))
            {
                result = result.Where(a => a.DEPARTMENTID == DepartmentId);
            }
            return result;
        }

        /// <summary>
        /// 查询序列号是否存在
        /// </summary>
        /// <param name="SN">序列号</param>
        /// <returns></returns>
        public bool SNIsExists(string SN)
        {
            return _entities.Any(a => a.SN == SN);
        }
    }
}
