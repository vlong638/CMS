//using Oracle.DataAccess.Client;
//using System;
//using System.Data.Common;
//using System.Data.Odbc;
//using System.Data.OleDb;
//using System.Data.SqlClient;

//namespace MyDataAccess
//{
//    //public class MySession
//    //{
//    //    #region Fields
//    //    DbConnection _conn;


//    //    #endregion

//    //    #region Properties
//    //    public DbConnection Conn
//    //    {
//    //        get { return _conn; }
//    //        set { _conn = value; }
//    //    }
        
//    //    #endregion
        
//    //    #region Methods

//    //    #region 测试BrakeLength
//    //    public List<BrakeLength> GetBrakeLengthList()
//    //    {
//    //        List<BrakeLength> daos = new List<BrakeLength>();
//    //        //获取连接对象
//    //        using (DbConnection conn = MyConnectionFactory.CreateConnection())
//    //        {
//    //            conn.Open();
//    //            //获取命令对象
//    //            DbCommand cmd = conn.CreateCommand();
//    //            cmd.Connection = conn;
//    //            cmd.CommandText = "select * from BrakingInfo";

//    //            DbTransaction transaction = conn.BeginTransaction();

//    //            //从数据读取器输出数据
//    //            using (DbDataReader dateReader = cmd.ExecuteReader())
//    //            {
//    //                while (dateReader.Read())
//    //                {
//    //                    BrakeLength dao = new BrakeLength();
//    //                    DataReaderToEntity(dateReader, dao);
//    //                    daos.Add(dao);
//    //                }
//    //            }
//    //        }
//    //        return daos;
//    //    }
//    //    public void DataReaderToEntity(DbDataReader dateReader, BrakeLength dao)
//    //    {
//    //        if (dateReader["Speed"] == null || dateReader["Speed"] == DBNull.Value)
//    //        {
//    //            dao.Speed = 0;
//    //        }
//    //        else
//    //        {
//    //            dao.Speed = int.Parse(dateReader["Speed"].ToString());
//    //        }
//    //        if (dateReader["LengthForMessage"] == null || dateReader["LengthForMessage"] == DBNull.Value)
//    //        {
//    //            dao.Length = 0;
//    //        }
//    //        else
//    //        {
//    //            dao.Length = int.Parse(dateReader["LengthForMessage"].ToString());
//    //        }
//    //    } 
//    //    #endregion

//    //    #endregion

//    //}

//    public class MyConnectionFactory
//    {
//        #region NestedTypes
//        // 服务类型枚举
//        enum DataProvider { SQLServer,Oracle, OleDB, ODBC, None }
//        #endregion

//        #region Methods
//        //(Connection)连接对象的实现
//        static DbConnection GetConnection(DataProvider dataProvider)
//        {
//            DbConnection conn = null;
//            switch (dataProvider)
//            {
//                case DataProvider.SQLServer:
//                    conn = new SqlConnection();
//                    break;
//                case DataProvider.Oracle:
//                    conn = new OracleConnection();
//                    break;
//                case DataProvider.OleDB:
//                    conn = new OleDbConnection();
//                    break;
//                case DataProvider.ODBC:
//                    conn = new OdbcConnection();
//                    break;
//                case DataProvider.None:
//                    throw new NotImplementedException();
//            }
//            return conn;
//        }
//        static DbConnection CreateConnection(DataProvider dataProvider)
//        {
//            //string connectionString1 = ConfigurationManager.ConnectionStrings["sqlProvider"].ConnectionString;
//            string connectionString = @"Data Source=192.168.2.122;Initial Catalog=BTBuild;Persist Security Info=True;User ID=sa;Password=sa";

//            DbConnection conn = GetConnection(dataProvider);
//            conn.ConnectionString = connectionString;
//            return conn;
//        }
//        static DbConnection CreateConnection(string dataProviderString)
//        {
//            if (string.IsNullOrEmpty(dataProviderString)&&!Enum.IsDefined(typeof(DataProvider), dataProviderString))
//            {
//                return CreateConnection(DataProvider.None);
//            }
//            else
//            {
//                DataProvider dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
//                return CreateConnection(dataProvider);
//            }
//        } 
//        public static DbConnection CreateConnection()
//        {
//            //string dataProvider = ConfigurationManager.AppSettings["dataProvider"];
//            string dataProvider = "SQLServer";
//            return CreateConnection(dataProvider);

//        }
//        public static DbCommand CreateCommand(DbConnection conn)
//        {
//            DbCommand cmd= conn.CreateCommand();
//            cmd.Connection = conn;
//            return cmd;
//        } 
//        #endregion
//    }
//}
