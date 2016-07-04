using System;
using System.Collections.Generic;
using System.Data;

namespace FIAT.DDL.Entities
{
    public class SY_BANKS
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

        private string _code;
        public string CODE
        {
            get { return _code; }
            set
            {
                if (value.Length > 20)
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
                if (value.Length > 64)
                {
                    throw new Exception("字段NAME长度超过限制");
                }
                _name = value;
            }
        }

        private string _directbankcode;
        public string DIRECTBANKCODE
        {
            get { return _directbankcode; }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("字段DIRECTBANKCODE长度超过限制");
                }
                _directbankcode = value;
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

        private DateTime _uptodate;
        public DateTime UPTODATE
        {
            get { return _uptodate; }
            set { _uptodate = value; }
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

        private DateTime _createdon;
        public DateTime CREATEDON
        {
            get { return _createdon; }
            set { _createdon = value; }
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

        private DateTime _lastmodifiedon;
        public DateTime LASTMODIFIEDON
        {
            get { return _lastmodifiedon; }
            set { _lastmodifiedon = value; }
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
        public SY_BANKS(int urid = 0, int isactive = 1, int displayorder = 0, int createdby = 0, int lastmodifiedby = 0, int rowversion = 1)
        {
            this.URID = urid;
            this.ISACTIVE = isactive;
            this.DISPLAYORDER = displayorder;
            this.CREATEDBY = createdby;
            this.LASTMODIFIEDBY = lastmodifiedby;
            this.ROWVERSION = rowversion;
        }
        public SY_BANKS(string code, string name, int urid = 0, int isactive = 1, int displayorder = 0, int createdby = 0, int lastmodifiedby = 0, int rowversion = 1)
            : this(urid, isactive, displayorder, createdby, lastmodifiedby, rowversion)
        {
            this.CODE = code;
            this.NAME = name;
        }
        public SY_BANKS(DataRow row)
        {
            this.URID = Convert.ToInt32(row["URID"]);
            this.CODE = Convert.ToString(row["CODE"]);
            this.NAME = Convert.ToString(row["NAME"]);
            if (row["DIRECTBANKCODE"] != DBNull.Value && row["DIRECTBANKCODE"].ToString() != "")
            {
                this.DIRECTBANKCODE = Convert.ToString(row["DIRECTBANKCODE"]);
            }
            if (row["DESCRIPTION"] != DBNull.Value && row["DESCRIPTION"].ToString() != "")
            {
                this.DESCRIPTION = Convert.ToString(row["DESCRIPTION"]);
            }
            if (row["UPTODATE"] != DBNull.Value && row["UPTODATE"].ToString() != "")
            {
                this.UPTODATE = Convert.ToDateTime(row["UPTODATE"]);
            }
            this.ISACTIVE = Convert.ToInt32(row["ISACTIVE"]);
            this.DISPLAYORDER = Convert.ToInt32(row["DISPLAYORDER"]);
            this.CREATEDON = Convert.ToDateTime(row["CREATEDON"]);
            this.CREATEDBY = Convert.ToInt32(row["CREATEDBY"]);
            this.LASTMODIFIEDON = Convert.ToDateTime(row["LASTMODIFIEDON"]);
            this.LASTMODIFIEDBY = Convert.ToInt32(row["LASTMODIFIEDBY"]);
            this.ROWVERSION = Convert.ToInt32(row["ROWVERSION"]);
        }
        #endregion

        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
