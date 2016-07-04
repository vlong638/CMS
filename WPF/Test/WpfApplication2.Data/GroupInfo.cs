namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 批次信息表
	/// </summary>
	[Serializable]
	[DataContract]
	public class GroupInfo : Sui.ComponentModel.DataModelBase
	{
		#region Fields
		/// <summary>
		/// 批次号
		/// </summary>
		private Guid _groupID;
		/// <summary>
		/// 批次名称
		/// </summary>
		private string _groupName;
		/// <summary>
		/// 导入时间
		/// </summary>
		private DateTime? _startTime;
		/// <summary>
		/// 操作员
		/// </summary>
		private string _operatorName;
		/// <summary>
		/// 是否成功导入
		/// </summary>
		private bool? _isSuccessed;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public GroupInfo()
		{
			_groupID = Guid.NewGuid();
			_groupName = null;
			_startTime = null;
			_operatorName = null;
			_isSuccessed = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public GroupInfo(GroupInfo source)
		{
			_groupID = source.GroupID;
			_groupName = source.GroupName;
			_startTime = source.StartTime;
			_operatorName = source.OperatorName;
			_isSuccessed = source.IsSuccessed;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public GroupInfo(Guid groupID, string groupName, DateTime? startTime, string operatorName, bool? isSuccessed)
		{
			_groupID = groupID;
			_groupName = groupName;
			_startTime = startTime;
			_operatorName = operatorName;
			_isSuccessed = isSuccessed;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of GroupInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public GroupInfo(DataRow dr)
		{
			object data;
			data = dr["GroupID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_groupID = Guid.NewGuid();
			}
			else
			{
				_groupID = Guid.Parse(data.ToString());
			}
			data = dr["GroupName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_groupName = null;
			}
			else
			{
				_groupName = data.ToString();
			}
			data = dr["StartTime"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_startTime = null;
			}
			else
			{
				_startTime = DateTime.Parse(data.ToString());
			}
			data = dr["OperatorName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_operatorName = null;
			}
			else
			{
				_operatorName = data.ToString();
			}
			data = dr["IsSuccessed"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_isSuccessed = null;
			}
			else
			{
				_isSuccessed = bool.Parse(data.ToString());
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// 批次号
		/// </summary>
		[DataMember]
		public Guid GroupID
		{
			get { return _groupID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _groupID, value, () => this.GroupID);
				}
				else
				{
					_groupID = value;
				}
			}
		}

		/// <summary>
		/// 批次名称
		/// </summary>
		[DataMember]
		public string GroupName
		{
			get { return _groupName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _groupName, value, () => this.GroupName);
				}
				else
				{
					_groupName = value;
				}
			}
		}

		/// <summary>
		/// 导入时间
		/// </summary>
		[DataMember]
		public DateTime? StartTime
		{
			get { return _startTime; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _startTime, value, () => this.StartTime);
				}
				else
				{
					_startTime = value;
				}
			}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		[DataMember]
		public string OperatorName
		{
			get { return _operatorName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _operatorName, value, () => this.OperatorName);
				}
				else
				{
					_operatorName = value;
				}
			}
		}

		/// <summary>
		/// 是否成功导入
		/// </summary>
		[DataMember]
		public bool? IsSuccessed
		{
			get { return _isSuccessed; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _isSuccessed, value, () => this.IsSuccessed);
				}
				else
				{
					_isSuccessed = value;
				}
			}
		}

		#endregion

		#region ManualCode
		/***PRESERVE_BEGIN MANUAL_CODE***/
		/***PRESERVE_END MANUAL_CODE***/
		#endregion
	}
}