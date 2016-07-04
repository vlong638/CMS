using VLCommon.AnyDB.Enums;
using FIAT.DDL.Entities;
using MyDataAccess.ADO_NET;
using Oracle.DataAccess.Client;

namespace GrowthSystem.DDL.DAL
{
    public class UserTaskDAL : MyDAL
    {
        #region Properties
        #endregion
        #region Constructors
        public UserTaskDAL(IMySession session)
            : base(session)
        {
            this.TableName = "UserTask";
        }
        #endregion
        #region Methods
        #region Create
        public int Insert(UserTask entity)
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.AppendText(string.Format("insert into {0}({1}) values ({2})", TableName,
                "Id,Name,MetricField,TargetValue,Type,AccountId,CurrentValue,ProcessStatus"));
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.ID, UserTask.IDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.NAME, UserTask.NAMEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.METRICFIELD, UserTask.METRICFIELDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.TARGETVALUE, UserTask.TARGETVALUEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.TYPE, UserTask.TYPEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.ACCOUNTID, UserTask.ACCOUNTIDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.CURRENTVALUE, UserTask.CURRENTVALUEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.PROCESSSTATUS, UserTask.PROCESSSTATUSProperty));
            return Session.ExecuteNonQuery(command);
        }
        #endregion
        #region Retrieve
        public UserTask SelectOne()
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.CommandText = string.Format("select * from {0} where {1}",TableName,
                "");
            var reader = Session.ExecuteDataReader(command);
            UserTask result = null;
            if (reader.Read())
            {
                result = new UserTask(reader);
            }
            return result;
        }
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
        #endregion
        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
