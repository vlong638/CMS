using FIAT.DDL.Entities;
using MyDataAccess.ADO_NET;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace FIAT.DDL.DAL
{
    public class BANKSDAL : MyDAL
    {
        #region Constructor
        public BANKSDAL(IMySession session)
            : base(session)
        {
            this.TableName = "BANKS";
        }
        #endregion

        #region Methods
        #region Insert
        //public int InsertBANKSList(IEnumerable<BANKS> entityList)
        public int Insert(BANKS entity)
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.CommandText = string.Format("insert into {0}({1}) values ({2})", TableName,
                "URID,CODE,NAME,SYBANKID,DIRECTBANKCODE,DIRECTFLAG,DESCRIPTION,ISACTIVE,DISPLAYORDER,CREATEDON,CREATEDBY,LASTMODIFIEDON,LASTMODIFIEDBY,ROWVERSION",
                ":URID,:CODE,:NAME,:SYBANKID,:DIRECTBANKCODE,:DIRECTFLAG,:DESCRIPTION,:ISACTIVE,:DISPLAYORDER,:CREATEDON,:CREATEDBY,:LASTMODIFIEDON,:LASTMODIFIEDBY,:ROWVERSION");
            command.Parameters.Add(new OracleParameter("URID", OracleDbType.Decimal, 10) { Value = entity.URID });
            command.Parameters.Add(new OracleParameter("CODE", OracleDbType.Varchar2, 20) { Value = entity.CODE });
            command.Parameters.Add(new OracleParameter("NAME", OracleDbType.Varchar2, 64) { Value = entity.NAME });
            command.Parameters.Add(new OracleParameter("SYBANKID", OracleDbType.Decimal, 10) { Value = entity.SYBANKID });
            command.Parameters.Add(new OracleParameter("DIRECTBANKCODE", OracleDbType.Varchar2, 20) { Value = entity.DIRECTBANKCODE });
            command.Parameters.Add(new OracleParameter("DIRECTFLAG", OracleDbType.Decimal, 2) { Value = entity.DIRECTFLAG });
            command.Parameters.Add(new OracleParameter("DESCRIPTION", OracleDbType.Varchar2, 512) { Value = entity.DESCRIPTION });
            command.Parameters.Add(new OracleParameter("ISACTIVE", OracleDbType.Decimal, 2) { Value = entity.ISACTIVE });
            command.Parameters.Add(new OracleParameter("DISPLAYORDER", OracleDbType.Decimal, 10) { Value = entity.DISPLAYORDER });
            command.Parameters.Add(new OracleParameter("CREATEDON", OracleDbType.Date) { Value = entity.CREATEDON });
            command.Parameters.Add(new OracleParameter("CREATEDBY", OracleDbType.Decimal, 10) { Value = entity.CREATEDBY });
            command.Parameters.Add(new OracleParameter("LASTMODIFIEDON", OracleDbType.Date) { Value = entity.LASTMODIFIEDON });
            command.Parameters.Add(new OracleParameter("LASTMODIFIEDBY", OracleDbType.Decimal, 10) { Value = entity.LASTMODIFIEDBY });
            command.Parameters.Add(new OracleParameter("ROWVERSION", OracleDbType.Decimal, 19) { Value = entity.ROWVERSION });
            return Session.ExecuteNonQuery(command);
        }
        #endregion

        #region Delete
        //public int DeleteBANKSList(IEnumerable<BANKS> entityList)
        public int DeleteBANKS(int urid)
        {
            string sql = string.Format("delete from {0} where urid = {1};", TableName, urid);
            return Session.ExecuteNonQuery(sql);
        }
        #endregion

        #region Update
        //public int UpdateBANKSList(IEnumerable<BANKS> entityList)
        public int UpdateBANKS(BANKS entity)
        {
            string sql = string.Format("update {0} set {2} where urid = {1};", TableName, "", "");
            return Session.ExecuteNonQuery(sql);
        }
        #endregion

        #region Select
        public int GetURID()
        {
            string sql = string.Format("select max(urid)+1 from {0};", TableName);
            return Convert.ToInt32(Session.ExecuteScalar(sql));
        }
        public int Select(int id)
        {
            OracleCommand command = (OracleCommand)Session.Connection.CreateCommand();
            command.CommandText = string.Format("select * from {0} where ", TableName,
                "URID,CODE,NAME,SYBANKID,DIRECTBANKCODE,DIRECTFLAG,DESCRIPTION,ISACTIVE,DISPLAYORDER,CREATEDON,CREATEDBY,LASTMODIFIEDON,LASTMODIFIEDBY,ROWVERSION",
                ":URID,:CODE,:NAME,:SYBANKID,:DIRECTBANKCODE,:DIRECTFLAG,:DESCRIPTION,:ISACTIVE,:DISPLAYORDER,:CREATEDON,:CREATEDBY,:LASTMODIFIEDON,:LASTMODIFIEDBY,:ROWVERSION");
            command.Parameters.Add(new OracleParameter("URID", OracleDbType.Decimal, 10) { Value = entity.URID });
            command.Parameters.Add(new OracleParameter("CODE", OracleDbType.Varchar2, 20) { Value = entity.CODE });
            command.Parameters.Add(new OracleParameter("NAME", OracleDbType.Varchar2, 64) { Value = entity.NAME });
            command.Parameters.Add(new OracleParameter("SYBANKID", OracleDbType.Decimal, 10) { Value = entity.SYBANKID });
            command.Parameters.Add(new OracleParameter("DIRECTBANKCODE", OracleDbType.Varchar2, 20) { Value = entity.DIRECTBANKCODE });
            command.Parameters.Add(new OracleParameter("DIRECTFLAG", OracleDbType.Decimal, 2) { Value = entity.DIRECTFLAG });
            command.Parameters.Add(new OracleParameter("DESCRIPTION", OracleDbType.Varchar2, 512) { Value = entity.DESCRIPTION });
            command.Parameters.Add(new OracleParameter("ISACTIVE", OracleDbType.Decimal, 2) { Value = entity.ISACTIVE });
            command.Parameters.Add(new OracleParameter("DISPLAYORDER", OracleDbType.Decimal, 10) { Value = entity.DISPLAYORDER });
            command.Parameters.Add(new OracleParameter("CREATEDON", OracleDbType.Date) { Value = entity.CREATEDON });
            command.Parameters.Add(new OracleParameter("CREATEDBY", OracleDbType.Decimal, 10) { Value = entity.CREATEDBY });
            command.Parameters.Add(new OracleParameter("LASTMODIFIEDON", OracleDbType.Date) { Value = entity.LASTMODIFIEDON });
            command.Parameters.Add(new OracleParameter("LASTMODIFIEDBY", OracleDbType.Decimal, 10) { Value = entity.LASTMODIFIEDBY });
            command.Parameters.Add(new OracleParameter("ROWVERSION", OracleDbType.Decimal, 19) { Value = entity.ROWVERSION });
            return Session.ExecuteNonQuery(command);
        }
        public List<BANKS> GetBANKS()
        {
            List<BANKS> result = new List<BANKS>();
            string sql = string.Format("select * from {0};", TableName);
            DataTable dt = Session.ExecuteDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new BANKS(row));
            }
            return result;
        }
        #endregion
        #endregion

        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
