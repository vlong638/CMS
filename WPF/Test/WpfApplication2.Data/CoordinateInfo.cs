namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 坐标系信息表
	/// </summary>
	[Serializable]
	[DataContract]
	public class CoordinateInfo : Sui.ComponentModel.DataModelBase
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
		/// 坐标系编号
		/// </summary>
		private string _coordinateID;
		/// <summary>
		/// 坐标系名称
		/// </summary>
		private string _coordinateName;
		/// <summary>
		/// 长度
		/// </summary>
		private string _length;
		/// <summary>
		/// 备注
		/// </summary>
		private string _remark;
		/// <summary>
		/// 是否与坐标系方向相反
		/// </summary>
		private string _isReversed;
		/// <summary>
		/// 本坐标系公里标
		/// </summary>
		private string _currentMileage;
		/// <summary>
		/// 临界坐标系公里表
		/// </summary>
		private string _edgeMileage;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public CoordinateInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_category = int.MinValue;
			_coordinateID = null;
			_coordinateName = null;
			_length = null;
			_remark = null;
			_isReversed = null;
			_currentMileage = null;
			_edgeMileage = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public CoordinateInfo(CoordinateInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_category = source.Category;
			_coordinateID = source.CoordinateID;
			_coordinateName = source.CoordinateName;
			_length = source.Length;
			_remark = source.Remark;
			_isReversed = source.IsReversed;
			_currentMileage = source.CurrentMileage;
			_edgeMileage = source.EdgeMileage;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public CoordinateInfo(Guid groupID, int category, string coordinateID, string coordinateName, string length, string remark, string isReversed, string currentMileage, string edgeMileage)
		{
			_groupID = groupID;
			_category = category;
			_coordinateID = coordinateID;
			_coordinateName = coordinateName;
			_length = length;
			_remark = remark;
			_isReversed = isReversed;
			_currentMileage = currentMileage;
			_edgeMileage = edgeMileage;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public CoordinateInfo(int iD, Guid groupID, int category, string coordinateID, string coordinateName, string length, string remark, string isReversed, string currentMileage, string edgeMileage)
		{
			_iD = iD;
			_groupID = groupID;
			_category = category;
			_coordinateID = coordinateID;
			_coordinateName = coordinateName;
			_length = length;
			_remark = remark;
			_isReversed = isReversed;
			_currentMileage = currentMileage;
			_edgeMileage = edgeMileage;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of CoordinateInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public CoordinateInfo(DataRow dr)
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
			data = dr["CoordinateID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_coordinateID = null;
			}
			else
			{
				_coordinateID = data.ToString();
			}
			data = dr["CoordinateName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_coordinateName = null;
			}
			else
			{
				_coordinateName = data.ToString();
			}
			data = dr["Length"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_length = null;
			}
			else
			{
				_length = data.ToString();
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
			data = dr["IsReversed"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_isReversed = null;
			}
			else
			{
				_isReversed = data.ToString();
			}
			data = dr["CurrentMileage"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_currentMileage = null;
			}
			else
			{
				_currentMileage = data.ToString();
			}
			data = dr["EdgeMileage"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_edgeMileage = null;
			}
			else
			{
				_edgeMileage = data.ToString();
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
		/// 坐标系编号
		/// </summary>
		[DataMember]
		public string CoordinateID
		{
			get { return _coordinateID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _coordinateID, value, () => this.CoordinateID);
				}
				else
				{
					_coordinateID = value;
				}
			}
		}

		/// <summary>
		/// 坐标系名称
		/// </summary>
		[DataMember]
		public string CoordinateName
		{
			get { return _coordinateName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _coordinateName, value, () => this.CoordinateName);
				}
				else
				{
					_coordinateName = value;
				}
			}
		}

		/// <summary>
		/// 长度
		/// </summary>
		[DataMember]
		public string Length
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

		/// <summary>
		/// 是否与坐标系方向相反
		/// </summary>
		[DataMember]
		public string IsReversed
		{
			get { return _isReversed; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _isReversed, value, () => this.IsReversed);
				}
				else
				{
					_isReversed = value;
				}
			}
		}

		/// <summary>
		/// 本坐标系公里标
		/// </summary>
		[DataMember]
		public string CurrentMileage
		{
			get { return _currentMileage; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _currentMileage, value, () => this.CurrentMileage);
				}
				else
				{
					_currentMileage = value;
				}
			}
		}

		/// <summary>
		/// 临界坐标系公里表
		/// </summary>
		[DataMember]
		public string EdgeMileage
		{
			get { return _edgeMileage; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _edgeMileage, value, () => this.EdgeMileage);
				}
				else
				{
					_edgeMileage = value;
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