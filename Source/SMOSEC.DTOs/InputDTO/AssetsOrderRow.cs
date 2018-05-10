using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 资产选择时候，所用数据类型
    /// </summary>
    public class AssetsOrderRow
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
        /// 资产条码
        /// </summary>
        public string ASSID { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public string SN { get; set; }
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
