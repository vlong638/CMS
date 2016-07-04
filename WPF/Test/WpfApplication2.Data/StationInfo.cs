namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 车站信息
	/// </summary>
	[Serializable]
	[DataContract]
	public class StationInfo : Sui.ComponentModel.DataModelBase
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
		/// 大区编号
		/// </summary>
		private int _regionID;
		/// <summary>
		/// 小区编号
		/// </summary>
		private int _areaID;
		/// <summary>
		/// 车站编号
		/// </summary>
		private int _stationID;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StationInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_stationName = null;
			_regionID = int.MinValue;
			_areaID = int.MinValue;
			_stationID = int.MinValue;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public StationInfo(StationInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_stationName = source.StationName;
			_regionID = source.RegionID;
			_areaID = source.AreaID;
			_stationID = source.StationID;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public StationInfo(Guid groupID, string stationName, int regionID, int areaID, int stationID)
		{
			_groupID = groupID;
			_stationName = stationName;
			_regionID = regionID;
			_areaID = areaID;
			_stationID = stationID;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public StationInfo(int iD, Guid groupID, string stationName, int regionID, int areaID, int stationID)
		{
			_iD = iD;
			_groupID = groupID;
			_stationName = stationName;
			_regionID = regionID;
			_areaID = areaID;
			_stationID = stationID;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of StationInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public StationInfo(DataRow dr)
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
			data = dr["RegionID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_regionID = int.MinValue;
			}
			else
			{
				_regionID = int.Parse(data.ToString());
			}
			data = dr["AreaID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_areaID = int.MinValue;
			}
			else
			{
				_areaID = int.Parse(data.ToString());
			}
			data = dr["StationID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_stationID = int.MinValue;
			}
			else
			{
				_stationID = int.Parse(data.ToString());
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
		/// 大区编号
		/// </summary>
		[DataMember]
		public int RegionID
		{
			get { return _regionID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _regionID, value, () => this.RegionID);
				}
				else
				{
					_regionID = value;
				}
			}
		}

		/// <summary>
		/// 小区编号
		/// </summary>
		[DataMember]
		public int AreaID
		{
			get { return _areaID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _areaID, value, () => this.AreaID);
				}
				else
				{
					_areaID = value;
				}
			}
		}

		/// <summary>
		/// 车站编号
		/// </summary>
		[DataMember]
		public int StationID
		{
			get { return _stationID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _stationID, value, () => this.StationID);
				}
				else
				{
					_stationID = value;
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