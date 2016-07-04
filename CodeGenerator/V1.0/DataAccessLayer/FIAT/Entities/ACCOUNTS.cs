using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using System;
using System.Data;
using System.Data.Common;

namespace FIAT.DDL.Entities
{
    //public class ACCOUNTS
    //{
    //    #region Properties
    //    //public DBFieldItem<decimal> URIDProperty = new DBFieldItem<decimal>("URID", FieldItemType.NUMBER, 10, 2, false);
    //    //public decimal URID { get { return URIDProperty.Value; } set { URIDProperty.Value = value; } }

    //    private decimal _entityid;
    //    public decimal ENTITYID
    //    {
    //        get { return _entityid; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段ENTITYID长度超过限制");
    //            }
    //            _entityid = value;
    //        }
    //    }

    //    private decimal _segid;
    //    public decimal SEGID
    //    {
    //        get { return _segid; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段SEGID长度超过限制");
    //            }
    //            _segid = value;
    //        }
    //    }

    //    private decimal _banklocationid;
    //    public decimal BANKLOCATIONID
    //    {
    //        get { return _banklocationid; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段BANKLOCATIONID长度超过限制");
    //            }
    //            _banklocationid = value;
    //        }
    //    }

    //    private string _briefnumber;
    //    public string BRIEFNUMBER
    //    {
    //        get { return _briefnumber; }
    //        set
    //        {
    //            if (value.ToString().Length > 20)
    //            {
    //                throw new Exception("字段BRIEFNUMBER长度超过限制");
    //            }
    //            _briefnumber = value;
    //        }
    //    }

    //    private string _accountnumber;
    //    public string ACCOUNTNUMBER
    //    {
    //        get { return _accountnumber; }
    //        set
    //        {
    //            if (value.ToString().Length > 64)
    //            {
    //                throw new Exception("字段ACCOUNTNUMBER长度超过限制");
    //            }
    //            _accountnumber = value;
    //        }
    //    }

    //    private string _accountname;
    //    public string ACCOUNTNAME
    //    {
    //        get { return _accountname; }
    //        set
    //        {
    //            if (value.ToString().Length > 256)
    //            {
    //                throw new Exception("字段ACCOUNTNAME长度超过限制");
    //            }
    //            _accountname = value;
    //        }
    //    }

    //    private decimal _savingtype;
    //    public decimal SAVINGTYPE
    //    {
    //        get { return _savingtype; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段SAVINGTYPE长度超过限制");
    //            }
    //            _savingtype = value;
    //        }
    //    }

    //    private decimal _accountclass;
    //    public decimal ACCOUNTCLASS
    //    {
    //        get { return _accountclass; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段ACCOUNTCLASS长度超过限制");
    //            }
    //            _accountclass = value;
    //        }
    //    }

    //    private decimal _accounttypeid;
    //    public decimal ACCOUNTTYPEID
    //    {
    //        get { return _accounttypeid; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段ACCOUNTTYPEID长度超过限制");
    //            }
    //            _accounttypeid = value;
    //        }
    //    }

    //    private decimal _accountgroupid;
    //    public decimal ACCOUNTGROUPID
    //    {
    //        get { return _accountgroupid; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段ACCOUNTGROUPID长度超过限制");
    //            }
    //            _accountgroupid = value;
    //        }
    //    }

    //    private decimal _isbankdirect;
    //    public decimal ISBANKDIRECT
    //    {
    //        get { return _isbankdirect; }
    //        set
    //        {
    //            if (value.ToString().Length > 2)
    //            {
    //                throw new Exception("字段ISBANKDIRECT长度超过限制");
    //            }
    //            _isbankdirect = value;
    //        }
    //    }

    //    private decimal _musterflag;
    //    public decimal MUSTERFLAG
    //    {
    //        get { return _musterflag; }
    //        set
    //        {
    //            if (value.ToString().Length > 2)
    //            {
    //                throw new Exception("字段MUSTERFLAG长度超过限制");
    //            }
    //            _musterflag = value;
    //        }
    //    }

