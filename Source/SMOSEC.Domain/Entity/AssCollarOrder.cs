using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.Domain.Entity
{
    /// <summary>
    /// 领用单
    /// </summary>
    public class AssCollarOrder : IAggregateRoot
    {
        /// <summary>
        /// 领用单号
        /// </summary>
        [Key]
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("领用单号")]
        public string COID { get; set; }

        /// <summary>
        /// 领用人
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("领用人")]
        public string USERID { get; set; }

        /// <summary>
        /// 领用时间
        /// </summary>
        [Required]
        [DisplayName("领用时间")]
        public DateTime COLLARDATE { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [StringLength(maximumLength: 4, ErrorMessage = "长度不能超过4")]
        [DisplayName("区域")]
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 使用部门
        /// </summary>
        [StringLength(maximumLength: 50, ErrorMessage = "长度不能超过50")]
        [DisplayName("使用部门")]
        public string INUSEDDEP { get; set; }

        /// <summary>
        /// 存放地点
        /// </summary>
        [StringLength(maximumLength: 50, ErrorMessage = "长度不能超过50")]
        [DisplayName("存放地点")]
        public string PLACE { get; set; }

        /// <summary>
        /// 预计退库时间
        /// </summary>
        [DisplayName("预计退库时间")]
        public DateTime EPTRESTOREDATE { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("处理人")]
        public string HANDLEMAN { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("说明")]
        public string NOTE { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CREATEDATE { get; set; }

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
        public DateTime MODIFYDATE { get; set; }

        /// <summary>
        /// 更新用户
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("更新用户")]
        public string MODIFYUSER { get; set; }

    }

}