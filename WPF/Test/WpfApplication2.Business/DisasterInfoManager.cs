namespace WpfApplication2.Business
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Linq;
	using GenDB.Data;
	using WpfApplication2.Data;
	using WpfApplication2.DataAccess;

	/// <summary>
	/// 灾害信息表业务逻辑类
	/// </summary>
	public class DisasterInfoManager : BizBase
	{
		#region Fields
		private DisasterInfoDAL _dal;
		#endregion

		#region Constructors

		/// <summary>
		/// 初始化 <see cref="DisasterInfoManager" /> 类的新实例。
		/// </summary>
		/// <param name="session"></param>
		public DisasterInfoManager(ISession session)
			: base(session)
		{
			_dal = new DisasterInfoDAL(session);
		}

		/// <summary>
		/// 初始化 <see cref="DisasterInfoManager" /> 类的新实例。
		/// </summary>
		public DisasterInfoManager()
		{
			_dal = new DisasterInfoDAL(base.Session);
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
			bool ret = false;
			try
			{
				Session.Open();
				Session.BeginTransaction();
				ret = _dal.Insert(dao);
				Session.CommitTransaction();
			}
			catch (Exception err)
			{
				ret = false;
				Log.Error(dao, err);
				Session.RollBackTransaction();
			}
			finally
			{
				Session.Close();
			}
			return ret;
		}

		/// <summary>
		/// 更新灾害信息表
		/// </summary>
		/// <param name="dao">数据对象</param>
		/// <returns>成功/失败</returns>
		public bool Update(DisasterInfo dao)
		{
			bool ret = false;
			try
			{
				Session.Open();
				Session.BeginTransaction();
				ret = _dal.Update(dao);
				Session.CommitTransaction();
			}
			catch (Exception err)
			{
				ret = false;
				Log.Error(dao, err);
				Session.RollBackTransaction();
			}
			finally
			{
				Session.Close();
			}
			return ret;
		}
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="dao">数据对象</param>
        /// <returns>成功/失败</returns>
        public bool Insert(List<DisasterInfo> daos)
        {
            bool ret = true;
            try
            {
                Session.Open();
                Session.BeginTransaction();
                for (int i = 0; i < daos.Count; i++)
                {
                    _dal.Insert(daos[i]);
                }

                Session.CommitTransaction();
            }
            catch (Exception err)
            {
                ret = false;
                Log.Error(daos, err);
                Session.RollBackTransaction();
            }
            finally
            {
                Session.Close();
            }
            return ret;
        }
		/// <summary>
		/// 删除指定主键的灾害信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>成功/失败</returns>
		public bool Delete(int iD)
		{
			bool ret = false;
			try
			{
				Session.Open();
				Session.BeginTransaction();
				ret = _dal.Delete(iD);
				Session.CommitTransaction();
			}
			catch (Exception err)
			{
				ret = false;
				Log.Error("删除数据失败", err);
				Session.RollBackTransaction();
			}
			finally
			{
				Session.Close();
			}
			return ret;
		}

		/// <summary>
		/// 获取指定的灾害信息表
		/// </summary>
		/// <param name="iD">顺序号</param>
		/// <returns>灾害信息表</returns>
		public DisasterInfo SelectOne(int iD)
		{
			return _dal.SelectOne(iD);
		}

		/// <summary>
		/// 获取所有的灾害信息表
		/// </summary>
		/// <returns>所有信息</returns>
		public SqlResult SelectAll()
		{
			return _dal.SelectAll();
		}

		/// <summary>
		/// 获取所有的灾害信息表集合
		/// </summary>
		/// <returns>所有信息</returns>
		public ObservableCollection<DisasterInfo> SelectAllCollection()
		{
			return _dal.SelectAllCollection();
		}

		/// <summary>
		/// 获取指定大小的一页灾害信息表
		/// </summary>
		/// <param name="pageIndex">当前页码</param>
		/// <param name="pageSize">分页大小</param>
		/// <param name="rowsCount">总记录条数</param>
		/// <returns>分页数据</returns>
		public SqlResult SelectAll(int pageIndex, int pageSize, int rowsCount)
		{
			return Session.Excecute(_dal.SelectAllSqlStatementOrder(), pageIndex, pageSize, rowsCount);
		}

		/// <summary>
		/// 获取指定大小的一页灾害信息表集合
		/// </summary>
		/// <param name="pageIndex">当前页码</param>
		/// <param name="pageSize">分页大小</param>
		/// <param name="rowsCount">总记录条数</param>
		/// <returns>分页数据</returns>
		public ObservableCollection<DisasterInfo> SelectAllCollection(int pageIndex, int pageSize, int rowsCount)
		{
			ObservableCollection<DisasterInfo> datas = new ObservableCollection<DisasterInfo>();
			GenDataReader reader = Session.ExcecuteReader(_dal.SelectAllSqlStatement(), pageIndex, pageSize, rowsCount);
			while (reader.Read())
			{
				DisasterInfo dao = new DisasterInfo();
				_dal.DataReaderToEntity(reader, dao);
				datas.Add(dao);
			}
			reader.Close();
			return datas;
		}

		/// <summary>
		/// 获取灾害信息表的总记录数
		/// </summary>
		/// <returns>记录数</returns>
		public int GetAllRowsCount()
		{
			return Session.ExcecuteRowCount(_dal.SelectAllSqlStatement());
		}

		#endregion

		#region ManualCode
		/***PRESERVE_BEGIN MANUAL_CODE***/
		/***PRESERVE_END MANUAL_CODE***/
		#endregion
	}
}