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
	/// 进场数据表数据访问类
	/// </summary>
	public class ApproachInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="ApproachInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public ApproachInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增进场数据表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(ApproachInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into ApproachInfo(GroupID,ResponderID,ApprochID,ApprochInfo,ApproachType,StartAnnunciatorName,StartAnnunciatorDisplay,EndAnnunciator,ExperiencedResponders,ExperiencedTurnouts,ExperiencedSpeeds,ExperiencedStationSections,AffectedDisasters) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ResponderID", dao.ResponderID, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ApprochID", dao.ApprochID, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ApprochInfo", dao.ApprochInfo, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ApproachType", dao.ApproachType, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StartAnnunciatorName", dao.StartAnnunciatorName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StartAnnunciatorDisplay", dao.StartAnnunciatorDisplay, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("EndAnnunciator", dao.EndAnnunciator, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ExperiencedResponders", dao.ExperiencedResponders, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ExperiencedTurnouts", dao.ExperiencedTurnouts, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ExperiencedSpeeds", dao.ExperiencedSpeeds, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ExperiencedStationSections", dao.ExperiencedStationSections, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("AffectedDisasters", dao.AffectedDisasters, SqlDbType.NVarChar));
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
		/// 更新进场数据表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(ApproachInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update ApproachInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",ResponderID=");
			stmt.AppendParameter(_session.MakeInParameter("ResponderID", dao.ResponderID, SqlDbType.NVarChar));
			stmt.AppendString(",ApprochID=");
			stmt.AppendParameter(_session.MakeInParameter("ApprochID", dao.ApprochID, SqlDbType.NVarChar));
			stmt.AppendString(",ApprochInfo=");
			stmt.AppendParameter(_session.MakeInParameter("ApprochInfo", dao.ApprochInfo, SqlDbType.NVarChar));
			stmt.AppendString(",ApproachType=");
			stmt.AppendParameter(_session.MakeInParameter("ApproachType", dao.ApproachType, SqlDbType.NVarChar));
			stmt.AppendString(",StartAnnunciatorName=");
			stmt.AppendParameter(_session.MakeInParameter("StartAnnunciatorName", dao.StartAnnunciatorName, SqlDbType.NVarChar));
			stmt.AppendString(",StartAnnunciatorDisplay=");
			stmt.AppendParameter(_session.MakeInParameter("StartAnnunciatorDisplay", dao.StartAnnunciatorDisplay, SqlDbType.NVarChar));
			stmt.AppendString(",EndAnnunciator=");
			stmt.AppendParameter(_session.MakeInParameter("EndAnnunciator", dao.EndAnnunciator, SqlDbType.NVarChar));
			stmt.AppendString(",ExperiencedResponders=");
			stmt.AppendParameter(_session.MakeInParameter("ExperiencedResponders", dao.ExperiencedResponders, SqlDbType.NVarChar));
			stmt.AppendString(",ExperiencedTurnouts=");
			stmt.AppendParameter(_session.MakeInParameter("ExperiencedTurnouts", dao.ExperiencedTurnouts, SqlDbType.NVarChar));
			stmt.AppendString(",ExperiencedSpeeds=");
			stmt.AppendParameter(_session.MakeInParameter("ExperiencedSpeeds", dao.ExperiencedSpeeds, SqlDbType.NVarChar));
			stmt.AppendString(",ExperiencedStationSections=");
			stmt.AppendParameter(_session.MakeInParameter("ExperiencedStationSections", dao.ExperiencedStationSections, SqlDbType.NVarChar));
			stmt.AppendString(",AffectedDisasters=");
			stmt.AppendParameter(_session.MakeInParameter("AffectedDisasters", dao.AffectedDisasters, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的进场数据表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from ApproachInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的进场数据表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>进场数据表</returns>
		public ApproachInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ApproachInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			ApproachInfo approachInfo = new ApproachInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], approachInfo);
			}
			return approachInfo;
		}

		/// <summary>
		/// 获取所有的进场数据表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ApproachInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的进场数据表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<ApproachInfo> SelectAllCollection()
		{
			ObservableCollection<ApproachInfo> datas = new ObservableCollection<ApproachInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ApproachInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				ApproachInfo dao = new ApproachInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成ApproachInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">ApproachInfo实体类</param>
		public void DataRowToEntity(DataRow dr, ApproachInfo dao)
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
			if (dr["ResponderID"] == null || dr["ResponderID"] == DBNull.Value)
			{
				dao.ResponderID = null;
			}
			else
			{
				dao.ResponderID = dr["ResponderID"].ToString();
			}
			if (dr["ApprochID"] == null || dr["ApprochID"] == DBNull.Value)
			{
				dao.ApprochID = null;
			}
			else
			{
				dao.ApprochID = dr["ApprochID"].ToString();
			}
			if (dr["ApprochInfo"] == null || dr["ApprochInfo"] == DBNull.Value)
			{
				dao.ApprochInfo = null;
			}
			else
			{
				dao.ApprochInfo = dr["ApprochInfo"].ToString();
			}
			if (dr["ApproachType"] == null || dr["ApproachType"] == DBNull.Value)
			{
				dao.ApproachType = null;
			}
			else
			{
				dao.ApproachType = dr["ApproachType"].ToString();
			}
			if (dr["StartAnnunciatorName"] == null || dr["StartAnnunciatorName"] == DBNull.Value)
			{
				dao.StartAnnunciatorName = null;
			}
			else
			{
				dao.StartAnnunciatorName = dr["StartAnnunciatorName"].ToString();
			}
			if (dr["StartAnnunciatorDisplay"] == null || dr["StartAnnunciatorDisplay"] == DBNull.Value)
			{
				dao.StartAnnunciatorDisplay = null;
			}
			else
			{
				dao.StartAnnunciatorDisplay = dr["StartAnnunciatorDisplay"].ToString();
			}
			if (dr["EndAnnunciator"] == null || dr["EndAnnunciator"] == DBNull.Value)
			{
				dao.EndAnnunciator = null;
			}
			else
			{
				dao.EndAnnunciator = dr["EndAnnunciator"].ToString();
			}
			if (dr["ExperiencedResponders"] == null || dr["ExperiencedResponders"] == DBNull.Value)
			{
				dao.ExperiencedResponders = null;
			}
			else
			{
				dao.ExperiencedResponders = dr["ExperiencedResponders"].ToString();
			}
			if (dr["ExperiencedTurnouts"] == null || dr["ExperiencedTurnouts"] == DBNull.Value)
			{
				dao.ExperiencedTurnouts = null;
			}
			else
			{
				dao.ExperiencedTurnouts = dr["ExperiencedTurnouts"].ToString();
			}
			if (dr["ExperiencedSpeeds"] == null || dr["ExperiencedSpeeds"] == DBNull.Value)
			{
				dao.ExperiencedSpeeds = null;
			}
			else
			{
				dao.ExperiencedSpeeds = dr["ExperiencedSpeeds"].ToString();
			}
			if (dr["ExperiencedStationSections"] == null || dr["ExperiencedStationSections"] == DBNull.Value)
			{
				dao.ExperiencedStationSections = null;
			}
			else
			{
				dao.ExperiencedStationSections = dr["ExperiencedStationSections"].ToString();
			}
			if (dr["AffectedDisasters"] == null || dr["AffectedDisasters"] == DBNull.Value)
			{
				dao.AffectedDisasters = null;
			}
			else
			{
				dao.AffectedDisasters = dr["AffectedDisasters"].ToString();
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的ApproachInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">ApproachInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, ApproachInfo dao)
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
			data = reader["ResponderID"];
			if (data == null || data == DBNull.Value)
			{
				dao.ResponderID = null;
			}
			else
			{
				dao.ResponderID = data.ToString();
			}
			data = reader["ApprochID"];
			if (data == null || data == DBNull.Value)
			{
				dao.ApprochID = null;
			}
			else
			{
				dao.ApprochID = data.ToString();
			}
			data = reader["ApprochInfo"];
			if (data == null || data == DBNull.Value)
			{
				dao.ApprochInfo = null;
			}
			else
			{
				dao.ApprochInfo = data.ToString();
			}
			data = reader["ApproachType"];
			if (data == null || data == DBNull.Value)
			{
				dao.ApproachType = null;
			}
			else
			{
				dao.ApproachType = data.ToString();
			}
			data = reader["StartAnnunciatorName"];
			if (data == null || data == DBNull.Value)
			{
				dao.StartAnnunciatorName = null;
			}
			else
			{
				dao.StartAnnunciatorName = data.ToString();
			}
			data = reader["StartAnnunciatorDisplay"];
			if (data == null || data == DBNull.Value)
			{
				dao.StartAnnunciatorDisplay = null;
			}
			else
			{
				dao.StartAnnunciatorDisplay = data.ToString();
			}
			data = reader["EndAnnunciator"];
			if (data == null || data == DBNull.Value)
			{
				dao.EndAnnunciator = null;
			}
			else
			{
				dao.EndAnnunciator = data.ToString();
			}
			data = reader["ExperiencedResponders"];
			if (data == null || data == DBNull.Value)
			{
				dao.ExperiencedResponders = null;
			}
			else
			{
				dao.ExperiencedResponders = data.ToString();
			}
			data = reader["ExperiencedTurnouts"];
			if (data == null || data == DBNull.Value)
			{
				dao.ExperiencedTurnouts = null;
			}
			else
			{
				dao.ExperiencedTurnouts = data.ToString();
			}
			data = reader["ExperiencedSpeeds"];
			if (data == null || data == DBNull.Value)
			{
				dao.ExperiencedSpeeds = null;
			}
			else
			{
				dao.ExperiencedSpeeds = data.ToString();
			}
			data = reader["ExperiencedStationSections"];
			if (data == null || data == DBNull.Value)
			{
				dao.ExperiencedStationSections = null;
			}
			else
			{
				dao.ExperiencedStationSections = data.ToString();
			}
			data = reader["AffectedDisasters"];
			if (data == null || data == DBNull.Value)
			{
				dao.AffectedDisasters = null;
			}
			else
			{
				dao.AffectedDisasters = data.ToString();
			}
		}

		/// <summary>
		/// 获取所有的进场数据表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ApproachInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有进场数据表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ApproachInfo order by ID");
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