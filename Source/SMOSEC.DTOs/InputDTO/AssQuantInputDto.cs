using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 库存
    /// </summary>
    public class AssQuantInputDto : IEntity
    {
        /// <summary>
        /// 资产条码
        /// </summary>
        [Required]
        [StringLength(maximumLength: 8, ErrorMessage = "长度不能超过8")]
        [DisplayName("资产条码")]
        public string ASSID { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 4, ErrorMessage = "长度不能超过4")]
        [DisplayName("区域编号")]
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        [DisplayName("数量")]
        public decimal QUANTITY { get; set; }

        /// <summary>
        /// 闲置数量
        /// </summary>
        [Required]
        [DisplayName("闲置数量")]
        public decimal UNUSEDQTY { get; set; }

        /// <summary>
        /// 使用中数量
        /// </summary>
        [Required]
        [DisplayName("使用中数量")]
        public decimal INUSEQTY { get; set; }

        /// <summary>
        /// 维修中数量
        /// </summary>
        [Required]
        [DisplayName("维修中数量")]
        public decimal INREPAIRQTY { get; set; }

        /// <summary>
        /// 报废数量
        /// </summary>
        [Required]
        [DisplayName("报废数量")]
        public decimal INSCRAPQTY { get; set; }

        /// <summary>
        /// 借用中数量
        /// </summary>
        [Required]
        [DisplayName("借用中数量")]
        public decimal INBORROWQTY { get; set; }

        /// <summary>
        /// 调拨中数量
        /// </summary>
        [Required]
        [DisplayName("调拨中数量")]
        public decimal INTRANSFERQTY { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("管理员")]
        public string MANAGER { get; set; }

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