using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIATTester.Helper;
using MyDataAccess.ADO_NET;
using System.Data;
using CodeGenerator.Helper.DDL;

namespace FIATTester
{
    class Program
    {
        enum testEnum
        {
            xia=313,
            ye=1314
        }
        static void Main(string[] args)
        {
            //Tester test1 = new Tester();
            //test1.Session.BeginTransaction();
            //test1.GenerateStudent();
            //test1.Session.RollBackTransaction();

            //Tester test2 = new Tester();
            //test2.Session.BeginTransaction();
            //test2.GenerateStudent();
            //test2.Session.CommitTransaction();

            ////DataRow 无列时取值 
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Age",typeof(int));
            //dt.Rows.Add("西安", 1221);
            //dt.Rows.Add("中国", 5555);
            //var value = dt.Rows[0]["Value"];
            //=>DataRow无该列

            //将DataRow插入另一个表可用dataTable.ImportRow(dataRow);
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Age", typeof(int));
            //dt.Rows.Add("西安", 1221);
            //dt.Rows.Add("中国", 5555);
            //DataTable dt2 = dt.Copy();
            //dt2.Clear();
            //foreach (DataRow dataRow in dt.Rows)
            //{
            //    dt2.ImportRow(dataRow);
            //    dt.Rows.Remove(dataRow);
            //}


            //测试数据库取值 需要调整项目属性-生成-目标平台为Any CPU
            //new Tester().GenerateBanks();
            //int i = new Tester().GetURID();

            //数据库相关测试
            //var re1 = new Tester().ExcuteDataReader("select distinct TSPAM.EntityCode from TSMID.TS_PayApplyMains TSPAM left join TSMID.TS_PayApplyStates TSPAS on TSPAM.urid=TSPAS.MainID where (TSPAS.DealState=1 or TSPAS.DealState is null)");
            //DataTable re2 = new Tester().ExcuteDataTable("select distinct TSPAM.EntityCode from TSMID.TS_PayApplyMains TSPAM left join TSMID.TS_PayApplyStates TSPAS on TSPAM.urid=TSPAS.MainID where (TSPAS.DealState=1 or TSPAS.DealState is null)");
            //List<string> validEntityCodes = new List<string>();
            //int i = 1;
            //int j = i++;
            //j = i = i + 1;
            //string result = string.Format("test{0}{0}", 1);

            //string valueInt = "313";
            //string valueStr = "ye";
            //string valueEx = "ye1";
            //testEnum test;
            //Enum.TryParse(valueInt, out test);
            //Enum.TryParse(valueStr, out test);
            //Enum.TryParse(valueEx, out test);



            ////获取所有属性
            //List<string> propertyNames = new List<string>();
            //Type t=typeof(FIAT.DDL.Entities.BANKS);
            //System.Reflection.PropertyInfo[] properties = t.GetProperties();
            //foreach (System.Reflection.PropertyInfo property in properties)
            //{
            //    propertyNames.Add(property.Name);
            //}
            //测试DDL生成的DAL的Insert
            //new Tester().GetBANKS();
            //new Tester().GenerateBanks();
            while (Console.ReadLine() == "")
            {
                //根据DDL生成三成架构代码文件
                new DDLManager().ConvertDirectory();
            }
        }

        class Node
        {
            public string Value { get; set; }
        }
        private void WriteString(Node text)
        {
            if (text != null)
            {
                Console.Write(text.Value);
            }
        }
    }
}
