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
	/// 站内轨道区段与道岔映射表数据访问类
	/// </summary>
	public class StationSectionMappingDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="StationSectionMappingDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public StationSectionMappingDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增站内轨道区段与道岔映射表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(StationSectionMapping dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into StationSectionMapping(GroupID,SectionName,StationName,TurnoutIDs) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SectionName", dao.SectionName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("TurnoutIDs", dao.TurnoutIDs, SqlDbType.NVarChar));
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
		/// 更新站内轨道区段与道岔映射表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(StationSectionMapping dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update StationSectionMapping set ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.AppendString(",GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",TurnoutIDs=");
			stmt.AppendParameter(_session.MakeInParameter("TurnoutIDs", dao.TurnoutIDs, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("SectionName=");
			stmt.AppendParameter(_session.MakeInParameter("SectionName", dao.SectionName, SqlDbType.NVarChar));
			stmt.AppendString(" and StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的站内轨道区段与道岔映射表
		/// </summary>
		/// <param name="sectionName">区段名称</param>
		/// <param name="stationName">车站名称</param>
		/// <returns>成功/失败</returns>
		public bool Delete(string sectionName,string stationName)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from StationSectionMapping where ");
			stmt.AppendString("SectionName=");
			stmt.AppendParameter(_session.MakeInParameter("SectionName", sectionName, SqlDbType.NVarChar));
			stmt.AppendString(" and StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", stationName, SqlDbType.NVarChar));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的站内轨道区段与道岔映射表
		/// </summary>
		/// <param name="sectionName">区段名称</param>
		/// <param name="stationName">车站名称</param>
		/// <returns>站内轨道区段与道岔映射表</returns>
		public StationSectionMapping SelectOne(string sectionName,string stationName)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionMapping where ");
			stmt.AppendString("SectionName=");
			stmt.AppendParameter(_session.MakeInParameter("SectionName", sectionName, SqlDbType.NVarChar));
			stmt.AppendString(" and StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", stationName, SqlDbType.NVarChar));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			StationSectionMapping stationSectionMapping = new StationSectionMapping();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], stationSectionMapping);
			}
			return stationSectionMapping;
		}

		/// <summary>
		/// 获取所有的站内轨道区段与道岔映射表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionMapping");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的站内轨道区段与道岔映射表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<StationSectionMapping> SelectAllCollection()
		{
			ObservableCollection<StationSectionMapping> datas = new ObservableCollection<StationSectionMapping>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionMapping");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				StationSectionMapping dao = new StationSectionMapping();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成StationSectionMapping
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">StationSectionMapping实体类</param>
		public void DataRowToEntity(DataRow dr, StationSectionMapping dao)
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
			if (dr["SectionName"] == null || dr["SectionName"] == DBNull.Value)
			{
				dao.SectionName = null;
			}
			else
			{
				dao.SectionName = dr["SectionName"].ToString();
			}
			if (dr["StationName"] == null || dr["StationName"] == DBNull.Value)
			{
				dao.StationName = null;
			}
			else
			{
				dao.StationName = dr["StationName"].ToString();
			}
			if (dr["TurnoutIDs"] == null || dr["TurnoutIDs"] == DBNull.Value)
			{
				dao.TurnoutIDs = null;
			}
			else
			{
				dao.TurnoutIDs = dr["TurnoutIDs"].ToString();
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的StationSectionMapping
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">StationSectionMapping实体类</param>
		public void DataReaderToEntity(IDataReader reader, StationSectionMapping dao)
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
			data = reader["SectionName"];
			if (data == null || data == DBNull.Value)
			{
				dao.SectionName = null;
			}
			else
			{
				dao.SectionName = data.ToString();
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
			data = reader["TurnoutIDs"];
			if (data == null || data == DBNull.Value)
			{
				dao.TurnoutIDs = null;
			}
			else
			{
				dao.TurnoutIDs = data.ToString();
			}
		}

		/// <summary>
		/// 获取所有的站内轨道区段与道岔映射表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionMapping");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有站内轨道区段与道岔映射表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionMapping order by SectionName,StationName");
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