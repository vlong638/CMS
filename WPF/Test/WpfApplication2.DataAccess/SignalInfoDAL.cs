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
	/// 信号数据表数据访问类
	/// </summary>
	public class SignalInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="SignalInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public SignalInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增信号数据表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(SignalInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into SignalInfo(GroupID,Category,StationName,SignalName,SignalMileage,SignalType,IsolationType,SectionName,SectionCarrirer,SectionLength,SectionAttribute,Remark) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SignalName", dao.SignalName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SignalMileage", dao.SignalMileage, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SignalType", dao.SignalType, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("IsolationType", dao.IsolationType, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SectionName", dao.SectionName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SectionCarrirer", dao.SectionCarrirer, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SectionLength", dao.SectionLength, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("SectionAttribute", dao.SectionAttribute, SqlDbType.NVarChar));
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
		/// 更新信号数据表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(SignalInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update SignalInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",StationName=");
			stmt.AppendParameter(_session.MakeInParameter("StationName", dao.StationName, SqlDbType.NVarChar));
			stmt.AppendString(",SignalName=");
			stmt.AppendParameter(_session.MakeInParameter("SignalName", dao.SignalName, SqlDbType.NVarChar));
			stmt.AppendString(",SignalMileage=");
			stmt.AppendParameter(_session.MakeInParameter("SignalMileage", dao.SignalMileage, SqlDbType.NVarChar));
			stmt.AppendString(",SignalType=");
			stmt.AppendParameter(_session.MakeInParameter("SignalType", dao.SignalType, SqlDbType.Int));
			stmt.AppendString(",IsolationType=");
			stmt.AppendParameter(_session.MakeInParameter("IsolationType", dao.IsolationType, SqlDbType.Int));
			stmt.AppendString(",SectionName=");
			stmt.AppendParameter(_session.MakeInParameter("SectionName", dao.SectionName, SqlDbType.NVarChar));
			stmt.AppendString(",SectionCarrirer=");
			stmt.AppendParameter(_session.MakeInParameter("SectionCarrirer", dao.SectionCarrirer, SqlDbType.NVarChar));
			stmt.AppendString(",SectionLength=");
			stmt.AppendParameter(_session.MakeInParameter("SectionLength", dao.SectionLength, SqlDbType.Int));
			stmt.AppendString(",SectionAttribute=");
			stmt.AppendParameter(_session.MakeInParameter("SectionAttribute", dao.SectionAttribute, SqlDbType.NVarChar));
			stmt.AppendString(",Remark=");
			stmt.AppendParameter(_session.MakeInParameter("Remark", dao.Remark, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的信号数据表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from SignalInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的信号数据表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>信号数据表</returns>
		public SignalInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SignalInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			SignalInfo signalInfo = new SignalInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], signalInfo);
			}
			return signalInfo;
		}

		/// <summary>
		/// 获取所有的信号数据表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SignalInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的信号数据表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<SignalInfo> SelectAllCollection()
		{
			ObservableCollection<SignalInfo> datas = new ObservableCollection<SignalInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SignalInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				SignalInfo dao = new SignalInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成SignalInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">SignalInfo实体类</param>
		public void DataRowToEntity(DataRow dr, SignalInfo dao)
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
			if (dr["StationName"] == null || dr["StationName"] == DBNull.Value)
			{
				dao.StationName = null;
			}
			else
			{
				dao.StationName = dr["StationName"].ToString();
			}
			if (dr["SignalName"] == null || dr["SignalName"] == DBNull.Value)
			{
				dao.SignalName = null;
			}
			else
			{
				dao.SignalName = dr["SignalName"].ToString();
			}
			if (dr["SignalMileage"] == null || dr["SignalMileage"] == DBNull.Value)
			{
				dao.SignalMileage = null;
			}
			else
			{
				dao.SignalMileage = dr["SignalMileage"].ToString();
			}
			if (dr["SignalType"] == null || dr["SignalType"] == DBNull.Value)
			{
				dao.SignalType = int.MinValue;
			}
			else
			{
				dao.SignalType = int.Parse(dr["SignalType"].ToString());
			}
			if (dr["IsolationType"] == null || dr["IsolationType"] == DBNull.Value)
			{
				dao.IsolationType = int.MinValue;
			}
			else
			{
				dao.IsolationType = int.Parse(dr["IsolationType"].ToString());
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
			if (dr["SectionAttribute"] == null || dr["SectionAttribute"] == DBNull.Value)
			{
				dao.SectionAttribute = null;
			}
			else
			{
				dao.SectionAttribute = dr["SectionAttribute"].ToString();
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
		/// 获取指定的IDataReader中的SignalInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">SignalInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, SignalInfo dao)
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
			data = reader["StationName"];
			if (data == null || data == DBNull.Value)
			{
				dao.StationName = null;
			}
			else
			{
				dao.StationName = data.ToString();
			}
			data = reader["SignalName"];
			if (data == null || data == DBNull.Value)
			{
				dao.SignalName = null;
			}
			else
			{
				dao.SignalName = data.ToString();
			}
			data = reader["SignalMileage"];
			if (data == null || data == DBNull.Value)
			{
				dao.SignalMileage = null;
			}
			else
			{
				dao.SignalMileage = data.ToString();
			}
			data = reader["SignalType"];
			if (data == null || data == DBNull.Value)
			{
				dao.SignalType = int.MinValue;
			}
			else
			{
				dao.SignalType = int.Parse(data.ToString());
			}
			data = reader["IsolationType"];
			if (data == null || data == DBNull.Value)
			{
				dao.IsolationType = int.MinValue;
			}
			else
			{
				dao.IsolationType = int.Parse(data.ToString());
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
			data = reader["SectionAttribute"];
			if (data == null || data == DBNull.Value)
			{
				dao.SectionAttribute = null;
			}
			else
			{
				dao.SectionAttribute = data.ToString();
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
		/// 获取所有的信号数据表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SignalInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有信号数据表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from SignalInfo order by ID");
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