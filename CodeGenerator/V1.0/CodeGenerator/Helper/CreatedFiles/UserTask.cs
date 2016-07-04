using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using System;
using System.Data;
using System.Data.Common;

namespace GrowthSystem.DDL.Entities
{
    public class UserTask
    {
        #region Properties
        #region StaticProperties
        public static DBFieldItem IDProperty = new DBFieldItem("ID",false, FieldItemType.NVARCHAR, 50, 0,true);
        public static DBFieldItem NAMEProperty = new DBFieldItem("NAME",false, FieldItemType.NVARCHAR, 50, 0,true);
        public static DBFieldItem METRICFIELDProperty = new DBFieldItem("METRICFIELD",false, FieldItemType.INT, 0, 0,true);
        public static DBFieldItem TARGETVALUEProperty = new DBFieldItem("TARGETVALUE",false, FieldItemType.INT, 0, 0,true);
        public static DBFieldItem TYPEProperty = new DBFieldItem("TYPE",false, FieldItemType.INT, 0, 0,true);
        public static DBFieldItem ACCOUNTIDProperty = new DBFieldItem("ACCOUNTID",false, FieldItemType.NVARCHAR, 50, 0,true);
        public static DBFieldItem CURRENTVALUEProperty = new DBFieldItem("CURRENTVALUE",false, FieldItemType.INT, 0, 0,true);
        public static DBFieldItem PROCESSSTATUSProperty = new DBFieldItem("PROCESSSTATUS",false, FieldItemType.INT, 0, 0,true);
        #endregion
        #region StandardProperties
        private string _id;
        public string ID { get { return _id; } set { _id = value; } }
        private string _name;
        public string NAME { get { return _name; } set { _name = value; } }
        private int _metricfield;
        public int METRICFIELD { get { return _metricfield; } set { _metricfield = value; } }
        private int _targetvalue;
        public int TARGETVALUE { get { return _targetvalue; } set { _targetvalue = value; } }
        private int _type;
        public int TYPE { get { return _type; } set { _type = value; } }
        private string _accountid;
        public string ACCOUNTID { get { return _accountid; } set { _accountid = value; } }
        private int _currentvalue;
        public int CURRENTVALUE { get { return _currentvalue; } set { _currentvalue = value; } }
        private int _processstatus;
        public int PROCESSSTATUS { get { return _processstatus; } set { _processstatus = value; } }
        #endregion
        #endregion
        #region Constructors
        public UserTask()
        {

        }
        public UserTask(DataRow row)
        {
            if (row["ID"] != DBNull.Value && row["ID"].ToString() != "")
            {
                this.ID = Convert.ToString(row["ID"]);
            }
            if (row["NAME"] != DBNull.Value && row["NAME"].ToString() != "")
            {
                this.NAME = Convert.ToString(row["NAME"]);
            }
            if (row["METRICFIELD"] != DBNull.Value && row["METRICFIELD"].ToString() != "")
            {
                this.METRICFIELD = Convert.ToInt32(row["METRICFIELD"]);
            }
            if (row["TARGETVALUE"] != DBNull.Value && row["TARGETVALUE"].ToString() != "")
            {
                this.TARGETVALUE = Convert.ToInt32(row["TARGETVALUE"]);
            }
            if (row["TYPE"] != DBNull.Value && row["TYPE"].ToString() != "")
            {
                this.TYPE = Convert.ToInt32(row["TYPE"]);
            }
            if (row["ACCOUNTID"] != DBNull.Value && row["ACCOUNTID"].ToString() != "")
            {
                this.ACCOUNTID = Convert.ToString(row["ACCOUNTID"]);
            }
            if (row["CURRENTVALUE"] != DBNull.Value && row["CURRENTVALUE"].ToString() != "")
            {
                this.CURRENTVALUE = Convert.ToInt32(row["CURRENTVALUE"]);
            }
            if (row["PROCESSSTATUS"] != DBNull.Value && row["PROCESSSTATUS"].ToString() != "")
            {
                this.PROCESSSTATUS = Convert.ToInt32(row["PROCESSSTATUS"]);
            }

        }
        public UserTask(DbDataReader row)
        {
            if (row["ID"] != DBNull.Value && row["ID"].ToString() != "")
            {
                this.ID = Convert.ToString(row["ID"]);
            }
            if (row["NAME"] != DBNull.Value && row["NAME"].ToString() != "")
            {
                this.NAME = Convert.ToString(row["NAME"]);
            }
            if (row["METRICFIELD"] != DBNull.Value && row["METRICFIELD"].ToString() != "")
            {
                this.METRICFIELD = Convert.ToInt32(row["METRICFIELD"]);
            }
            if (row["TARGETVALUE"] != DBNull.Value && row["TARGETVALUE"].ToString() != "")
            {
                this.TARGETVALUE = Convert.ToInt32(row["TARGETVALUE"]);
            }
            if (row["TYPE"] != DBNull.Value && row["TYPE"].ToString() != "")
            {
                this.TYPE = Convert.ToInt32(row["TYPE"]);
            }
            if (row["ACCOUNTID"] != DBNull.Value && row["ACCOUNTID"].ToString() != "")
            {
                this.ACCOUNTID = Convert.ToString(row["ACCOUNTID"]);
            }
            if (row["CURRENTVALUE"] != DBNull.Value && row["CURRENTVALUE"].ToString() != "")
            {
                this.CURRENTVALUE = Convert.ToInt32(row["CURRENTVALUE"]);
            }
            if (row["PROCESSSTATUS"] != DBNull.Value && row["PROCESSSTATUS"].ToString() != "")
            {
                this.PROCESSSTATUS = Convert.ToInt32(row["PROCESSSTATUS"]);
            }

        }
        #endregion
        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
