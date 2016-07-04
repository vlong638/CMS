using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
//using Oracle.DataAccess.Client;
using System.Data.SqlClient;
//using VLCommon.Oracle.Utilities;
using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using VLCommon.AnyDB.Utilities;

namespace MyDataAccess.ADO_NET
{
    /// <summary>
    /// 会话对象
    /// </summary>
    public class MySession : IMySession
    {
        #region NestedTypes
        /// <summary>
        /// 数据提供器
        /// </summary>
        public DataProvider DataProvider { set; get; }
        #endregion

        #region Constructors
        protected MySession()
        {
            string connectString = new System.Configuration.AppSettingsReader().GetValue("DefaultConnectString", typeof(string)).ToString();
            this.Connection = GetConnection(DataProvider.SQLServer, connectString);
        }
        //未能加载文件或程序集“Oracle.DataAccess, Version=2.111.7.20, Culture=neutral, PublicKeyToken=89b483f429c47342”或它的某一个依赖项。系统找不到指定的文件。
        //把程序目标平台设置为x86
        public MySession(DataProvider dataProvider, string connectString = null)
        {
            if (connectString == null)
                connectString = new System.Configuration.AppSettingsReader().GetValue("DefaultConnectString", typeof(string)).ToString();
            this.DataProvider = dataProvider;
            this.Connection = GetConnection(dataProvider, connectString);
        }

        ~MySession()
        {
            Close();
        }
        #endregion

        #region Connection and Command
        /// <summary>
        /// 连接对象
        /// </summary>
        public DbConnection Connection { private set; get; }
        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <param name="dataProvider">数据提供程序</param> 
        private DbConnection GetConnection(DataProvider dataProvider, string connectionString = "")
        {
            DbConnection conn = null;
            switch (dataProvider)
            {
                case DataProvider.SQLServer:
                    conn = new SqlConnection(connectionString);
                    break;
                //case DataProvider.Oracle:
                //    conn = new OracleConnection(connectionString);
                //    break;
                case DataProvider.OleDB:
                    conn = new OleDbConnection(connectionString);
                    break;
                case DataProvider.ODBC:
                    conn = new OdbcConnection(connectionString);
                    break;
                case DataProvider.None:
                    throw new NotImplementedException();
            }
            return conn;
        }
        /// <summary>
        /// 获取命令对象
        /// </summary>
        public DbCommand GetCommand(string sql)
        {
            var command = Connection.CreateCommand();
            command.CommandText = sql;
            return command;
        }
        /// <summary>
        /// 开启连接
        /// </summary>
        public void Open()
        {
            Connection.Open();
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }
        #endregion

