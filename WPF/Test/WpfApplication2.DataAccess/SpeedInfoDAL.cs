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
	/// 线路速度表数据访问类
	/// </summary>
	public class SpeedInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="SpeedInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public SpeedInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增线路速度表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(SpeedInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into SpeedInfo(GroupID,Category,Speed,Length,EndMileage,Remark) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Speed", dao.Speed, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Length", dao.Length, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("EndMileage", dao.EndMileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Remark", dao.Remark, SqlDbType.NVarChar));
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
		/// 更新线路速度表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(SpeedInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update SpeedInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",Speed=");
			stmt.AppendParameter(_session.MakeInParameter("Speed", dao.Speed, SqlDbType.Int));
			stmt.AppendString(",Length=");
			stmt.AppendParameter(_session.MakeInParameter("Length", dao.Length, SqlDbType.Int));
			stmt.AppendString(",EndMileage=");
			stmt.AppendParameter(_session.MakeInParameter("EndMileage", dao.EndMileage, SqlDbType.NVarChar));
			stmt.AppendString(",Remark=");
			stmt.AppendParameter(_session.MakeInParameter("Remark", dao.Remark, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的线路速度表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from SpeedInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的线路速度表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>线路速度表</returns>
		public SpeedInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SpeedInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			SpeedInfo speedInfo = new SpeedInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], speedInfo);
			}
			return speedInfo;
		}

		/// <summary>
		/// 获取所有的线路速度表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SpeedInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的线路速度表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<SpeedInfo> SelectAllCollection()
		{
			ObservableCollection<SpeedInfo> datas = new ObservableCollection<SpeedInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SpeedInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				SpeedInfo dao = new SpeedInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成SpeedInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">SpeedInfo实体类</param>
		public void DataRowToEntity(DataRow dr, SpeedInfo dao)
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
				dao.Category = int.MinValue;
			}
			else
			{
				dao.Category = int.Parse(dr["Category"].ToString());
			}
			if (dr["Speed"] == null || dr["Speed"] == DBNull.Value)
			{
				dao.Speed = int.MinValue;
			}
			else
			{
				dao.Speed = int.Parse(dr["Speed"].ToString());
			}
			if (dr["Length"] == null || dr["Length"] == DBNull.Value)
			{
				dao.Length = int.MinValue;
			}
			else
			{
				dao.Length = int.Parse(dr["Length"].ToString());
			}
			if (dr["EndMileage"] == null || dr["EndMileage"] == DBNull.Value)
			{
				dao.EndMileage = null;
			}
			else
			{
				dao.EndMileage = dr["EndMileage"].ToString();
			}
			if (dr["Remark"] == null || dr["Remark"] == DBNull.Value)
			{
				dao.Remark = null;
			}
			else
			{
				dao.Remark = dr["Remark"].ToString();
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的SpeedInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">SpeedInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, SpeedInfo dao)
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
				dao.Category = int.MinValue;
			}
			else
			{
				dao.Category = int.Parse(data.ToString());
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
			data = reader["Length"];
			if (data == null || data == DBNull.Value)
			{
				dao.Length = int.MinValue;
			}
			else
			{
				dao.Length = int.Parse(data.ToString());
			}
			data = reader["EndMileage"];
			if (data == null || data == DBNull.Value)
			{
				dao.EndMileage = null;
			}
			else
			{
				dao.EndMileage = data.ToString();
			}
			data = reader["Remark"];
			if (data == null || data == DBNull.Value)
			{
				dao.Remark = null;
			}
			else
			{
				dao.Remark = data.ToString();
			}
		}

		/// <summary>
		/// 获取所有的线路速度表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SpeedInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有线路速度表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SpeedInfo order by ID");
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