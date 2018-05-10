using SMOSEC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.DTOs.InputDTO
{
    public class ROInputDto : IEntity
    {
        /// <summary>
        /// 报修单编号
        /// </summary>
        public string ROID { get; set; }
        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime APPLYDATE { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string HANDLEMAN { get; set; }
        /// <summary>
        /// 花费
        /// </summary>
        public decimal? COST { get; set; }
        /// <summary>
        /// 维修内容
        /// </summary>
        public string REPAIRCONTENT { get; set; }
        /// <summary>
        /// 当前状态(0 等待维修，1 维修完毕，默认值等待维修)
        /// </summary>
        public int STATUS { get; set; }
        /// <summary>
        /// 是否开启SN控制(0 未开启，1开启)
        /// </summary>
        public int ISSNCONTROL { get; set; }
        /// <summary>
        /// 备注
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
        /// 修改时间
        /// </summary>
        public DateTime? MODIFYDATE { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string MODIFYUSER { get; set; }
        /// <summary>
        /// 行项信息
        /// </summary>
        public List<AssRepairOrderRow> Rows { get; set; }
    }
}
