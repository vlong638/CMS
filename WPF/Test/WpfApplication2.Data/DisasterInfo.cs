namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 灾害信息表
	/// </summary>
	[Serializable]
	[DataContract]
	public class DisasterInfo : Sui.ComponentModel.DataModelBase
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
		/// 车站名称
		/// </summary>
		private string _stationName;
		/// <summary>
		/// 行向类别
		/// </summary>
		private int _category;
		/// <summary>
		/// 起点里程
		/// </summary>
		private string _startMileage;
		/// <summary>
		/// 终点里程
		/// </summary>
		private string _endMileage;
		/// <summary>
		/// 继电器名称
		/// </summary>
		private string _warningRelay;
		/// <summary>
		/// 侵限影响区段名称
		/// </summary>
		private string _affectedSectionName;
		/// <summary>
		/// 备注
		/// </summary>
		private string _remark;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DisasterInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_stationName = null;
			_category = int.MinValue;
			_startMileage = null;
			_endMileage = null;
			_warningRelay = null;
			_affectedSectionName = null;
			_remark = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public DisasterInfo(DisasterInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_stationName = source.StationName;
			_category = source.Category;
			_startMileage = source.StartMileage;
			_endMileage = source.EndMileage;
			_warningRelay = source.WarningRelay;
			_affectedSectionName = source.AffectedSectionName;
			_remark = source.Remark;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public DisasterInfo(Guid groupID, string stationName, int category, string startMileage, string endMileage, string warningRelay, string affectedSectionName, string remark)
		{
			_groupID = groupID;
			_stationName = stationName;
			_category = category;
			_startMileage = startMileage;
			_endMileage = endMileage;
			_warningRelay = warningRelay;
			_affectedSectionName = affectedSectionName;
			_remark = remark;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public DisasterInfo(int iD, Guid groupID, string stationName, int category, string startMileage, string endMileage, string warningRelay, string affectedSectionName, string remark)
		{
			_iD = iD;
			_groupID = groupID;
			_stationName = stationName;
			_category = category;
			_startMileage = startMileage;
			_endMileage = endMileage;
			_warningRelay = warningRelay;
			_affectedSectionName = affectedSectionName;
			_remark = remark;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of DisasterInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public DisasterInfo(DataRow dr)
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
			data = dr["StationName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_stationName = null;
			}
			else
			{
				_stationName = data.ToString();
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
			data = dr["StartMileage"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_startMileage = null;
			}
			else
			{
				_startMileage = data.ToString();
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
			data = dr["WarningRelay"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_warningRelay = null;
			}
			else
			{
				_warningRelay = data.ToString();
			}
			data = dr["AffectedSectionName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_affectedSectionName = null;
			}
			else
			{
				_affectedSectionName = data.ToString();
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
		/// 起点里程
		/// </summary>
		[DataMember]
		public string StartMileage
		{
			get { return _startMileage; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _startMileage, value, () => this.StartMileage);
				}
				else
				{
					_startMileage = value;
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
		/// 继电器名称
		/// </summary>
		[DataMember]
		public string WarningRelay
		{
			get { return _warningRelay; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _warningRelay, value, () => this.WarningRelay);
				}
				else
				{
					_warningRelay = value;
				}
			}
		}

		/// <summary>
		/// 侵限影响区段名称
		/// </summary>
		[DataMember]
		public string AffectedSectionName
		{
			get { return _affectedSectionName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _affectedSectionName, value, () => this.AffectedSectionName);
				}
				else
				{
					_affectedSectionName = value;
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
        /// 行向类别
        /// </summary>
        private string _categoryStr;
        [DataMember]
        public string CategoryStr
        {
            get { return _categoryStr; }
            set
            {
                WpfApplication2.Converter.ExcelConverter.ConvertCategory(value, ref _categoryStr);
                _category = int.Parse(_categoryStr);
            }
        }
		#endregion
	}
}