        #region Transaction
        /// <summary>
        /// 事务对象
        /// </summary>
        public DbTransaction Transaction { set; get; }
        /// <summary>
        /// 启用事务
        /// </summary>
        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }
        /// <summary>
        /// 启用事务
        /// </summary>
        public void BeginTransaction(IsolationLevel level)
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            Transaction = Connection.BeginTransaction(level);
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            Transaction.Commit();
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollBackTransaction()
        {
            Transaction.Rollback();
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
        #endregion

        #region Execute Methods
        #region ExecuteNonQuery
        public int ExecuteNonQuery(string sql)
        {
            DbCommand command = GetCommand(sql);
            return ExecuteNonQuery(command);
        }
        public int ExecuteNonQuery(DbCommand command)
        {
            if (this.Transaction != null)
                command.Transaction = this.Transaction;
            int result = command.ExecuteNonQuery();
            return result;
        }
        #endregion

        #region ExecuteScalar
        public object ExecuteScalar(string sql)
        {
            DbCommand command = GetCommand(sql);
            return ExecuteScalar(command);
        }
        public object ExecuteScalar(DbCommand command)
        {
            if (this.Transaction != null)
                command.Transaction = this.Transaction;
            object result = command.ExecuteScalar();
            return result;
        }
        #endregion

        #region ExecuteDataReader
        /// <summary>
        /// 数据适配对象
        /// </summary>
        public DbDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                {
                    switch (DataProvider)
                    {
                        case DataProvider.SQLServer:
                            _adapter = new SqlDataAdapter();
                            _adapter.SelectCommand = new SqlCommand();
                            break;
                        case DataProvider.Oracle:
                        case DataProvider.OleDB:
                        case DataProvider.ODBC:
                        case DataProvider.None:
                        default:
                            throw new NotImplementedException("无该类型适配器");
                    }
                }
                return _adapter;
            }
        }
        private DbDataAdapter _adapter;

        public DbDataReader ExecuteDataReader(string sql)
        {
            DbCommand command = GetCommand(sql);
            return ExecuteDataReader(command);
        }
        public DbDataReader ExecuteDataReader(DbCommand command)
        {
            if (this.Transaction != null)
                command.Transaction = this.Transaction;
            var result = command.ExecuteReader();
            return result;
        }
        #endregion

        #region ExecuteDataSet
        public DataSet ExecuteDataSet(string sql)
        {
            DbCommand command = GetCommand(sql);
            return ExecuteDataSet(command);
        }
        public DataSet ExecuteDataSet(DbCommand command)
        {
            if (this.Transaction != null)
                command.Transaction = this.Transaction;
            DataSet ds = new DataSet();
            Fill(command, ds);
            return ds;
        }
        private int Fill(DbCommand command, DataSet ds)
        {
            Adapter.SelectCommand = command;
            Adapter.SelectCommand.CommandTimeout = 10;
            Adapter.SelectCommand.Connection = Connection;
            Adapter.SelectCommand.Transaction = Transaction;
            return Adapter.Fill(ds);
        }
        #endregion

        #region ExecuteReader
        public DbDataReader ExecuteReader(string sql)
        {
            DbCommand command = GetCommand(sql);
            return ExecuteReader(command);
        }
        public DbDataReader ExecuteReader(DbCommand command)
        {
            if (this.Transaction != null)
                command.Transaction = this.Transaction;
            var result = command.ExecuteReader();
            return result;
        }
        #endregion

        #region ExecuteDataTable
        public DataTable ExecuteDataTable(string sql)
        {
            DbCommand command = GetCommand(sql);
            return ExecuteDataTable(command);
        }
        public DataTable ExecuteDataTable(DbCommand command)
        {
            if (this.Transaction != null)
                command.Transaction = this.Transaction;
            DataTable dt = new DataTable();
            Fill(command, dt);
            return dt;
        }
        private int Fill(DbCommand command, DataTable dt)
        {
            Adapter.SelectCommand = command;
            Adapter.SelectCommand.CommandTimeout = 10;
            Adapter.SelectCommand.Connection = Connection;
            Adapter.SelectCommand.Transaction = Transaction;
            return Adapter.Fill(dt);
        }
        #endregion
        #endregion

        #region DbParameter
        private DbParameterGenerator _dbParameterGenerator { set; get; }
        /// <summary>
        /// 参数生成器
        /// </summary>
        public DbParameterGenerator DBParameterGenerator
        {
            set { _dbParameterGenerator = value; }
            get
            {
                if (_dbParameterGenerator == null)
                {
                    _dbParameterGenerator = GetParameterGenerator(this.DataProvider);
                }
                return _dbParameterGenerator;
            }
        }
        /// <summary>
        /// 获取参数生成器
        /// </summary>
        /// <param name="dataProvider">数据提供程序</param> 
        DbParameterGenerator GetParameterGenerator(DataProvider dataProvider)
        {
            DbParameterGenerator parameterGenerator = null;
            switch (dataProvider)
            {
                case DataProvider.SQLServer:
                case DataProvider.Oracle:
                //parameterGenerator = new OracleParameterGenerator();
                case DataProvider.OleDB:
                case DataProvider.ODBC:
                case DataProvider.None:
                default:
                    throw new NotImplementedException();
            }
            return parameterGenerator;
        }

        #endregion
    }

    public static class MySessionEx
    {
        public static void AppendText(this DbCommand command, string sql)
        {
            if (string.IsNullOrEmpty(command.CommandText))
            {
                command.CommandText = sql;
            }
            else
            {
                command.CommandText += sql;
            }
        }
        public static void AppendParameter(this DbCommand command, DbParameter parameter)
        {
            string uniqueParameterName = parameter.ParameterName + command.Parameters.Count;
            parameter.ParameterName = uniqueParameterName;
            command.CommandText += "@" + parameter.ParameterName;
            command.Parameters.Add(parameter);
        }
    }
}
