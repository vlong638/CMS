using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data;
using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using VLCommon.AnyDB.Utilities;

namespace MyDataAccess.ADO_NET
{
    /// <summary>
    /// 会话接口
    /// </summary>
    public interface IMySession
    {
        #region NestedTypes
        DbConnection Connection{get;}
        DbTransaction Transaction { get; }
        DbDataAdapter Adapter { get; }
        DataProvider DataProvider { set; get; }
        DbParameterGenerator DBParameterGenerator { set; get; }
        #endregion

        #region 连接
        void Open();
        void Close(); 
        #endregion

        #region 事务
        void BeginTransaction();
        void BeginTransaction(IsolationLevel level);
        void CommitTransaction();
        void RollBackTransaction();
        #endregion

        #region 数据库操作
        int ExecuteNonQuery(string sql);
        int ExecuteNonQuery(DbCommand command);

        object ExecuteScalar(string sql);
        object ExecuteScalar(DbCommand command);

        DbDataReader ExecuteDataReader(string sql);
        DbDataReader ExecuteDataReader(DbCommand command);

        DataSet ExecuteDataSet(string sql);
        DataSet ExecuteDataSet(DbCommand command);

        DataTable ExecuteDataTable(string sql);
        DataTable ExecuteDataTable(DbCommand command);
        #endregion
    }
}
