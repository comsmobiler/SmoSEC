namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 单据详情时的序列号信息传输类
    /// </summary>
    public class OperDetailSnOutputDto
    {
        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public string Sn { get; set; }
        /// <summary>
        /// 资产编号
        /// </summary>
        public string Assid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}