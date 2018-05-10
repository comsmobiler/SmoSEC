namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 单据详情时的资产信息传输类,退库单和归还单用
    /// </summary>
    public class OperDetailAssExOutputDto
    {
        public string Image { get; set; }
        public string Assid { get; set; }
        public string Name { get; set; }
        public string Sourceid { get; set; }
        public decimal Qty { get; set; }
    }
}