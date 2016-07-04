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
	/// 站内区段信息数据访问类
	/// </summary>
	public class StationSectionInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="StationSectionInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public StationSectionInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增站内区段信息
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(StationSectionInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into StationSectionInfo(GroupID,StationName,SectionName,SectionCarrirer,SectionLength,LayerType,TurnoutIDs) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SectionName", dao.SectionName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SectionCarrirer", dao.SectionCarrirer, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SectionLength", dao.SectionLength, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("LayerType", dao.LayerType, SqlDbType.Int));
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
		/// 更新站内区段信息
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(StationSectionInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update StationSectionInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",SectionName=");
			stmt.AppendParameter(_session.MakeInParameter("SectionName", dao.SectionName, SqlDbType.NVarChar));
			stmt.AppendString(",SectionCarrirer=");
			stmt.AppendParameter(_session.MakeInParameter("SectionCarrirer", dao.SectionCarrirer, SqlDbType.NVarChar));
			stmt.AppendString(",SectionLength=");
			stmt.AppendParameter(_session.MakeInParameter("SectionLength", dao.SectionLength, SqlDbType.Int));
			stmt.AppendString(",LayerType=");
			stmt.AppendParameter(_session.MakeInParameter("LayerType", dao.LayerType, SqlDbType.Int));
			stmt.AppendString(",TurnoutIDs=");
			stmt.AppendParameter(_session.MakeInParameter("TurnoutIDs", dao.TurnoutIDs, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的站内区段信息
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from StationSectionInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的站内区段信息
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>站内区段信息</returns>
		public StationSectionInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			StationSectionInfo stationSectionInfo = new StationSectionInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], stationSectionInfo);
			}
			return stationSectionInfo;
		}

		/// <summary>
		/// 获取所有的站内区段信息
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的站内区段信息集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<StationSectionInfo> SelectAllCollection()
		{
			ObservableCollection<StationSectionInfo> datas = new ObservableCollection<StationSectionInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				StationSectionInfo dao = new StationSectionInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成StationSectionInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">StationSectionInfo实体类</param>
		public void DataRowToEntity(DataRow dr, StationSectionInfo dao)
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
			if (dr["SectionName"] == null || dr["SectionName"] == DBNull.Value)
			{
				dao.SectionName = null;
			}
			else
			{
				dao.SectionName = dr["SectionName"].ToString();
			}
			if (dr["SectionCarrirer"] == null || dr["SectionCarrirer"] == DBNull.Value)
			{
				dao.SectionCarrirer = null;
			}
			else
			{
				dao.SectionCarrirer = dr["SectionCarrirer"].ToString();
			}
			if (dr["SectionLength"] == null || dr["SectionLength"] == DBNull.Value)
			{
				dao.SectionLength = int.MinValue;
			}
			else
			{
				dao.SectionLength = int.Parse(dr["SectionLength"].ToString());
			}
			if (dr["LayerType"] == null || dr["LayerType"] == DBNull.Value)
			{
				dao.LayerType = null;
			}
			else
			{
				dao.LayerType = int.Parse(dr["LayerType"].ToString());
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
		/// 获取指定的IDataReader中的StationSectionInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">StationSectionInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, StationSectionInfo dao)
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
			data = reader["SectionName"];
			if (data == null || data == DBNull.Value)
			{
				dao.SectionName = null;
			}
			else
			{
				dao.SectionName = data.ToString();
			}
			data = reader["SectionCarrirer"];
			if (data == null || data == DBNull.Value)
			{
				dao.SectionCarrirer = null;
			}
			else
			{
				dao.SectionCarrirer = data.ToString();
			}
			data = reader["SectionLength"];
			if (data == null || data == DBNull.Value)
			{
				dao.SectionLength = int.MinValue;
			}
			else
			{
				dao.SectionLength = int.Parse(data.ToString());
			}
			data = reader["LayerType"];
			if (data == null || data == DBNull.Value)
			{
				dao.LayerType = null;
			}
			else
			{
				dao.LayerType = int.Parse(data.ToString());
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
		/// 获取所有的站内区段信息
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有站内区段信息
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from StationSectionInfo order by ID");
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