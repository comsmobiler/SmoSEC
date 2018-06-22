using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 入库单传输信息
    /// </summary>
    public class WarehouseReceiptInputDto : IEntity
    {
        /// <summary>
        /// 入库单号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("入库单号")]
        public string WRID { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        [Required]
        [DisplayName("区域编号")]
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 业务日期
        /// </summary>
        [Required]
        [DisplayName("业务日期")]
        public DateTime BUSINESSDATE { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("供应商")]
        public string VENDOR { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("处理人")]
        public string HANDLEMAN { get; set; }

        /// <summary>
        /// 处理日期
        /// </summary>
        [Required]
        [DisplayName("处理日期")]
        public DateTime HANDLEDATE { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("备注")]
        public string NOTE { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("创建者")]
        public string CREATEUSER { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("修改者")]
        public string MODIFYUSER { get; set; }

        /// <summary>
        /// 入库单行项信息
        /// </summary>
        public List<WarehouseReceiptRowInputDto> RowInputDtos { get; set; }

    }

}