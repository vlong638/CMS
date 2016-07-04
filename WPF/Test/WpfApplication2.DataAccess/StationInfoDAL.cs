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
	/// 车站信息数据访问类
	/// </summary>
	public class StationInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="StationInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public StationInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增车站信息
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(StationInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into StationInfo(GroupID,StationName,RegionID,AreaID,StationID) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("RegionID", dao.RegionID, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("AreaID", dao.AreaID, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StationID", dao.StationID, SqlDbType.Int));
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
		/// 更新车站信息
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(StationInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update StationInfo set ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.AppendString(",GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",RegionID=");
			stmt.AppendParameter(_session.MakeInParameter("RegionID", dao.RegionID, SqlDbType.Int));
			stmt.AppendString(",AreaID=");
			stmt.AppendParameter(_session.MakeInParameter("AreaID", dao.AreaID, SqlDbType.Int));
			stmt.AppendString(",StationID=");
			stmt.AppendParameter(_session.MakeInParameter("StationID", dao.StationID, SqlDbType.Int));
			stmt.AppendString(" where ");
			stmt.AppendString("StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的车站信息
		/// </summary>
		/// <param name="stationName">车站名称</param>
		/// <returns>成功/失败</returns>
		public bool Delete(string stationName)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from StationInfo where StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", stationName, SqlDbType.NVarChar));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的车站信息
		/// </summary>
		/// <param name="stationName">车站名称</param>
		/// <returns>车站信息</returns>
		public StationInfo SelectOne(string stationName)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationInfo where StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", stationName, SqlDbType.NVarChar));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			StationInfo stationInfo = new StationInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], stationInfo);
			}
			return stationInfo;
		}

		/// <summary>
		/// 获取所有的车站信息
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的车站信息集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<StationInfo> SelectAllCollection()
		{
			ObservableCollection<StationInfo> datas = new ObservableCollection<StationInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				StationInfo dao = new StationInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成StationInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">StationInfo实体类</param>
		public void DataRowToEntity(DataRow dr, StationInfo dao)
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
			if (dr["StationName"] == null || dr["StationName"] == DBNull.Value)
			{
				dao.StationName = null;
			}
			else
			{
				dao.StationName = dr["StationName"].ToString();
			}
			if (dr["RegionID"] == null || dr["RegionID"] == DBNull.Value)
			{
				dao.RegionID = int.MinValue;
			}
			else
			{
				dao.RegionID = int.Parse(dr["RegionID"].ToString());
			}
			if (dr["AreaID"] == null || dr["AreaID"] == DBNull.Value)
			{
				dao.AreaID = int.MinValue;
			}
			else
			{
				dao.AreaID = int.Parse(dr["AreaID"].ToString());
			}
			if (dr["StationID"] == null || dr["StationID"] == DBNull.Value)
			{
				dao.StationID = int.MinValue;
			}
			else
			{
				dao.StationID = int.Parse(dr["StationID"].ToString());
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的StationInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">StationInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, StationInfo dao)
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
			data = reader["StationName"];
			if (data == null || data == DBNull.Value)
			{
				dao.StationName = null;
			}
			else
			{
				dao.StationName = data.ToString();
			}
			data = reader["RegionID"];
			if (data == null || data == DBNull.Value)
			{
				dao.RegionID = int.MinValue;
			}
			else
			{
				dao.RegionID = int.Parse(data.ToString());
			}
			data = reader["AreaID"];
			if (data == null || data == DBNull.Value)
			{
				dao.AreaID = int.MinValue;
			}
			else
			{
				dao.AreaID = int.Parse(data.ToString());
			}
			data = reader["StationID"];
			if (data == null || data == DBNull.Value)
			{
				dao.StationID = int.MinValue;
			}
			else
			{
				dao.StationID = int.Parse(data.ToString());
			}
		}

		/// <summary>
		/// 获取所有的车站信息
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有车站信息
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationInfo order by StationName");
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