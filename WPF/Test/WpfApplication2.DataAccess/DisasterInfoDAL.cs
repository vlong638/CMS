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
	/// 灾害信息表数据访问类
	/// </summary>
	public class DisasterInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="DisasterInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public DisasterInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增灾害信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(DisasterInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into DisasterInfo(GroupID,StationName,Category,StartMileage,EndMileage,WarningRelay,AffectedSectionName,Remark) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StartMileage", dao.StartMileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("EndMileage", dao.EndMileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("WarningRelay", dao.WarningRelay, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("AffectedSectionName", dao.AffectedSectionName, SqlDbType.NVarChar));
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
		/// 更新灾害信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(DisasterInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update DisasterInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",StartMileage=");
			stmt.AppendParameter(_session.MakeInParameter("StartMileage", dao.StartMileage, SqlDbType.NVarChar));
			stmt.AppendString(",EndMileage=");
			stmt.AppendParameter(_session.MakeInParameter("EndMileage", dao.EndMileage, SqlDbType.NVarChar));
			stmt.AppendString(",WarningRelay=");
			stmt.AppendParameter(_session.MakeInParameter("WarningRelay", dao.WarningRelay, SqlDbType.NVarChar));
			stmt.AppendString(",AffectedSectionName=");
			stmt.AppendParameter(_session.MakeInParameter("AffectedSectionName", dao.AffectedSectionName, SqlDbType.NVarChar));
			stmt.AppendString(",Remark=");
			stmt.AppendParameter(_session.MakeInParameter("Remark", dao.Remark, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的灾害信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from DisasterInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的灾害信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>灾害信息表</returns>
		public DisasterInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from DisasterInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			DisasterInfo disasterInfo = new DisasterInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], disasterInfo);
			}
			return disasterInfo;
		}

		/// <summary>
		/// 获取所有的灾害信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from DisasterInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的灾害信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<DisasterInfo> SelectAllCollection()
		{
			ObservableCollection<DisasterInfo> datas = new ObservableCollection<DisasterInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from DisasterInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				DisasterInfo dao = new DisasterInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成DisasterInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">DisasterInfo实体类</param>
		public void DataRowToEntity(DataRow dr, DisasterInfo dao)
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
			if (dr["Category"] == null || dr["Category"] == DBNull.Value)
			{
				dao.Category = int.MinValue;
			}
			else
			{
				dao.Category = int.Parse(dr["Category"].ToString());
			}
			if (dr["StartMileage"] == null || dr["StartMileage"] == DBNull.Value)
			{
				dao.StartMileage = null;
			}
			else
			{
				dao.StartMileage = dr["StartMileage"].ToString();
			}
			if (dr["EndMileage"] == null || dr["EndMileage"] == DBNull.Value)
			{
				dao.EndMileage = null;
			}
			else
			{
				dao.EndMileage = dr["EndMileage"].ToString();
			}
			if (dr["WarningRelay"] == null || dr["WarningRelay"] == DBNull.Value)
			{
				dao.WarningRelay = null;
			}
			else
			{
				dao.WarningRelay = dr["WarningRelay"].ToString();
			}
			if (dr["AffectedSectionName"] == null || dr["AffectedSectionName"] == DBNull.Value)
			{
				dao.AffectedSectionName = null;
			}
			else
			{
				dao.AffectedSectionName = dr["AffectedSectionName"].ToString();
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
		/// 获取指定的IDataReader中的DisasterInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">DisasterInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, DisasterInfo dao)
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
			data = reader["Category"];
			if (data == null || data == DBNull.Value)
			{
				dao.Category = int.MinValue;
			}
			else
			{
				dao.Category = int.Parse(data.ToString());
			}
			data = reader["StartMileage"];
			if (data == null || data == DBNull.Value)
			{
				dao.StartMileage = null;
			}
			else
			{
				dao.StartMileage = data.ToString();
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
			data = reader["WarningRelay"];
			if (data == null || data == DBNull.Value)
			{
				dao.WarningRelay = null;
			}
			else
			{
				dao.WarningRelay = data.ToString();
			}
			data = reader["AffectedSectionName"];
			if (data == null || data == DBNull.Value)
			{
				dao.AffectedSectionName = null;
			}
			else
			{
				dao.AffectedSectionName = data.ToString();
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
		/// 获取所有的灾害信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from DisasterInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有灾害信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from DisasterInfo order by ID");
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