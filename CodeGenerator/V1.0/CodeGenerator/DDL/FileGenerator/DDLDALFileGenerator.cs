using CodeGenerator.Helper.DDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DDL.FileGenerator
{
    public class DDLDALFileGenerator : BaseDDLFileGenerator
    {
        public override string DefaultFileName
        {
            get
            {
                return Parent.ClassName + "DAL" + ".cs";
            }
        }

        internal DDLDALFileGenerator(DDLEntity parent) : base(parent) { }

        protected override string Generate(string targetNamespace, List<string> additionalNamespace = null)
        {
            StringBuilder sb = new StringBuilder();
            //填充Usings
            sb.AppendUsings(new List<string>() { "VLCommon.AnyDB.Enums", "FIAT.DDL.Entities", "MyDataAccess.ADO_NET", "Oracle.DataAccess.Client" });
            //填充命名空间Start
            sb.AppendNameSpaceStart(targetNamespace);
            //填充类名Start
            sb.AppendClassStart(Parent.DALClassName, "MyDAL");
            //填充属性
            sb.AppendDALProperties();
            //填充构造函数
            sb.AppendDALConstructors(Parent);
            //填充方法
            sb.AppendDALMethods(Parent);
            //填充手工区域
            sb.AppendManualField();
            //填充类名End
            sb.AppendClassEnd();
            //填充命名空间End
            sb.AppendNameSpaceEnd();
            return sb.ToString();
        }
    }
    internal static class DDLDALFileGeneratorEx
    {
        #region Constructors
        public static void AppendDALConstructors(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendConstructorsStart();
            sb.AppendDALConstructorWithSession(entity);
            sb.AppendConstructorsEnd();
        }
        private static void AppendDALConstructorWithSession(this StringBuilder sb, DDLEntity entity)
        {
            string parameterString = "IMySession session";
            string assignmentString = string.Format("            this.TableName = \"{0}\";", entity.ClassName);
            string chainingString = "base(session)";
            sb.AppendConstructor(entity.DALClassName, parameterString, assignmentString, chainingString);
        }
        #endregion

        #region Methods
        public static void AppendDALMethods(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendMethodsStart();
            sb.AppendDALCreateMethods(entity);
            sb.AppendDALRetrieveMethods(entity);
            sb.AppendDALUpdateMethods(entity);
            sb.AppendDALDeleteMethods(entity);
            sb.AppendMethodsEnd();
        }
        #region Create
        public static void AppendDALCreateMethods(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendRegionStart("Create");
            sb.AppendDALMethod_Insert(entity);
            //MultiInsert
            sb.AppendRegionEnd();
        }
        public static void AppendDALMethod_Insert(this StringBuilder sb, DDLEntity entity)
        {
            //        public int Insert(TB_STUDENT entity)
            //        {
            //目标
            //            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            //            command.AppendText(string.Format("insert into {0}({1}) values (", TableName,
            sb.AppendFormatLine("        public int Insert({0} entity)", entity.ClassName);
            sb.AppendLine("        {");
            sb.AppendLine("            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();");
            sb.AppendLine("            command.AppendText(string.Format(\"insert into {0}({1}) values ({2})\", TableName,");
            //目标
            //                "URID,NAME,AGE,REMARK1,REMARK2"));
            List<string> propertyNames = new List<string>();
            foreach (var item in entity.Items)
            {
                propertyNames.Add(item.Title);
            }
            sb.AppendFormatLine("                \"{0}\"));", string.Join(",", propertyNames));
            foreach (DDLEntityFieldItem item in entity.Items)
            {
                //目标
                //            command.Parameters.Add(Session.DBParameterGenerator.GetParameter(entity.URID, BANKS.URIDProperty));
                sb.AppendFormatLine("            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.{0}, {1}.{0}Property));",
                        item.UpperTitle,
                        entity.ClassName);
                //目标
                //            command.AppendText(",");
                if (item != entity.Items.Last())
                {
                    sb.AppendLine("            command.AppendText(\", \");");
                }
            }
            //目标
            //            command.AppendText(")");
            //        }
            sb.AppendLine("            return Session.ExecuteNonQuery(command);");
            sb.AppendLine("        }");
        }
        #endregion
        public static void AppendDALRetrieveMethods(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendRegionStart("Retrieve");
            sb.AppendDALMethod_SelectOne(entity);
            sb.AppendRegionEnd();
        }
        public static void AppendDALMethod_SelectOne(this StringBuilder sb, DDLEntity entity)
        {
            #region 方法原型
            //public ACCOUNTS SelectOne(int urid)
            //{
            //    OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            //    command.CommandText = string.Format("select * from {0} where {1}",
            //        TableName,
            //        "URID = :URID");
            //    command.Parameters.Add(Session.GetParameter(code, BANKS.URIDProperty));
            //    var reader = Session.ExecuteDataReader(command);
            //    ACCOUNTS result = null;
            //    if (reader.Read())
            //    {
            //        result = new ACCOUNTS(reader);
            //    }
            //    return result;
            //} 
            #endregion
            string methodParameterString = string.Join(",",
                entity.PrimaryKeyItems.Select<DDLEntityFieldItem, string>(c =>
                {
                    return string.Format("{0} {1}", c.TypeString, c.LowerTitle);
                }));
            string commandParameterString = string.Join(",",
                entity.PrimaryKeyItems.Select<DDLEntityFieldItem, string>(c =>
                {
                    return string.Format(@"{0} = :{0}", c.UpperTitle);
                }));
            sb.AppendFormatLine(
@"        public {0} SelectOne({1})
        {{
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.CommandText = string.Format(""select * from {{0}} where {{1}}"",TableName,
                ""{2}"");",
          entity.ClassName,
          methodParameterString,
          commandParameterString);
            foreach (DDLEntityFieldItem item in entity.PrimaryKeyItems)
            {
                //目标
                //            command.Parameters.Add(Session.DBParameterGenerator.GetParameter(code, BANKS.URIDProperty));
                sb.AppendLine(string.Format(@"            command.Parameters.Add(Session.DBParameterGenerator.GetParameter({0},{1}.{2}Property));", 
                    item.LowerTitle,
                    entity.ClassName,
                    item.UpperTitle));
            }
            sb.AppendFormatLine(
@"            var reader = Session.ExecuteDataReader(command);
            {0} result = null;
            if (reader.Read())
            {{
                result = new {0}(reader);
            }}
            return result;
        }}",
          entity.ClassName);
        }
        public static void AppendDALUpdateMethods(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendRegionStart("Update");

            sb.AppendRegionEnd();
        }
        public static void AppendDALDeleteMethods(this StringBuilder sb, DDLEntity entity)
        {
            sb.AppendRegionStart("Delete");

            sb.AppendRegionEnd();
        }
        #endregion
    }
}
