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
	/// 断链信息表数据访问类
	/// </summary>
	public class ChainScissionInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="ChainScissionInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public ChainScissionInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增断链信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(ChainScissionInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into ChainScissionInfo(GroupID,LineName,Category,Type,StartMileage,EndMileage,LongChain,ShortChain) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("LineName", dao.LineName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Type", dao.Type, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StartMileage", dao.StartMileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("EndMileage", dao.EndMileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("LongChain", dao.LongChain, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("ShortChain", dao.ShortChain, SqlDbType.Int));
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
		/// 更新断链信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(ChainScissionInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update ChainScissionInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",LineName=");
			stmt.AppendParameter(_session.MakeInParameter("LineName", dao.LineName, SqlDbType.NVarChar));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",Type=");
			stmt.AppendParameter(_session.MakeInParameter("Type", dao.Type, SqlDbType.NVarChar));
			stmt.AppendString(",StartMileage=");
			stmt.AppendParameter(_session.MakeInParameter("StartMileage", dao.StartMileage, SqlDbType.NVarChar));
			stmt.AppendString(",EndMileage=");
			stmt.AppendParameter(_session.MakeInParameter("EndMileage", dao.EndMileage, SqlDbType.NVarChar));
			stmt.AppendString(",LongChain=");
			stmt.AppendParameter(_session.MakeInParameter("LongChain", dao.LongChain, SqlDbType.Int));
			stmt.AppendString(",ShortChain=");
			stmt.AppendParameter(_session.MakeInParameter("ShortChain", dao.ShortChain, SqlDbType.Int));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的断链信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from ChainScissionInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的断链信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>断链信息表</returns>
		public ChainScissionInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ChainScissionInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			ChainScissionInfo chainScissionInfo = new ChainScissionInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], chainScissionInfo);
			}
			return chainScissionInfo;
		}

		/// <summary>
		/// 获取所有的断链信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ChainScissionInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的断链信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<ChainScissionInfo> SelectAllCollection()
		{
			ObservableCollection<ChainScissionInfo> datas = new ObservableCollection<ChainScissionInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ChainScissionInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				ChainScissionInfo dao = new ChainScissionInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成ChainScissionInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">ChainScissionInfo实体类</param>
		public void DataRowToEntity(DataRow dr, ChainScissionInfo dao)
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
			if (dr["LineName"] == null || dr["LineName"] == DBNull.Value)
			{
				dao.LineName = null;
			}
			else
			{
				dao.LineName = dr["LineName"].ToString();
			}
			if (dr["Category"] == null || dr["Category"] == DBNull.Value)
			{
				dao.Category = int.MinValue;
			}
			else
			{
				dao.Category = int.Parse(dr["Category"].ToString());
			}
			if (dr["Type"] == null || dr["Type"] == DBNull.Value)
			{
				dao.Type = null;
			}
			else
			{
				dao.Type = dr["Type"].ToString();
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
			if (dr["LongChain"] == null || dr["LongChain"] == DBNull.Value)
			{
				dao.LongChain = null;
			}
			else
			{
				dao.LongChain = int.Parse(dr["LongChain"].ToString());
			}
			if (dr["ShortChain"] == null || dr["ShortChain"] == DBNull.Value)
			{
				dao.ShortChain = null;
			}
			else
			{
				dao.ShortChain = int.Parse(dr["ShortChain"].ToString());
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的ChainScissionInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">ChainScissionInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, ChainScissionInfo dao)
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
			data = reader["LineName"];
			if (data == null || data == DBNull.Value)
			{
				dao.LineName = null;
			}
			else
			{
				dao.LineName = data.ToString();
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
			data = reader["Type"];
			if (data == null || data == DBNull.Value)
			{
				dao.Type = null;
			}
			else
			{
				dao.Type = data.ToString();
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
			data = reader["LongChain"];
			if (data == null || data == DBNull.Value)
			{
				dao.LongChain = null;
			}
			else
			{
				dao.LongChain = int.Parse(data.ToString());
			}
			data = reader["ShortChain"];
			if (data == null || data == DBNull.Value)
			{
				dao.ShortChain = null;
			}
			else
			{
				dao.ShortChain = int.Parse(data.ToString());
			}
		}

		/// <summary>
		/// 获取所有的断链信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ChainScissionInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有断链信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from ChainScissionInfo order by ID");
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