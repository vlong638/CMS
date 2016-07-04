namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// RBC信息表
	/// </summary>
	[Serializable]
	[DataContract]
	public class RBCInfo : Sui.ComponentModel.DataModelBase
	{
		#region Fields
		/// <summary>
		/// 顺序号
		/// </summary>
		private int _iD;
		/// <summary>
		/// 批次号
		/// </summary>
		private Guid _groupID;
		/// <summary>
		/// 行向类型
		/// </summary>
		private int _category;
		/// <summary>
		/// 起始站名
		/// </summary>
		private string _startStationName;
		/// <summary>
		/// 终点站名
		/// </summary>
		private string _endStationName;
		/// <summary>
		/// 地区编号
		/// </summary>
		private int _areaID;
		/// <summary>
		/// RBC编号
		/// </summary>
		private int _rBCID;
		/// <summary>
		/// 电话号码
		/// </summary>
		private string _phoneNum;
		/// <summary>
		/// 起点
		/// </summary>
		private string _startPoint;
		/// <summary>
		/// 分界
		/// </summary>
		private string _cutoff;
		/// <summary>
		/// 终点
		/// </summary>
		private string _endPoint;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public RBCInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_category = int.MinValue;
			_startStationName = null;
			_endStationName = null;
			_areaID = int.MinValue;
			_rBCID = int.MinValue;
			_phoneNum = null;
			_startPoint = null;
			_cutoff = null;
			_endPoint = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public RBCInfo(RBCInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_category = source.Category;
			_startStationName = source.StartStationName;
			_endStationName = source.EndStationName;
			_areaID = source.AreaID;
			_rBCID = source.RBCID;
			_phoneNum = source.PhoneNum;
			_startPoint = source.StartPoint;
			_cutoff = source.Cutoff;
			_endPoint = source.EndPoint;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public RBCInfo(Guid groupID, int category, string startStationName, string endStationName, int areaID, int rBCID, string phoneNum, string startPoint, string cutoff, string endPoint)
		{
			_groupID = groupID;
			_category = category;
			_startStationName = startStationName;
			_endStationName = endStationName;
			_areaID = areaID;
			_rBCID = rBCID;
			_phoneNum = phoneNum;
			_startPoint = startPoint;
			_cutoff = cutoff;
			_endPoint = endPoint;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public RBCInfo(int iD, Guid groupID, int category, string startStationName, string endStationName, int areaID, int rBCID, string phoneNum, string startPoint, string cutoff, string endPoint)
		{
			_iD = iD;
			_groupID = groupID;
			_category = category;
			_startStationName = startStationName;
			_endStationName = endStationName;
			_areaID = areaID;
			_rBCID = rBCID;
			_phoneNum = phoneNum;
			_startPoint = startPoint;
			_cutoff = cutoff;
			_endPoint = endPoint;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of RBCInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public RBCInfo(DataRow dr)
		{
			object data;
			data = dr["ID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_iD = int.MinValue;
			}
			else
			{
				_iD = int.Parse(data.ToString());
			}
			data = dr["GroupID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_groupID = Guid.NewGuid();
			}
			else
			{
				_groupID = Guid.Parse(data.ToString());
			}
			data = dr["Category"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_category = int.MinValue;
			}
			else
			{
				_category = int.Parse(data.ToString());
			}
			data = dr["StartStationName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_startStationName = null;
			}
			else
			{
				_startStationName = data.ToString();
			}
			data = dr["EndStationName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_endStationName = null;
			}
			else
			{
				_endStationName = data.ToString();
			}
			data = dr["AreaID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_areaID = int.MinValue;
			}
			else
			{
				_areaID = int.Parse(data.ToString());
			}
			data = dr["RBCID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_rBCID = int.MinValue;
			}
			else
			{
				_rBCID = int.Parse(data.ToString());
			}
			data = dr["PhoneNum"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_phoneNum = null;
			}
			else
			{
				_phoneNum = data.ToString();
			}
			data = dr["StartPoint"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_startPoint = null;
			}
			else
			{
				_startPoint = data.ToString();
			}
			data = dr["Cutoff"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_cutoff = null;
			}
			else
			{
				_cutoff = data.ToString();
			}
			data = dr["EndPoint"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_endPoint = null;
			}
			else
			{
				_endPoint = data.ToString();
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// 顺序号
		/// </summary>
		[DataMember]
		public int ID
		{
			get { return _iD; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _iD, value, () => this.ID);
				}
				else
				{
					_iD = value;
				}
			}
		}

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
		/// 行向类型
		/// </summary>
		[DataMember]
		public int Category
		{
			get { return _category; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _category, value, () => this.Category);
				}
				else
				{
					_category = value;
				}
			}
		}

		/// <summary>
		/// 起始站名
		/// </summary>
		[DataMember]
		public string StartStationName
		{
			get { return _startStationName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _startStationName, value, () => this.StartStationName);
				}
				else
				{
					_startStationName = value;
				}
			}
		}

		/// <summary>
		/// 终点站名
		/// </summary>
		[DataMember]
		public string EndStationName
		{
			get { return _endStationName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _endStationName, value, () => this.EndStationName);
				}
				else
				{
					_endStationName = value;
				}
			}
		}

		/// <summary>
		/// 地区编号
		/// </summary>
		[DataMember]
		public int AreaID
		{
			get { return _areaID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _areaID, value, () => this.AreaID);
				}
				else
				{
					_areaID = value;
				}
			}
		}

		/// <summary>
		/// RBC编号
		/// </summary>
		[DataMember]
		public int RBCID
		{
			get { return _rBCID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _rBCID, value, () => this.RBCID);
				}
				else
				{
					_rBCID = value;
				}
			}
		}

		/// <summary>
		/// 电话号码
		/// </summary>
		[DataMember]
		public string PhoneNum
		{
			get { return _phoneNum; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _phoneNum, value, () => this.PhoneNum);
				}
				else
				{
					_phoneNum = value;
				}
			}
		}

		/// <summary>
		/// 起点
		/// </summary>
		[DataMember]
		public string StartPoint
		{
			get { return _startPoint; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _startPoint, value, () => this.StartPoint);
				}
				else
				{
					_startPoint = value;
				}
			}
		}

		/// <summary>
		/// 分界
		/// </summary>
		[DataMember]
		public string Cutoff
		{
			get { return _cutoff; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _cutoff, value, () => this.Cutoff);
				}
				else
				{
					_cutoff = value;
				}
			}
		}

		/// <summary>
		/// 终点
		/// </summary>
		[DataMember]
		public string EndPoint
		{
			get { return _endPoint; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _endPoint, value, () => this.EndPoint);
				}
				else
				{
					_endPoint = value;
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