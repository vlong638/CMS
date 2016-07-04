using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using System;
using System.Data;
using System.Data.Common;

namespace FIAT.DDL.Entities
{
    public class BANKS
    {
        #region Properties
        #region StaticProperties
        public static DBFieldItem URIDProperty = new DBFieldItem("URID",false, FieldItemType.NUMBER, 10, 0,false);
        public static DBFieldItem CODEProperty = new DBFieldItem("CODE",true, FieldItemType.VARCHAR2, 20, 0,false);
        public static DBFieldItem NAMEProperty = new DBFieldItem("NAME",true, FieldItemType.VARCHAR2, 64, 0,false);
        public static DBFieldItem SYBANKIDProperty = new DBFieldItem("SYBANKID",false, FieldItemType.NUMBER, 10, 0,true);
        public static DBFieldItem DIRECTBANKCODEProperty = new DBFieldItem("DIRECTBANKCODE",false, FieldItemType.VARCHAR2, 20, 0,true);
        public static DBFieldItem DIRECTFLAGProperty = new DBFieldItem("DIRECTFLAG",false, FieldItemType.NUMBER, 2, 0,false);
        public static DBFieldItem DESCRIPTIONProperty = new DBFieldItem("DESCRIPTION",false, FieldItemType.VARCHAR2, 512, 0,true);
        public static DBFieldItem ISACTIVEProperty = new DBFieldItem("ISACTIVE",false, FieldItemType.NUMBER, 2, 0,false);
        public static DBFieldItem DISPLAYORDERProperty = new DBFieldItem("DISPLAYORDER",false, FieldItemType.NUMBER, 10, 0,false);
        public static DBFieldItem CREATEDONProperty = new DBFieldItem("CREATEDON",false, FieldItemType.DATE, 0, 0,false);
        public static DBFieldItem CREATEDBYProperty = new DBFieldItem("CREATEDBY",false, FieldItemType.NUMBER, 10, 0,false);
        public static DBFieldItem LASTMODIFIEDONProperty = new DBFieldItem("LASTMODIFIEDON",false, FieldItemType.DATE, 0, 0,false);
        public static DBFieldItem LASTMODIFIEDBYProperty = new DBFieldItem("LASTMODIFIEDBY",false, FieldItemType.NUMBER, 10, 0,false);
        public static DBFieldItem ROWVERSIONProperty = new DBFieldItem("ROWVERSION",false, FieldItemType.NUMBER, 19, 0,false);
        #endregion
        #region StandardProperties
        private decimal _urid;
        public decimal URID { get { return _urid; } set { _urid = value; } }
        private string _code;
        public string CODE { get { return _code; } set { _code = value; } }
        private string _name;
        public string NAME { get { return _name; } set { _name = value; } }
        private decimal _sybankid;
        public decimal SYBANKID { get { return _sybankid; } set { _sybankid = value; } }
        private string _directbankcode;
        public string DIRECTBANKCODE { get { return _directbankcode; } set { _directbankcode = value; } }
        private decimal _directflag;
        public decimal DIRECTFLAG { get { return _directflag; } set { _directflag = value; } }
        private string _description;
        public string DESCRIPTION { get { return _description; } set { _description = value; } }
        private decimal _isactive;
        public decimal ISACTIVE { get { return _isactive; } set { _isactive = value; } }
        private decimal _displayorder;
        public decimal DISPLAYORDER { get { return _displayorder; } set { _displayorder = value; } }
        private DateTime _createdon;
        public DateTime CREATEDON { get { return _createdon; } set { _createdon = value; } }
        private decimal _createdby;
        public decimal CREATEDBY { get { return _createdby; } set { _createdby = value; } }
        private DateTime _lastmodifiedon;
        public DateTime LASTMODIFIEDON { get { return _lastmodifiedon; } set { _lastmodifiedon = value; } }
        private decimal _lastmodifiedby;
        public decimal LASTMODIFIEDBY { get { return _lastmodifiedby; } set { _lastmodifiedby = value; } }
        private decimal _rowversion;
        public decimal ROWVERSION { get { return _rowversion; } set { _rowversion = value; } }
        #endregion
        #endregion
        #region Constructors
        public BANKS(decimal urid = 0, decimal isactive = 1, decimal displayorder = 0, decimal createdby = 0, decimal lastmodifiedby = 0, decimal rowversion = 1)
        {
            this.URID = urid;
            this.ISACTIVE = isactive;
            this.DISPLAYORDER = displayorder;
            this.CREATEDBY = createdby;
            this.LASTMODIFIEDBY = lastmodifiedby;
            this.ROWVERSION = rowversion;

        }
        public BANKS(string code, string name, decimal directflag, decimal urid = 0, decimal isactive = 1, decimal displayorder = 0, decimal createdby = 0, decimal lastmodifiedby = 0, decimal rowversion = 1)
            : this(urid, isactive, displayorder, createdby, lastmodifiedby, rowversion)
        {
            this.CODE = code;
            this.NAME = name;
            this.DIRECTFLAG = directflag;

        }
        public BANKS(DataRow row)
        {
            this.URID = Convert.ToDecimal(row["URID"]);
            this.CODE = Convert.ToString(row["CODE"]);
            this.NAME = Convert.ToString(row["NAME"]);
            if (row["SYBANKID"] != DBNull.Value && row["SYBANKID"].ToString() != "")
            {
                this.SYBANKID = Convert.ToDecimal(row["SYBANKID"]);
            }
            if (row["DIRECTBANKCODE"] != DBNull.Value && row["DIRECTBANKCODE"].ToString() != "")
            {
                this.DIRECTBANKCODE = Convert.ToString(row["DIRECTBANKCODE"]);
            }
            this.DIRECTFLAG = Convert.ToDecimal(row["DIRECTFLAG"]);
            if (row["DESCRIPTION"] != DBNull.Value && row["DESCRIPTION"].ToString() != "")
            {
                this.DESCRIPTION = Convert.ToString(row["DESCRIPTION"]);
            }
            this.ISACTIVE = Convert.ToDecimal(row["ISACTIVE"]);
            this.DISPLAYORDER = Convert.ToDecimal(row["DISPLAYORDER"]);
            this.CREATEDON = Convert.ToDateTime(row["CREATEDON"]);
            this.CREATEDBY = Convert.ToDecimal(row["CREATEDBY"]);
            this.LASTMODIFIEDON = Convert.ToDateTime(row["LASTMODIFIEDON"]);
            this.LASTMODIFIEDBY = Convert.ToDecimal(row["LASTMODIFIEDBY"]);
            this.ROWVERSION = Convert.ToDecimal(row["ROWVERSION"]);

        }
        public BANKS(DbDataReader row)
        {
            this.URID = Convert.ToDecimal(row["URID"]);
            this.CODE = Convert.ToString(row["CODE"]);
            this.NAME = Convert.ToString(row["NAME"]);
            if (row["SYBANKID"] != DBNull.Value && row["SYBANKID"].ToString() != "")
            {
                this.SYBANKID = Convert.ToDecimal(row["SYBANKID"]);
            }
            if (row["DIRECTBANKCODE"] != DBNull.Value && row["DIRECTBANKCODE"].ToString() != "")
            {
                this.DIRECTBANKCODE = Convert.ToString(row["DIRECTBANKCODE"]);
            }
            this.DIRECTFLAG = Convert.ToDecimal(row["DIRECTFLAG"]);
            if (row["DESCRIPTION"] != DBNull.Value && row["DESCRIPTION"].ToString() != "")
            {
                this.DESCRIPTION = Convert.ToString(row["DESCRIPTION"]);
            }
            this.ISACTIVE = Convert.ToDecimal(row["ISACTIVE"]);
            this.DISPLAYORDER = Convert.ToDecimal(row["DISPLAYORDER"]);
            this.CREATEDON = Convert.ToDateTime(row["CREATEDON"]);
            this.CREATEDBY = Convert.ToDecimal(row["CREATEDBY"]);
            this.LASTMODIFIEDON = Convert.ToDateTime(row["LASTMODIFIEDON"]);
            this.LASTMODIFIEDBY = Convert.ToDecimal(row["LASTMODIFIEDBY"]);
            this.ROWVERSION = Convert.ToDecimal(row["ROWVERSION"]);

        }
        #endregion
        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
