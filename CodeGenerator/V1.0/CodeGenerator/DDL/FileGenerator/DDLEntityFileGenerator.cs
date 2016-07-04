using VLCommon.AnyDB.Enums;
using CodeGenerator.Helper.DDL;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.DDL.FileGenerator
{
    public class DDLEntityFileGenerator : BaseDDLFileGenerator
    {
        public override string DefaultFileName
        {
            get
            {
                return Parent.ClassName + ".cs";
            }
        }

        internal DDLEntityFileGenerator(DDLEntity parent) : base(parent) { }

        protected override string Generate(string targetNamespace, List<string> additionalNamespace = null)
        {
            StringBuilder sb = new StringBuilder();
            //填充Usings
            sb.AppendUsings(new List<string>() { "VLCommon.AnyDB.Entities", "VLCommon.AnyDB.Enums", "System", "System.Data", "System.Data.Common" });
            //填充命名空间Start
            sb.AppendNameSpaceStart(targetNamespace);
            //填充类名Start
            sb.AppendClassStart(Parent.EntityClassName);
            //填充属性
            sb.AppendEntityProperties(Parent.Items);
            //填充构造函数
            sb.AppendEntityConstructors(Parent);
            //填充手工区域
            sb.AppendManualField();
            //填充类名End
            sb.AppendClassEnd();
            //填充命名空间End
            sb.AppendNameSpaceEnd();

            return sb.ToString();
        }
    }
    internal static class DDLEntityFileGeneratorEx
    {
        #region Constructors
        /// <summary>
        /// 生成Entity文件的构造函数
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="entity"></param>
        internal static void AppendEntityConstructors(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendConstructorsStart();
            sb.AppendEntityConstructorWithOptionalParameters(entity);
            sb.AppendEntityConstructorWithRequiredParameters(entity);
            sb.AppendEntityConstructorWithDataRow(entity);
            sb.AppendEntityConstructorWithDbDataReader(entity);
            sb.AppendConstructorsEnd();
        }
        /// <summary>
        /// 构造函数:(可选项)
        /// </summary>
        /// <param name="sb"></param>
        private static void AppendEntityConstructorWithOptionalParameters(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendConstructor(entity.ClassName, GetEntityOptionalParameterArgumentString(entity), GetEntityOptionalParameterAssignmentString(entity));
        }
        /// <summary>
        /// 构造函数:(必填项,可选项)
        /// </summary>
        /// <param name="sb"></param>
        private static void AppendEntityConstructorWithRequiredParameters(this StringBuilder sb, DDLEntity entity)
        {
            if (entity.RequiredItems.Count == 0)
                return;

            sb.AppendConstructor(entity.ClassName, GetEntityRequiredParameterArgumentString(entity), GetEntityRequiredParameterAssignmentString(entity), GetEntityRequiredParameterChainingString(entity));
        }
        /// <summary>
        /// 构造函数:(DataRow)
        /// </summary>
        /// <param name="sb"></param>
        private static void AppendEntityConstructorWithDataRow(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendConstructor(entity.ClassName, "DataRow row", GetEntityDataRowAssignmentString(entity));
        }
        /// <summary>
        /// 构造函数:(DbDataReader)
        /// </summary>
        /// <param name="sb"></param>
        private static void AppendEntityConstructorWithDbDataReader(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendConstructor(entity.ClassName, "DbDataReader row", GetEntityDataRowAssignmentString(entity));
        }
        #region 构造函数相关信息

        #region 可选项
        private static string GetEntityOptionalParameterArgumentString(DDLEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            var OptionalItems = entity.OptionalItems;
            foreach (var item in OptionalItems)
            {
                sb.AppendFormat("{0} {1} = {2}", item.TypeString, item.ParameterTitle, item.DefaultValueString);
                if (item != OptionalItems.Last())
                    sb.Append(", ");
            }
            return sb.ToString();
        }
        private static string GetEntityOptionalParameterAssignmentString(DDLEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            var OptionalItems = entity.OptionalItems;
            foreach (var item in OptionalItems)
            {
                sb.AppendFormatLine("            this.{0} = {1};", item.UpperTitle, item.ParameterTitle);
            }
            return sb.ToString();
        }
        #endregion

        #region DataRow
        private static string GetEntityDataRowAssignmentString(DDLEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            var Items = entity.Items;
            foreach (DDLEntityFieldItem item in Items)
            {
                if (item.Nullable)
                {
                    sb.AppendFormatLine("            if (row[\"{0}\"] != DBNull.Value && row[\"{1}\"].ToString() != \"\")", item.UpperTitle, item.UpperTitle);
                    sb.AppendLine("            {");
                    sb.AppendFormatLine("                this.{0} = {2}(row[\"{1}\"]);", item.UpperTitle, item.UpperTitle, item.TypeConvertString);
                    sb.AppendLine("            }");
                }
                else
                {
                    sb.AppendFormatLine("            this.{0} = {2}(row[\"{1}\"]);", item.UpperTitle, item.UpperTitle, item.TypeConvertString);
                }
            }
            return sb.ToString();
        }
        #endregion

        #region 必填项
        private static string GetEntityRequiredParameterArgumentString(DDLEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            var RequiredItems = entity.RequiredItems;
            //日期值暂不处理
            RequiredItems.RemoveAll(c => c.Type == VLCommon.AnyDB.Enums.FieldItemType.DATE);
            var OptionalItems = entity.OptionalItems;
            foreach (var item in RequiredItems)
            {
                sb.AppendFormat("{0} {1}", item.TypeString, item.ParameterTitle);
                if (item != RequiredItems.Last())
                    sb.Append(", ");
            }
            if (OptionalItems.Count != 0)
            {
                sb.Append(", ");
            }
            foreach (var item in OptionalItems)
            {
                sb.AppendFormat("{0} {1} = {2}", item.TypeString, item.ParameterTitle, item.DefaultValueString);
                if (item != OptionalItems.Last())
                    sb.Append(", ");
            }
            return sb.ToString();
        }
        private static string GetEntityRequiredParameterAssignmentString(DDLEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            var RequiredItems = entity.RequiredItems;
            //日期值暂不处理
            RequiredItems.RemoveAll(c => c.Type == FieldItemType.DATE);
            foreach (var item in RequiredItems)
            {
                sb.AppendFormatLine("            this.{0} = {1};", item.UpperTitle, item.ParameterTitle);
            }
            return sb.ToString();
        }
        private static string GetEntityRequiredParameterChainingString(DDLEntity entity)
        {
            var OptionalItems = entity.OptionalItems;
            if (OptionalItems.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("this(");
                foreach (var item in OptionalItems)
                {
                    sb.AppendFormat("{0}", item.ParameterTitle);
                    if (item != OptionalItems.Last())
                        sb.Append(", ");
                }
                sb.Append(")");
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #endregion

        #endregion

        #region Properties
        /// <summary>
        /// 生成Entity文件的属性
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="Items"></param>
        internal static void AppendEntityProperties(this StringBuilder sb, List<DDLEntityFieldItem> Items)
        {
            sb.AppendPropertiesStart();
            sb.AppendRegionStart("StaticProperties");
            foreach (var item in Items)
            {
                item.AppendEntityStaticProperties(ref sb);
            }
            sb.AppendPropertiesEnd();
            sb.AppendRegionStart("StandardProperties");
            foreach (var item in Items)
            {
                item.AppendEntityStandardProperties(ref sb);
            }
            sb.AppendPropertiesEnd();
            sb.AppendPropertiesEnd();
        }
        /// <summary>
        /// 根据DDL表字段对象增加对应的静态 属性
        /// </summary>
        /// <param name="item"></param>
        /// <param name="sb"></param>
        internal static void AppendEntityStaticProperties(this DDLEntityFieldItem item, ref StringBuilder sb)
        {
            //目标
            //#region StaticFields
            //public static DBFieldItem URIDProperty = new DBFieldItem("URID", false, FieldItemType.NUMBER, 10, 0, false);
            //#endregion
            sb.AppendFormatLine("        public static DBFieldItem {0}Property = new DBFieldItem(\"{0}\",{1}, FieldItemType.{2}, {3}, {4},{5});",
                item.UpperTitle,
                item.IsPrivateKeyString,
                item.Type,
                item.Length,
                item.Accuracy,
                item.NullableString);
        }
        /// <summary>
        /// 根据DDL表字段对象增加对应的属性
        /// </summary>
        /// <param name="item"></param>
        /// <param name="sb"></param>
        internal static void AppendEntityStandardProperties(this DDLEntityFieldItem item, ref StringBuilder sb)
        {
            //目标
            //        private decimal _urid;
            //        public decimal URID { get { return _urid; } set { _urid = value; } }
            sb.AppendFormatLine("        private {0} _{1};",
                item.TypeString,
                item.LowerTitle);
            sb.AppendFormatLine("        public {0} {1} {{ get {{ return _{2}; }} set {{ _{2} = value; }} }}",
                item.TypeString,
                item.UpperTitle,
                item.LowerTitle);
        }
        #endregion
    }
}
