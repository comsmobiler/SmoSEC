using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.Domain.Entity
{
    /// <summary>
    /// 仓库
    /// </summary>
    public class WareHourse:IAggregateRoot
    {
        /// <summary>
        /// 仓库编码
        /// </summary>
        [Key]
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("仓库编码")]
        public String WAREID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [DisplayName("名称")]
        public String NAME { get; set; }
        /// <summary>
        /// 是否启用(0 不启用，1 启用，默认为1)
        /// </summary>
        [Required]
        [DisplayName("是否启用")]
        public Int32 ISENABLE { get; set; }
    }
}