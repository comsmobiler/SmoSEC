using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    public class AssRepairOrderDto:IEntity
    {
        /// <summary>
        /// 区域编码
        /// </summary>
        [Key]
        [DisplayName("报修单编号")]
        public int RPOID { get; set; }
        /// <summary>
        /// 业务日期
        /// </summary>
        [Required]
        [DisplayName("业务日期")]
        public DateTime APPLYDATE { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        [Required]
        [DisplayName("处理人")]
        public String HANDLEMAN { get; set; }
        /// <summary>
        /// 花费
        /// </summary>
        [DisplayName("花费")]
        public String COST { get; set; }
        /// <summary>
        /// 维修内容
        /// </summary>
        [DisplayName("维修内容")]
        public String REPAIRCONTENT { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public String NOTE { get; set; }
    }
}
