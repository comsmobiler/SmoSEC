using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseReceiptRowInputDto : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("")]
        public string CID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("")]
        public decimal QUANTITY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("")]
        public decimal MONEY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("")]
        public string BATCH { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("")]
        public string NOTE { get; set; }

    }

}