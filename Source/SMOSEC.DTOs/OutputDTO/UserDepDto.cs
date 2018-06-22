using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 用户表（含用户部门信息）的传输对象,用于返回查询结果
    /// </summary>
    public class UserDepDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string USER_ID { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string USER_NAME { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string USER_IMAGEID { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DEPARTMENTID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DEPARTMENTNAME { get; set; }
    }
}
