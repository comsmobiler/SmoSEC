using System;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 退库单
    /// </summary>
    public class AssRestoreOrderOutputDto
    {
        /// <summary>
        /// 退库单号
        /// </summary>
        public string Rsoid { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        public string Handleman { get; set; }

        /// <summary>
        /// 实际退库时间
        /// </summary>
        public DateTime Restoredate { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 退库人
        /// </summary>
        public string Restorer { get; set; }

    }

}