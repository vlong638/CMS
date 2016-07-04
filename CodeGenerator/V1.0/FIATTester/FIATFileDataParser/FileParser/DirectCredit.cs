using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIATFileDataParser.FileParser
{
    #region ResultCollections
    /// <summary>
    /// 解析数据集合
    /// </summary>
    public class CreditColleciton : ImportDataCollection<FileEntity<FileLineEntity<DirectCreditData>>>
    {
        public CreditColleciton(FileTypeEnum type)
        {
            this.Type = type;
        }

        public override DataTable ToDataTable(string tableName)
        {
            if (this.Count() <= 0)
                throw new Exception("数据为空");

            DataTable dt = new DataTable(tableName);
            //生成标头
            var dtItems = this.First(c => c.Count > 0).First().Data.GetSemicolonSeparatedItemColumns();
            if (this.Count() <= 0)
                throw new Exception("数据项为空");
            foreach (var dtItem in dtItems)
            {
                dt.Columns.Add(dtItem);
            }
            //生成数据
            this.ForEach(c => c.ForEach(p => dt.Rows.Add(p.ToDataRow(dt.NewRow()))));
            //目标表数据结构由业务定义 实体本身只保证自己的数据转换成表 故这里应该移至业务处理处
            ////补足目标表数据
            //AppendDataTable(dt);
            return dt;
        }

        //private void AppendDataTable(DataTable dt)
        //{
        //    //URID
        //    dt.Columns.Add("URID");
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dt.Rows[i]["URID"] = i;
        //    }
        //    //其他补足字段
        //    DataTable target = Asiatom.Treasury.IntermediateTable.TS_PayApplyMains.GenerateMainTableStructure();
        //    List<string> arry = new List<string>();
        //    foreach (DataColumn item in target.Columns)
        //    {
        //        if (!dt.Columns.Contains(item.Caption))
        //            dt.Columns.Add(item.Caption);
        //    }
        //}
    }
    #endregion

    #region FileDatas
    /// <summary>
    /// 文件解析数据
    /// </summary>
    public class CreditFileData : FileEntity<FileLineEntity<DirectCreditData>>
    {
        public string CreatedDate { set; get; }
        public int ReadLineCount { set; get; }
        public int ParsedItemCount { get { return this.Count(); } }

        public CreditFileData(CreditColleciton parent, string filePath)
            : base(parent,filePath)
        {
            this.CreatedDate = DateTime.Now.ToString("yyyy-MM-dd");

            ParseFile(filePath);
        }

        public override void ParseFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath, Encoding.Default))
            {
                int index = 1;
                string text;
                while (!string.IsNullOrEmpty(text = reader.ReadLine()))
                {
                    this.Add(new DirectCredit(this, index, text));
                    index++;
                }
            }
        }
    }
    #endregion

    #region FileLineEntity
    /// <summary>
    /// DirectCreditData数据
    /// </summary>
    public class DirectCreditData
    {
        public List<SemicolonSeparatedItem> FileFieldItems = new List<SemicolonSeparatedItem>();
        public List<StaticSetupItem> StaticFieldItems = new List<StaticSetupItem>();

        /// <summary>
        /// 获取数据对象列集合
        /// </summary>
        /// <returns></returns>
        public List<string> GetSemicolonSeparatedItemColumns()
        {
            List<string> columns = new List<string>();
            //分组字段添加
            IEnumerable<SemicolonSeparatedItem> fileFields = FileFieldItems.Where(c => c.Key != null && c.IsGrouped == true);
            IEnumerable<string> groupNames = fileFields.Select(c => c.Key).Distinct();
            if (groupNames.Count() > 0)
            {
                SemicolonSeparatedItem.AddColumnByFieldName(ref columns, groupNames);
            }
            //未分组字段添加
            fileFields = FileFieldItems.Where(c => c.Key != null && c.IsGrouped == false);
            if (fileFields.Count() > 0)
            {
                SemicolonSeparatedItem.AddColumnByFieldName(ref columns, fileFields.Select(c => c.Key));
            }
            //静态字段添加
            if (StaticFieldItems.Count() > 0)
                SemicolonSeparatedItem.AddColumnByFieldName(ref columns, StaticFieldItems.Select(c => c.Key));
            //检查重复
            if (columns.Count != columns.Distinct().Count())
            {
                List<string> columnCopy = new List<string>(columns);

                var distinctColumns = columns.Distinct();
                foreach (var distinctColumn in distinctColumns)
                {
                    columnCopy.Remove(distinctColumn);
                }
                throw new Exception(string.Format("下列字段出现重复:{0}", string.Join("|", columnCopy)));
            }
            return columns.Distinct().ToList();
        }
    }

    public class DirectCredit : FileLineEntity<DirectCreditData>
    {
        #region Constructors
        /// <summary>
        /// 文件行对象
        /// </summary>
        /// <param name="index">行序号</param>
        /// <param name="text">行内容</param>
        /// <param name="parent">所属文件集</param>
        public DirectCredit(CreditFileData parent, int index, string text)
            : base(parent, index)
        {
            InitItems();

            Parse(text);
        }

        #endregion

        #region Methods
        /// <summary>
        /// 初始化集合列
        /// </summary>
        protected override void InitItems()
        {
            Data = new DirectCreditData();
            Data.FileFieldItems = new List<SemicolonSeparatedItem>();
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(1, "Order Party Account", "PayBankAccount"));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(2, "Order Party Account Currency", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(3, "Charge Account", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(4, "Charge Account Currency", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(5, "Transaction Mode", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(6, "Instruction for Charges", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(7, "Urgent Flag", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(8, "Bulk Posting", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(9, "Transaction Currency", "CurrencyCode"));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(10, "Transaction Date", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(11, "Transaction Date Type", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(12, "Bulk Reference", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(13, "Business Category", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(14, "Business Descriptions", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(15, "Schedule Date", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(16, "Restricted Transaction Flag", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(17, "Reserved", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(18, "Transaction Amount", "PayAmount"));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(19, "Transaction Instructions", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(20, "Transaction Details 1/ Applicant Mailing Address 1", "RecBankLocationName", 1));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(21, "Transaction Details 2/ Applicant Mailing Address 2", "RecBankLocationName", 2));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(22, "Transaction Details 3/ Applicant Mailing Address 3", "RecBankLocationName", 3));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(23, "Transaction Details 4/ Applicant Mailing Address 4", "RecBankLocationName", 4));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(24, "Special Instruction 1", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(25, "Special Instruction 2", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(26, "Counter-party Code", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(27, "Counter-party Name", "RecName|RecBankAccountName"));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(28, "Counter-party Account", "RecBankAccount"));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(29, "Counter-party Account Ccy", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(30, "Counter-party National ID/ Beneficiary Account Type", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(31, "Counter-party Address Line 1", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(32, "Counter-party Address Line 2", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(33, "Counter-party Address Line 3", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(34, "Counter-party Country of Residence", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(35, "Counter-party Bank Branch Code/ Drawee Bank Code", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(36, "Counter-party Bank Branch Name / Account with Intermediary Bank", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(37, "Counter-party Bank Name/ Applicant Mailing Name", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(38, "Counter-party Bank SWIFT", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(39, "Counter-party Bank Clearing Code", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(40, "Counter-party Bank Clearing Code Type", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(41, "Counter-party Bank Address line 1", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(42, "Counter-party Bank Address line 2", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(43, "Counter-party Bank Address line 3", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(44, "Counter-party Bank Country", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(45, "Intermediary Bank Name", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(46, "Intermediary Bank Address Line 1 / Counter-party Address Line 4", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(47, "Intermediary Bank Address Line 2 / Counter-party Address Line 5", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(48, "Intermediary Bank Address Line 3", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(49, "Intermediary Bank Country", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(50, "Intermediary Bank SWIFT", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(51, "Intermediary Bank Clearing Code/ Location Code", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(52, "Intermediary Bank Clearing Code Type / Location Name", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(53, "Sender Info/ Special Instr 3", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(54, "Receiver Info/ Special Instr 4", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(55, "Order Info/ Special Instr 5", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(56, "Counter-Party Reference / Special Instr 6/ Drawee Bank Name", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(57, "Order party reference (Customer Ref)", "SourceNoteCode"));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(58, "Mailing Name", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(59, "Fax Number", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(60, "Orderer Reference/ Remarks/Your/Sender Reference/ Sender Tax ID", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(61, "Commercial Reference/ Particulars/Misc/Receiver Ref/ Receiver tax ID", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(62, "Order Date/ Cheque Date", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(63, "Transaction Type", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(64, "Transaction ID", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(65, "Additional Transaction Details Count", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(66, "Extended Payment Details (Asia only)", null));
            Data.FileFieldItems.Add(new SemicolonSeparatedItem(67, "Reserve", null));

            Data.StaticFieldItems = new List<StaticSetupItem>();
            Data.StaticFieldItems.Add(new StaticSetupItem("CorpaccessSystemsCode", Parent.Parent.Type.ToString()));
            Data.StaticFieldItems.Add(new StaticSetupItem("SourceBatchNumber", new FileInfo(Parent.FilePath).Name));
            Data.StaticFieldItems.Add(new StaticSetupItem("SourceAskNumber", Index.ToString()));
            Data.StaticFieldItems.Add(new StaticSetupItem("EntityCode", ""));
            Data.StaticFieldItems.Add(new StaticSetupItem("PayDate", ((CreditFileData)Parent).CreatedDate));
            Data.StaticFieldItems.Add(new StaticSetupItem("PayTypeCode", "509"));//填写：509 对外收款_手工
            Data.StaticFieldItems.Add(new StaticSetupItem("SettlementModeCode", "101"));//填写：同行走 102 代发工资(直联批量代付)，跨行走101 对外支付(直联单笔)
            Data.StaticFieldItems.Add(new StaticSetupItem("PayEntityCode", ""));
            Data.StaticFieldItems.Add(new StaticSetupItem("RecObjectType", "5"));
            Data.StaticFieldItems.Add(new StaticSetupItem("IsPrivate", Parent.Parent.Type == FileTypeEnum.CMS ? "1" : "2"));//1 - 对私 - CMS ; 2 - 对公 - WFS
        }
        /// <summary>
        /// 将行文本转换为数据对象
        /// </summary>
        /// <param name="text"></param>
        protected override void Parse(string text)
        {
            //源文本行数据
            string[] values = text.Split(SemicolonSeparatedItem.TextSplitter);
            if (values.Length <= 0)
            {
                throw new Exception("数据为空");
            }
            if (values.Length < Data.FileFieldItems.Count)
            {
                throw new Exception("数据项数有误");
            }
            //目标
            foreach (SemicolonSeparatedItem FileFieldItem in Data.FileFieldItems)
            {
                FileFieldItem.SetValue(values);
            }
        }
        public override DataRow ToDataRow(DataRow row)
        {
            //分组字段赋值
            IEnumerable<SemicolonSeparatedItem> fileFields = Data.FileFieldItems.Where(c => c.Key != null && c.IsGrouped == true);
            IEnumerable<string> groupNames = fileFields.Select(c => c.Key).Distinct();
            foreach (string groupName in groupNames)
            {
                string fieldValue = string.Join("", fileFields.Where(c => c.Key == groupName).OrderBy(c => c.Index).Select(c => c.Value).ToArray());
                SemicolonSeparatedItem.FillRowValueByValueAndName(ref row, groupName, fieldValue);
            }
            //未分组字段赋值
            fileFields = Data.FileFieldItems.Where(c => c.Key != null && c.IsGrouped == false);
            foreach (SemicolonSeparatedItem field in fileFields)
            {
                SemicolonSeparatedItem.FillRowValueByValueAndName(ref row, field.Key, field.Value);
            }
            //静态字段赋值
            foreach (var field in Data.StaticFieldItems)
            {
                SemicolonSeparatedItem.FillRowValueByValueAndName(ref row, field.Key, field.Value);
            }

            return row;
        }
        #endregion
    }
    #endregion

    #region LineValueItem
    public class StaticSetupItem : LineValueEntity
    {
        public StaticSetupItem(string columnName, string value)
        {
            SetKey(columnName);
            SetValue(value);
        }
    }

    public class SemicolonSeparatedItem : LineValueEntity
    {
        public static char TextSplitter = ';';
        public static char ColumnNamesSplitter = '|';

        public SemicolonSeparatedItem(int index, string name, string columnName)
        {
            this.Index = index;
            this.Name = name;
            this._key = columnName;
            this.IsGrouped = false;
        }
        public SemicolonSeparatedItem(int index, string name, string columnName, int groupIndex)
        {
            this.Index = index;
            this.Name = name;
            this._key = columnName;
            this.IsGrouped = true;
            this.GroupIndex = groupIndex;
        }

        public int Index { set; get; }
        public string Name { set; get; }
        public bool IsMultiColumns
        {
            get
            {
                return GetKey() != null && GetKey().Contains('|');
            }
        }
        public bool IsGrouped { set; get; }
        public int GroupIndex { set; get; }

        public void SetValue(string[] values)
        {
            SetValue(values[Index - 1]);
        }

        //column赋值 统一处理一对多
        public static void AddColumnByFieldName(ref List<string> columns, IEnumerable<string> fieldNames)
        {
            foreach (var fieldName in fieldNames)
            {
                if (fieldName.Contains(SemicolonSeparatedItem.ColumnNamesSplitter))
                {
                    columns.AddRange(fieldName.Split(SemicolonSeparatedItem.ColumnNamesSplitter));
                }
                else
                {
                    columns.Add(fieldName);
                }
            }
        }
        //row赋值 统一处理一对多
        public static void FillRowValueByValueAndName(ref DataRow row, string columnName, string fieldValue)
        {
            if (columnName.Contains(SemicolonSeparatedItem.ColumnNamesSplitter))
            {
                string[] targetNames = columnName.Split(SemicolonSeparatedItem.ColumnNamesSplitter);
                foreach (string targetName in targetNames)
                {
                    row[targetName] = fieldValue;
                }
            }
            else
            {
                row[columnName] = fieldValue;
            }
        }
    } 
    #endregion
}
