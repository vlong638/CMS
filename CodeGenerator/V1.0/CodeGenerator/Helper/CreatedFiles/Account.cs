using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using System;
using System.Data;
using System.Data.Common;

namespace GrowthSystem.DDL.Entities
{
    public class Account
    {
        #region Properties
        #region StaticProperties
        public static DBFieldItem IDProperty = new DBFieldItem("ID",false, FieldItemType.INT, 0, 0,true);
        public static DBFieldItem RESOURCETYPEProperty = new DBFieldItem("RESOURCETYPE",false, FieldItemType.INT, 0, 0,true);
        public static DBFieldItem RESOURCEIDProperty = new DBFieldItem("RESOURCEID",false, FieldItemType.NVARCHAR, 0, 0,true);
        public static DBFieldItem LEVELProperty = new DBFieldItem("LEVEL",false, FieldItemType.INT, 0, 0,true);
        #endregion
        #region StandardProperties
        private int _id;
        public int ID { get { return _id; } set { _id = value; } }
        private int _resourcetype;
        public int RESOURCETYPE { get { return _resourcetype; } set { _resourcetype = value; } }
        private string _resourceid;
        public string RESOURCEID { get { return _resourceid; } set { _resourceid = value; } }
        private int _level;
        public int LEVEL { get { return _level; } set { _level = value; } }
        #endregion
        #endregion
        #region Constructors
        public Account()
        {

        }
        public Account(DataRow row)
        {
            if (row["ID"] != DBNull.Value && row["ID"].ToString() != "")
            {
                this.ID = Convert.ToInt32(row["ID"]);
            }
            if (row["RESOURCETYPE"] != DBNull.Value && row["RESOURCETYPE"].ToString() != "")
            {
                this.RESOURCETYPE = Convert.ToInt32(row["RESOURCETYPE"]);
            }
            if (row["RESOURCEID"] != DBNull.Value && row["RESOURCEID"].ToString() != "")
            {
                this.RESOURCEID = Convert.ToString(row["RESOURCEID"]);
            }
            if (row["LEVEL"] != DBNull.Value && row["LEVEL"].ToString() != "")
            {
                this.LEVEL = Convert.ToInt32(row["LEVEL"]);
            }

        }
        public Account(DbDataReader row)
        {
            if (row["ID"] != DBNull.Value && row["ID"].ToString() != "")
            {
                this.ID = Convert.ToInt32(row["ID"]);
            }
            if (row["RESOURCETYPE"] != DBNull.Value && row["RESOURCETYPE"].ToString() != "")
            {
                this.RESOURCETYPE = Convert.ToInt32(row["RESOURCETYPE"]);
            }
            if (row["RESOURCEID"] != DBNull.Value && row["RESOURCEID"].ToString() != "")
            {
                this.RESOURCEID = Convert.ToString(row["RESOURCEID"]);
            }
            if (row["LEVEL"] != DBNull.Value && row["LEVEL"].ToString() != "")
            {
                this.LEVEL = Convert.ToInt32(row["LEVEL"]);
            }

        }
        #endregion
        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
