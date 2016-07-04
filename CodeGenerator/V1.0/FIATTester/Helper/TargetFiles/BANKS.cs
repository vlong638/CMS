            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;

namespace DDLEntities
{
    public class BANKS
        private int _urid;
        public int URID
        {
            get { return _urid; }
            set { _urid = value; }
        }
        private string _code;
        public string CODE
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _name;
        public string NAME
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _sybankid;
        public int SYBANKID
        {
            get { return _sybankid; }
            set { _sybankid = value; }
        }
        private string _directbankcode;
        public string DIRECTBANKCODE
        {
            get { return _directbankcode; }
            set { _directbankcode = value; }
        }
        private int _directflag;
        public int DIRECTFLAG
        {
            get { return _directflag; }
            set { _directflag = value; }
        }
        private string _description;
        public string DESCRIPTION
        {
            get { return _description; }
            set { _description = value; }
        }
        private int _isactive;
        public int ISACTIVE
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
        private int _displayorder;
        public int DISPLAYORDER
        {
            get { return _displayorder; }
            set { _displayorder = value; }
        }
        private DateTime _createdon;
        public DateTime CREATEDON
        {
            get { return _createdon; }
            set
            {
                if (value.ToString().Length > 0)
                {
                    throw new Exception("字段CREATEDON长度超过限制");
                }
                _createdon = value;
            }
        }
        private int _createdby;
        public int CREATEDBY
        {
            get { return _createdby; }
            set { _createdby = value; }
        }
        private DateTime _lastmodifiedon;
        public DateTime LASTMODIFIEDON
        {
            get { return _lastmodifiedon; }
            set
            {
                if (value.ToString().Length > 0)
                {
                    throw new Exception("字段LASTMODIFIEDON长度超过限制");
                }
                _lastmodifiedon = value;
            }
        }
        private int _lastmodifiedby;
        public int LASTMODIFIEDBY
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
        }
        private int _rowversion;
        public int ROWVERSION
        {
            get { return _rowversion; }
            set { _rowversion = value; }
        }
    }
}
