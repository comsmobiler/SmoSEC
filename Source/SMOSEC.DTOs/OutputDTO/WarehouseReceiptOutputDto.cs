using System;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseReceiptOutputDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string WRID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LOCATIONID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LOCATIONNAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime BUSINESSDATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VENDOR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HANDLEMAN { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HANDLEMANNAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime HANDLEDATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NOTE { get; set; }

    }

}