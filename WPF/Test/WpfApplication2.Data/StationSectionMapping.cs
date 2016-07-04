namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 站内轨道区段与道岔映射表
	/// </summary>
	[Serializable]
	[DataContract]
	public class StationSectionMapping : Sui.ComponentModel.DataModelBase
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
		/// 区段名称
		/// </summary>
		private string _sectionName;
		/// <summary>
		/// 车站名称
		/// </summary>
		private string _stationName;
		/// <summary>
		/// 道岔集
		/// </summary>
		private string _turnoutIDs;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StationSectionMapping()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_sectionName = null;
			_stationName = null;
			_turnoutIDs = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public StationSectionMapping(StationSectionMapping source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_sectionName = source.SectionName;
			_stationName = source.StationName;
			_turnoutIDs = source.TurnoutIDs;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public StationSectionMapping(Guid groupID, string sectionName, string stationName, string turnoutIDs)
		{
			_groupID = groupID;
			_sectionName = sectionName;
			_stationName = stationName;
			_turnoutIDs = turnoutIDs;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public StationSectionMapping(int iD, Guid groupID, string sectionName, string stationName, string turnoutIDs)
		{
			_iD = iD;
			_groupID = groupID;
			_sectionName = sectionName;
			_stationName = stationName;
			_turnoutIDs = turnoutIDs;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of StationSectionMapping.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public StationSectionMapping(DataRow dr)
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
			data = dr["SectionName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_sectionName = null;
			}
			else
			{
				_sectionName = data.ToString();
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
		/// 道岔集
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