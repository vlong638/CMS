namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 线路坡度表
	/// </summary>
	[Serializable]
	[DataContract]
	public class GradientInfo : Sui.ComponentModel.DataModelBase
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
		/// 起点站名
		/// </summary>
		private string _startStationName;
		/// <summary>
		/// 终点站名
		/// </summary>
		private string _endStationName;
		/// <summary>
		/// 行向类型
		/// </summary>
		private int _category;
		/// <summary>
		/// 坡度
		/// </summary>
		private decimal _gradient;
		/// <summary>
		/// 长度
		/// </summary>
		private int _length;
		/// <summary>
		/// 终点里程
		/// </summary>
		private string _endMileage;
		/// <summary>
		/// 备注
		/// </summary>
		private string _remark;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public GradientInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_startStationName = null;
			_endStationName = null;
			_category = int.MinValue;
			_gradient = decimal.MinValue;
			_length = int.MinValue;
			_endMileage = null;
			_remark = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public GradientInfo(GradientInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_startStationName = source.StartStationName;
			_endStationName = source.EndStationName;
			_category = source.Category;
			_gradient = source.Gradient;
			_length = source.Length;
			_endMileage = source.EndMileage;
			_remark = source.Remark;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public GradientInfo(Guid groupID, string startStationName, string endStationName, int category, decimal gradient, int length, string endMileage, string remark)
		{
			_groupID = groupID;
			_startStationName = startStationName;
			_endStationName = endStationName;
			_category = category;
			_gradient = gradient;
			_length = length;
			_endMileage = endMileage;
			_remark = remark;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public GradientInfo(int iD, Guid groupID, string startStationName, string endStationName, int category, decimal gradient, int length, string endMileage, string remark)
		{
			_iD = iD;
			_groupID = groupID;
			_startStationName = startStationName;
			_endStationName = endStationName;
			_category = category;
			_gradient = gradient;
			_length = length;
			_endMileage = endMileage;
			_remark = remark;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of GradientInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public GradientInfo(DataRow dr)
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
			data = dr["Category"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_category = int.MinValue;
			}
			else
			{
				_category = int.Parse(data.ToString());
			}
			data = dr["Gradient"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_gradient = decimal.MinValue;
			}
			else
			{
				_gradient = decimal.Parse(data.ToString());
			}
			data = dr["Length"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_length = int.MinValue;
			}
			else
			{
				_length = int.Parse(data.ToString());
			}
			data = dr["EndMileage"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_endMileage = null;
			}
			else
			{
				_endMileage = data.ToString();
			}
			data = dr["Remark"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_remark = null;
			}
			else
			{
				_remark = data.ToString();
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
		/// 起点站名
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
		/// 坡度
		/// </summary>
		[DataMember]
		public decimal Gradient
		{
			get { return _gradient; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _gradient, value, () => this.Gradient);
				}
				else
				{
					_gradient = value;
				}
			}
		}

		/// <summary>
		/// 长度
		/// </summary>
		[DataMember]
		public int Length
		{
			get { return _length; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _length, value, () => this.Length);
				}
				else
				{
					_length = value;
				}
			}
		}

		/// <summary>
		/// 终点里程
		/// </summary>
		[DataMember]
		public string EndMileage
		{
			get { return _endMileage; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _endMileage, value, () => this.EndMileage);
				}
				else
				{
					_endMileage = value;
				}
			}
		}

		/// <summary>
		/// 备注
		/// </summary>
		[DataMember]
		public string Remark
		{
			get { return _remark; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _remark, value, () => this.Remark);
				}
				else
				{
					_remark = value;
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