    //    private decimal _miniuptransferamount;
    //    public decimal MINIUPTRANSFERAMOUNT
    //    {
    //        get { return _miniuptransferamount; }
    //        set
    //        {
    //            if (value.ToString().Length > 126)
    //            {
    //                throw new Exception("字段MINIUPTRANSFERAMOUNT长度超过限制");
    //            }
    //            _miniuptransferamount = value;
    //        }
    //    }

    //    private decimal _minitransferamount;
    //    public decimal MINITRANSFERAMOUNT
    //    {
    //        get { return _minitransferamount; }
    //        set
    //        {
    //            if (value.ToString().Length > 126)
    //            {
    //                throw new Exception("字段MINITRANSFERAMOUNT长度超过限制");
    //            }
    //            _minitransferamount = value;
    //        }
    //    }

    //    private decimal _reservedbalance;
    //    public decimal RESERVEDBALANCE
    //    {
    //        get { return _reservedbalance; }
    //        set
    //        {
    //            if (value.ToString().Length > 126)
    //            {
    //                throw new Exception("字段RESERVEDBALANCE长度超过限制");
    //            }
    //            _reservedbalance = value;
    //        }
    //    }

    //    private decimal _integerrate;
    //    public decimal INTEGERRATE
    //    {
    //        get { return _integerrate; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段INTEGERRATE长度超过限制");
    //            }
    //            _integerrate = value;
    //        }
    //    }

    //    private string _descript;
    //    public string DESCRIPT
    //    {
    //        get { return _descript; }
    //        set
    //        {
    //            if (value.ToString().Length > 400)
    //            {
    //                throw new Exception("字段DESCRIPT长度超过限制");
    //            }
    //            _descript = value;
    //        }
    //    }

    //    private decimal _assessbalance;
    //    public decimal ASSESSBALANCE
    //    {
    //        get { return _assessbalance; }
    //        set
    //        {
    //            if (value.ToString().Length > 126)
    //            {
    //                throw new Exception("字段ASSESSBALANCE长度超过限制");
    //            }
    //            _assessbalance = value;
    //        }
    //    }

    //    private string _otherglaccount;
    //    public string OTHERGLACCOUNT
    //    {
    //        get { return _otherglaccount; }
    //        set
    //        {
    //            if (value.ToString().Length > 64)
    //            {
    //                throw new Exception("字段OTHERGLACCOUNT长度超过限制");
    //            }
    //            _otherglaccount = value;
    //        }
    //    }

    //    private string _otheraccountnumber;
    //    public string OTHERACCOUNTNUMBER
    //    {
    //        get { return _otheraccountnumber; }
    //        set
    //        {
    //            if (value.ToString().Length > 64)
    //            {
    //                throw new Exception("字段OTHERACCOUNTNUMBER长度超过限制");
    //            }
    //            _otheraccountnumber = value;
    //        }
    //    }

    //    private decimal _currencyid;
    //    public decimal CURRENCYID
    //    {
    //        get { return _currencyid; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段CURRENCYID长度超过限制");
    //            }
    //            _currencyid = value;
    //        }
    //    }

    //    private decimal _isnotional;
    //    public decimal ISNOTIONAL
    //    {
    //        get { return _isnotional; }
    //        set
    //        {
    //            if (value.ToString().Length > 2)
    //            {
    //                throw new Exception("字段ISNOTIONAL长度超过限制");
    //            }
    //            _isnotional = value;
    //        }
    //    }

    //    private decimal _isnonstandard;
    //    public decimal ISNONSTANDARD
    //    {
    //        get { return _isnonstandard; }
    //        set
    //        {
    //            if (value.ToString().Length > 2)
    //            {
    //                throw new Exception("字段ISNONSTANDARD长度超过限制");
    //            }
    //            _isnonstandard = value;
    //        }
    //    }

    //    private string _licenseno;
    //    public string LICENSENO
    //    {
    //        get { return _licenseno; }
    //        set
    //        {
    //            if (value.ToString().Length > 40)
    //            {
    //                throw new Exception("字段LICENSENO长度超过限制");
    //            }
    //            _licenseno = value;
    //        }
    //    }

    //    private decimal _withdrawaccountid;
    //    public decimal WITHDRAWACCOUNTID
    //    {
    //        get { return _withdrawaccountid; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段WITHDRAWACCOUNTID长度超过限制");
    //            }
    //            _withdrawaccountid = value;
    //        }
    //    }

