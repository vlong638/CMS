using VLCommon.AnyDB.Enums;
using GrowthSystem.DDL.Entities;
using MyDataAccess.ADO_NET;
using Oracle.DataAccess.Client;

namespace GrowthSystem.DDL.DAL
{
    public class AccountDAL : MyDAL
    {
        #region Properties
        #endregion
        #region Constructors
        public AccountDAL(IMySession session)
            : base(session)
        {
            this.TableName = "Account";
        }
        #endregion
        #region Methods
        #region Create
        public int Insert(Account entity)
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.AppendText(string.Format("insert into {0}({1}) values ({2})", TableName,
                "Id,ResourceType,ResourceId,Level"));
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.ID, Account.IDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.RESOURCETYPE, Account.RESOURCETYPEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.RESOURCEID, Account.RESOURCEIDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.LEVEL, Account.LEVELProperty));
            return Session.ExecuteNonQuery(command);
        }
        #endregion
        #region Retrieve
        public Account SelectOne()
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.CommandText = string.Format("select * from {0} where {1}",TableName,
                "");
            var reader = Session.ExecuteDataReader(command);
            Account result = null;
            if (reader.Read())
            {
                result = new Account(reader);
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
