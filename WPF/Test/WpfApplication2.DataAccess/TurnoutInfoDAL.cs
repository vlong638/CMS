namespace WpfApplication2.DataAccess
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Linq;
	using GenDB.Data;
	using WpfApplication2.Data;

	/// <summary>
	/// 道岔信息表数据访问类
	/// </summary>
	public class TurnoutInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="TurnoutInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public TurnoutInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增道岔信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(TurnoutInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into TurnoutInfo(GroupID,Category,StationName,TurnoutName,Mileage,Siding,Speed,TFLine,default1,default2,default3,default4) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("TurnoutName", dao.TurnoutName, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Mileage", dao.Mileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Siding", dao.Siding, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Speed", dao.Speed, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("TFLine", dao.TFLine, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("default1", dao.Default1, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("default2", dao.Default2, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("default3", dao.Default3, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("default4", dao.Default4, SqlDbType.NVarChar));
			stmt.AppendString(");select SCOPE_IDENTITY();");
			stmt.StatementType = SqlStatementType.Identity;
			SqlResult result = _session.Excecute(stmt);
			if (result.Data != null)
			{
				dao.ID = int.Parse(result.Data.ToString());
				return true;
			}
			return false;
		}

		/// <summary>
		/// 更新道岔信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(TurnoutInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update TurnoutInfo set ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.AppendString(",GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",Mileage=");
			stmt.AppendParameter(_session.MakeInParameter("Mileage", dao.Mileage, SqlDbType.NVarChar));
			stmt.AppendString(",Siding=");
			stmt.AppendParameter(_session.MakeInParameter("Siding", dao.Siding, SqlDbType.NVarChar));
			stmt.AppendString(",Speed=");
			stmt.AppendParameter(_session.MakeInParameter("Speed", dao.Speed, SqlDbType.Int));
			stmt.AppendString(",TFLine=");
			stmt.AppendParameter(_session.MakeInParameter("TFLine", dao.TFLine, SqlDbType.NVarChar));
			stmt.AppendString(",default1=");
			stmt.AppendParameter(_session.MakeInParameter("default1", dao.Default1, SqlDbType.NVarChar));
			stmt.AppendString(",default2=");
			stmt.AppendParameter(_session.MakeInParameter("default2", dao.Default2, SqlDbType.NVarChar));
			stmt.AppendString(",default3=");
			stmt.AppendParameter(_session.MakeInParameter("default3", dao.Default3, SqlDbType.NVarChar));
			stmt.AppendString(",default4=");
			stmt.AppendParameter(_session.MakeInParameter("default4", dao.Default4, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(" and TurnoutName=");
			stmt.AppendParameter(_session.MakeInParameter("TurnoutName", dao.TurnoutName, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的道岔信息表
		/// </summary>
		/// <param name="stationName">车站名称</param>
		/// <param name="turnoutName">道岔名称</param>
		/// <returns>成功/失败</returns>
		public bool Delete(string stationName,int turnoutName)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from TurnoutInfo where ");
			stmt.AppendString("StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", stationName, SqlDbType.NVarChar));
			stmt.AppendString(" and TurnoutName=");
			stmt.AppendParameter(_session.MakeInParameter("TurnoutName", turnoutName, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的道岔信息表
		/// </summary>
		/// <param name="stationName">车站名称</param>
		/// <param name="turnoutName">道岔名称</param>
		/// <returns>道岔信息表</returns>
		public TurnoutInfo SelectOne(string stationName,int turnoutName)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TurnoutInfo where ");
			stmt.AppendString("StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", stationName, SqlDbType.NVarChar));
			stmt.AppendString(" and TurnoutName=");
			stmt.AppendParameter(_session.MakeInParameter("TurnoutName", turnoutName, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			TurnoutInfo turnoutInfo = new TurnoutInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], turnoutInfo);
			}
			return turnoutInfo;
		}

		/// <summary>
		/// 获取所有的道岔信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TurnoutInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的道岔信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<TurnoutInfo> SelectAllCollection()
		{
			ObservableCollection<TurnoutInfo> datas = new ObservableCollection<TurnoutInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TurnoutInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				TurnoutInfo dao = new TurnoutInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成TurnoutInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">TurnoutInfo实体类</param>
		public void DataRowToEntity(DataRow dr, TurnoutInfo dao)
		{
			if (dr["ID"] == null || dr["ID"] == DBNull.Value)
			{
				dao.ID = int.MinValue;
			}
			else
			{
				dao.ID = int.Parse(dr["ID"].ToString());
			}
			if (dr["GroupID"] == null || dr["GroupID"] == DBNull.Value)
			{
				dao.GroupID = Guid.NewGuid();
			}
			else
			{
				dao.GroupID = Guid.Parse(dr["GroupID"].ToString());
			}
			if (dr["Category"] == null || dr["Category"] == DBNull.Value)
			{
				dao.Category = null;
			}
			else
			{
				dao.Category = int.Parse(dr["Category"].ToString());
			}
			if (dr["StationName"] == null || dr["StationName"] == DBNull.Value)
			{
				dao.StationName = null;
			}
			else
			{
				dao.StationName = dr["StationName"].ToString();
			}
			if (dr["TurnoutName"] == null || dr["TurnoutName"] == DBNull.Value)
			{
				dao.TurnoutName = int.MinValue;
			}
			else
			{
				dao.TurnoutName = int.Parse(dr["TurnoutName"].ToString());
			}
			if (dr["Mileage"] == null || dr["Mileage"] == DBNull.Value)
			{
				dao.Mileage = null;
			}
			else
			{
				dao.Mileage = dr["Mileage"].ToString();
			}
			if (dr["Siding"] == null || dr["Siding"] == DBNull.Value)
			{
				dao.Siding = null;
			}
			else
			{
				dao.Siding = dr["Siding"].ToString();
			}
			if (dr["Speed"] == null || dr["Speed"] == DBNull.Value)
			{
				dao.Speed = int.MinValue;
			}
			else
			{
				dao.Speed = int.Parse(dr["Speed"].ToString());
			}
			if (dr["TFLine"] == null || dr["TFLine"] == DBNull.Value)
			{
				dao.TFLine = null;
			}
			else
			{
				dao.TFLine = dr["TFLine"].ToString();
			}
			if (dr["default1"] == null || dr["default1"] == DBNull.Value)
			{
				dao.Default1 = null;
			}
			else
			{
				dao.Default1 = dr["default1"].ToString();
			}
			if (dr["default2"] == null || dr["default2"] == DBNull.Value)
			{
				dao.Default2 = null;
			}
			else
			{
				dao.Default2 = dr["default2"].ToString();
			}
			if (dr["default3"] == null || dr["default3"] == DBNull.Value)
			{
				dao.Default3 = null;
			}
			else
			{
				dao.Default3 = dr["default3"].ToString();
			}
			if (dr["default4"] == null || dr["default4"] == DBNull.Value)
			{
				dao.Default4 = null;
			}
			else
			{
				dao.Default4 = dr["default4"].ToString();
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的TurnoutInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">TurnoutInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, TurnoutInfo dao)
		{
			object data;
			data = reader["ID"];
			if (data == null || data == DBNull.Value)
			{
				dao.ID = int.MinValue;
			}
			else
			{
				dao.ID = int.Parse(data.ToString());
			}
			data = reader["GroupID"];
			if (data == null || data == DBNull.Value)
			{
				dao.GroupID = Guid.NewGuid();
			}
			else
			{
				dao.GroupID = Guid.Parse(data.ToString());
			}
			data = reader["Category"];
			if (data == null || data == DBNull.Value)
			{
				dao.Category = null;
			}
			else
			{
				dao.Category = int.Parse(data.ToString());
			}
			data = reader["StationName"];
			if (data == null || data == DBNull.Value)
			{
				dao.StationName = null;
			}
			else
			{
				dao.StationName = data.ToString();
			}
			data = reader["TurnoutName"];
			if (data == null || data == DBNull.Value)
			{
				dao.TurnoutName = int.MinValue;
			}
			else
			{
				dao.TurnoutName = int.Parse(data.ToString());
			}
			data = reader["Mileage"];
			if (data == null || data == DBNull.Value)
			{
				dao.Mileage = null;
			}
			else
			{
				dao.Mileage = data.ToString();
			}
			data = reader["Siding"];
			if (data == null || data == DBNull.Value)
			{
				dao.Siding = null;
			}
			else
			{
				dao.Siding = data.ToString();
			}
			data = reader["Speed"];
			if (data == null || data == DBNull.Value)
			{
				dao.Speed = int.MinValue;
			}
			else
			{
				dao.Speed = int.Parse(data.ToString());
			}
			data = reader["TFLine"];
			if (data == null || data == DBNull.Value)
			{
				dao.TFLine = null;
			}
			else
			{
				dao.TFLine = data.ToString();
			}
			data = reader["default1"];
			if (data == null || data == DBNull.Value)
			{
				dao.Default1 = null;
			}
			else
			{
				dao.Default1 = data.ToString();
			}
			data = reader["default2"];
			if (data == null || data == DBNull.Value)
			{
				dao.Default2 = null;
			}
			else
			{
				dao.Default2 = data.ToString();
			}
			data = reader["default3"];
			if (data == null || data == DBNull.Value)
			{
				dao.Default3 = null;
			}
			else
			{
				dao.Default3 = data.ToString();
			}
			data = reader["default4"];
			if (data == null || data == DBNull.Value)
			{
				dao.Default4 = null;
			}
			else
			{
				dao.Default4 = data.ToString();
			}
		}

		/// <summary>
		/// 获取所有的道岔信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TurnoutInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有道岔信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TurnoutInfo order by StationName,TurnoutName");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		#endregion

		#region ManualCode
		/***PRESERVE_BEGIN MANUAL_CODE***/
		/***PRESERVE_END MANUAL_CODE***/
		#endregion
	}
}