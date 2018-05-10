using System;

namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 
    /// </summary>
    public class OutboundOrderOutputDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string OOID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LOCATIONID { get; set; }

        /// 
        /// </summary>
        public string LOCATIONNAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TYPENAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime BUSINESSDATE { get; set; }

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