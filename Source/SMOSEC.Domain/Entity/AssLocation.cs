using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.Domain.Entity
{
    public class AssLocation : IAggregateRoot
    {
        /// <summary>
        /// 区域编码
        /// </summary>
        [Key]
        [DisplayName("区域编码")]
        public String LOCATIONID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [DisplayName("名称")]
        public String NAME { get; set; }

        /// <summary>
        /// 管理者
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("管理者")]
        public string MANAGER { get; set; }
        /// <summary>
        /// 是否启用(0 不启用，1 启用，默认为1)
        /// </summary>
        [Required]
        [DisplayName("是否启用")]
        public Int32 ISENABLE { get; set; }

        /// <summary>
        /// 是否锁定(0 不锁定，1 锁定，默认为0)
        /// </summary>
        [Required]
        [DisplayName("是否锁定")]
        public Int32 ISLOCKED { get; set; }
    }
}
