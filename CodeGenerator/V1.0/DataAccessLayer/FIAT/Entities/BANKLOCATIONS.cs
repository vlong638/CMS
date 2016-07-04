using System;
using System.Collections.Generic;
using System.Data;

namespace FIAT.DDL.Entities
{
    public class BANKLOCATIONS
    {
        #region Properties
        private int _urid;
        public int URID
        {
            get { return _urid; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段URID长度超过限制");
                }
                _urid = value;
            }
        }

        private int _entityid;
        public int ENTITYID
        {
            get { return _entityid; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段ENTITYID长度超过限制");
                }
                _entityid = value;
            }
        }

        private int _bankid;
        public int BANKID
        {
            get { return _bankid; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段BANKID长度超过限制");
                }
                _bankid = value;
            }
        }

        private int _sybanklocationid;
        public int SYBANKLOCATIONID
        {
            get { return _sybanklocationid; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段SYBANKLOCATIONID长度超过限制");
                }
                _sybanklocationid = value;
            }
        }

        private int _areaid;
        public int AREAID
        {
            get { return _areaid; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段AREAID长度超过限制");
                }
                _areaid = value;
            }
        }

        private string _areacode;
        public string AREACODE
        {
            get { return _areacode; }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("字段AREACODE长度超过限制");
                }
                _areacode = value;
            }
        }

        private string _areaname;
        public string AREANAME
        {
            get { return _areaname; }
            set
            {
                if (value.Length > 64)
                {
                    throw new Exception("字段AREANAME长度超过限制");
                }
                _areaname = value;
            }
        }

        private string _briefname;
        public string BRIEFNAME
        {
            get { return _briefname; }
            set
            {
                if (value.Length > 64)
                {
                    throw new Exception("字段BRIEFNAME长度超过限制");
                }
                _briefname = value;
            }
        }

        private string _code;
        public string CODE
        {
            get { return _code; }
            set
            {
                if (value.Length > 32)
                {
                    throw new Exception("字段CODE长度超过限制");
                }
                _code = value;
            }
        }

        private string _name;
        public string NAME
        {
            get { return _name; }
            set
            {
                if (value.Length > 128)
                {
                    throw new Exception("字段NAME长度超过限制");
                }
                _name = value;
            }
        }

        private string _bankoutletcode;
        public string BANKOUTLETCODE
        {
            get { return _bankoutletcode; }
            set
            {
                if (value.Length > 16)
                {
                    throw new Exception("字段BANKOUTLETCODE长度超过限制");
                }
                _bankoutletcode = value;
            }
        }

        private int _countryid;
        public int COUNTRYID
        {
            get { return _countryid; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段COUNTRYID长度超过限制");
                }
                _countryid = value;
            }
        }

        private string _province;
        public string PROVINCE
        {
            get { return _province; }
            set
            {
                if (value.Length > 64)
                {
                    throw new Exception("字段PROVINCE长度超过限制");
                }
                _province = value;
            }
        }

        private string _city;
        public string CITY
        {
            get { return _city; }
            set
            {
                if (value.Length > 64)
                {
                    throw new Exception("字段CITY长度超过限制");
                }
                _city = value;
            }
        }

        private string _address1;
        public string ADDRESS1
        {
            get { return _address1; }
            set
            {
                if (value.Length > 100)
                {
                    throw new Exception("字段ADDRESS1长度超过限制");
                }
                _address1 = value;
            }
        }

        private string _address2;
        public string ADDRESS2
        {
            get { return _address2; }
            set
            {
                if (value.Length > 100)
                {
                    throw new Exception("字段ADDRESS2长度超过限制");
                }
                _address2 = value;
            }
        }

        private string _address3;
        public string ADDRESS3
        {
            get { return _address3; }
            set
            {
                if (value.Length > 100)
                {
                    throw new Exception("字段ADDRESS3长度超过限制");
                }
                _address3 = value;
            }
        }

        private string _telephone;
        public string TELEPHONE
        {
            get { return _telephone; }
            set
            {
                if (value.Length > 64)
                {
                    throw new Exception("字段TELEPHONE长度超过限制");
                }
                _telephone = value;
            }
        }

        private string _contacter;
        public string CONTACTER
        {
            get { return _contacter; }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("字段CONTACTER长度超过限制");
                }
                _contacter = value;
            }
        }

        private string _postalcode;
        public string POSTALCODE
        {
            get { return _postalcode; }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("字段POSTALCODE长度超过限制");
                }
                _postalcode = value;
            }
        }

        private string _branch;
        public string BRANCH
        {
            get { return _branch; }
            set
            {
                if (value.Length > 64)
                {
                    throw new Exception("字段BRANCH长度超过限制");
                }
                _branch = value;
            }
        }

        private int _calendarid;
        public int CALENDARID
        {
            get { return _calendarid; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段CALENDARID长度超过限制");
                }
                _calendarid = value;
            }
        }

        private int _segid;
        public int SEGID
        {
            get { return _segid; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段SEGID长度超过限制");
                }
                _segid = value;
            }
        }

        private string _description;
        public string DESCRIPTION
        {
            get { return _description; }
            set
            {
                if (value.Length > 512)
                {
                    throw new Exception("字段DESCRIPTION长度超过限制");
                }
                _description = value;
            }
        }

        private int _isactive;
        public int ISACTIVE
        {
            get { return _isactive; }
            set
            {
                if (value.ToString().Length > 2)
                {
                    throw new Exception("字段ISACTIVE长度超过限制");
                }
                _isactive = value;
            }
        }

        private int _displayorder;
        public int DISPLAYORDER
        {
            get { return _displayorder; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段DISPLAYORDER长度超过限制");
                }
                _displayorder = value;
            }
        }

        private int _createdby;
        public int CREATEDBY
        {
            get { return _createdby; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段CREATEDBY长度超过限制");
                }
                _createdby = value;
            }
        }

        private DateTime _createdon;
        public DateTime CREATEDON
        {
            get { return _createdon; }
            set { _createdon = value; }
        }

        private int _lastmodifiedby;
        public int LASTMODIFIEDBY
        {
            get { return _lastmodifiedby; }
            set
            {
                if (value.ToString().Length > 10)
                {
                    throw new Exception("字段LASTMODIFIEDBY长度超过限制");
                }
                _lastmodifiedby = value;
            }
        }

        private DateTime _lastmodifiedon;
        public DateTime LASTMODIFIEDON
        {
            get { return _lastmodifiedon; }
            set { _lastmodifiedon = value; }
        }

        private int _rowversion;
        public int ROWVERSION
        {
            get { return _rowversion; }
            set
            {
                if (value.ToString().Length > 19)
                {
                    throw new Exception("字段ROWVERSION长度超过限制");
                }
                _rowversion = value;
            }
        }
        #endregion

        #region Constructors
        public BANKLOCATIONS(int urid = 0, int isactive = 1, int displayorder = 0, int createdby = 0, int lastmodifiedby = 0, int rowversion = 1)
        {
            this.URID = urid;
            this.ISACTIVE = isactive;
            this.DISPLAYORDER = displayorder;
            this.CREATEDBY = createdby;
            this.LASTMODIFIEDBY = lastmodifiedby;
            this.ROWVERSION = rowversion;
        }
        public BANKLOCATIONS(int entityid, int bankid, string code, string name, int calendarid, int urid = 0, int isactive = 1, int displayorder = 0, int createdby = 0, int lastmodifiedby = 0, int rowversion = 1)
            : this(urid, isactive, displayorder, createdby, lastmodifiedby, rowversion)
        {
            this.ENTITYID = entityid;
            this.BANKID = bankid;
            this.CODE = code;
            this.NAME = name;
            this.CALENDARID = calendarid;
        }
        public BANKLOCATIONS(DataRow row)
        {
            this.URID = Convert.ToInt32(row["URID"]);
            this.ENTITYID = Convert.ToInt32(row["ENTITYID"]);
            this.BANKID = Convert.ToInt32(row["BANKID"]);
            if (row["SYBANKLOCATIONID"] != DBNull.Value && row["SYBANKLOCATIONID"].ToString() != "")
            {
                this.SYBANKLOCATIONID = Convert.ToInt32(row["SYBANKLOCATIONID"]);
            }
            if (row["AREAID"] != DBNull.Value && row["AREAID"].ToString() != "")
            {
                this.AREAID = Convert.ToInt32(row["AREAID"]);
            }
            if (row["AREACODE"] != DBNull.Value && row["AREACODE"].ToString() != "")
            {
                this.AREACODE = Convert.ToString(row["AREACODE"]);
            }
            if (row["AREANAME"] != DBNull.Value && row["AREANAME"].ToString() != "")
            {
                this.AREANAME = Convert.ToString(row["AREANAME"]);
            }
            if (row["BRIEFNAME"] != DBNull.Value && row["BRIEFNAME"].ToString() != "")
            {
                this.BRIEFNAME = Convert.ToString(row["BRIEFNAME"]);
            }
            this.CODE = Convert.ToString(row["CODE"]);
            this.NAME = Convert.ToString(row["NAME"]);
            if (row["BANKOUTLETCODE"] != DBNull.Value && row["BANKOUTLETCODE"].ToString() != "")
            {
                this.BANKOUTLETCODE = Convert.ToString(row["BANKOUTLETCODE"]);
            }
            if (row["COUNTRYID"] != DBNull.Value && row["COUNTRYID"].ToString() != "")
            {
                this.COUNTRYID = Convert.ToInt32(row["COUNTRYID"]);
            }
            if (row["PROVINCE"] != DBNull.Value && row["PROVINCE"].ToString() != "")
            {
                this.PROVINCE = Convert.ToString(row["PROVINCE"]);
            }
            if (row["CITY"] != DBNull.Value && row["CITY"].ToString() != "")
            {
                this.CITY = Convert.ToString(row["CITY"]);
            }
            if (row["ADDRESS1"] != DBNull.Value && row["ADDRESS1"].ToString() != "")
            {
                this.ADDRESS1 = Convert.ToString(row["ADDRESS1"]);
            }
            if (row["ADDRESS2"] != DBNull.Value && row["ADDRESS2"].ToString() != "")
            {
                this.ADDRESS2 = Convert.ToString(row["ADDRESS2"]);
            }
            if (row["ADDRESS3"] != DBNull.Value && row["ADDRESS3"].ToString() != "")
            {
                this.ADDRESS3 = Convert.ToString(row["ADDRESS3"]);
            }
            if (row["TELEPHONE"] != DBNull.Value && row["TELEPHONE"].ToString() != "")
            {
                this.TELEPHONE = Convert.ToString(row["TELEPHONE"]);
            }
            if (row["CONTACTER"] != DBNull.Value && row["CONTACTER"].ToString() != "")
            {
                this.CONTACTER = Convert.ToString(row["CONTACTER"]);
            }
            if (row["POSTALCODE"] != DBNull.Value && row["POSTALCODE"].ToString() != "")
            {
                this.POSTALCODE = Convert.ToString(row["POSTALCODE"]);
            }
            if (row["BRANCH"] != DBNull.Value && row["BRANCH"].ToString() != "")
            {
                this.BRANCH = Convert.ToString(row["BRANCH"]);
            }
            this.CALENDARID = Convert.ToInt32(row["CALENDARID"]);
            if (row["SEGID"] != DBNull.Value && row["SEGID"].ToString() != "")
            {
                this.SEGID = Convert.ToInt32(row["SEGID"]);
            }
            if (row["DESCRIPTION"] != DBNull.Value && row["DESCRIPTION"].ToString() != "")
            {
                this.DESCRIPTION = Convert.ToString(row["DESCRIPTION"]);
            }
            this.ISACTIVE = Convert.ToInt32(row["ISACTIVE"]);
            this.DISPLAYORDER = Convert.ToInt32(row["DISPLAYORDER"]);
            this.CREATEDBY = Convert.ToInt32(row["CREATEDBY"]);
            this.CREATEDON = Convert.ToDateTime(row["CREATEDON"]);
            this.LASTMODIFIEDBY = Convert.ToInt32(row["LASTMODIFIEDBY"]);
            this.LASTMODIFIEDON = Convert.ToDateTime(row["LASTMODIFIEDON"]);
            this.ROWVERSION = Convert.ToInt32(row["ROWVERSION"]);
        }
        #endregion

        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
