using SMOSEC.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SMOSEC.Infrastructure.Configuration
{
    /// <summary>
    /// 区域表的配置信息类
    /// </summary>
    public class AssLocationConfiguration : EntityTypeConfiguration<AssLocation>
    {
        /// <summary>
        /// 配置区域表的映射信息
        /// </summary>
        public AssLocationConfiguration()
        {
            Property(l => l.LOCATIONID).IsRequired();
        }
    }
}
