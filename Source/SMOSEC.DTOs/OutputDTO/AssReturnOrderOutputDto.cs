using System;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 归还单
    /// </summary>
    public class AssReturnOrderOutputDto
    {
        /// <summary>
        /// 归还单编号
        /// </summary>
        public string Rtoid { get; set; }

        /// <summary>
        /// 归还人
        /// </summary>
        public string Returner { get; set; }

        /// <summary>
        /// 归还日期
        /// </summary>
        public DateTime Returndate { get; set; }

        /// <summary>
        /// 归还到区域
        /// </summary>
        public string Locationid { get; set; }

        /// <summary>
        /// 归还处理人
        /// </summary>
        public string Handleman { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

    }

}