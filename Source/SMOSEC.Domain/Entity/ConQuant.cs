using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMOSEC.Domain.Entity
{
    /// <summary>
    /// 耗材库存表
    /// </summary>
    public class ConQuant:IAggregateRoot
    {
        /// <summary>
        /// 库存编号
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("库存编号")]
        public int QID { get; set; }

        /// <summary>
        /// 耗材编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("耗材编号")]
        public string CID { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("仓库编号")]
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        [DisplayName("数量")]
        public decimal QUANTITY { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CREATEDATE { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("创建用户")]
        public string CREATEUSER { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DisplayName("更新时间")]
        public DateTime MODIFYDATE { get; set; }

        /// <summary>
        /// 更新用户
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("更新用户")]
        public string MODIFYUSER { get; set; }

        /// <summary>
        /// 是否锁定(0-不锁定,1-锁定)
        /// </summary>
        [DisplayName("是否锁定(0-不锁定,1-锁定)")]
        public int ISLOCKED { get; set; }
    }
}