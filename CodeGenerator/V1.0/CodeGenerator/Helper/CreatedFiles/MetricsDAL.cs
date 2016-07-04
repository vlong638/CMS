using VLCommon.AnyDB.Enums;
using FIAT.DDL.Entities;
using MyDataAccess.ADO_NET;
using Oracle.DataAccess.Client;

namespace GrowthSystem.DDL.DAL
{
    public class MetricsDAL : MyDAL
    {
        #region Properties
        #endregion
        #region Constructors
        public MetricsDAL(IMySession session)
            : base(session)
        {
            this.TableName = "Metrics";
        }
        #endregion
        #region Methods
        #region Create
        public int Insert(Metrics entity)
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.AppendText(string.Format("insert into {0}({1}) values ({2})", TableName,
                "UserId,Consuption,TotalOrder,CreateTime"));
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.USERID, Metrics.USERIDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.CONSUPTION, Metrics.CONSUPTIONProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.TOTALORDER, Metrics.TOTALORDERProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.CREATETIME, Metrics.CREATETIMEProperty));
            return Session.ExecuteNonQuery(command);
        }
        #endregion
        #region Retrieve
        public Metrics SelectOne()
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.CommandText = string.Format("select * from {0} where {1}",TableName,
                "");
            var reader = Session.ExecuteDataReader(command);
            Metrics result = null;
            if (reader.Read())
            {
                result = new Metrics(reader);
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
