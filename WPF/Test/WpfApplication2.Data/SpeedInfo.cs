namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 线路速度表
	/// </summary>
	[Serializable]
	[DataContract]
	public class SpeedInfo : Sui.ComponentModel.DataModelBase
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
		/// 行向类别
		/// </summary>
		private int _category;
		/// <summary>
		/// 速度
		/// </summary>
		private int _speed;
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
		public SpeedInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_category = int.MinValue;
			_speed = int.MinValue;
			_length = int.MinValue;
			_endMileage = null;
			_remark = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public SpeedInfo(SpeedInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_category = source.Category;
			_speed = source.Speed;
			_length = source.Length;
			_endMileage = source.EndMileage;
			_remark = source.Remark;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public SpeedInfo(Guid groupID, int category, int speed, int length, string endMileage, string remark)
		{
			_groupID = groupID;
			_category = category;
			_speed = speed;
			_length = length;
			_endMileage = endMileage;
			_remark = remark;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public SpeedInfo(int iD, Guid groupID, int category, int speed, int length, string endMileage, string remark)
		{
			_iD = iD;
			_groupID = groupID;
			_category = category;
			_speed = speed;
			_length = length;
			_endMileage = endMileage;
			_remark = remark;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of SpeedInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public SpeedInfo(DataRow dr)
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
			data = dr["Speed"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_speed = int.MinValue;
			}
			else
			{
				_speed = int.Parse(data.ToString());
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
		/// 行向类别
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
		/// 速度
		/// </summary>
		[DataMember]
		public int Speed
		{
			get { return _speed; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _speed, value, () => this.Speed);
				}
				else
				{
					_speed = value;
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