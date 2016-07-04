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
	/// 批次信息表数据访问类
	/// </summary>
	public class GroupInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="GroupInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public GroupInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增批次信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(GroupInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into GroupInfo(GroupID,GroupName,StartTime,OperatorName,IsSuccessed) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("GroupName", dao.GroupName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StartTime", dao.StartTime, SqlDbType.DateTime));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("OperatorName", dao.OperatorName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("IsSuccessed", dao.IsSuccessed, SqlDbType.Bit));
			stmt.AppendString(")");
			stmt.StatementType = SqlStatementType.Insert;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 更新批次信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(GroupInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update GroupInfo set ");
			stmt.AppendString("GroupName=");
			stmt.AppendParameter(_session.MakeInParameter("GroupName", dao.GroupName, SqlDbType.NVarChar));
			stmt.AppendString(",StartTime=");
			stmt.AppendParameter(_session.MakeInParameter("StartTime", dao.StartTime, SqlDbType.DateTime));
			stmt.AppendString(",OperatorName=");
			stmt.AppendParameter(_session.MakeInParameter("OperatorName", dao.OperatorName, SqlDbType.NVarChar));
			stmt.AppendString(",IsSuccessed=");
			stmt.AppendParameter(_session.MakeInParameter("IsSuccessed", dao.IsSuccessed, SqlDbType.Bit));
			stmt.AppendString(" where ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的批次信息表
		/// </summary>
		/// <param name="groupID">批次号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(Guid groupID)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from GroupInfo where GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", groupID, SqlDbType.UniqueIdentifier));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的批次信息表
		/// </summary>
		/// <param name="groupID">批次号</param>
		/// <returns>批次信息表</returns>
		public GroupInfo SelectOne(Guid groupID)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from GroupInfo where GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", groupID, SqlDbType.UniqueIdentifier));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			GroupInfo groupInfo = new GroupInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], groupInfo);
			}
			return groupInfo;
		}

		/// <summary>
		/// 获取所有的批次信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from GroupInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的批次信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<GroupInfo> SelectAllCollection()
		{
			ObservableCollection<GroupInfo> datas = new ObservableCollection<GroupInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from GroupInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				GroupInfo dao = new GroupInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成GroupInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">GroupInfo实体类</param>
		public void DataRowToEntity(DataRow dr, GroupInfo dao)
		{
			if (dr["GroupID"] == null || dr["GroupID"] == DBNull.Value)
			{
				dao.GroupID = Guid.NewGuid();
			}
			else
			{
				dao.GroupID = Guid.Parse(dr["GroupID"].ToString());
			}
			if (dr["GroupName"] == null || dr["GroupName"] == DBNull.Value)
			{
				dao.GroupName = null;
			}
			else
			{
				dao.GroupName = dr["GroupName"].ToString();
			}
			if (dr["StartTime"] == null || dr["StartTime"] == DBNull.Value)
			{
				dao.StartTime = null;
			}
			else
			{
				dao.StartTime = DateTime.Parse(dr["StartTime"].ToString());
			}
			if (dr["OperatorName"] == null || dr["OperatorName"] == DBNull.Value)
			{
				dao.OperatorName = null;
			}
			else
			{
				dao.OperatorName = dr["OperatorName"].ToString();
			}
			if (dr["IsSuccessed"] == null || dr["IsSuccessed"] == DBNull.Value)
			{
				dao.IsSuccessed = null;
			}
			else
			{
				dao.IsSuccessed = bool.Parse(dr["IsSuccessed"].ToString());
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的GroupInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">GroupInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, GroupInfo dao)
		{
			object data;
			data = reader["GroupID"];
			if (data == null || data == DBNull.Value)
			{
				dao.GroupID = Guid.NewGuid();
			}
			else
			{
				dao.GroupID = Guid.Parse(data.ToString());
			}
			data = reader["GroupName"];
			if (data == null || data == DBNull.Value)
			{
				dao.GroupName = null;
			}
			else
			{
				dao.GroupName = data.ToString();
			}
			data = reader["StartTime"];
			if (data == null || data == DBNull.Value)
			{
				dao.StartTime = null;
			}
			else
			{
				dao.StartTime = DateTime.Parse(data.ToString());
			}
			data = reader["OperatorName"];
			if (data == null || data == DBNull.Value)
			{
				dao.OperatorName = null;
			}
			else
			{
				dao.OperatorName = data.ToString();
			}
			data = reader["IsSuccessed"];
			if (data == null || data == DBNull.Value)
			{
				dao.IsSuccessed = null;
			}
			else
			{
				dao.IsSuccessed = bool.Parse(data.ToString());
			}
		}

		/// <summary>
		/// 获取所有的批次信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from GroupInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有批次信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from GroupInfo order by GroupID");
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