    //    private string _description;
    //    public string DESCRIPTION
    //    {
    //        get { return _description; }
    //        set
    //        {
    //            if (value.ToString().Length > 255)
    //            {
    //                throw new Exception("字段DESCRIPTION长度超过限制");
    //            }
    //            _description = value;
    //        }
    //    }

    //    private string _field1;
    //    public string FIELD1
    //    {
    //        get { return _field1; }
    //        set
    //        {
    //            if (value.ToString().Length > 256)
    //            {
    //                throw new Exception("字段FIELD1长度超过限制");
    //            }
    //            _field1 = value;
    //        }
    //    }

    //    private string _field2;
    //    public string FIELD2
    //    {
    //        get { return _field2; }
    //        set
    //        {
    //            if (value.ToString().Length > 256)
    //            {
    //                throw new Exception("字段FIELD2长度超过限制");
    //            }
    //            _field2 = value;
    //        }
    //    }

    //    private string _field3;
    //    public string FIELD3
    //    {
    //        get { return _field3; }
    //        set
    //        {
    //            if (value.ToString().Length > 256)
    //            {
    //                throw new Exception("字段FIELD3长度超过限制");
    //            }
    //            _field3 = value;
    //        }
    //    }

    //    private decimal _accountstate;
    //    public decimal ACCOUNTSTATE
    //    {
    //        get { return _accountstate; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段ACCOUNTSTATE长度超过限制");
    //            }
    //            _accountstate = value;
    //        }
    //    }

    //    private decimal _isactive;
    //    public decimal ISACTIVE
    //    {
    //        get { return _isactive; }
    //        set
    //        {
    //            if (value.ToString().Length > 2)
    //            {
    //                throw new Exception("字段ISACTIVE长度超过限制");
    //            }
    //            _isactive = value;
    //        }
    //    }

    //    private decimal _applyid;
    //    public decimal APPLYID
    //    {
    //        get { return _applyid; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段APPLYID长度超过限制");
    //            }
    //            _applyid = value;
    //        }
    //    }

    //    private string _organizationcode;
    //    public string ORGANIZATIONCODE
    //    {
    //        get { return _organizationcode; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段ORGANIZATIONCODE长度超过限制");
    //            }
    //            _organizationcode = value;
    //        }
    //    }

    //    private DateTime _dateopened;
    //    public DateTime DATEOPENED
    //    {
    //        get { return _dateopened; }
    //        set { _dateopened = value; }
    //    }

    //    private decimal _displayorder;
    //    public decimal DISPLAYORDER
    //    {
    //        get { return _displayorder; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段DISPLAYORDER长度超过限制");
    //            }
    //            _displayorder = value;
    //        }
    //    }

    //    private DateTime _dateclosed;
    //    public DateTime DATECLOSED
    //    {
    //        get { return _dateclosed; }
    //        set { _dateclosed = value; }
    //    }

    //    private decimal _createdby;
    //    public decimal CREATEDBY
    //    {
    //        get { return _createdby; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段CREATEDBY长度超过限制");
    //            }
    //            _createdby = value;
    //        }
    //    }

    //    private DateTime _createdon;
    //    public DateTime CREATEDON
    //    {
    //        get { return _createdon; }
    //        set { _createdon = value; }
    //    }

    //    private decimal _lastmodifiedby;
    //    public decimal LASTMODIFIEDBY
    //    {
    //        get { return _lastmodifiedby; }
    //        set
    //        {
    //            if (value.ToString().Length > 10)
    //            {
    //                throw new Exception("字段LASTMODIFIEDBY长度超过限制");
    //            }
    //            _lastmodifiedby = value;
    //        }
    //    }

    //    private DateTime _lastmodifiedon;
    //    public DateTime LASTMODIFIEDON
    //    {
    //        get { return _lastmodifiedon; }
    //        set { _lastmodifiedon = value; }
    //    }

