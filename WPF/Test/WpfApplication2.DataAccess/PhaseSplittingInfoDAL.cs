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
	/// 分相信息表数据访问类
	/// </summary>
	public class PhaseSplittingInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="PhaseSplittingInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public PhaseSplittingInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增分相信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(PhaseSplittingInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into PhaseSplittingInfo(GroupID,Category,StartMileage,EndMileage,Length,Remark1,Remark2) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StartMileage", dao.StartMileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("EndMileage", dao.EndMileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Length", dao.Length, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Remark1", dao.Remark1, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Remark2", dao.Remark2, SqlDbType.NVarChar));
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
		/// 更新分相信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(PhaseSplittingInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update PhaseSplittingInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",StartMileage=");
			stmt.AppendParameter(_session.MakeInParameter("StartMileage", dao.StartMileage, SqlDbType.NVarChar));
			stmt.AppendString(",EndMileage=");
			stmt.AppendParameter(_session.MakeInParameter("EndMileage", dao.EndMileage, SqlDbType.NVarChar));
			stmt.AppendString(",Length=");
			stmt.AppendParameter(_session.MakeInParameter("Length", dao.Length, SqlDbType.Int));
			stmt.AppendString(",Remark1=");
			stmt.AppendParameter(_session.MakeInParameter("Remark1", dao.Remark1, SqlDbType.NVarChar));
			stmt.AppendString(",Remark2=");
			stmt.AppendParameter(_session.MakeInParameter("Remark2", dao.Remark2, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的分相信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from PhaseSplittingInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的分相信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>分相信息表</returns>
		public PhaseSplittingInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from PhaseSplittingInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			PhaseSplittingInfo phaseSplittingInfo = new PhaseSplittingInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], phaseSplittingInfo);
			}
			return phaseSplittingInfo;
		}

		/// <summary>
		/// 获取所有的分相信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from PhaseSplittingInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的分相信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<PhaseSplittingInfo> SelectAllCollection()
		{
			ObservableCollection<PhaseSplittingInfo> datas = new ObservableCollection<PhaseSplittingInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from PhaseSplittingInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				PhaseSplittingInfo dao = new PhaseSplittingInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成PhaseSplittingInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">PhaseSplittingInfo实体类</param>
		public void DataRowToEntity(DataRow dr, PhaseSplittingInfo dao)
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
			if (dr["Length"] == null || dr["Length"] == DBNull.Value)
			{
				dao.Length = int.MinValue;
			}
			else
			{
				dao.Length = int.Parse(dr["Length"].ToString());
			}
			if (dr["Remark1"] == null || dr["Remark1"] == DBNull.Value)
			{
				dao.Remark1 = null;
			}
			else
			{
				dao.Remark1 = dr["Remark1"].ToString();
			}
			if (dr["Remark2"] == null || dr["Remark2"] == DBNull.Value)
			{
				dao.Remark2 = null;
			}
			else
			{
				dao.Remark2 = dr["Remark2"].ToString();
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的PhaseSplittingInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">PhaseSplittingInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, PhaseSplittingInfo dao)
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
			data = reader["Length"];
			if (data == null || data == DBNull.Value)
			{
				dao.Length = int.MinValue;
			}
			else
			{
				dao.Length = int.Parse(data.ToString());
			}
			data = reader["Remark1"];
			if (data == null || data == DBNull.Value)
			{
				dao.Remark1 = null;
			}
			else
			{
				dao.Remark1 = data.ToString();
			}
			data = reader["Remark2"];
			if (data == null || data == DBNull.Value)
			{
				dao.Remark2 = null;
			}
			else
			{
				dao.Remark2 = data.ToString();
			}
		}

		/// <summary>
		/// 获取所有的分相信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from PhaseSplittingInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有分相信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from PhaseSplittingInfo order by ID");
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