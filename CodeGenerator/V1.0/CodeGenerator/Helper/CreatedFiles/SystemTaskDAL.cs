using VLCommon.AnyDB.Enums;
using FIAT.DDL.Entities;
using MyDataAccess.ADO_NET;
using Oracle.DataAccess.Client;

namespace GrowthSystem.DDL.DAL
{
    public class SystemTaskDAL : MyDAL
    {
        #region Properties
        #endregion
        #region Constructors
        public SystemTaskDAL(IMySession session)
            : base(session)
        {
            this.TableName = "SystemTask";
        }
        #endregion
        #region Methods
        #region Create
        public int Insert(SystemTask entity)
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.AppendText(string.Format("insert into {0}({1}) values ({2})", TableName,
                "Id,Name,MetricField,TargetValue,Type"));
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.ID, SystemTask.IDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.NAME, SystemTask.NAMEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.METRICFIELD, SystemTask.METRICFIELDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.TARGETVALUE, SystemTask.TARGETVALUEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.TYPE, SystemTask.TYPEProperty));
            return Session.ExecuteNonQuery(command);
        }
        #endregion
        #region Retrieve
        public SystemTask SelectOne()
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.CommandText = string.Format("select * from {0} where {1}",TableName,
                "");
            var reader = Session.ExecuteDataReader(command);
            SystemTask result = null;
            if (reader.Read())
            {
                result = new SystemTask(reader);
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
