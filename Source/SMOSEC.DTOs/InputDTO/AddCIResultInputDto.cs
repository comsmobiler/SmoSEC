using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMOSEC.DTOs.InputDTO
{
    /// <summary>
    /// 开始盘点时,第一次添加盘点单结果行项时,传给后台的数据
    /// </summary>
    public class AddCIResultInputDto
    {
        /// <summary>
        /// 盘点单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 盘点单编号
        /// </summary>
        public string IID { get; set; }

        /// <summary>
        /// 盘点人
        /// </summary>
        public string HANDLEMAN { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }
    }
}
