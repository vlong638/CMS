using VLCommon.AnyDB;
using VLCommon.AnyDB.Enums;
//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator.Helper.DDL
{
    /// <summary>
    /// DDL表字段对象
    /// </summary>
    internal class DDLEntityFieldItem
    {
        #region Properties
        #region 主属性
        public string Title { get; set; }
        public bool IsPrivateKey { get; set; }
        public FieldItemType Type { get; set; }
        public int Length { get; set; }
        public int Accuracy { get; set; }
        public bool Nullable { get; set; }
        public string DefaultValue { get; set; }
        #endregion

        #region 辅助属性
        public string IsPrivateKeyString
        {
            get
            {
                return this.IsPrivateKey ? "true" : "false";
            }
        }
        public string NullableString
        {
            get
            {
                return this.Nullable ? "true" : "false";
            }
        }
        private bool? _hasDefaultValue;
        public bool HasDefaultValue
        {
            get
            {
                if (!_hasDefaultValue.HasValue)
                    _hasDefaultValue = !string.IsNullOrEmpty(DefaultValue) && DefaultValue != "NULL";
                return _hasDefaultValue.Value;
            }
        }
        public string DefaultValueString
        {
            get
            {
                if (!HasDefaultValue)
                    throw new Exception("该字段无默认值");

                string result = "";
                switch (Type)
                {
                    case FieldItemType.FLOAT:
                    case FieldItemType.NUMBER:
                    case FieldItemType.NUMERIC:
                        result = DefaultValue;
                        break;
                    case FieldItemType.NVARCHAR2:
                    case FieldItemType.VARCHAR2:
                    case FieldItemType.DATE:
                    case FieldItemType.DATETIME:
                    case FieldItemType.INT:
                    case FieldItemType.NVARCHAR:
                        result = string.Format("\"{0}\"", DefaultValue);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                return result;
            }
        }
        private string _typeString;
        public string TypeString
        {
            get
            {
                if (string.IsNullOrEmpty(_typeString))
                {
                    switch (Type)
                    {
                        case FieldItemType.FLOAT:
                        case FieldItemType.NUMBER:
                        case FieldItemType.NUMERIC:
                            _typeString = "decimal";
                            break;
                        case FieldItemType.NVARCHAR2:
                        case FieldItemType.VARCHAR2:
                        case FieldItemType.NVARCHAR:
                            _typeString = "string";
                            break;
                        case FieldItemType.DATE:
                        case FieldItemType.DATETIME:
                            _typeString = "DateTime";
                            break;
                        case FieldItemType.INT:
                            _typeString = "int";
                            break;
                        default:
                            throw new NotImplementedException(string.Format("该DDLEntityItemType:{0}类型未实现", this.Type));
                    }
                }
                return _typeString;
            }
        }
        private string _typeConvertString;
        public string TypeConvertString
        {
            get
            {
                if (string.IsNullOrEmpty(_typeConvertString))
                {
                    switch (Type)
                    {
                        case FieldItemType.FLOAT:
                        case FieldItemType.NUMBER:
                        case FieldItemType.NUMERIC:
                            _typeConvertString = "Convert.ToDecimal";
                            break;
                        case FieldItemType.INT:
                            _typeConvertString = "Convert.ToInt32";
                            break;
                        case FieldItemType.NVARCHAR2:
                        case FieldItemType.VARCHAR2:
                        case FieldItemType.NVARCHAR:
                            _typeConvertString = "Convert.ToString";
                            _typeConvertString = "Convert.ToString";
                            break;
                        case FieldItemType.DATE:
                        case FieldItemType.DATETIME:
                            _typeConvertString = "Convert.ToDateTime";
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
                return _typeConvertString;
            }
        }
        private string _upperTitle;
        public string UpperTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_upperTitle))
                {
                    _upperTitle = Title.ToUpper();
                }
                return _upperTitle;
            }
        }
        private string _lowerTitle;
        public string LowerTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_lowerTitle))
                {
                    _lowerTitle = Title.ToLower();
                }
                return _lowerTitle;
            }
        }
        private string _parameterTitle;
        public string ParameterTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_parameterTitle))
                {
                    _parameterTitle = Title.ToLower();
                }
                return _parameterTitle;
            }
        }
        //public OracleDbType DbType
        //{
        //    get
        //    {
        //        switch (this.Type)
        //        {
        //            case FieldItemType.FLOAT:
        //            case FieldItemType.NUMBER:
        //                return OracleDbType.Decimal;
        //            case FieldItemType.NVARCHAR2:
        //                return OracleDbType.NVarchar2;
        //            case FieldItemType.VARCHAR2:
        //                return OracleDbType.Varchar2;
        //            case FieldItemType.DATE:
        //                return OracleDbType.Date;
        //            default:
        //                throw new NotImplementedException("该数据类型未实现");
        //        }
        //    }
        //}
        #endregion
        #endregion

        #region Constructors
        public DDLEntityFieldItem(Match match)
        {
            //对象字段赋值
            string title = match.Groups[1].ToString();
            FieldItemType type = (FieldItemType)Enum.Parse(typeof(FieldItemType), match.Groups[2].ToString());
            int length = 0;
            int accuracy = 0;
            if (match.Groups[3].ToString() != "")
            {
                string laValues = match.Groups[3].ToString().Trim('(', ')', ' ');
                string[] values = laValues.Split(',');
                length = int.Parse(values[0]);
                if (values.Length > 1)
                    accuracy = int.Parse(values[1]);
            }
            string defaultValue = match.Groups[4].ToString();
            if (defaultValue != "")
            {
                defaultValue = defaultValue.Substring(9);
            }
            bool nullable = string.IsNullOrEmpty(match.Groups[5].ToString());

            Init(title, false, type, length, accuracy, defaultValue, nullable);
        }
        public DDLEntityFieldItem(string title, bool isPrimaryKey, FieldItemType type, int length, int accuracy, string defaultValue, bool nullable)
        {
            Init(title, isPrimaryKey, type, length, accuracy, defaultValue, nullable);
        }
        public DDLEntityFieldItem(string title)
        {
            this.Title = title;
        }
        private void Init(string title, bool isPrimaryKey, FieldItemType type, int length, int accuracy, string defaultValue, bool nullable)
        {
            this.Title = title;
            this.IsPrivateKey = isPrimaryKey;
            this.Type = type;
            this.Length = length;
            this.Accuracy = accuracy;
            this.DefaultValue = defaultValue;
            this.Nullable = nullable;
        }
        #endregion
    }
}
