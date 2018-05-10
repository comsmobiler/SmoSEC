using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMOSEC.Domain.Entity
{
    /// <summary>
    /// 报废单
    /// </summary>
    [Table("AssScrapOrder")]
    public class AssScrapOrder : IAggregateRoot
    {
        /// <summary>
        /// 报废单编号
        /// </summary>
        [Key]
        public string SOID { get; set; }
        /// <summary>
        /// 清理日期
        /// </summary>
        public DateTime SCRAPDATE { get; set; }
        /// <summary>
        /// 清理人
        /// </summary>
        public string SCRAPMAN { get; set; }
        /// <summary>
        /// 当前状态(0 已报废，1 已还原，默认值已报废)
        /// </summary>
        public int? STATUS { get; set; }
//        /// <summary>
//        /// 是否开启SN控制(0 未开启，1开启)
//        /// </summary>
//        public int ISSNCONTROL { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string NOTE { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CREATEUSER { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEDATE { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? MODIFYDATE { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string MODIFYUSER { get; set; }
    }

}
