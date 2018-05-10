using System;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 借用单
    /// </summary>
    public class AssBorrowOrderOutputDto
    {
        /// <summary>
        /// 借用单号
        /// </summary>
        public string Boid { get; set; }

        /// <summary>
        /// 借用人
        /// </summary>
        public string Borrower { get; set; }

        /// <summary>
        /// 借出时间
        /// </summary>
        public DateTime Borrowdate { get; set; }

        /// <summary>
        /// 预计归还时间
        /// </summary>
        public DateTime Eptreturndate { get; set; }

        /// <summary>
        /// 借出处理人
        /// </summary>
        public string Brhandleman { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        public string Locationid { get; set; }

//        /// <summary>
//        /// 实际归还时间
//        /// </summary>
//        public DateTime? Returndate { get; set; }
//
//        /// <summary>
//        /// 归还处理人
//        /// </summary>
//        public string Rthandleman { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Note { get; set; }
//
//        /// <summary>
//        /// 当前状态(0 借用中，1 归还完毕，默认值借用中)
//        /// </summary>
//        public int Status { get; set; }

    }

}