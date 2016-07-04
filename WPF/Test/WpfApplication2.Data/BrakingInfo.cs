namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 制动距离信息表
	/// </summary>
	[Serializable]
	[DataContract]
	public class BrakingInfo : Sui.ComponentModel.DataModelBase
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
		/// 速度
		/// </summary>
		private int _speed;
		/// <summary>
		/// 坡度
		/// </summary>
		private decimal _gradient;
		/// <summary>
		/// 300T制动距离
		/// </summary>
		private int _lengthFor300T;
		/// <summary>
		/// 牵引计算制动距离
		/// </summary>
		private int _lengthForPulling;
		/// <summary>
		/// 报文制动距离
		/// </summary>
		private int _lengthForMessage;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BrakingInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_speed = int.MinValue;
			_gradient = decimal.MinValue;
			_lengthFor300T = int.MinValue;
			_lengthForPulling = int.MinValue;
			_lengthForMessage = int.MinValue;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public BrakingInfo(BrakingInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_speed = source.Speed;
			_gradient = source.Gradient;
			_lengthFor300T = source.LengthFor300T;
			_lengthForPulling = source.LengthForPulling;
			_lengthForMessage = source.LengthForMessage;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public BrakingInfo(Guid groupID, int speed, decimal gradient, int lengthFor300T, int lengthForPulling, int lengthForMessage)
		{
			_groupID = groupID;
			_speed = speed;
			_gradient = gradient;
			_lengthFor300T = lengthFor300T;
			_lengthForPulling = lengthForPulling;
			_lengthForMessage = lengthForMessage;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public BrakingInfo(int iD, Guid groupID, int speed, decimal gradient, int lengthFor300T, int lengthForPulling, int lengthForMessage)
		{
			_iD = iD;
			_groupID = groupID;
			_speed = speed;
			_gradient = gradient;
			_lengthFor300T = lengthFor300T;
			_lengthForPulling = lengthForPulling;
			_lengthForMessage = lengthForMessage;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of BrakingInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public BrakingInfo(DataRow dr)
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
			data = dr["Speed"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_speed = int.MinValue;
			}
			else
			{
				_speed = int.Parse(data.ToString());
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
			data = dr["LengthFor300T"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_lengthFor300T = int.MinValue;
			}
			else
			{
				_lengthFor300T = int.Parse(data.ToString());
			}
			data = dr["LengthForPulling"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_lengthForPulling = int.MinValue;
			}
			else
			{
				_lengthForPulling = int.Parse(data.ToString());
			}
			data = dr["LengthForMessage"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_lengthForMessage = int.MinValue;
			}
			else
			{
				_lengthForMessage = int.Parse(data.ToString());
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
		/// 300T制动距离
		/// </summary>
		[DataMember]
		public int LengthFor300T
		{
			get { return _lengthFor300T; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _lengthFor300T, value, () => this.LengthFor300T);
				}
				else
				{
					_lengthFor300T = value;
				}
			}
		}

		/// <summary>
		/// 牵引计算制动距离
		/// </summary>
		[DataMember]
		public int LengthForPulling
		{
			get { return _lengthForPulling; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _lengthForPulling, value, () => this.LengthForPulling);
				}
				else
				{
					_lengthForPulling = value;
				}
			}
		}

		/// <summary>
		/// 报文制动距离
		/// </summary>
		[DataMember]
		public int LengthForMessage
		{
			get { return _lengthForMessage; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _lengthForMessage, value, () => this.LengthForMessage);
				}
				else
				{
					_lengthForMessage = value;
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