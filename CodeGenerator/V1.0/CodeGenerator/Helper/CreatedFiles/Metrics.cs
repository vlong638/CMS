using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using System;
using System.Data;
using System.Data.Common;

namespace GrowthSystem.DDL.Entities
{
    public class Metrics
    {
        #region Properties
        #region StaticProperties
        public static DBFieldItem USERIDProperty = new DBFieldItem("USERID",false, FieldItemType.NVARCHAR, 50, 0,true);
        public static DBFieldItem CONSUPTIONProperty = new DBFieldItem("CONSUPTION",false, FieldItemType.NUMERIC, 0, 0,true);
        public static DBFieldItem TOTALORDERProperty = new DBFieldItem("TOTALORDER",false, FieldItemType.NUMERIC, 0, 0,true);
        public static DBFieldItem CREATETIMEProperty = new DBFieldItem("CREATETIME",false, FieldItemType.DATETIME, 0, 0,true);
        #endregion
        #region StandardProperties
        private string _userid;
        public string USERID { get { return _userid; } set { _userid = value; } }
        private decimal _consuption;
        public decimal CONSUPTION { get { return _consuption; } set { _consuption = value; } }
        private decimal _totalorder;
        public decimal TOTALORDER { get { return _totalorder; } set { _totalorder = value; } }
        private DateTime _createtime;
        public DateTime CREATETIME { get { return _createtime; } set { _createtime = value; } }
        #endregion
        #endregion
        #region Constructors
        public Metrics()
        {

        }
        public Metrics(DataRow row)
        {
            if (row["USERID"] != DBNull.Value && row["USERID"].ToString() != "")
            {
                this.USERID = Convert.ToString(row["USERID"]);
            }
            if (row["CONSUPTION"] != DBNull.Value && row["CONSUPTION"].ToString() != "")
            {
                this.CONSUPTION = Convert.ToDecimal(row["CONSUPTION"]);
            }
            if (row["TOTALORDER"] != DBNull.Value && row["TOTALORDER"].ToString() != "")
            {
                this.TOTALORDER = Convert.ToDecimal(row["TOTALORDER"]);
            }
            if (row["CREATETIME"] != DBNull.Value && row["CREATETIME"].ToString() != "")
            {
                this.CREATETIME = Convert.ToDateTime(row["CREATETIME"]);
            }

        }
        public Metrics(DbDataReader row)
        {
            if (row["USERID"] != DBNull.Value && row["USERID"].ToString() != "")
            {
                this.USERID = Convert.ToString(row["USERID"]);
            }
            if (row["CONSUPTION"] != DBNull.Value && row["CONSUPTION"].ToString() != "")
            {
                this.CONSUPTION = Convert.ToDecimal(row["CONSUPTION"]);
            }
            if (row["TOTALORDER"] != DBNull.Value && row["TOTALORDER"].ToString() != "")
            {
                this.TOTALORDER = Convert.ToDecimal(row["TOTALORDER"]);
            }
            if (row["CREATETIME"] != DBNull.Value && row["CREATETIME"].ToString() != "")
            {
                this.CREATETIME = Convert.ToDateTime(row["CREATETIME"]);
            }

        }
        #endregion
        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
