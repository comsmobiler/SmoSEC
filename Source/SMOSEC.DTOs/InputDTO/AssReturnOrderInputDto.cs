using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 归还单
    /// </summary>
    public class AssReturnOrderInputDto : IEntity
    {
        /// <summary>
        /// 归还单编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("归还单编号")]
        public string RTOID { get; set; }

        /// <summary>
        /// 归还日期
        /// </summary>
        [Required]
        [DisplayName("归还日期")]
        public DateTime RETURNDATE { get; set; }

        /// <summary>
        /// 归还到区域
        /// </summary>
        [Required]
        [StringLength(maximumLength: 4, ErrorMessage = "长度不能超过4")]
        [DisplayName("归还到区域")]
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 归还处理人
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("归还处理人")]
        public string HANDLEMAN { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("备注")]
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
        /// 归还的所有资产编号
        /// </summary>
        public List<string> AssIds { get; set; }

    }

}