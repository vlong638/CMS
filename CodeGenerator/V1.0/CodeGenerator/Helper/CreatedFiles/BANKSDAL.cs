using VLCommon.AnyDB.Enums;
using FIAT.DDL.Entities;
using MyDataAccess.ADO_NET;
using Oracle.DataAccess.Client;

namespace GrowthSystem.DDL.DAL
{
    public class BANKSDAL : MyDAL
    {
        #region Properties
        #endregion
        #region Constructors
        public BANKSDAL(IMySession session)
            : base(session)
        {
            this.TableName = "BANKS";
        }
        #endregion
        #region Methods
        #region Create
        public int Insert(BANKS entity)
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.AppendText(string.Format("insert into {0}({1}) values ({2})", TableName,
                "URID,CODE,NAME,SYBANKID,DIRECTBANKCODE,DIRECTFLAG,DESCRIPTION,ISACTIVE,DISPLAYORDER,CREATEDON,CREATEDBY,LASTMODIFIEDON,LASTMODIFIEDBY,ROWVERSION"));
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.URID, BANKS.URIDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.CODE, BANKS.CODEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.NAME, BANKS.NAMEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.SYBANKID, BANKS.SYBANKIDProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.DIRECTBANKCODE, BANKS.DIRECTBANKCODEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.DIRECTFLAG, BANKS.DIRECTFLAGProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.DESCRIPTION, BANKS.DESCRIPTIONProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.ISACTIVE, BANKS.ISACTIVEProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.DISPLAYORDER, BANKS.DISPLAYORDERProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.CREATEDON, BANKS.CREATEDONProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.CREATEDBY, BANKS.CREATEDBYProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.LASTMODIFIEDON, BANKS.LASTMODIFIEDONProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.LASTMODIFIEDBY, BANKS.LASTMODIFIEDBYProperty));
            command.AppendText(", ");
            command.AppendParameter(Session.DBParameterGenerator.GetParameter(entity.ROWVERSION, BANKS.ROWVERSIONProperty));
            return Session.ExecuteNonQuery(command);
        }
        #endregion
        #region Retrieve
        public BANKS SelectOne(string code,string name)
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.CommandText = string.Format("select * from {0} where {1}",TableName,
                "CODE = :CODE,NAME = :NAME");
            command.Parameters.Add(Session.DBParameterGenerator.GetParameter(code,BANKS.CODEProperty));
            command.Parameters.Add(Session.DBParameterGenerator.GetParameter(name,BANKS.NAMEProperty));
            var reader = Session.ExecuteDataReader(command);
            BANKS result = null;
            if (reader.Read())
            {
                result = new BANKS(reader);
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
