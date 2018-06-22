using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 耗材列表所用传输数据类型
    /// </summary>
    public class ConsumablesOrderRow
    {
        /// <summary>
        /// 图片名称
        /// </summary>
        public string IMAGE { get; set; }
        /// <summary>
        /// 区域编号
        /// </summary>
        public string LOCATIONID { get; set; }
        /// <summary>
        /// 耗材编号
        /// </summary>
        public string CID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal QTY { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        public int? STATUS { get; set; }
    }
}
