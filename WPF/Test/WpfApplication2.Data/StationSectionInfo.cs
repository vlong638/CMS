namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 站内区段信息
	/// </summary>
	[Serializable]
	[DataContract]
	public class StationSectionInfo : Sui.ComponentModel.DataModelBase
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
		/// 末端信号机类型
		/// </summary>
		private int? _layerType;
		/// <summary>
		/// 道岔名称
		/// </summary>
		private string _turnoutIDs;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StationSectionInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_stationName = null;
			_sectionName = null;
			_sectionCarrirer = null;
			_sectionLength = int.MinValue;
			_layerType = null;
			_turnoutIDs = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public StationSectionInfo(StationSectionInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_stationName = source.StationName;
			_sectionName = source.SectionName;
			_sectionCarrirer = source.SectionCarrirer;
			_sectionLength = source.SectionLength;
			_layerType = source.LayerType;
			_turnoutIDs = source.TurnoutIDs;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public StationSectionInfo(Guid groupID, string stationName, string sectionName, string sectionCarrirer, int sectionLength, int? layerType, string turnoutIDs)
		{
			_groupID = groupID;
			_stationName = stationName;
			_sectionName = sectionName;
			_sectionCarrirer = sectionCarrirer;
			_sectionLength = sectionLength;
			_layerType = layerType;
			_turnoutIDs = turnoutIDs;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public StationSectionInfo(int iD, Guid groupID, string stationName, string sectionName, string sectionCarrirer, int sectionLength, int? layerType, string turnoutIDs)
		{
			_iD = iD;
			_groupID = groupID;
			_stationName = stationName;
			_sectionName = sectionName;
			_sectionCarrirer = sectionCarrirer;
			_sectionLength = sectionLength;
			_layerType = layerType;
			_turnoutIDs = turnoutIDs;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of StationSectionInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public StationSectionInfo(DataRow dr)
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
			data = dr["LayerType"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_layerType = null;
			}
			else
			{
				_layerType = int.Parse(data.ToString());
			}
			data = dr["TurnoutIDs"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_turnoutIDs = null;
			}
			else
			{
				_turnoutIDs = data.ToString();
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
		/// 末端信号机类型
		/// </summary>
		[DataMember]
		public int? LayerType
		{
			get { return _layerType; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _layerType, value, () => this.LayerType);
				}
				else
				{
					_layerType = value;
				}
			}
		}

		/// <summary>
		/// 道岔名称
		/// </summary>
		[DataMember]
		public string TurnoutIDs
		{
			get { return _turnoutIDs; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _turnoutIDs, value, () => this.TurnoutIDs);
				}
				else
				{
					_turnoutIDs = value;
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