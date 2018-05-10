namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 资产选择时的资产信息传输类,借用单和领用单用
    /// </summary>
    public class AssSelectExOutputDto
    {
        public bool IsChecked { get; set; }
        public string IMAGE { get; set; }
        public string ASSID { get; set; }
        public string NAME { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal QTY { get; set; }
    }
}