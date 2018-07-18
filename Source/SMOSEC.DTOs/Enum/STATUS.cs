using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOSEC.DTOs.Enum
{
    /// <summary>
    /// 枚举类，资产状态
    /// </summary>
    public enum STATUS
    {
        闲置 = 0,
        调拨中 = 1,
        使用中 = 2,
        维修中 = 3,
        报废 = 4,
        借用中 = 5,
        已删除=6
    }
}
