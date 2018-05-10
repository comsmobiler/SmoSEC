using SMOSEC.CommLib;
using SMOSEC.Domain.IRepository;
using SMOSEC.DTOs.InputDTO;
using SMOSEC.Infrastructure;
using SMOSEC.Repository.Assets;
using System;
using System.Linq;
using System.Text;

namespace SMOSEC.Application
{
    /// <summary>
    /// 帮助类，主要用于数据库对象的验证和产生表的主键ID
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// 数据库的上下文的接口
        /// </summary>
        public static IDbContext context = new SMOSECDbContext();

        /// <summary>
        /// 资产的仓储类的接口
        /// </summary>
        public static IAssetsRepository AssetsRepository = new AssetsRepository(context);
        /// <summary>
        /// 产生部分表的主键ID(调拨单、报废单、报修单)
        /// </summary>
        /// <param name="Head"></param>
        /// <param name="MaxID"></param>
        /// <returns></returns>
        public static String GeneratePRID(String Head, String MaxID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Head);
            if (String.IsNullOrWhiteSpace(MaxID))
            {
                sb.Append("000000001");
            }
            else
            {
                int HeadLength = Head.Length;
                int MinuteMax = int.Parse(MaxID.Substring(HeadLength, 9));
                String NowMax = (MinuteMax + 1).ToString();
                for (int i = 0; i < 10 - NowMax.Length - HeadLength; i++)
                {
                    sb.Append("0");
                }
                sb.Append(NowMax);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 产生部分表的主键ID
        /// </summary>
        /// <param name="Head">自定义的ID开头</param>
        /// <param name="MaxID">当前表中的最大ID</param>
        public static string GenerateID(string Head, string MaxID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Head);
            sb.Append(DateTime.Now.ToString("yyyyMMddHHmm"));
            if (string.IsNullOrEmpty(MaxID))
            {
                sb.Append("0001");
            }
            else if (MaxID.Contains(DateTime.Now.ToString("yyyyMMddHHmm")))
            {
                int HeadLength = Head.Length;
                int MinuteMax = int.Parse(MaxID.Substring(HeadLength + 12, 4));
                string NowMax = (MinuteMax + 1).ToString();
                for (int i = NowMax.Length; i < 4; i++)
                {
                    sb.Append("0");
                }
                sb.Append((MinuteMax + 1).ToString());
            }
            else
            {
                sb.Append("0001");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 产生部分表的主键ID
        /// </summary>
        /// <param name="Head">自定义的ID开头</param>
        /// <param name="MaxID">当前表中的最大ID</param>
        public static string GenerateIDEx(string Head, string MaxID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Head);
            sb.Append(DateTime.Now.ToString("yyyyMM"));
            if (string.IsNullOrEmpty(MaxID))
            {
                sb.Append("01");
            }
            else if (MaxID.Contains(DateTime.Now.ToString("yyyyMM")))
            {
                int HeadLength = Head.Length;
                int MinuteMax = int.Parse(MaxID.Substring(HeadLength + 6, 2));
                string NowMax = (MinuteMax + 1).ToString();
                for (int i = NowMax.Length; i < 2; i++)
                {
                    sb.Append("0");
                }
                sb.Append((MinuteMax + 1).ToString());
            }
            else
            {
                sb.Append("01");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 基础验证
        /// </summary>
        /// <param name="entity">继承自IEntity的泛型对象</param>
        public static StringBuilder BasicValidate<T>(T entity) where T : SMOSEC.DTOs.IEntity
        {
            StringBuilder sb = new StringBuilder();
            //基础验证
            if (entity != null)
            {
                foreach (var item in entity.IsValid())
                {
                    if (!string.IsNullOrEmpty(item.Message))
                    {
                        if (item.Message.Contains("必需的"))
                        {
                            sb.Append(item.FieldName + "是必需的!");
                        }
                        else
                        {
                            sb.Append(item.FieldName + item.Message + "!");
                        }
                    }
                }
            }
            else
            {
                string ShortName = entity.GetType().ToString().Replace("SMOSEC.DTOs", "");
                string ShowName = DealName(ShortName);
                sb.Append("传入了空的" + ShowName + "对象.");
            }
            return sb;
        }

        public static StringBuilder ValidateAssets(AssetsInputDto inputDto)
        {
            StringBuilder stringBuilder=new StringBuilder();
            stringBuilder.Append(BasicValidate(inputDto).ToString());
            //额外验证
            //判断SN是否重复
            if (!string.IsNullOrEmpty(inputDto.SN))
            {
                if (AssetsRepository.SNIsExists(inputDto.SN))
                {
                    stringBuilder.Append("SN" + inputDto.SN + "已经存在.");
                }
            }
            return stringBuilder;
        }

        private static string DealName(string ShortName)
        {
            switch (ShortName)
            {
                case "CCTTInputDto":
                    return "成本中心类型模板";
                case "CCInputDto":
                    return "成本中心";
                case "LeaveInputDto":
                    return "请假单";
                case "RB_RowsInputDto":
                    return "消费记录";
                case "RBRTTInputDto":
                    return "报销类型模板";
                case "RBInputDto":
                    return "报销单";
                case "DepInputDto":
                    return "部门";
                case "UserInputDto":
                    return "用户";
                case "ALInputDto":
                    return "考勤记录";
                case "AT_CDInputDto":
                    return "自定义日期";
                case "ATInputDto":
                    return "考勤模板";
                default:
                    return "";
            }

        }
    }
}
