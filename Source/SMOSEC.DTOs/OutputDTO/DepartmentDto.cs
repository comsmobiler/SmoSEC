using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 部门列表里的传输对象,用于返回查询结果
    /// </summary>
    public class DepartmentDto
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        [Key]
        [StringLength(maximumLength: 10, ErrorMessage = "长度不能超过10")]
        [DisplayName("部门编号")]
        public string DEPARTMENTID { get; set; }
        /// <summary>
        /// 部门头像
        /// </summary>
        public string IMAGEID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("部门名称")]
        public string NAME { get; set; }

        /// <summary>
        /// 部门负责人
        /// </summary>
        [StringLength(maximumLength: 20, ErrorMessage = "长度不能超过20")]
        [DisplayName("部门负责人")]
        public string MANAGER { get; set; }
        /// <summary>
        /// 部门负责人名字
        /// </summary>
        public string MANAGERNAME { get; set; }

        /// <summary>
        /// 是否启用(0-不启用,1-启用)
        /// </summary>
        [Required]
        [DisplayName("是否启用(0-不启用,1-启用)")]
        public int ISENABLE { get; set; }
        /// <summary>
        /// 部门人员
        /// </summary>
        public List<string> UserIDs = new List<string>();
        /// <summary>
        /// 创建日期
        /// </summary>
        [Required]
        [DisplayName("创建日期")]
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
