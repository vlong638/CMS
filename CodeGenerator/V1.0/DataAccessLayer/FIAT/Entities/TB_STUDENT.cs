using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using System;
using System.Data;
using System.Data.Common;

namespace FIAT.DDL.Entities
{
    public class TB_STUDENT
    {
        #region Properties
        #region StaticProperties
        public static DBFieldItem URIDProperty = new DBFieldItem("URID",false, FieldItemType.NUMBER, 0, 0,false);
        public static DBFieldItem NAMEProperty = new DBFieldItem("NAME",false, FieldItemType.NVARCHAR2, 20, 0,true);
        public static DBFieldItem AGEProperty = new DBFieldItem("AGE",false, FieldItemType.NUMBER, 0, 0,true);
        public static DBFieldItem REMARK1Property = new DBFieldItem("REMARK1",false, FieldItemType.NVARCHAR2, 100, 0,true);
        public static DBFieldItem REMARK2Property = new DBFieldItem("REMARK2",false, FieldItemType.NVARCHAR2, 100, 0,true);
        #endregion
        #region StandardProperties
        private decimal _urid;
        public decimal URID { get { return _urid; } set { _urid = value; } }
        private string _name;
        public string NAME { get { return _name; } set { _name = value; } }
        private decimal _age;
        public decimal AGE { get { return _age; } set { _age = value; } }
        private string _remark1;
        public string REMARK1 { get { return _remark1; } set { _remark1 = value; } }
        private string _remark2;
        public string REMARK2 { get { return _remark2; } set { _remark2 = value; } }
        #endregion
        #endregion
        #region Constructors
        public TB_STUDENT()
        {

        }
        public TB_STUDENT(decimal urid)
        {
            this.URID = urid;

        }
        public TB_STUDENT(DataRow row)
        {
            this.URID = Convert.ToDecimal(row["URID"]);
            if (row["NAME"] != DBNull.Value && row["NAME"].ToString() != "")
            {
                this.NAME = Convert.ToString(row["NAME"]);
            }
            if (row["AGE"] != DBNull.Value && row["AGE"].ToString() != "")
            {
                this.AGE = Convert.ToDecimal(row["AGE"]);
            }
            if (row["REMARK1"] != DBNull.Value && row["REMARK1"].ToString() != "")
            {
                this.REMARK1 = Convert.ToString(row["REMARK1"]);
            }
            if (row["REMARK2"] != DBNull.Value && row["REMARK2"].ToString() != "")
            {
                this.REMARK2 = Convert.ToString(row["REMARK2"]);
            }

        }
        public TB_STUDENT(DbDataReader row)
        {
            this.URID = Convert.ToDecimal(row["URID"]);
            if (row["NAME"] != DBNull.Value && row["NAME"].ToString() != "")
            {
                this.NAME = Convert.ToString(row["NAME"]);
            }
            if (row["AGE"] != DBNull.Value && row["AGE"].ToString() != "")
            {
                this.AGE = Convert.ToDecimal(row["AGE"]);
            }
            if (row["REMARK1"] != DBNull.Value && row["REMARK1"].ToString() != "")
            {
                this.REMARK1 = Convert.ToString(row["REMARK1"]);
            }
            if (row["REMARK2"] != DBNull.Value && row["REMARK2"].ToString() != "")
            {
                this.REMARK2 = Convert.ToString(row["REMARK2"]);
            }

        }
        #endregion
        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
