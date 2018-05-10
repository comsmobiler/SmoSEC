using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;

namespace SMOSEC.DTOs.InputDTO
{
    public class TOInputDto : IEntity
    {
        /// <summary>
        /// 调拨单编号
        /// </summary>
        public string TOID { get; set; }
        /// <summary>
        /// 调入区域
        /// </summary>
        public string DESLOCATIONID { get; set; }
        /// <summary>
        /// 调入管理员
        /// </summary>
        public string MANAGER { get; set; }
        /// <summary>
        /// 调入日期
        /// </summary>
        public DateTime TRANSFERDATE { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string HANDLEMAN { get; set; }
        /// <summary>
        /// 处理日期
        /// </summary>
        public DateTime? HANDLEDATE { get; set; }
        /// <summary>
        /// 状态(0 调拨中,1 调拨完成,2 取消调拨,默认为调拨中)
        /// </summary>
        public int? STATUS { get; set; }
        /// <summary>
        /// 是否开启SN控制(0 未开启，1开启)
        /// </summary>
        public int ISSNCONTROL { get; set; }
        /// <summary>
        /// 调拨说明
        /// </summary>
        public string NOTE { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CREATEUSER { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEDATE { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? MODIFYDATE { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string MODIFYUSER { get; set; }
        /// <summary>
        /// 行项信息
        /// </summary>
        public List<AssTransferOrderRow> Rows { get; set; }
    }
}
