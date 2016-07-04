namespace FIAT.DDL.DAL
{
    //public class ACCOUNTSDAL : MyDAL
    //{
    //    #region Properties
    //    #endregion

    //    #region Constructors
    //    public ACCOUNTSDAL(IMySession session)
    //        : base(session)
    //    {
    //        this.TableName = "ACCOUNTS";
    //    }
    //    #endregion

    //    #region Methods
    //    #region Create
    //    public int Insert(ACCOUNTS entity)
    //    {
    //        OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
    //        command.CommandText = string.Format("insert into {0}({1}) values ({2})", TableName,
    //            "URID,ENTITYID,SEGID,BANKLOCATIONID,BRIEFNUMBER,ACCOUNTNUMBER,ACCOUNTNAME,SAVINGTYPE,ACCOUNTCLASS,ACCOUNTTYPEID,ACCOUNTGROUPID,ISBANKDIRECT,MUSTERFLAG,MINIUPTRANSFERAMOUNT,MINITRANSFERAMOUNT,RESERVEDBALANCE,INTEGERRATE,DESCRIPT,ASSESSBALANCE,OTHERGLACCOUNT,OTHERACCOUNTNUMBER,CURRENCYID,ISNOTIONAL,ISNONSTANDARD,LICENSENO,WITHDRAWACCOUNTID,DESCRIPTION,FIELD1,FIELD2,FIELD3,ACCOUNTSTATE,ISACTIVE,APPLYID,ORGANIZATIONCODE,DATEOPENED,DISPLAYORDER,DATECLOSED,CREATEDBY,CREATEDON,LASTMODIFIEDBY,LASTMODIFIEDON,ROWVERSION",
    //            ":URID,:ENTITYID,:SEGID,:BANKLOCATIONID,:BRIEFNUMBER,:ACCOUNTNUMBER,:ACCOUNTNAME,:SAVINGTYPE,:ACCOUNTCLASS,:ACCOUNTTYPEID,:ACCOUNTGROUPID,:ISBANKDIRECT,:MUSTERFLAG,:MINIUPTRANSFERAMOUNT,:MINITRANSFERAMOUNT,:RESERVEDBALANCE,:INTEGERRATE,:DESCRIPT,:ASSESSBALANCE,:OTHERGLACCOUNT,:OTHERACCOUNTNUMBER,:CURRENCYID,:ISNOTIONAL,:ISNONSTANDARD,:LICENSENO,:WITHDRAWACCOUNTID,:DESCRIPTION,:FIELD1,:FIELD2,:FIELD3,:ACCOUNTSTATE,:ISACTIVE,:APPLYID,:ORGANIZATIONCODE,:DATEOPENED,:DISPLAYORDER,:DATECLOSED,:CREATEDBY,:CREATEDON,:LASTMODIFIEDBY,:LASTMODIFIEDON,:ROWVERSION");
    //        //command.Parameters.Add(Session.GetParameter(entity.URIDProperty));



    //        //command.Parameters.Add(new OracleParameter("URID", OracleDbType.Decimal, 10) { Value = entity.URID });
    //        command.Parameters.Add(new OracleParameter("ENTITYID", OracleDbType.Decimal,10) { Value = entity.ENTITYID });
    //        command.Parameters.Add(new OracleParameter("SEGID", OracleDbType.Decimal,10) { Value = entity.SEGID });
    //        command.Parameters.Add(new OracleParameter("BANKLOCATIONID", OracleDbType.Decimal,10) { Value = entity.BANKLOCATIONID });
    //        command.Parameters.Add(new OracleParameter("BRIEFNUMBER", OracleDbType.Varchar2,20) { Value = entity.BRIEFNUMBER });
    //        command.Parameters.Add(new OracleParameter("ACCOUNTNUMBER", OracleDbType.Varchar2,64) { Value = entity.ACCOUNTNUMBER });
    //        command.Parameters.Add(new OracleParameter("ACCOUNTNAME", OracleDbType.Varchar2,256) { Value = entity.ACCOUNTNAME });
    //        command.Parameters.Add(new OracleParameter("SAVINGTYPE", OracleDbType.Decimal,10) { Value = entity.SAVINGTYPE });
    //        command.Parameters.Add(new OracleParameter("ACCOUNTCLASS", OracleDbType.Decimal,10) { Value = entity.ACCOUNTCLASS });
    //        command.Parameters.Add(new OracleParameter("ACCOUNTTYPEID", OracleDbType.Decimal,10) { Value = entity.ACCOUNTTYPEID });
    //        command.Parameters.Add(new OracleParameter("ACCOUNTGROUPID", OracleDbType.Decimal,10) { Value = entity.ACCOUNTGROUPID });
    //        command.Parameters.Add(new OracleParameter("ISBANKDIRECT", OracleDbType.Decimal,2) { Value = entity.ISBANKDIRECT });
    //        command.Parameters.Add(new OracleParameter("MUSTERFLAG", OracleDbType.Decimal,2) { Value = entity.MUSTERFLAG });
    //        command.Parameters.Add(new OracleParameter("MINIUPTRANSFERAMOUNT", OracleDbType.Decimal,126) { Value = entity.MINIUPTRANSFERAMOUNT });
    //        command.Parameters.Add(new OracleParameter("MINITRANSFERAMOUNT", OracleDbType.Decimal,126) { Value = entity.MINITRANSFERAMOUNT });
    //        command.Parameters.Add(new OracleParameter("RESERVEDBALANCE", OracleDbType.Decimal,126) { Value = entity.RESERVEDBALANCE });
    //        command.Parameters.Add(new OracleParameter("INTEGERRATE", OracleDbType.Decimal,10) { Value = entity.INTEGERRATE });
    //        command.Parameters.Add(new OracleParameter("DESCRIPT", OracleDbType.Varchar2,400) { Value = entity.DESCRIPT });
    //        command.Parameters.Add(new OracleParameter("ASSESSBALANCE", OracleDbType.Decimal,126) { Value = entity.ASSESSBALANCE });
    //        command.Parameters.Add(new OracleParameter("OTHERGLACCOUNT", OracleDbType.Varchar2,64) { Value = entity.OTHERGLACCOUNT });
    //        command.Parameters.Add(new OracleParameter("OTHERACCOUNTNUMBER", OracleDbType.Varchar2,64) { Value = entity.OTHERACCOUNTNUMBER });
    //        command.Parameters.Add(new OracleParameter("CURRENCYID", OracleDbType.Decimal,10) { Value = entity.CURRENCYID });
    //        command.Parameters.Add(new OracleParameter("ISNOTIONAL", OracleDbType.Decimal,2) { Value = entity.ISNOTIONAL });
    //        command.Parameters.Add(new OracleParameter("ISNONSTANDARD", OracleDbType.Decimal,2) { Value = entity.ISNONSTANDARD });
    //        command.Parameters.Add(new OracleParameter("LICENSENO", OracleDbType.Varchar2,40) { Value = entity.LICENSENO });
    //        command.Parameters.Add(new OracleParameter("WITHDRAWACCOUNTID", OracleDbType.Decimal,10) { Value = entity.WITHDRAWACCOUNTID });
    //        command.Parameters.Add(new OracleParameter("DESCRIPTION", OracleDbType.Varchar2,255) { Value = entity.DESCRIPTION });
    //        command.Parameters.Add(new OracleParameter("FIELD1", OracleDbType.Varchar2,256) { Value = entity.FIELD1 });
    //        command.Parameters.Add(new OracleParameter("FIELD2", OracleDbType.Varchar2,256) { Value = entity.FIELD2 });
    //        command.Parameters.Add(new OracleParameter("FIELD3", OracleDbType.Varchar2,256) { Value = entity.FIELD3 });
    //        command.Parameters.Add(new OracleParameter("ACCOUNTSTATE", OracleDbType.Decimal,10) { Value = entity.ACCOUNTSTATE });
    //        command.Parameters.Add(new OracleParameter("ISACTIVE", OracleDbType.Decimal,2) { Value = entity.ISACTIVE });
    //        command.Parameters.Add(new OracleParameter("APPLYID", OracleDbType.Decimal,10) { Value = entity.APPLYID });
    //        command.Parameters.Add(new OracleParameter("ORGANIZATIONCODE", OracleDbType.Varchar2,10) { Value = entity.ORGANIZATIONCODE });
    //        command.Parameters.Add(new OracleParameter("DATEOPENED", OracleDbType.Date) { Value = entity.DATEOPENED });
    //        command.Parameters.Add(new OracleParameter("DISPLAYORDER", OracleDbType.Decimal,10) { Value = entity.DISPLAYORDER });
    //        command.Parameters.Add(new OracleParameter("DATECLOSED", OracleDbType.Date) { Value = entity.DATECLOSED });
    //        command.Parameters.Add(new OracleParameter("CREATEDBY", OracleDbType.Decimal,10) { Value = entity.CREATEDBY });
    //        command.Parameters.Add(new OracleParameter("CREATEDON", OracleDbType.Date) { Value = entity.CREATEDON });
    //        command.Parameters.Add(new OracleParameter("LASTMODIFIEDBY", OracleDbType.Decimal,10) { Value = entity.LASTMODIFIEDBY });
    //        command.Parameters.Add(new OracleParameter("LASTMODIFIEDON", OracleDbType.Date) { Value = entity.LASTMODIFIEDON });
    //        command.Parameters.Add(new OracleParameter("ROWVERSION", OracleDbType.Decimal,19) { Value = entity.ROWVERSION });
    //        return Session.ExecuteNonQuery(command);
    //    }
    //    #endregion
    //    #region Retrieve
    //    public ACCOUNTS SelectOne(int urid)
    //    {
    //        OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
    //        command.CommandText = string.Format("select * from {0} where {1}", 
    //            TableName,
    //            "URID = :URID");
    //        command.Parameters.Add(Session.GetParameter(urid));
    //        var reader = Session.ExecuteDataReader(command);
    //        ACCOUNTS result=null;
    //        if (reader.Read())
    //        {
    //            result= new ACCOUNTS(reader);
    //        }
    //        return result;
    //    }
    //    #endregion
    //    #region Update
    //    #endregion
    //    #region Delete
    //    #endregion
    //    #endregion

    //    #region ManualCode
    //    //手工添加的内容请于此处添加
    //    #endregion
    //}
}
