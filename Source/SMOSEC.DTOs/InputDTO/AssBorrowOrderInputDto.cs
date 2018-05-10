using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 借用单
    /// </summary>
    public class AssBorrowOrderInputDto : IEntity
    {
        /// <summary>
        /// 借用单号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("借用单号")]
        public string BOID { get; set; }

        /// <summary>
        /// 借用人
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("借用人")]
        public string BORROWER { get; set; }

        /// <summary>
        /// 借出时间
        /// </summary>
        [Required]
        [DisplayName("借出时间")]
        public DateTime BORROWDATE { get; set; }

        /// <summary>
        /// 预计归还时间
        /// </summary>
        [Required]
        [DisplayName("预计归还时间")]
        public DateTime EPTRETURNDATE { get; set; }

        /// <summary>
        /// 借出处理人
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("借出处理人")]
        public string BRHANDLEMAN { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 4, ErrorMessage = "长度不能超过4")]
        [DisplayName("区域编号")]
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("说明")]
        public string NOTE { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("创建用户")]
        public string CREATEUSER { get; set; }

        /// <summary>
        /// 更新用户
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("更新用户")]
        public string MODIFYUSER { get; set; }

        /// <summary>
        /// 借用的所有资产编号
        /// </summary>
        public List<string> AssIds { get; set; }
    }


}