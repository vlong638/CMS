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
	/// 制动距离信息表数据访问类
	/// </summary>
	public class BrakingInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="BrakingInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public BrakingInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增制动距离信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(BrakingInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into BrakingInfo(GroupID,Speed,Gradient,LengthFor300T,LengthForPulling,LengthForMessage) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Speed", dao.Speed, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Gradient", dao.Gradient, SqlDbType.Decimal));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("LengthFor300T", dao.LengthFor300T, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("LengthForPulling", dao.LengthForPulling, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("LengthForMessage", dao.LengthForMessage, SqlDbType.Int));
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
		/// 更新制动距离信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(BrakingInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update BrakingInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",Speed=");
			stmt.AppendParameter(_session.MakeInParameter("Speed", dao.Speed, SqlDbType.Int));
			stmt.AppendString(",Gradient=");
			stmt.AppendParameter(_session.MakeInParameter("Gradient", dao.Gradient, SqlDbType.Decimal));
			stmt.AppendString(",LengthFor300T=");
			stmt.AppendParameter(_session.MakeInParameter("LengthFor300T", dao.LengthFor300T, SqlDbType.Int));
			stmt.AppendString(",LengthForPulling=");
			stmt.AppendParameter(_session.MakeInParameter("LengthForPulling", dao.LengthForPulling, SqlDbType.Int));
			stmt.AppendString(",LengthForMessage=");
			stmt.AppendParameter(_session.MakeInParameter("LengthForMessage", dao.LengthForMessage, SqlDbType.Int));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的制动距离信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from BrakingInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的制动距离信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>制动距离信息表</returns>
		public BrakingInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from BrakingInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			BrakingInfo brakingInfo = new BrakingInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], brakingInfo);
			}
			return brakingInfo;
		}

		/// <summary>
		/// 获取所有的制动距离信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from BrakingInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的制动距离信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<BrakingInfo> SelectAllCollection()
		{
			ObservableCollection<BrakingInfo> datas = new ObservableCollection<BrakingInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from BrakingInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				BrakingInfo dao = new BrakingInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成BrakingInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">BrakingInfo实体类</param>
		public void DataRowToEntity(DataRow dr, BrakingInfo dao)
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
			if (dr["Speed"] == null || dr["Speed"] == DBNull.Value)
			{
				dao.Speed = int.MinValue;
			}
			else
			{
				dao.Speed = int.Parse(dr["Speed"].ToString());
			}
			if (dr["Gradient"] == null || dr["Gradient"] == DBNull.Value)
			{
				dao.Gradient = decimal.MinValue;
			}
			else
			{
				dao.Gradient = decimal.Parse(dr["Gradient"].ToString());
			}
			if (dr["LengthFor300T"] == null || dr["LengthFor300T"] == DBNull.Value)
			{
				dao.LengthFor300T = int.MinValue;
			}
			else
			{
				dao.LengthFor300T = int.Parse(dr["LengthFor300T"].ToString());
			}
			if (dr["LengthForPulling"] == null || dr["LengthForPulling"] == DBNull.Value)
			{
				dao.LengthForPulling = int.MinValue;
			}
			else
			{
				dao.LengthForPulling = int.Parse(dr["LengthForPulling"].ToString());
			}
			if (dr["LengthForMessage"] == null || dr["LengthForMessage"] == DBNull.Value)
			{
				dao.LengthForMessage = int.MinValue;
			}
			else
			{
				dao.LengthForMessage = int.Parse(dr["LengthForMessage"].ToString());
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的BrakingInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">BrakingInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, BrakingInfo dao)
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
			data = reader["Speed"];
			if (data == null || data == DBNull.Value)
			{
				dao.Speed = int.MinValue;
			}
			else
			{
				dao.Speed = int.Parse(data.ToString());
			}
			data = reader["Gradient"];
			if (data == null || data == DBNull.Value)
			{
				dao.Gradient = decimal.MinValue;
			}
			else
			{
				dao.Gradient = decimal.Parse(data.ToString());
			}
			data = reader["LengthFor300T"];
			if (data == null || data == DBNull.Value)
			{
				dao.LengthFor300T = int.MinValue;
			}
			else
			{
				dao.LengthFor300T = int.Parse(data.ToString());
			}
			data = reader["LengthForPulling"];
			if (data == null || data == DBNull.Value)
			{
				dao.LengthForPulling = int.MinValue;
			}
			else
			{
				dao.LengthForPulling = int.Parse(data.ToString());
			}
			data = reader["LengthForMessage"];
			if (data == null || data == DBNull.Value)
			{
				dao.LengthForMessage = int.MinValue;
			}
			else
			{
				dao.LengthForMessage = int.Parse(data.ToString());
			}
		}

		/// <summary>
		/// 获取所有的制动距离信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from BrakingInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有制动距离信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from BrakingInfo order by ID");
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