namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 单据详情时的资产信息传输类,借用单和领用单用
    /// </summary>
    public class OperDetailAssOutputDto
    {
        public string Image { get; set; }
        public string Assid { get; set; }
        public string Name { get; set; }
        public decimal Qty { get; set; }
    }
}