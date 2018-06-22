using System;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 出库单数据传输对象
    /// </summary>
    public class OutboundOrderOutputDto
    {
        /// <summary>
        /// 出库单编号
        /// </summary>
        public string OOID { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        public string LOCATIONID { get; set; }


        /// <summary>
        /// 区域名称
        /// </summary>
        public string LOCATIONNAME { get; set; }

        /// <summary>
        /// 出库类型编号
        /// </summary>
        public int TYPE { get; set; }

        /// <summary>
        /// 出库类型名称
        /// </summary>
        public string TYPENAME { get; set; }

        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime BUSINESSDATE { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        public string HANDLEMAN { get; set; }

        /// <summary>
        /// 处理人名称
        /// </summary>
        public string HANDLEMANNAME { get; set; }

        /// <summary>
        /// 处理日期
        /// </summary>
        public DateTime HANDLEDATE { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string NOTE { get; set; }

    }
}