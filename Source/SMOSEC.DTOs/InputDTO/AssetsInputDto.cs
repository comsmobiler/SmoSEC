using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 资产信息
    /// </summary>
    public class AssetsInputDto : IEntity
    {
        /// <summary>
        /// 资产编号
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("资产编号")]
        public string AssId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        [StringLength(maximumLength: 4, ErrorMessage = "长度不能超过4")]
        [DisplayName("类型")]
        public string TypeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "长度不能超过50")]
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("图片")]
        public string Image { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("规格")]
        public string Specification { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("序列号")]
        public string SN { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [StringLength(maximumLength: 6, ErrorMessage = "长度不能超过6")]
        [DisplayName("单位")]
        public string Unit { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [DisplayName("价格")]
        public decimal? Price { get; set; }

        /// <summary>
        /// 使用的部门
        /// </summary>
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("使用的部门")]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 购买日期
        /// </summary>
        [Required]
        [DisplayName("购买日期")]
        public DateTime BuyDate { get; set; }

        /// <summary>
        /// 当前使用者
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("当前使用者")]
        public string CurrentUser { get; set; }

        /// <summary>
        /// 管理者
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("管理者")]
        public string Manager { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        [StringLength(maximumLength: 4, ErrorMessage = "长度不能超过4")]
        [DisplayName("区域编号")]
        public string LocationId { get; set; }

        /// <summary>
        /// 存放地
        /// </summary>
        [StringLength(maximumLength: 50, ErrorMessage = "长度不能超过50")]
        [DisplayName("存放地")]
        public string Place { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        [Required]
        [DisplayName("过期日期")]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("供应商")]
        public string Vendor { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [StringLength(maximumLength: 200, ErrorMessage = "长度不能超过200")]
        [DisplayName("说明")]
        public string Note { get; set; }

//        /// <summary>
//        /// 创建日期
//        /// </summary>
//        [DisplayName("创建日期")]
//        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("创建者")]
        public string CreateUser { get; set; }

//        /// <summary>
//        /// 更新时间
//        /// </summary>
//        [DisplayName("更新时间")]
//        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("更新人")]
        public string ModifyUser { get; set; }
    }

}