using CodeGenerator.Helper.DDL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DDL.FileGenerator
{
    public abstract class BaseDDLFileGenerator
    {
        internal DDLEntity Parent { set; get; }
        //消息
        private StringBuilder _message = new StringBuilder();
        public string Message { get { return _message.ToString(); } }
        protected void RecordMessage(string pattern, params string[] args)
        {
            _message.AppendFormat(pattern, args);
        }
        //执行结果状态
        public bool ExcuteState { set; get; }

        internal BaseDDLFileGenerator(DDLEntity parent)
        {
            this.Parent = parent;
        }


        #region 需实现方法
        /// <summary>
        ///  默认名
        /// </summary>
        public virtual string DefaultFileName { get { return ""; } }
        /// <summary>
        /// 文件内容生成
        /// </summary>
        /// <param name="targetNamespace"></param>
        /// <param name="additionalNamespace"></param>
        protected abstract string Generate(string targetNamespace, List<string> additionalNamespace = null);
        #endregion

        /// <summary>
        /// 文件生成
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="targetNamespace"></param>
        /// <param name="additionalNamespace"></param>
        /// <returns></returns>
        public bool GenerateFile(string targetPath, string targetNamespace, List<string> additionalNamespace = null)
        {
            try
            {
                File.WriteAllText(targetPath, Generate(targetNamespace, additionalNamespace));
                RecordMessage("文件创建成功");
                ExcuteState = true;
            }
            catch (Exception ex)
            {
                RecordMessage(ex.ToString());
                ExcuteState = false;
            }
            return ExcuteState;
        }
    }
    internal static class DDLCommonFileGeneratorEx
    {
        #region Utilities Methods
        internal static void AppendFormatLine(this StringBuilder sb, string format, params object[] args)
        {
            try
            {
                sb.AppendLine(string.Format(format, args));
            }
            catch (Exception)
            {
            }
        }
        internal static void AppendRegionStart(this StringBuilder sb, string regionName)
        {
            sb.AppendFormatLine("        #region {0}", regionName);
        }
        internal static void AppendRegionEnd(this StringBuilder sb)
        {
            sb.AppendLine("        #endregion");
        }
        #endregion

        #region Using
        static string UsingPattern = "using {0};" + System.Environment.NewLine;
        static List<string> BasicUsings = new List<string>()
        {
            "System",
            "System.Collections.Generic",
            "System.Data"
        };
        public static void AppendUsings(this StringBuilder sb, List<string> usings = null, params string[] exUsings)
        {
            List<string> Usings = new List<string>();
            //添加主要命名空间引用
            if (usings != null)
            {
                Usings.AddRange(usings);
                Usings = Usings.Distinct().ToList();
            }
            else
            {
                Usings.AddRange(BasicUsings);
            }
            //添加额外命名空间引用
            foreach (string exUsing in exUsings)
            {
                if (!string.IsNullOrEmpty(exUsing))
                    Usings.Add(exUsing);
            }
            //消重
            foreach (string Using in Usings.Distinct())
            {
                sb.AppendFormat(UsingPattern, Using);
            }
            //排序
            Usings.Sort();
            sb.AppendLine();
        }
        #endregion

        #region NameSpace
        public static void AppendNameSpaceStart(this StringBuilder sb, string nameSpace)
        {
            sb.AppendFormatLine("namespace {0}", nameSpace);
            sb.AppendLine("{");
        }
        public static void AppendNameSpaceEnd(this StringBuilder sb)
        {
            sb.AppendLine("}");
        }
        #endregion

        #region Class
        public static void AppendClassStart(this StringBuilder sb, string className, string baseClassName = null)
        {
            sb.AppendFormatLine("    public class {0}{1}", className, baseClassName == null ? "" : string.Format(" : {0}", baseClassName));
            sb.AppendLine("    {");
        }
        public static void AppendClassEnd(this StringBuilder sb)
        {
            sb.AppendLine("    }");
        }
        #endregion

        #region Properties
        internal static void AppendPropertiesStart(this StringBuilder sb)
        {
            sb.AppendRegionStart("Properties");
        }
        internal static void AppendPropertiesEnd(this StringBuilder sb)
        {
            sb.AppendRegionEnd();
        }
        public static void AppendDALProperties(this StringBuilder sb)
        {
            sb.AppendPropertiesStart();
            sb.AppendPropertiesEnd();
        }
        #endregion

        #region Constructors
        internal static void AppendConstructorsStart(this StringBuilder sb)
        {
            sb.AppendRegionStart("Constructors");
        }
        internal static void AppendConstructorsEnd(this StringBuilder sb)
        {
            sb.AppendRegionEnd();
        }
        /// <summary>
        /// 模板:添加构造函数字符串
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="className">类名</param>
        /// <param name="parameterString">标准格式:(DataType1 DataName1, DataType2 DataName2,...)</param>
        /// <param name="assignmentString">标准格式:(            this.{0} = {1};)</param>
        /// <param name="chainingString">标准格式:(DataName1, DataName2,...)</param>
        internal static void AppendConstructor(this StringBuilder sb, string className, string parameterString, string assignmentString, string chainingString = "")
        {
            sb.AppendFormatLine("        public {0}({1})", className, parameterString);
            if (!string.IsNullOrEmpty(chainingString))
                sb.AppendFormatLine("            : {0}", chainingString);
            sb.AppendLine("        {");
            sb.AppendLine(assignmentString);
            sb.AppendLine("        }");
        }
        #endregion

        #region Methods
        internal static void AppendMethodsStart(this StringBuilder sb)
        {
            sb.AppendRegionStart("Methods");
        }
        internal static void AppendMethodsEnd(this StringBuilder sb)
        {
            sb.AppendRegionEnd();
        }
        #endregion

        #region Manual
        public static void AppendManualField(this StringBuilder sb)
        {
            sb.AppendRegionStart("ManualCode");
            sb.AppendLine("        //手工添加的内容请于此处添加");
            sb.AppendRegionEnd();
        }
        #endregion
    }
}
