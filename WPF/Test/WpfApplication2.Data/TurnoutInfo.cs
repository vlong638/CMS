namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 道岔信息表
	/// </summary>
	[Serializable]
	[DataContract]
	public class TurnoutInfo : Sui.ComponentModel.DataModelBase
	{
		#region Fields
		/// <summary>
		/// 顺序表
		/// </summary>
		private int _iD;
		/// <summary>
		/// 批次号
		/// </summary>
		private Guid _groupID;
		/// <summary>
		/// 行向类别
		/// </summary>
		private int? _category;
		/// <summary>
		/// 车站名称
		/// </summary>
		private string _stationName;
		/// <summary>
		/// 道岔名称
		/// </summary>
		private int _turnoutName;
		/// <summary>
		/// 岔尖里程
		/// </summary>
		private string _mileage;
		/// <summary>
		/// 正线/侧线
		/// </summary>
		private string _siding;
		/// <summary>
		/// 容许速度
		/// </summary>
		private int _speed;
		/// <summary>
		/// 三四线
		/// </summary>
		private string _tFLine;
		/// <summary>
		/// 预留字段1
		/// </summary>
		private string _default1;
		/// <summary>
		/// 预留字段2
		/// </summary>
		private string _default2;
		/// <summary>
		/// 定位开向侧线
		/// </summary>
		private string _default3;
		/// <summary>
		/// 侧位进入何区
		/// </summary>
		private string _default4;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TurnoutInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_category = null;
			_stationName = null;
			_turnoutName = int.MinValue;
			_mileage = null;
			_siding = null;
			_speed = int.MinValue;
			_tFLine = null;
			_default1 = null;
			_default2 = null;
			_default3 = null;
			_default4 = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public TurnoutInfo(TurnoutInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_category = source.Category;
			_stationName = source.StationName;
			_turnoutName = source.TurnoutName;
			_mileage = source.Mileage;
			_siding = source.Siding;
			_speed = source.Speed;
			_tFLine = source.TFLine;
			_default1 = source.Default1;
			_default2 = source.Default2;
			_default3 = source.Default3;
			_default4 = source.Default4;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public TurnoutInfo(Guid groupID, int? category, string stationName, int turnoutName, string mileage, string siding, int speed, string tFLine, string default1, string default2, string default3, string default4)
		{
			_groupID = groupID;
			_category = category;
			_stationName = stationName;
			_turnoutName = turnoutName;
			_mileage = mileage;
			_siding = siding;
			_speed = speed;
			_tFLine = tFLine;
			_default1 = default1;
			_default2 = default2;
			_default3 = default3;
			_default4 = default4;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public TurnoutInfo(int iD, Guid groupID, int? category, string stationName, int turnoutName, string mileage, string siding, int speed, string tFLine, string default1, string default2, string default3, string default4)
		{
			_iD = iD;
			_groupID = groupID;
			_category = category;
			_stationName = stationName;
			_turnoutName = turnoutName;
			_mileage = mileage;
			_siding = siding;
			_speed = speed;
			_tFLine = tFLine;
			_default1 = default1;
			_default2 = default2;
			_default3 = default3;
			_default4 = default4;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of TurnoutInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public TurnoutInfo(DataRow dr)
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
				_category = null;
			}
			else
			{
				_category = int.Parse(data.ToString());
			}
			data = dr["StationName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_stationName = null;
			}
			else
			{
				_stationName = data.ToString();
			}
			data = dr["TurnoutName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_turnoutName = int.MinValue;
			}
			else
			{
				_turnoutName = int.Parse(data.ToString());
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
			data = dr["Siding"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_siding = null;
			}
			else
			{
				_siding = data.ToString();
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
			data = dr["TFLine"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_tFLine = null;
			}
			else
			{
				_tFLine = data.ToString();
			}
			data = dr["default1"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_default1 = null;
			}
			else
			{
				_default1 = data.ToString();
			}
			data = dr["default2"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_default2 = null;
			}
			else
			{
				_default2 = data.ToString();
			}
			data = dr["default3"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_default3 = null;
			}
			else
			{
				_default3 = data.ToString();
			}
			data = dr["default4"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_default4 = null;
			}
			else
			{
				_default4 = data.ToString();
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// 顺序表
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
		public int? Category
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
		/// 车站名称
		/// </summary>
		[DataMember]
		public string StationName
		{
			get { return _stationName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _stationName, value, () => this.StationName);
				}
				else
				{
					_stationName = value;
				}
			}
		}

		/// <summary>
		/// 道岔名称
		/// </summary>
		[DataMember]
		public int TurnoutName
		{
			get { return _turnoutName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _turnoutName, value, () => this.TurnoutName);
				}
				else
				{
					_turnoutName = value;
				}
			}
		}

		/// <summary>
		/// 岔尖里程
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
		/// 正线/侧线
		/// </summary>
		[DataMember]
		public string Siding
		{
			get { return _siding; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _siding, value, () => this.Siding);
				}
				else
				{
					_siding = value;
				}
			}
		}

		/// <summary>
		/// 容许速度
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
		/// 三四线
		/// </summary>
		[DataMember]
		public string TFLine
		{
			get { return _tFLine; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _tFLine, value, () => this.TFLine);
				}
				else
				{
					_tFLine = value;
				}
			}
		}

		/// <summary>
		/// 预留字段1
		/// </summary>
		[DataMember]
		public string Default1
		{
			get { return _default1; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _default1, value, () => this.Default1);
				}
				else
				{
					_default1 = value;
				}
			}
		}

		/// <summary>
		/// 预留字段2
		/// </summary>
		[DataMember]
		public string Default2
		{
			get { return _default2; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _default2, value, () => this.Default2);
				}
				else
				{
					_default2 = value;
				}
			}
		}

		/// <summary>
		/// 定位开向侧线
		/// </summary>
		[DataMember]
		public string Default3
		{
			get { return _default3; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _default3, value, () => this.Default3);
				}
				else
				{
					_default3 = value;
				}
			}
		}

		/// <summary>
		/// 侧位进入何区
		/// </summary>
		[DataMember]
		public string Default4
		{
			get { return _default4; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _default4, value, () => this.Default4);
				}
				else
				{
					_default4 = value;
				}
			}
		}

		#endregion

        #region ManualCode
        /// <summary>
        /// 行向类别
        /// </summary>
        private string _categoryStr;
        [DataMember]
        public string CategoryStr
        {
            get { return Category.ToString(); }
            set
            {
                WpfApplication2.Converter.ExcelConverter.ConvertCategory(value, ref _categoryStr);
                _category = int.Parse(_categoryStr);
            }
        }
		#endregion
	}
}