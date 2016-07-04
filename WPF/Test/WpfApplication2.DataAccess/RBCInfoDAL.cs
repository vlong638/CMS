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
	/// RBC信息表数据访问类
	/// </summary>
	public class RBCInfoDAL
	{
		#region Fields
		private ISession _session;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="RBCInfoDAL" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public RBCInfoDAL(ISession session)
		{
			_session = session;
		}

		#endregion

		#region Methods

		/// <summary>
		/// 新增RBC信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Insert(RBCInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("insert into RBCInfo(GroupID,Category,StartStationName,EndStationName,AreaID,RBCID,PhoneNum,StartPoint,Cutoff,EndPoint) values (");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StartStationName", dao.StartStationName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("EndStationName", dao.EndStationName, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("AreaID", dao.AreaID, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("RBCID", dao.RBCID, SqlDbType.Int));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("PhoneNum", dao.PhoneNum, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("StartPoint", dao.StartPoint, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("Cutoff", dao.Cutoff, SqlDbType.NVarChar));
			stmt.AppendString(",");
			stmt.AppendParameter(_session.MakeInParameter("EndPoint", dao.EndPoint, SqlDbType.NVarChar));
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
		/// 更新RBC信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(RBCInfo dao)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("update RBCInfo set ");
			stmt.AppendString("GroupID=");
			stmt.AppendParameter(_session.MakeInParameter("GroupID", dao.GroupID, SqlDbType.UniqueIdentifier));
			stmt.AppendString(",Category=");
			stmt.AppendParameter(_session.MakeInParameter("Category", dao.Category, SqlDbType.Int));
			stmt.AppendString(",StartStationName=");
			stmt.AppendParameter(_session.MakeInParameter("StartStationName", dao.StartStationName, SqlDbType.NVarChar));
			stmt.AppendString(",EndStationName=");
			stmt.AppendParameter(_session.MakeInParameter("EndStationName", dao.EndStationName, SqlDbType.NVarChar));
			stmt.AppendString(",AreaID=");
			stmt.AppendParameter(_session.MakeInParameter("AreaID", dao.AreaID, SqlDbType.Int));
			stmt.AppendString(",RBCID=");
			stmt.AppendParameter(_session.MakeInParameter("RBCID", dao.RBCID, SqlDbType.Int));
			stmt.AppendString(",PhoneNum=");
			stmt.AppendParameter(_session.MakeInParameter("PhoneNum", dao.PhoneNum, SqlDbType.NVarChar));
			stmt.AppendString(",StartPoint=");
			stmt.AppendParameter(_session.MakeInParameter("StartPoint", dao.StartPoint, SqlDbType.NVarChar));
			stmt.AppendString(",Cutoff=");
			stmt.AppendParameter(_session.MakeInParameter("Cutoff", dao.Cutoff, SqlDbType.NVarChar));
			stmt.AppendString(",EndPoint=");
			stmt.AppendParameter(_session.MakeInParameter("EndPoint", dao.EndPoint, SqlDbType.NVarChar));
			stmt.AppendString(" where ");
			stmt.AppendString("ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", dao.ID, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Update;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 删除指定主键的RBC信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("delete from RBCInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Delete;
			return _session.Excecute(stmt).RowsAffected > 0;
		}

		/// <summary>
		/// 获取指定的RBC信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>RBC信息表</returns>
		public RBCInfo SelectOne(int iD)
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from RBCInfo where ID=");
			stmt.AppendParameter(_session.MakeInParameter("ID", iD, SqlDbType.Int));
			stmt.StatementType = SqlStatementType.Select;
			SqlResult result = _session.Excecute(stmt);
			RBCInfo rBCInfo = new RBCInfo();
			if (result.RowsAffected > 0)
			{
				DataRowToEntity(result.Tables[0].Rows[0], rBCInfo);
			}
			return rBCInfo;
		}

		/// <summary>
		/// 获取所有的RBC信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from RBCInfo");
			stmt.StatementType = SqlStatementType.Select;
			return _session.Excecute(stmt);
		}

		/// <summary>
		/// 获取所有的RBC信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<RBCInfo> SelectAllCollection()
		{
			ObservableCollection<RBCInfo> datas = new ObservableCollection<RBCInfo>();
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from RBCInfo");
			stmt.StatementType = SqlStatementType.Select;
			GenDataReader reader = _session.ExcecuteReader(stmt);
			while (reader.Read())
			{
				RBCInfo dao = new RBCInfo();
				DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取指定的数据行DataRow转换成RBCInfo
		/// </summary>
		/// <param name="dr">DataRow数据</param>
		/// <param name="dao">RBCInfo实体类</param>
		public void DataRowToEntity(DataRow dr, RBCInfo dao)
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
			if (dr["StartStationName"] == null || dr["StartStationName"] == DBNull.Value)
			{
				dao.StartStationName = null;
			}
			else
			{
				dao.StartStationName = dr["StartStationName"].ToString();
			}
			if (dr["EndStationName"] == null || dr["EndStationName"] == DBNull.Value)
			{
				dao.EndStationName = null;
			}
			else
			{
				dao.EndStationName = dr["EndStationName"].ToString();
			}
			if (dr["AreaID"] == null || dr["AreaID"] == DBNull.Value)
			{
				dao.AreaID = int.MinValue;
			}
			else
			{
				dao.AreaID = int.Parse(dr["AreaID"].ToString());
			}
			if (dr["RBCID"] == null || dr["RBCID"] == DBNull.Value)
			{
				dao.RBCID = int.MinValue;
			}
			else
			{
				dao.RBCID = int.Parse(dr["RBCID"].ToString());
			}
			if (dr["PhoneNum"] == null || dr["PhoneNum"] == DBNull.Value)
			{
				dao.PhoneNum = null;
			}
			else
			{
				dao.PhoneNum = dr["PhoneNum"].ToString();
			}
			if (dr["StartPoint"] == null || dr["StartPoint"] == DBNull.Value)
			{
				dao.StartPoint = null;
			}
			else
			{
				dao.StartPoint = dr["StartPoint"].ToString();
			}
			if (dr["Cutoff"] == null || dr["Cutoff"] == DBNull.Value)
			{
				dao.Cutoff = null;
			}
			else
			{
				dao.Cutoff = dr["Cutoff"].ToString();
			}
			if (dr["EndPoint"] == null || dr["EndPoint"] == DBNull.Value)
			{
				dao.EndPoint = null;
			}
			else
			{
				dao.EndPoint = dr["EndPoint"].ToString();
			}
		}

		/// <summary>
		/// 获取指定的IDataReader中的RBCInfo
		/// </summary>
		/// <param name="reader">IDataReader对象</param>
		/// <param name="dao">RBCInfo实体类</param>
		public void DataReaderToEntity(IDataReader reader, RBCInfo dao)
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
			data = reader["StartStationName"];
			if (data == null || data == DBNull.Value)
			{
				dao.StartStationName = null;
			}
			else
			{
				dao.StartStationName = data.ToString();
			}
			data = reader["EndStationName"];
			if (data == null || data == DBNull.Value)
			{
				dao.EndStationName = null;
			}
			else
			{
				dao.EndStationName = data.ToString();
			}
			data = reader["AreaID"];
			if (data == null || data == DBNull.Value)
			{
				dao.AreaID = int.MinValue;
			}
			else
			{
				dao.AreaID = int.Parse(data.ToString());
			}
			data = reader["RBCID"];
			if (data == null || data == DBNull.Value)
			{
				dao.RBCID = int.MinValue;
			}
			else
			{
				dao.RBCID = int.Parse(data.ToString());
			}
			data = reader["PhoneNum"];
			if (data == null || data == DBNull.Value)
			{
				dao.PhoneNum = null;
			}
			else
			{
				dao.PhoneNum = data.ToString();
			}
			data = reader["StartPoint"];
			if (data == null || data == DBNull.Value)
			{
				dao.StartPoint = null;
			}
			else
			{
				dao.StartPoint = data.ToString();
			}
			data = reader["Cutoff"];
			if (data == null || data == DBNull.Value)
			{
				dao.Cutoff = null;
			}
			else
			{
				dao.Cutoff = data.ToString();
			}
			data = reader["EndPoint"];
			if (data == null || data == DBNull.Value)
			{
				dao.EndPoint = null;
			}
			else
			{
				dao.EndPoint = data.ToString();
			}
		}

		/// <summary>
		/// 获取所有的RBC信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatement()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from RBCInfo");
			stmt.StatementType = SqlStatementType.Select;
			return stmt;
		}

		/// <summary>
		/// 获取按主键排序的所有RBC信息表
		/// </summary>
		/// <returns>Sql语句块</returns>
		public SqlStatement SelectAllSqlStatementOrder()
		{
			SqlStatement stmt = _session.CreateSqlStatement();
			stmt.AppendString("select * from RBCInfo order by ID");
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