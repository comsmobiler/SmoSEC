using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 入库相关信息
    /// </summary>
    public class AssetsInStorageInputDto
    {
        [Required]
        [DisplayName("资产编号")]
        public string ASSID { get; set; }
        public List<string> SnList { get; set; }
        [Required]
        [DisplayName("资产数量")]
        public decimal Quantity { get; set; }
        [Required]
        [DisplayName("区域编号")]
        public string LocationId { get; set; }
        [Required]
        [DisplayName("创建用户")]
        public string UserId { get; set; }
        [Required]
        [DisplayName("是否是创建资产页面")]
        public bool IsFromAss { get; set; }
        [Required]
        [DisplayName("过期时间")]
        public DateTime ExpiryDate { get; set; }

    }
}