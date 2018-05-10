using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 
    /// </summary>
    public class OutboundOrderInputDto : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("")]
        public string OOID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("")]
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("")]
        public int TYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("")]
        public DateTime BUSINESSDATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("")]
        public string HANDLEMAN { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DisplayName("")]
        public DateTime HANDLEDATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("")]
        public string NOTE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("")]
        public string CREATEUSER { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("")]
        public string MODIFYUSER { get; set; }

        public List<OutboundOrderRowInputDto> RowInputDtos { get; set; }
    }

}