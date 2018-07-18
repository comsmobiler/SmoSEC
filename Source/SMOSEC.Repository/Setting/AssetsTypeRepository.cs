using SMOSEC.Domain.Entity;
using SMOSEC.Domain.IRepository;
using SMOSEC.Infrastructure;
using System;
using System.Linq;

namespace SMOSEC.Repository.Assets
{
    /// <summary>
    /// 资产类别的仓储实现，仅用于查询
    /// </summary>
    public class AssetsTypeRepository : BaseRepository<AssetsType>, IAssetsTypeRepository
    {
        /// <summary>
        /// 仓储类的构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public AssetsTypeRepository(IDbContext dbContext)
            : base(dbContext)
        { }
        /// <summary>
        /// 根据类型编号返回资产类别对象
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IQueryable<AssetsType> GetByID(String ID)
        {
            return _entities.Where(x => x.TYPEID == ID);
        }
        /// <summary>
        /// 获取所有大类
        /// </summary>
        /// <returns></returns>
        public IQueryable<AssetsType> GetAllFirstLevel()
        {
            return _entities.Where(x => x.TLEVEL == 1);
        }
        /// <summary>
        /// 根据父类型编号，获取子类型数据
        /// </summary>
        /// <param name="TypeID"></param>
        /// <returns></returns>
        public IQueryable<AssetsType> GetByParentTypeID(string TypeID)
        {
            return _entities.Where(x => x.PARENTTYPEID == TypeID);
        }
        /// <summary>
        /// 根据类型编号判断是否为父分类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IQueryable<AssetsType> IsParent(string ID)
        {
            return _entities.Where(x => x.PARENTTYPEID == ID);
        }
    }
}
