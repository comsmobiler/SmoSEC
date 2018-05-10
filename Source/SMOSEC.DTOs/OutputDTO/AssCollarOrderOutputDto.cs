using System;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 领用单
    /// </summary>
    public class AssCollarOrderOutputDto
    {
        /// <summary>
        /// 领用单号
        /// </summary>
        public string Coid { get; set; }

        /// <summary>
        /// 领用人
        /// </summary>
        public string Userid { get; set; }

        /// <summary>
        /// 领用时间
        /// </summary>
        public DateTime Collardate { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Locationid { get; set; }

        /// <summary>
        /// 使用部门
        /// </summary>
        public string Inusedep { get; set; }

        /// <summary>
        /// 存放地点
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// 预计退库时间
        /// </summary>
        public DateTime? Eptrestoredate { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        public string Handleman { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 当前状态(0 领用中，1 退库完毕，默认值领用中)
        /// </summary>
        public int Status { get; set; }

    }

}