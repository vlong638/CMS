//using VLCommon.AnyDB.Enums;
//using FIAT.DDL.Entities;
//using MyDataAccess.ADO_NET;
//using Oracle.DataAccess.Client;

//namespace FIAT.DDL.DAL
//{
//    public class TB_STUDENTDAL : MyDAL
//    {
//        #region Properties
//        #endregion
//        #region Constructors
//        public TB_STUDENTDAL(IMySession session)
//            : base(session)
//        {
//            this.TableName = "TB_STUDENT";
//        }
//        #endregion
//        #region Methods
//        #region Create
//        public int Insert(TB_STUDENT entity)
//        {
//            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
//            command.AppendText(string.Format("insert into {0}({1}) values ({2})", TableName,
//                "URID,NAME,AGE,REMARK1,REMARK2"));
//            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.URID, TB_STUDENT.URIDProperty));
//            command.AppendText(", ");
//            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.NAME, TB_STUDENT.NAMEProperty));
//            command.AppendText(", ");
//            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.AGE, TB_STUDENT.AGEProperty));
//            command.AppendText(", ");
//            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.REMARK1, TB_STUDENT.REMARK1Property));
//            command.AppendText(", ");
//            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.REMARK2, TB_STUDENT.REMARK2Property));
//            return Session.ExecuteNonQuery(command);
//        }
//        #endregion
//        #region Retrieve
//        public TB_STUDENT SelectOne()
//        {
//            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
//            command.CommandText = string.Format("select * from {0} where {1}",TableName,
//                "");
//            var reader = Session.ExecuteDataReader(command);
//            TB_STUDENT result = null;
//            if (reader.Read())
//            {
//                result = new TB_STUDENT(reader);
//            }
//            return result;
//        }
//        #endregion
//        #region Update
//        #endregion
//        #region Delete
//        #endregion
//        #endregion
//        #region ManualCode
//        //手工添加的内容请于此处添加
//        #endregion
//    }
//}
