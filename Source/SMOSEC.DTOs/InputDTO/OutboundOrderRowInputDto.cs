using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 出库单行项信息
    /// </summary>
    public class OutboundOrderRowInputDto : IEntity
    {
        /// <summary>
        /// 耗材编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("耗材编号")]
        public string CID { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        [DisplayName("数量")]
        public decimal QUANTITY { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Required]
        [DisplayName("金额")]
        public decimal MONEY { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("备注")]
        public string NOTE { get; set; }

    }

}