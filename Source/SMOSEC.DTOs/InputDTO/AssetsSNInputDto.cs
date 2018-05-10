using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 
    /// </summary>
    public class AssetsSNInputDto : IEntity
    {
        /// <summary>
        /// 序列号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("序列号")]
        public string SN { get; set; }

        /// <summary>
        /// 资产条码
        /// </summary>
        [Required]
        [StringLength(maximumLength: 8, ErrorMessage = "长度不能超过8")]
        [DisplayName("资产条码")]
        public string ASSID { get; set; }

        /// <summary>
        /// 使用人
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("使用人")]
        public string USERID { get; set; }

        /// <summary>
        /// 当前状态(0 闲置,1 调拨中,2 使用中,3 维修中,4 报废，5借用中)默认为闲置
        /// </summary>
        [Required]
        [DisplayName("当前状态(0 闲置,1 调拨中,2 使用中,3 维修中,4 报废，5借用中)默认为闲置")]
        public int STATUS { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        [StringLength(maximumLength: 4, ErrorMessage = "长度不能超过4")]
        [DisplayName("区域编号")]
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 最后一次领用单号
        /// </summary>
        [StringLength(maximumLength: 15, ErrorMessage = "长度不能超过15")]
        [DisplayName("最后一次领用单号")]
        public string LASTCOID { get; set; }

        /// <summary>
        /// 最后一次退库单号
        /// </summary>
        [StringLength(maximumLength: 15, ErrorMessage = "长度不能超过15")]
        [DisplayName("最后一次退库单号")]
        public string LASTRSOID { get; set; }

        /// <summary>
        /// 最后一次借用单号
        /// </summary>
        [StringLength(maximumLength: 15, ErrorMessage = "长度不能超过15")]
        [DisplayName("最后一次借用单号")]
        public string LASTBOID { get; set; }

        /// <summary>
        /// 最后一次调拨单号
        /// </summary>
        [StringLength(maximumLength: 15, ErrorMessage = "长度不能超过15")]
        [DisplayName("最后一次调拨单号")]
        public string LASTTOID { get; set; }

        /// <summary>
        /// 最后一次维修单号
        /// </summary>
        [StringLength(maximumLength: 15, ErrorMessage = "长度不能超过15")]
        [DisplayName("最后一次维修单号")]
        public string LASTRPOID { get; set; }

        /// <summary>
        /// 最后一次清理单号
        /// </summary>
        [StringLength(maximumLength: 15, ErrorMessage = "长度不能超过15")]
        [DisplayName("最后一次清理单号")]
        public string LASTSOID { get; set; }

        /// <summary>
        /// 最后一次归还单号
        /// </summary>
        [StringLength(maximumLength: 15, ErrorMessage = "长度不能超过15")]
        [DisplayName("最后一次归还单号")]
        public string LASTRTOID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CREATEDATE { get; set; }

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
        public DateTime? MODIFYDATE { get; set; }

        /// <summary>
        /// 更新用户
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("更新用户")]
        public string MODIFYUSER { get; set; }

    }

}