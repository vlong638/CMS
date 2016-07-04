namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 应答器位置
	/// </summary>
	[Serializable]
	[DataContract]
	public class TransponderLocation : Sui.ComponentModel.DataModelBase
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
		/// 应答器名称
		/// </summary>
		private string _transponderName;
		/// <summary>
		/// 应答器编码
		/// </summary>
		private string _transponderID;
		/// <summary>
		/// 里程
		/// </summary>
		private string _mileage;
		/// <summary>
		/// 设备类型
		/// </summary>
		private string _type;
		/// <summary>
		/// 用途
		/// </summary>
		private string _usage;
		/// <summary>
		/// 备注1
		/// </summary>
		private string _remark1;
		/// <summary>
		/// 备注2
		/// </summary>
		private string _remark2;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TransponderLocation()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_category = int.MinValue;
			_transponderName = null;
			_transponderID = null;
			_mileage = null;
			_type = null;
			_usage = null;
			_remark1 = null;
			_remark2 = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public TransponderLocation(TransponderLocation source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_category = source.Category;
			_transponderName = source.TransponderName;
			_transponderID = source.TransponderID;
			_mileage = source.Mileage;
			_type = source.Type;
			_usage = source.Usage;
			_remark1 = source.Remark1;
			_remark2 = source.Remark2;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public TransponderLocation(Guid groupID, int category, string transponderName, string transponderID, string mileage, string type, string usage, string remark1, string remark2)
		{
			_groupID = groupID;
			_category = category;
			_transponderName = transponderName;
			_transponderID = transponderID;
			_mileage = mileage;
			_type = type;
			_usage = usage;
			_remark1 = remark1;
			_remark2 = remark2;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public TransponderLocation(int iD, Guid groupID, int category, string transponderName, string transponderID, string mileage, string type, string usage, string remark1, string remark2)
		{
			_iD = iD;
			_groupID = groupID;
			_category = category;
			_transponderName = transponderName;
			_transponderID = transponderID;
			_mileage = mileage;
			_type = type;
			_usage = usage;
			_remark1 = remark1;
			_remark2 = remark2;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of TransponderLocation.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public TransponderLocation(DataRow dr)
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
			data = dr["TransponderName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_transponderName = null;
			}
			else
			{
				_transponderName = data.ToString();
			}
			data = dr["TransponderID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_transponderID = null;
			}
			else
			{
				_transponderID = data.ToString();
			}
			data = dr["Mileage"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_mileage = null;
			}
			else
			{
				_mileage = data.ToString();
			}
			data = dr["Type"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_type = null;
			}
			else
			{
				_type = data.ToString();
			}
			data = dr["Usage"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_usage = null;
			}
			else
			{
				_usage = data.ToString();
			}
			data = dr["Remark1"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_remark1 = null;
			}
			else
			{
				_remark1 = data.ToString();
			}
			data = dr["Remark2"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_remark2 = null;
			}
			else
			{
				_remark2 = data.ToString();
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
		/// 应答器名称
		/// </summary>
		[DataMember]
		public string TransponderName
		{
			get { return _transponderName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _transponderName, value, () => this.TransponderName);
				}
				else
				{
					_transponderName = value;
				}
			}
		}

		/// <summary>
		/// 应答器编码
		/// </summary>
		[DataMember]
		public string TransponderID
		{
			get { return _transponderID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _transponderID, value, () => this.TransponderID);
				}
				else
				{
					_transponderID = value;
				}
			}
		}

		/// <summary>
		/// 里程
		/// </summary>
		[DataMember]
		public string Mileage
		{
			get { return _mileage; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _mileage, value, () => this.Mileage);
				}
				else
				{
					_mileage = value;
				}
			}
		}

		/// <summary>
		/// 设备类型
		/// </summary>
		[DataMember]
		public string Type
		{
			get { return _type; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _type, value, () => this.Type);
				}
				else
				{
					_type = value;
				}
			}
		}

		/// <summary>
		/// 用途
		/// </summary>
		[DataMember]
		public string Usage
		{
			get { return _usage; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _usage, value, () => this.Usage);
				}
				else
				{
					_usage = value;
				}
			}
		}

		/// <summary>
		/// 备注1
		/// </summary>
		[DataMember]
		public string Remark1
		{
			get { return _remark1; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _remark1, value, () => this.Remark1);
				}
				else
				{
					_remark1 = value;
				}
			}
		}

		/// <summary>
		/// 备注2
		/// </summary>
		[DataMember]
		public string Remark2
		{
			get { return _remark2; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _remark2, value, () => this.Remark2);
				}
				else
				{
					_remark2 = value;
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