namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 信号数据表
	/// </summary>
	[Serializable]
	[DataContract]
	public class SignalInfo : Sui.ComponentModel.DataModelBase
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
		/// 车站名
		/// </summary>
		private string _stationName;
		/// <summary>
		/// 信号点名称
		/// </summary>
		private string _signalName;
		/// <summary>
		/// 信号点里程
		/// </summary>
		private string _signalMileage;
		/// <summary>
		/// 信号点类型
		/// </summary>
		private int _signalType;
		/// <summary>
		/// 绝缘节类型
		/// </summary>
		private int _isolationType;
		/// <summary>
		/// 区段名称
		/// </summary>
		private string _sectionName;
		/// <summary>
		/// 区段载频
		/// </summary>
		private string _sectionCarrirer;
		/// <summary>
		/// 区段长度
		/// </summary>
		private int _sectionLength;
		/// <summary>
		/// 区段属性
		/// </summary>
		private string _sectionAttribute;
		/// <summary>
		/// 备注
		/// </summary>
		private string _remark;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SignalInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_category = int.MinValue;
			_stationName = null;
			_signalName = null;
			_signalMileage = null;
			_signalType = int.MinValue;
			_isolationType = int.MinValue;
			_sectionName = null;
			_sectionCarrirer = null;
			_sectionLength = int.MinValue;
			_sectionAttribute = null;
			_remark = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public SignalInfo(SignalInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_category = source.Category;
			_stationName = source.StationName;
			_signalName = source.SignalName;
			_signalMileage = source.SignalMileage;
			_signalType = source.SignalType;
			_isolationType = source.IsolationType;
			_sectionName = source.SectionName;
			_sectionCarrirer = source.SectionCarrirer;
			_sectionLength = source.SectionLength;
			_sectionAttribute = source.SectionAttribute;
			_remark = source.Remark;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public SignalInfo(Guid groupID, int category, string stationName, string signalName, string signalMileage, int signalType, int isolationType, string sectionName, string sectionCarrirer, int sectionLength, string sectionAttribute, string remark)
		{
			_groupID = groupID;
			_category = category;
			_stationName = stationName;
			_signalName = signalName;
			_signalMileage = signalMileage;
			_signalType = signalType;
			_isolationType = isolationType;
			_sectionName = sectionName;
			_sectionCarrirer = sectionCarrirer;
			_sectionLength = sectionLength;
			_sectionAttribute = sectionAttribute;
			_remark = remark;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public SignalInfo(int iD, Guid groupID, int category, string stationName, string signalName, string signalMileage, int signalType, int isolationType, string sectionName, string sectionCarrirer, int sectionLength, string sectionAttribute, string remark)
		{
			_iD = iD;
			_groupID = groupID;
			_category = category;
			_stationName = stationName;
			_signalName = signalName;
			_signalMileage = signalMileage;
			_signalType = signalType;
			_isolationType = isolationType;
			_sectionName = sectionName;
			_sectionCarrirer = sectionCarrirer;
			_sectionLength = sectionLength;
			_sectionAttribute = sectionAttribute;
			_remark = remark;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of SignalInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public SignalInfo(DataRow dr)
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
			data = dr["StationName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_stationName = null;
			}
			else
			{
				_stationName = data.ToString();
			}
			data = dr["SignalName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_signalName = null;
			}
			else
			{
				_signalName = data.ToString();
			}
			data = dr["SignalMileage"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_signalMileage = null;
			}
			else
			{
				_signalMileage = data.ToString();
			}
			data = dr["SignalType"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_signalType = int.MinValue;
			}
			else
			{
				_signalType = int.Parse(data.ToString());
			}
			data = dr["IsolationType"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_isolationType = int.MinValue;
			}
			else
			{
				_isolationType = int.Parse(data.ToString());
			}
			data = dr["SectionName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_sectionName = null;
			}
			else
			{
				_sectionName = data.ToString();
			}
			data = dr["SectionCarrirer"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_sectionCarrirer = null;
			}
			else
			{
				_sectionCarrirer = data.ToString();
			}
			data = dr["SectionLength"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_sectionLength = int.MinValue;
			}
			else
			{
				_sectionLength = int.Parse(data.ToString());
			}
			data = dr["SectionAttribute"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_sectionAttribute = null;
			}
			else
			{
				_sectionAttribute = data.ToString();
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
		/// 车站名
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
		/// 信号点名称
		/// </summary>
		[DataMember]
		public string SignalName
		{
			get { return _signalName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _signalName, value, () => this.SignalName);
				}
				else
				{
					_signalName = value;
				}
			}
		}

		/// <summary>
		/// 信号点里程
		/// </summary>
		[DataMember]
		public string SignalMileage
		{
			get { return _signalMileage; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _signalMileage, value, () => this.SignalMileage);
				}
				else
				{
					_signalMileage = value;
				}
			}
		}

		/// <summary>
		/// 信号点类型
		/// </summary>
		[DataMember]
		public int SignalType
		{
			get { return _signalType; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _signalType, value, () => this.SignalType);
				}
				else
				{
					_signalType = value;
				}
			}
		}

		/// <summary>
		/// 绝缘节类型
		/// </summary>
		[DataMember]
		public int IsolationType
		{
			get { return _isolationType; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _isolationType, value, () => this.IsolationType);
				}
				else
				{
					_isolationType = value;
				}
			}
		}

		/// <summary>
		/// 区段名称
		/// </summary>
		[DataMember]
		public string SectionName
		{
			get { return _sectionName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _sectionName, value, () => this.SectionName);
				}
				else
				{
					_sectionName = value;
				}
			}
		}

		/// <summary>
		/// 区段载频
		/// </summary>
		[DataMember]
		public string SectionCarrirer
		{
			get { return _sectionCarrirer; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _sectionCarrirer, value, () => this.SectionCarrirer);
				}
				else
				{
					_sectionCarrirer = value;
				}
			}
		}

		/// <summary>
		/// 区段长度
		/// </summary>
		[DataMember]
		public int SectionLength
		{
			get { return _sectionLength; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _sectionLength, value, () => this.SectionLength);
				}
				else
				{
					_sectionLength = value;
				}
			}
		}

		/// <summary>
		/// 区段属性
		/// </summary>
		[DataMember]
		public string SectionAttribute
		{
			get { return _sectionAttribute; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _sectionAttribute, value, () => this.SectionAttribute);
				}
				else
				{
					_sectionAttribute = value;
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
        /// <summary>
        /// 信号点类型
        /// </summary>
        private string _signalTypeStr;
        [DataMember]
        public string SignalTypeStr
        {
            get { return _signalTypeStr; }
            set
            {
                _signalTypeStr = value;
                WpfApplication2.Converter.ExcelConverter.ConvertSignalType(value, ref _signalType);
            }
        }
        /// <summary>
        /// 绝缘节类型
        /// </summary>
        private string _isolationTypeStr;
        [DataMember]
        public string IsolationTypeStr
        {
            get { return _isolationTypeStr; }
            set
            {
                _isolationTypeStr = value;
                WpfApplication2.Converter.ExcelConverter.ConvertIsolocationType(value, ref _isolationType);
            }
        }
		#endregion
	}
}