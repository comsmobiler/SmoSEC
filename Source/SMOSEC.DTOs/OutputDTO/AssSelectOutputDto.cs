namespace SMOSEC.DTOs.OutputDTO
{
    /// <summary>
    /// 资产选择以及扫码添加时的资产信息传输类,退库单和归还单用
    /// </summary>
    public class AssSelectOutputDto
    {
        public bool IsChecked { get; set; }
        public string IMAGE { get; set; }
        public string ASSID { get; set; }
        public string NAME { get; set; }
        public string SN { get; set; }
        public string USERNAME { get; set; }

    }
}