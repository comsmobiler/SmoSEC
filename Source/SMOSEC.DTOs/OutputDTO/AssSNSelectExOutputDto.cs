namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 资产选择时的序列号信息传输类,退库单和归还单用
    /// </summary>
    public class AssSNSelectExOutputDto
    {
        public bool IsChecked { get; set; }
        public string IMAGE { get; set; }
        public string SN { get; set; }
        public string ASSID { get; set; }
        public string NAME { get; set; }
        public string SOURCEID { get; set; }
    }
}