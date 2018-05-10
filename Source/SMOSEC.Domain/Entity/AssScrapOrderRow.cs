using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMOSEC.Domain.Entity
{
    /// <summary>
    /// 报废单行项
    /// </summary>
    [Table("AssScrapOrderRow")]
    public class AssScrapOrderRow : IAggregateRoot
    {
        /// <summary>
        /// 报废单行项编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public string SOROWID { get; set; }
        /// <summary>
        /// 报废单编号
        /// </summary>
        [Key]
        [Column(Order = 2)]
        public string SOID { get; set; }
        /// <summary>
        /// 区域编号
        /// </summary>
        public string LOCATIONID { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string IMAGE { get; set; }
        /// <summary>
        /// 资产条码
        /// </summary>
        public string ASSID { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 已报废数量
        /// </summary>
        public decimal SCRAPQTY { get; set; }
        /// <summary>
        /// 还原数量
        /// </summary>
        public decimal? RETURNQTY { get; set; }
        /// <summary>
        /// 当前状态(0 已报废，1 已还原，默认值已报废)
        /// </summary>
        public int? STATUS { get; set; }
        /// <summary>
        /// 当前所在部门
        /// </summary>
        public string CURRENTDEP { get; set; }
        /// <summary>
        /// 当前使用人
        /// </summary>
        public string CURRENTUSER { get; set; }
        /// <summary>
        /// 存放地址
        /// </summary>
        public string PLACE { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CREATEUSER { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEDATE { get; set; }
    }

}
