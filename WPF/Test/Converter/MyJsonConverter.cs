using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.IO;
using WpfApplication2.Entity;
using System.Runtime.Serialization.Json;

namespace WpfApplication2.Converter
{
    public class MyJsonConverter
    {
        public static List<T> ConvertDataTableToEntity<T>(DataTable dt) where T : class,new()
        {
            string source = JsonConvert.SerializeObject(dt, new DataTableConverter());
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<T>));
            StreamWriter wr = new StreamWriter(stream);
            wr.Write(source);
            wr.Flush();
            stream.Position = 0;
            Object obj = serializer.ReadObject(stream);
            List<T> result = (List<T>)obj;

            return result;
        }
        //public static void Test()
        //{
        //    string testdata1 = @"[{'SerialKey':'StockManage_StockApply','ModuleName':'采购单','PreCode':'CK', 'DateFormat':'年月日', 'IndexCode':'00001', 'Sepa':'-'}]";
        //    MemoryStream stream1 = new MemoryStream();
        //    DataContractJsonSerializer serialize1 = new DataContractJsonSerializer(typeof(List<SerialConstruct>));
        //    StreamWriter wr = new StreamWriter(stream1);
        //    testdata1 = testdata1.Replace('\'', '\"');
        //    wr.Write(testdata1);
        //    wr.Flush();
        //    stream1.Position = 0;
        //    Object obj = serialize1.ReadObject(stream1);
        //    List<SerialConstruct> p1 = (List<SerialConstruct>)obj;

        //    string testdata2 = @"[{'序号':'StockManage_StockApply','车站名称':'采购单','车站编号':'CK', '大区编号':'年月日', '小区编号':'00001'}]";
        //    MemoryStream stream2 = new MemoryStream();
        //    DataContractJsonSerializer serializer2 = new DataContractJsonSerializer(typeof(List<StationInfo>));
        //    wr = new StreamWriter(stream2);
        //    testdata2 = testdata2.Replace('\'', '\"');
        //    wr.Write(testdata2);
        //    wr.Flush();
        //    stream2.Position = 0;
        //    obj = serializer2.ReadObject(stream2);
        //    List<StationInfo> p2 = (List<StationInfo>)obj;
        //}
    }
}
