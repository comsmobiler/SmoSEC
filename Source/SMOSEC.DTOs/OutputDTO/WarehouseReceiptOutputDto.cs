using System;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 入库单信息传输对象
    /// </summary>
    public class WarehouseReceiptOutputDto
    {
        /// <summary>
        /// 入库单编号
        /// </summary>
        public string WRID { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string LOCATIONNAME { get; set; }

        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime BUSINESSDATE { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string VENDOR { get; set; }

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