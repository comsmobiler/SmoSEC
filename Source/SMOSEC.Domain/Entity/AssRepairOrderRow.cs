using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMOSEC.Domain.Entity
{
    /// <summary>
    /// 报修单行项
    /// </summary>
    [Table("AssRepairOrderRow")]
    public class AssRepairOrderRow : IAggregateRoot
    {
        /// <summary>
        /// 报修单行项编号
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public string ROROWID { get; set; }
        /// <summary>
        /// 报修单编号
        /// </summary>
        [Key]
        [Column(Order = 2)]
        public string ROID { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string IMAGE { get; set; }
        /// <summary>
        /// 区域编号
        /// </summary>
        public string LOCATIONID { get; set; }
        /// <summary>
        /// 资产条码
        /// </summary>
        public string ASSID { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public String SN { get; set; }
        /// <summary>
        /// 待维修数量
        /// </summary>
        public decimal WAITREPAIRQTY { get; set; }
        /// <summary>
        /// 已维修数量
        /// </summary>
        public decimal REPAIREDQTY { get; set; }
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
        /// 当前状态(0 等待维修，1 维修完毕，默认值等待维修)
        /// </summary>
        public int? STATUS { get; set; }
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
