using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMOSEC.Domain.Entity
{
    /// <summary>
    /// 盘点单所需盘点的行项
    /// </summary>
    public class AssInventoryRow:IAggregateRoot
    {
        /// <summary>
        /// 行项编号
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("行项编号")]
        public int IROWID { get; set; }

        /// <summary>
        /// 盘点单编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("盘点单编号")]
        public string IID { get; set; }

        /// <summary>
        /// 资产编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("资产编号")]
        public string ASSID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DisplayName("创建时间")]
        public DateTime CREATEDATE { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("创建者")]
        public string CREATEUSER { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Required]
        [DisplayName("修改时间")]
        public DateTime MODIFYDATE { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("修改者")]
        public string MODIFYUSER { get; set; }

    }
}