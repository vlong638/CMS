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
	/// 坐标系信息表数据访问类
	/// </summary>
	public class CoordinateInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="CoordinateInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public CoordinateInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增坐标系信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(CoordinateInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into CoordinateInfo(GroupID,Category,CoordinateID,CoordinateName,Length,Remark,IsReversed,CurrentMileage,EdgeMileage) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("CoordinateID", dao.CoordinateID, SqlDbType.VarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("CoordinateName", dao.CoordinateName, SqlDbType.VarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Length", dao.Length, SqlDbType.VarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Remark", dao.Remark, SqlDbType.VarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("IsReversed", dao.IsReversed, SqlDbType.VarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("CurrentMileage", dao.CurrentMileage, SqlDbType.VarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("EdgeMileage", dao.EdgeMileage, SqlDbType.VarChar));
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
		/// 更新坐标系信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(CoordinateInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update CoordinateInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",CoordinateID=");
			stmt.AppendParameter(_session.MakeInParameter("CoordinateID", dao.CoordinateID, SqlDbType.VarChar));
			stmt.AppendString(",CoordinateName=");
			stmt.AppendParameter(_session.MakeInParameter("CoordinateName", dao.CoordinateName, SqlDbType.VarChar));
			stmt.AppendString(",Length=");
			stmt.AppendParameter(_session.MakeInParameter("Length", dao.Length, SqlDbType.VarChar));
			stmt.AppendString(",Remark=");
			stmt.AppendParameter(_session.MakeInParameter("Remark", dao.Remark, SqlDbType.VarChar));
			stmt.AppendString(",IsReversed=");
			stmt.AppendParameter(_session.MakeInParameter("IsReversed", dao.IsReversed, SqlDbType.VarChar));
			stmt.AppendString(",CurrentMileage=");
			stmt.AppendParameter(_session.MakeInParameter("CurrentMileage", dao.CurrentMileage, SqlDbType.VarChar));
			stmt.AppendString(",EdgeMileage=");
			stmt.AppendParameter(_session.MakeInParameter("EdgeMileage", dao.EdgeMileage, SqlDbType.VarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的坐标系信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from CoordinateInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的坐标系信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>坐标系信息表</returns>
		public CoordinateInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from CoordinateInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			CoordinateInfo coordinateInfo = new CoordinateInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], coordinateInfo);
			}
			return coordinateInfo;
		}

		/// <summary>
		/// 获取所有的坐标系信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from CoordinateInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的坐标系信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<CoordinateInfo> SelectAllCollection()
		{
			ObservableCollection<CoordinateInfo> datas = new ObservableCollection<CoordinateInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from CoordinateInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				CoordinateInfo dao = new CoordinateInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成CoordinateInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">CoordinateInfo实体类</param>
		public void DataRowToEntity(DataRow dr, CoordinateInfo dao)
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
			if (dr["CoordinateID"] == null || dr["CoordinateID"] == DBNull.Value)
			{
				dao.CoordinateID = null;
			}
			else
			{
				dao.CoordinateID = dr["CoordinateID"].ToString();
			}
			if (dr["CoordinateName"] == null || dr["CoordinateName"] == DBNull.Value)
			{
				dao.CoordinateName = null;
			}
			else
			{
				dao.CoordinateName = dr["CoordinateName"].ToString();
			}
			if (dr["Length"] == null || dr["Length"] == DBNull.Value)
			{
				dao.Length = null;
			}
			else
			{
				dao.Length = dr["Length"].ToString();
			}
			if (dr["Remark"] == null || dr["Remark"] == DBNull.Value)
			{
				dao.Remark = null;
			}
			else
			{
				dao.Remark = dr["Remark"].ToString();
			}
			if (dr["IsReversed"] == null || dr["IsReversed"] == DBNull.Value)
			{
				dao.IsReversed = null;
			}
			else
			{
				dao.IsReversed = dr["IsReversed"].ToString();
			}
			if (dr["CurrentMileage"] == null || dr["CurrentMileage"] == DBNull.Value)
			{
				dao.CurrentMileage = null;
			}
			else
			{
				dao.CurrentMileage = dr["CurrentMileage"].ToString();
			}
			if (dr["EdgeMileage"] == null || dr["EdgeMileage"] == DBNull.Value)
			{
				dao.EdgeMileage = null;
			}
			else
			{
				dao.EdgeMileage = dr["EdgeMileage"].ToString();
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的CoordinateInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">CoordinateInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, CoordinateInfo dao)
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
			data = reader["CoordinateID"];
			if (data == null || data == DBNull.Value)
			{
				dao.CoordinateID = null;
			}
			else
			{
				dao.CoordinateID = data.ToString();
			}
			data = reader["CoordinateName"];
			if (data == null || data == DBNull.Value)
			{
				dao.CoordinateName = null;
			}
			else
			{
				dao.CoordinateName = data.ToString();
			}
			data = reader["Length"];
			if (data == null || data == DBNull.Value)
			{
				dao.Length = null;
			}
			else
			{
				dao.Length = data.ToString();
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
			data = reader["IsReversed"];
			if (data == null || data == DBNull.Value)
			{
				dao.IsReversed = null;
			}
			else
			{
				dao.IsReversed = data.ToString();
			}
			data = reader["CurrentMileage"];
			if (data == null || data == DBNull.Value)
			{
				dao.CurrentMileage = null;
			}
			else
			{
				dao.CurrentMileage = data.ToString();
			}
			data = reader["EdgeMileage"];
			if (data == null || data == DBNull.Value)
			{
				dao.EdgeMileage = null;
			}
			else
			{
				dao.EdgeMileage = data.ToString();
			}
		}

		/// <summary>
		/// 获取所有的坐标系信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from CoordinateInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有坐标系信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from CoordinateInfo order by ID");
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