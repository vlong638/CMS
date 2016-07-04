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
	/// 应答器位置数据访问类
	/// </summary>
	public class TransponderLocationDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="TransponderLocationDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public TransponderLocationDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增应答器位置
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(TransponderLocation dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into TransponderLocation(GroupID,Category,TransponderName,TransponderID,Mileage,Type,Usage,Remark1,Remark2) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("TransponderName", dao.TransponderName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("TransponderID", dao.TransponderID, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Mileage", dao.Mileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Type", dao.Type, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Usage", dao.Usage, SqlDbType.NVarChar));
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
		/// 更新应答器位置
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(TransponderLocation dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update TransponderLocation set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",TransponderName=");
			stmt.AppendParameter(_session.MakeInParameter("TransponderName", dao.TransponderName, SqlDbType.NVarChar));
			stmt.AppendString(",TransponderID=");
			stmt.AppendParameter(_session.MakeInParameter("TransponderID", dao.TransponderID, SqlDbType.NVarChar));
			stmt.AppendString(",Mileage=");
			stmt.AppendParameter(_session.MakeInParameter("Mileage", dao.Mileage, SqlDbType.NVarChar));
			stmt.AppendString(",Type=");
			stmt.AppendParameter(_session.MakeInParameter("Type", dao.Type, SqlDbType.NVarChar));
			stmt.AppendString(",Usage=");
			stmt.AppendParameter(_session.MakeInParameter("Usage", dao.Usage, SqlDbType.NVarChar));
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
		/// 删除指定主键的应答器位置
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from TransponderLocation where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的应答器位置
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>应答器位置</returns>
		public TransponderLocation SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TransponderLocation where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			TransponderLocation transponderLocation = new TransponderLocation();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], transponderLocation);
			}
			return transponderLocation;
		}

		/// <summary>
		/// 获取所有的应答器位置
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TransponderLocation");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的应答器位置集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<TransponderLocation> SelectAllCollection()
		{
			ObservableCollection<TransponderLocation> datas = new ObservableCollection<TransponderLocation>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TransponderLocation");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				TransponderLocation dao = new TransponderLocation();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成TransponderLocation
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">TransponderLocation实体类</param>
		public void DataRowToEntity(DataRow dr, TransponderLocation dao)
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
			if (dr["TransponderName"] == null || dr["TransponderName"] == DBNull.Value)
			{
				dao.TransponderName = null;
			}
			else
			{
				dao.TransponderName = dr["TransponderName"].ToString();
			}
			if (dr["TransponderID"] == null || dr["TransponderID"] == DBNull.Value)
			{
				dao.TransponderID = null;
			}
			else
			{
				dao.TransponderID = dr["TransponderID"].ToString();
			}
			if (dr["Mileage"] == null || dr["Mileage"] == DBNull.Value)
			{
				dao.Mileage = null;
			}
			else
			{
				dao.Mileage = dr["Mileage"].ToString();
			}
			if (dr["Type"] == null || dr["Type"] == DBNull.Value)
			{
				dao.Type = null;
			}
			else
			{
				dao.Type = dr["Type"].ToString();
			}
			if (dr["Usage"] == null || dr["Usage"] == DBNull.Value)
			{
				dao.Usage = null;
			}
			else
			{
				dao.Usage = dr["Usage"].ToString();
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
		/// 获取指定的IDataReader中的TransponderLocation
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">TransponderLocation实体类</param>
		public void DataReaderToEntity(IDataReader reader, TransponderLocation dao)
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
			data = reader["TransponderName"];
			if (data == null || data == DBNull.Value)
			{
				dao.TransponderName = null;
			}
			else
			{
				dao.TransponderName = data.ToString();
			}
			data = reader["TransponderID"];
			if (data == null || data == DBNull.Value)
			{
				dao.TransponderID = null;
			}
			else
			{
				dao.TransponderID = data.ToString();
			}
			data = reader["Mileage"];
			if (data == null || data == DBNull.Value)
			{
				dao.Mileage = null;
			}
			else
			{
				dao.Mileage = data.ToString();
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
			data = reader["Usage"];
			if (data == null || data == DBNull.Value)
			{
				dao.Usage = null;
			}
			else
			{
				dao.Usage = data.ToString();
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
		/// 获取所有的应答器位置
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TransponderLocation");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有应答器位置
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from TransponderLocation order by ID");
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