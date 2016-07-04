using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WpfApplication2.Converter
{
    public class ExcelConverter
    {
        static Hashtable htSignalType, htIsolocationType;
        static ExcelConverter()
        {
            htSignalType= new Hashtable();
            htSignalType.Add("没有信号机", 0);
            htSignalType.Add("进站信号机", 1);
            htSignalType.Add("出站信号机", 2);
            htSignalType.Add("通过信号机", 3);
            htSignalType.Add("进路信号机", 4);
            htSignalType.Add("调车信号机", 5);
            htSignalType.Add("出站口", 6);
            htIsolocationType = new Hashtable();
            htIsolocationType.Add("电气绝缘节", 1);
            htIsolocationType.Add("机械绝缘节", 2);
        }
        public static void ConvertCategory(string value, ref string resultValue)
        {
            int fieldValue = -1;
            bool IsUpGoing = value.Contains("上行");
            bool IsDownGoing = value.Contains("下行");
            bool IsPositive = value.Contains("正向");
            bool IsNegative = value.Contains("反向");
            //上行 无正反向
            if (IsUpGoing)
                fieldValue = 1;
            //下行 无正反向
            if (IsDownGoing)
                fieldValue = 2;
            //上行 正向
            if (IsUpGoing && IsPositive)
                fieldValue = 3;
            //上行 反向
            if (IsUpGoing && IsNegative)
                fieldValue = 4;
            //下行 正向
            if (IsDownGoing && IsPositive)
                fieldValue = 5;
            //下行 反向
            if (IsDownGoing && IsNegative)
                fieldValue = 6;
            resultValue = fieldValue.ToString();
        }
        public static void ConvertSignalType(string value, ref int fieldValue)
        {
            fieldValue = -1;
            if (htSignalType.ContainsKey(value))
            {
                fieldValue = (int)htSignalType[value];
            }
        }
        public static void ConvertIsolocationType(string value, ref int fieldValue)
        {
            fieldValue = -1;
            if (htSignalType.ContainsKey(value))
            {
                fieldValue = (int)htIsolocationType[value];
            }
        }
    }
}