    //    private decimal _rowversion;
    //    public decimal ROWVERSION
    //    {
    //        get { return _rowversion; }
    //        set
    //        {
    //            if (value.ToString().Length > 19)
    //            {
    //                throw new Exception("字段ROWVERSION长度超过限制");
    //            }
    //            _rowversion = value;
    //        }
    //    }
    //    #endregion
    //    #region Constructors
    //    public ACCOUNTS(decimal urid = 0, decimal isnonstandard = 0, decimal isactive = 1, decimal displayorder = 0, decimal createdby = 0, decimal lastmodifiedby = 0, decimal rowversion = 1)
    //    {
    //        this.URID = urid;
    //        this.ISNONSTANDARD = isnonstandard;
    //        this.ISACTIVE = isactive;
    //        this.DISPLAYORDER = displayorder;
    //        this.CREATEDBY = createdby;
    //        this.LASTMODIFIEDBY = lastmodifiedby;
    //        this.ROWVERSION = rowversion;
    //    }
    //    public ACCOUNTS(decimal entityid, decimal banklocationid, string accountnumber, decimal musterflag, decimal miniuptransferamount, decimal minitransferamount, decimal reservedbalance, decimal integerrate, decimal assessbalance, decimal currencyid, decimal isnotional, decimal accountstate, decimal urid = 0, decimal isnonstandard = 0, decimal isactive = 1, decimal displayorder = 0, decimal createdby = 0, decimal lastmodifiedby = 0, decimal rowversion = 1)
    //        : this(urid, isnonstandard, isactive, displayorder, createdby, lastmodifiedby, rowversion)
    //    {
    //        this.ENTITYID = entityid;
    //        this.BANKLOCATIONID = banklocationid;
    //        this.ACCOUNTNUMBER = accountnumber;
    //        this.MUSTERFLAG = musterflag;
    //        this.MINIUPTRANSFERAMOUNT = miniuptransferamount;
    //        this.MINITRANSFERAMOUNT = minitransferamount;
    //        this.RESERVEDBALANCE = reservedbalance;
    //        this.INTEGERRATE = integerrate;
    //        this.ASSESSBALANCE = assessbalance;
    //        this.CURRENCYID = currencyid;
    //        this.ISNOTIONAL = isnotional;
    //        this.ACCOUNTSTATE = accountstate;
    //    }
    //    public ACCOUNTS(DbDataReader row)
    //    {
    //        this.URID = Convert.ToDecimal(row["URID"]);
    //        this.ENTITYID = Convert.ToDecimal(row["ENTITYID"]);
    //        if (row["SEGID"] != DBNull.Value && row["SEGID"].ToString() != "")
    //        {
    //            this.SEGID = Convert.ToDecimal(row["SEGID"]);
    //        }
    //        this.BANKLOCATIONID = Convert.ToDecimal(row["BANKLOCATIONID"]);
    //        if (row["BRIEFNUMBER"] != DBNull.Value && row["BRIEFNUMBER"].ToString() != "")
    //        {
    //            this.BRIEFNUMBER = Convert.ToString(row["BRIEFNUMBER"]);
    //        }
    //        this.ACCOUNTNUMBER = Convert.ToString(row["ACCOUNTNUMBER"]);
    //        if (row["ACCOUNTNAME"] != DBNull.Value && row["ACCOUNTNAME"].ToString() != "")
    //        {
    //            this.ACCOUNTNAME = Convert.ToString(row["ACCOUNTNAME"]);
    //        }
    //        if (row["SAVINGTYPE"] != DBNull.Value && row["SAVINGTYPE"].ToString() != "")
    //        {
    //            this.SAVINGTYPE = Convert.ToDecimal(row["SAVINGTYPE"]);
    //        }
    //        if (row["ACCOUNTCLASS"] != DBNull.Value && row["ACCOUNTCLASS"].ToString() != "")
    //        {
    //            this.ACCOUNTCLASS = Convert.ToDecimal(row["ACCOUNTCLASS"]);
    //        }
    //        if (row["ACCOUNTTYPEID"] != DBNull.Value && row["ACCOUNTTYPEID"].ToString() != "")
    //        {
    //            this.ACCOUNTTYPEID = Convert.ToDecimal(row["ACCOUNTTYPEID"]);
    //        }
    //        if (row["ACCOUNTGROUPID"] != DBNull.Value && row["ACCOUNTGROUPID"].ToString() != "")
    //        {
    //            this.ACCOUNTGROUPID = Convert.ToDecimal(row["ACCOUNTGROUPID"]);
    //        }
    //        if (row["ISBANKDIRECT"] != DBNull.Value && row["ISBANKDIRECT"].ToString() != "")
    //        {
    //            this.ISBANKDIRECT = Convert.ToDecimal(row["ISBANKDIRECT"]);
    //        }
    //        this.MUSTERFLAG = Convert.ToDecimal(row["MUSTERFLAG"]);
    //        this.MINIUPTRANSFERAMOUNT = Convert.ToDecimal(row["MINIUPTRANSFERAMOUNT"]);
    //        this.MINITRANSFERAMOUNT = Convert.ToDecimal(row["MINITRANSFERAMOUNT"]);
    //        this.RESERVEDBALANCE = Convert.ToDecimal(row["RESERVEDBALANCE"]);
    //        this.INTEGERRATE = Convert.ToDecimal(row["INTEGERRATE"]);
    //        if (row["DESCRIPT"] != DBNull.Value && row["DESCRIPT"].ToString() != "")
    //        {
    //            this.DESCRIPT = Convert.ToString(row["DESCRIPT"]);
    //        }
    //        this.ASSESSBALANCE = Convert.ToDecimal(row["ASSESSBALANCE"]);
    //        if (row["OTHERGLACCOUNT"] != DBNull.Value && row["OTHERGLACCOUNT"].ToString() != "")
    //        {
    //            this.OTHERGLACCOUNT = Convert.ToString(row["OTHERGLACCOUNT"]);
    //        }
    //        if (row["OTHERACCOUNTNUMBER"] != DBNull.Value && row["OTHERACCOUNTNUMBER"].ToString() != "")
    //        {
    //            this.OTHERACCOUNTNUMBER = Convert.ToString(row["OTHERACCOUNTNUMBER"]);
    //        }
    //        this.CURRENCYID = Convert.ToDecimal(row["CURRENCYID"]);
    //        this.ISNOTIONAL = Convert.ToDecimal(row["ISNOTIONAL"]);
    //        this.ISNONSTANDARD = Convert.ToDecimal(row["ISNONSTANDARD"]);
    //        if (row["LICENSENO"] != DBNull.Value && row["LICENSENO"].ToString() != "")
    //        {
    //            this.LICENSENO = Convert.ToString(row["LICENSENO"]);
    //        }
    //        if (row["WITHDRAWACCOUNTID"] != DBNull.Value && row["WITHDRAWACCOUNTID"].ToString() != "")
    //        {
    //            this.WITHDRAWACCOUNTID = Convert.ToDecimal(row["WITHDRAWACCOUNTID"]);
    //        }
    //        if (row["DESCRIPTION"] != DBNull.Value && row["DESCRIPTION"].ToString() != "")
    //        {
    //            this.DESCRIPTION = Convert.ToString(row["DESCRIPTION"]);
    //        }
    //        if (row["FIELD1"] != DBNull.Value && row["FIELD1"].ToString() != "")
    //        {
    //            this.FIELD1 = Convert.ToString(row["FIELD1"]);
    //        }
    //        if (row["FIELD2"] != DBNull.Value && row["FIELD2"].ToString() != "")
    //        {
    //            this.FIELD2 = Convert.ToString(row["FIELD2"]);
    //        }
    //        if (row["FIELD3"] != DBNull.Value && row["FIELD3"].ToString() != "")
    //        {
    //            this.FIELD3 = Convert.ToString(row["FIELD3"]);
    //        }
    //        this.ACCOUNTSTATE = Convert.ToDecimal(row["ACCOUNTSTATE"]);
    //        this.ISACTIVE = Convert.ToDecimal(row["ISACTIVE"]);
    //        if (row["APPLYID"] != DBNull.Value && row["APPLYID"].ToString() != "")
    //        {
    //            this.APPLYID = Convert.ToDecimal(row["APPLYID"]);
    //        }
    //        if (row["ORGANIZATIONCODE"] != DBNull.Value && row["ORGANIZATIONCODE"].ToString() != "")
    //        {
    //            this.ORGANIZATIONCODE = Convert.ToString(row["ORGANIZATIONCODE"]);
    //        }
    //        if (row["DATEOPENED"] != DBNull.Value && row["DATEOPENED"].ToString() != "")
    //        {
    //            this.DATEOPENED = Convert.ToDateTime(row["DATEOPENED"]);
    //        }
    //        this.DISPLAYORDER = Convert.ToDecimal(row["DISPLAYORDER"]);
    //        if (row["DATECLOSED"] != DBNull.Value && row["DATECLOSED"].ToString() != "")
    //        {
    //            this.DATECLOSED = Convert.ToDateTime(row["DATECLOSED"]);
    //        }
    //        this.CREATEDBY = Convert.ToDecimal(row["CREATEDBY"]);
    //        this.CREATEDON = Convert.ToDateTime(row["CREATEDON"]);
    //        this.LASTMODIFIEDBY = Convert.ToDecimal(row["LASTMODIFIEDBY"]);
    //        this.LASTMODIFIEDON = Convert.ToDateTime(row["LASTMODIFIEDON"]);
    //        this.ROWVERSION = Convert.ToDecimal(row["ROWVERSION"]);
    //    }
    //    public ACCOUNTS(DataRow row)
    //    {
    //        this.URID = Convert.ToDecimal(row["URID"]);
    //        this.ENTITYID = Convert.ToDecimal(row["ENTITYID"]);
    //        if (row["SEGID"] != DBNull.Value && row["SEGID"].ToString() != "")
    //        {
    //            this.SEGID = Convert.ToDecimal(row["SEGID"]);
    //        }
    //        this.BANKLOCATIONID = Convert.ToDecimal(row["BANKLOCATIONID"]);
    //        if (row["BRIEFNUMBER"] != DBNull.Value && row["BRIEFNUMBER"].ToString() != "")
    //        {
    //            this.BRIEFNUMBER = Convert.ToString(row["BRIEFNUMBER"]);
    //        }
    //        this.ACCOUNTNUMBER = Convert.ToString(row["ACCOUNTNUMBER"]);
    //        if (row["ACCOUNTNAME"] != DBNull.Value && row["ACCOUNTNAME"].ToString() != "")
    //        {
    //            this.ACCOUNTNAME = Convert.ToString(row["ACCOUNTNAME"]);
    //        }
    //        if (row["SAVINGTYPE"] != DBNull.Value && row["SAVINGTYPE"].ToString() != "")
    //        {
    //            this.SAVINGTYPE = Convert.ToDecimal(row["SAVINGTYPE"]);
    //        }
    //        if (row["ACCOUNTCLASS"] != DBNull.Value && row["ACCOUNTCLASS"].ToString() != "")
    //        {
    //            this.ACCOUNTCLASS = Convert.ToDecimal(row["ACCOUNTCLASS"]);
    //        }
    //        if (row["ACCOUNTTYPEID"] != DBNull.Value && row["ACCOUNTTYPEID"].ToString() != "")
    //        {
    //            this.ACCOUNTTYPEID = Convert.ToDecimal(row["ACCOUNTTYPEID"]);
    //        }
    //        if (row["ACCOUNTGROUPID"] != DBNull.Value && row["ACCOUNTGROUPID"].ToString() != "")
    //        {
    //            this.ACCOUNTGROUPID = Convert.ToDecimal(row["ACCOUNTGROUPID"]);
    //        }
    //        if (row["ISBANKDIRECT"] != DBNull.Value && row["ISBANKDIRECT"].ToString() != "")
    //        {
    //            this.ISBANKDIRECT = Convert.ToDecimal(row["ISBANKDIRECT"]);
    //        }
    //        this.MUSTERFLAG = Convert.ToDecimal(row["MUSTERFLAG"]);
    //        this.MINIUPTRANSFERAMOUNT = Convert.ToDecimal(row["MINIUPTRANSFERAMOUNT"]);
    //        this.MINITRANSFERAMOUNT = Convert.ToDecimal(row["MINITRANSFERAMOUNT"]);
    //        this.RESERVEDBALANCE = Convert.ToDecimal(row["RESERVEDBALANCE"]);
    //        this.INTEGERRATE = Convert.ToDecimal(row["INTEGERRATE"]);
    //        if (row["DESCRIPT"] != DBNull.Value && row["DESCRIPT"].ToString() != "")
    //        {
    //            this.DESCRIPT = Convert.ToString(row["DESCRIPT"]);
    //        }
    //        this.ASSESSBALANCE = Convert.ToDecimal(row["ASSESSBALANCE"]);
    //        if (row["OTHERGLACCOUNT"] != DBNull.Value && row["OTHERGLACCOUNT"].ToString() != "")
    //        {
    //            this.OTHERGLACCOUNT = Convert.ToString(row["OTHERGLACCOUNT"]);
    //        }
    //        if (row["OTHERACCOUNTNUMBER"] != DBNull.Value && row["OTHERACCOUNTNUMBER"].ToString() != "")
    //        {
    //            this.OTHERACCOUNTNUMBER = Convert.ToString(row["OTHERACCOUNTNUMBER"]);
    //        }
    //        this.CURRENCYID = Convert.ToDecimal(row["CURRENCYID"]);
    //        this.ISNOTIONAL = Convert.ToDecimal(row["ISNOTIONAL"]);
    //        this.ISNONSTANDARD = Convert.ToDecimal(row["ISNONSTANDARD"]);
    //        if (row["LICENSENO"] != DBNull.Value && row["LICENSENO"].ToString() != "")
    //        {
    //            this.LICENSENO = Convert.ToString(row["LICENSENO"]);
    //        }
    //        if (row["WITHDRAWACCOUNTID"] != DBNull.Value && row["WITHDRAWACCOUNTID"].ToString() != "")
    //        {
    //            this.WITHDRAWACCOUNTID = Convert.ToDecimal(row["WITHDRAWACCOUNTID"]);
    //        }
    //        if (row["DESCRIPTION"] != DBNull.Value && row["DESCRIPTION"].ToString() != "")
    //        {
    //            this.DESCRIPTION = Convert.ToString(row["DESCRIPTION"]);
    //        }
    //        if (row["FIELD1"] != DBNull.Value && row["FIELD1"].ToString() != "")
    //        {
    //            this.FIELD1 = Convert.ToString(row["FIELD1"]);
    //        }
    //        if (row["FIELD2"] != DBNull.Value && row["FIELD2"].ToString() != "")
    //        {
    //            this.FIELD2 = Convert.ToString(row["FIELD2"]);
    //        }
    //        if (row["FIELD3"] != DBNull.Value && row["FIELD3"].ToString() != "")
    //        {
    //            this.FIELD3 = Convert.ToString(row["FIELD3"]);
    //        }
    //        this.ACCOUNTSTATE = Convert.ToDecimal(row["ACCOUNTSTATE"]);
    //        this.ISACTIVE = Convert.ToDecimal(row["ISACTIVE"]);
    //        if (row["APPLYID"] != DBNull.Value && row["APPLYID"].ToString() != "")
    //        {
    //            this.APPLYID = Convert.ToDecimal(row["APPLYID"]);
    //        }
    //        if (row["ORGANIZATIONCODE"] != DBNull.Value && row["ORGANIZATIONCODE"].ToString() != "")
    //        {
    //            this.ORGANIZATIONCODE = Convert.ToString(row["ORGANIZATIONCODE"]);
    //        }
    //        if (row["DATEOPENED"] != DBNull.Value && row["DATEOPENED"].ToString() != "")
    //        {
    //            this.DATEOPENED = Convert.ToDateTime(row["DATEOPENED"]);
    //        }
    //        this.DISPLAYORDER = Convert.ToDecimal(row["DISPLAYORDER"]);
    //        if (row["DATECLOSED"] != DBNull.Value && row["DATECLOSED"].ToString() != "")
    //        {
    //            this.DATECLOSED = Convert.ToDateTime(row["DATECLOSED"]);
    //        }
    //        this.CREATEDBY = Convert.ToDecimal(row["CREATEDBY"]);
    //        this.CREATEDON = Convert.ToDateTime(row["CREATEDON"]);
    //        this.LASTMODIFIEDBY = Convert.ToDecimal(row["LASTMODIFIEDBY"]);
    //        this.LASTMODIFIEDON = Convert.ToDateTime(row["LASTMODIFIEDON"]);
    //        this.ROWVERSION = Convert.ToDecimal(row["ROWVERSION"]);
    //    }
    //    #endregion
    //    #region ManualCode
    //    //手工添加的内容请于此处添加
    //    #endregion
    //}
}
