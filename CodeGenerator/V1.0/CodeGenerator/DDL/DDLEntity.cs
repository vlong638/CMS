using CodeGenerator.DDL.FileGenerator;
using VLCommon.AnyDB;
using VLCommon.AnyDB.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeGenerator.Helper.DDL
{
    /// <summary>
    /// DDL 表对象
    /// </summary>
    internal class DDLEntity
    {
        #region Properties
        #region 主属性
        /// <summary>
        /// 目标数据库
        /// </summary>
        public DataProvider DataProvider { set; get; }
        /// <summary>
        /// 类相关信息
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 类字段相关信息
        /// </summary>
        public List<DDLEntityFieldItem> Items = new List<DDLEntityFieldItem>();
        /// <summary>
        /// 主键字段
        /// </summary>
        public List<DDLEntityFieldItem> PrimaryKeyItems = new List<DDLEntityFieldItem>();
        #endregion

        #region 辅助属性
        private List<DDLEntityFieldItem> _requiredItems;
        private List<DDLEntityFieldItem> _optionalItems;
        /// <summary>
        /// 必填字段
        /// </summary>
        internal List<DDLEntityFieldItem> RequiredItems
        {
            get
            {
                if (_requiredItems == null)
                {
                    //必填列表 不为空且无默认值
                    _requiredItems = new List<DDLEntityFieldItem>();
                    _requiredItems.AddRange(Items.Where(c => c.Nullable == false && c.HasDefaultValue == false));
                    ////日期值暂不处理
                    //_requiredItems.RemoveAll(c => c.Type == FieldItemType.DATE);
                }
                return _requiredItems;
            }
        }
        /// <summary>
        /// 选填字段 先必填有默认值 后非必填有默认值
        /// </summary>
        internal List<DDLEntityFieldItem> OptionalItems
        {
            get
            {
                if (_optionalItems == null)
                {
                    var requiredOptionalItems = Items.Where(c => c.Nullable == false && c.HasDefaultValue == true);
                    var unrequiredOptionalItems = Items.Where(c => c.Nullable == true && c.HasDefaultValue == true);
                    _optionalItems = new List<DDLEntityFieldItem>();
                    _optionalItems.AddRange(requiredOptionalItems);
                    _optionalItems.AddRange(unrequiredOptionalItems);
                    //日期值暂不处理
                    _optionalItems.RemoveAll(c => c.Type == FieldItemType.DATE);
                }
                return _optionalItems;
            }
        }
        #endregion

        #region 文件生成属性
        internal string EntityClassName { get { return ClassName; } }
        internal string DALClassName { get { return ClassName + "DAL"; } }
        internal string BLLClassName { get { return ClassName + "BLL"; } }
        public DDLEntityFileGenerator EntityFileGenerator { get { return new DDLEntityFileGenerator(this); } }
        public DDLDALFileGenerator DALFileGenerator { get { return new DDLDALFileGenerator(this); } }
        public DDLBLLFileGenerator BLLFileGenerator { get { return new DDLBLLFileGenerator(this); } }
        //扩展生
        #endregion
        #endregion

        #region Constructors
        public DDLEntity(DataProvider dataProvider)
        {
            this.DataProvider = dataProvider;
        }
        public DDLEntity(DataProvider dataProvider, string title)
            : this(dataProvider)
        {
            ClassName = title;
        }
        public DDLEntity(DataProvider dataProvider, StreamReader sr)
            : this(dataProvider)
        {
            switch (dataProvider)
            {
                case DataProvider.SQLServer:
                    ParseDataForSQL(sr);
                    break;
                case DataProvider.Oracle:
                    ParseDataForOracle(sr);
                    break;
                case DataProvider.OleDB:
                case DataProvider.ODBC:
                case DataProvider.None:
                default:
                    break;
            }
        }

        private void ParseDataForSQL(StreamReader sr)
        {
            string text;
            string symbol = "[\\[\\]]";
            //解析首列-对象
            if (!string.IsNullOrEmpty(text = sr.ReadLine()))
            {
                if (text.TrimStart().StartsWith("CREATE TABLE"))
                {
                    //CREATE TABLE [dbo].[Account]
                    //Name
                    string pattern = string.Format("^CREATE TABLE {0}[\\w]+{0}.{0}([\\w]+){0}", symbol);
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(text);
                    if (match.Length > 0)
                    {
                        ClassName = match.Groups[1].ToString();
                    }
                    else
                    {
                        throw new Exception("未成功解析表名");
                    }
                }
            }
            //解析对象字段
            while (!string.IsNullOrEmpty(text = sr.ReadLine()))
            {
                string trimedText = text.TrimStart(' ', '\t', '(');
                ///目标
                ///(	"URID" NUMBER(10,0) DEFAULT 0 NOT NULL ENABLE, 
                ///Name,Type,(Length,Accuracy),(Default),(Not Null)
                ///[Id] INT NOT NULL PRIMARY KEY,


                if (trimedText.StartsWith("["))
                {
                    string pattern = string.Format("^{0}([\\w]+){0}\\s+(\\w+)(\\([\\d\\,]+\\))?( NOT NULL)?( DEFAULT \\w+)?", symbol);
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(trimedText);
                    if (match.Length > 0)
                    {
                        Items.Add(new DDLEntityFieldItem(match));
                    }
                }
                ////目标
                ////CONSTRAINT "PK_STUDENT" PRIMARY KEY ("STUDENTID", "NAME")
                //if (trimedText.StartsWith("CONSTRAINT"))
                //{
                //    //string pattern = "^CONSTRAINT \"\\w+\" PRIMARY KEY (\"\\w+\", \"NAME\")";
                //    string pattern = @"^CONSTRAINT ""\w+"" PRIMARY KEY \((""\w+""(, ""\w+"")*)\)";
                //    Regex regex = new Regex(pattern);
                //    Match match = regex.Match(trimedText);
                //    foreach (string primaryKey in match.Groups[1].ToString().Split(','))
                //    {
                //        DDLEntityFieldItem fieldItem = Items.First(c => c.Title == primaryKey.Trim('"', ' '));
                //        fieldItem.IsPrivateKey = true;
                //        PrimaryKeyItems.Add(fieldItem);
                //    }
                //}
            }
        }
        private void ParseDataForOracle(StreamReader sr)
        {
            string text;
            //解析首列-对象
            if (!string.IsNullOrEmpty(text = sr.ReadLine()))
            {
                if (text.TrimStart().StartsWith("CREATE TABLE"))
                {
                    //CREATE TABLE "ATS001"."BANKS" 
                    //Name
                    string symbol = "[\"]";
                    string pattern = string.Format("^CREATE TABLE {0}[\\w]+{0}.{0}([\\w]+){0}", symbol);
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(text);
                    if (match.Length > 0)
                    {
                        ClassName = match.Groups[1].ToString();
                    }
                    else
                    {
                        throw new Exception("未成功解析表名");
                    }
                }
            }
            //解析对象字段
            while (!string.IsNullOrEmpty(text = sr.ReadLine()))
            {
                string trimedText = text.TrimStart(' ', '\t', '(');
                ///目标
                ///(	"URID" NUMBER(10,0) DEFAULT 0 NOT NULL ENABLE, 
                ///Name,Type,(Length,Accuracy),(Default),(Not Null)
                ///[Id] INT NOT NULL PRIMARY KEY,


                if (trimedText.StartsWith("\""))
                {
                    string pattern = "^\"([\\w]+)\" (\\w+)(\\([\\d\\,]+\\))?( DEFAULT \\w+)?( NOT NULL)?";
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(trimedText);
                    if (match.Length > 0)
                    {
                        Items.Add(new DDLEntityFieldItem(match));
                    }
                }
                //目标
                //CONSTRAINT "PK_STUDENT" PRIMARY KEY ("STUDENTID", "NAME")
                if (trimedText.StartsWith("CONSTRAINT"))
                {
                    //string pattern = "^CONSTRAINT \"\\w+\" PRIMARY KEY (\"\\w+\", \"NAME\")";
                    string pattern = @"^CONSTRAINT ""\w+"" PRIMARY KEY \((""\w+""(, ""\w+"")*)\)";
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(trimedText);
                    foreach (string primaryKey in match.Groups[1].ToString().Split(','))
                    {
                        DDLEntityFieldItem fieldItem = Items.First(c => c.Title == primaryKey.Trim('"', ' '));
                        fieldItem.IsPrivateKey = true;
                        PrimaryKeyItems.Add(fieldItem);
                    }
                }
            }
        }
        #endregion
    }
}
