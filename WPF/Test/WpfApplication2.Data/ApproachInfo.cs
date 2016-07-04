namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 进场数据表
	/// </summary>
	[Serializable]
	[DataContract]
	public class ApproachInfo : Sui.ComponentModel.DataModelBase
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
		/// 应答器编号
		/// </summary>
		private string _responderID;
		/// <summary>
		/// 联锁进路编号
		/// </summary>
		private string _approchID;
		/// <summary>
		/// 进路信息
		/// </summary>
		private string _approchInfo;
		/// <summary>
		/// 进路类型
		/// </summary>
		private string _approachType;
		/// <summary>
		/// 始端信号机名称
		/// </summary>
		private string _startAnnunciatorName;
		/// <summary>
		/// 始端信号机显示
		/// </summary>
		private string _startAnnunciatorDisplay;
		/// <summary>
		/// 终端信号机
		/// </summary>
		private string _endAnnunciator;
		/// <summary>
		/// 应答器
		/// </summary>
		private string _experiencedResponders;
		/// <summary>
		/// 道岔
		/// </summary>
		private string _experiencedTurnouts;
		/// <summary>
		/// 线路速度
		/// </summary>
		private string _experiencedSpeeds;
		/// <summary>
		/// 轨道区段
		/// </summary>
		private string _experiencedStationSections;
		/// <summary>
		/// 灾害区段
		/// </summary>
		private string _affectedDisasters;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ApproachInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_responderID = null;
			_approchID = null;
			_approchInfo = null;
			_approachType = null;
			_startAnnunciatorName = null;
			_startAnnunciatorDisplay = null;
			_endAnnunciator = null;
			_experiencedResponders = null;
			_experiencedTurnouts = null;
			_experiencedSpeeds = null;
			_experiencedStationSections = null;
			_affectedDisasters = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public ApproachInfo(ApproachInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_responderID = source.ResponderID;
			_approchID = source.ApprochID;
			_approchInfo = source.ApprochInfo;
			_approachType = source.ApproachType;
			_startAnnunciatorName = source.StartAnnunciatorName;
			_startAnnunciatorDisplay = source.StartAnnunciatorDisplay;
			_endAnnunciator = source.EndAnnunciator;
			_experiencedResponders = source.ExperiencedResponders;
			_experiencedTurnouts = source.ExperiencedTurnouts;
			_experiencedSpeeds = source.ExperiencedSpeeds;
			_experiencedStationSections = source.ExperiencedStationSections;
			_affectedDisasters = source.AffectedDisasters;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public ApproachInfo(Guid groupID, string responderID, string approchID, string approchInfo, string approachType, string startAnnunciatorName, string startAnnunciatorDisplay, string endAnnunciator, string experiencedResponders, string experiencedTurnouts, string experiencedSpeeds, string experiencedStationSections, string affectedDisasters)
		{
			_groupID = groupID;
			_responderID = responderID;
			_approchID = approchID;
			_approchInfo = approchInfo;
			_approachType = approachType;
			_startAnnunciatorName = startAnnunciatorName;
			_startAnnunciatorDisplay = startAnnunciatorDisplay;
			_endAnnunciator = endAnnunciator;
			_experiencedResponders = experiencedResponders;
			_experiencedTurnouts = experiencedTurnouts;
			_experiencedSpeeds = experiencedSpeeds;
			_experiencedStationSections = experiencedStationSections;
			_affectedDisasters = affectedDisasters;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public ApproachInfo(int iD, Guid groupID, string responderID, string approchID, string approchInfo, string approachType, string startAnnunciatorName, string startAnnunciatorDisplay, string endAnnunciator, string experiencedResponders, string experiencedTurnouts, string experiencedSpeeds, string experiencedStationSections, string affectedDisasters)
		{
			_iD = iD;
			_groupID = groupID;
			_responderID = responderID;
			_approchID = approchID;
			_approchInfo = approchInfo;
			_approachType = approachType;
			_startAnnunciatorName = startAnnunciatorName;
			_startAnnunciatorDisplay = startAnnunciatorDisplay;
			_endAnnunciator = endAnnunciator;
			_experiencedResponders = experiencedResponders;
			_experiencedTurnouts = experiencedTurnouts;
			_experiencedSpeeds = experiencedSpeeds;
			_experiencedStationSections = experiencedStationSections;
			_affectedDisasters = affectedDisasters;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of ApproachInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public ApproachInfo(DataRow dr)
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
			data = dr["ResponderID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_responderID = null;
			}
			else
			{
				_responderID = data.ToString();
			}
			data = dr["ApprochID"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_approchID = null;
			}
			else
			{
				_approchID = data.ToString();
			}
			data = dr["ApprochInfo"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_approchInfo = null;
			}
			else
			{
				_approchInfo = data.ToString();
			}
			data = dr["ApproachType"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_approachType = null;
			}
			else
			{
				_approachType = data.ToString();
			}
			data = dr["StartAnnunciatorName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_startAnnunciatorName = null;
			}
			else
			{
				_startAnnunciatorName = data.ToString();
			}
			data = dr["StartAnnunciatorDisplay"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_startAnnunciatorDisplay = null;
			}
			else
			{
				_startAnnunciatorDisplay = data.ToString();
			}
			data = dr["EndAnnunciator"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_endAnnunciator = null;
			}
			else
			{
				_endAnnunciator = data.ToString();
			}
			data = dr["ExperiencedResponders"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_experiencedResponders = null;
			}
			else
			{
				_experiencedResponders = data.ToString();
			}
			data = dr["ExperiencedTurnouts"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_experiencedTurnouts = null;
			}
			else
			{
				_experiencedTurnouts = data.ToString();
			}
			data = dr["ExperiencedSpeeds"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_experiencedSpeeds = null;
			}
			else
			{
				_experiencedSpeeds = data.ToString();
			}
			data = dr["ExperiencedStationSections"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_experiencedStationSections = null;
			}
			else
			{
				_experiencedStationSections = data.ToString();
			}
			data = dr["AffectedDisasters"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_affectedDisasters = null;
			}
			else
			{
				_affectedDisasters = data.ToString();
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
		/// 应答器编号
		/// </summary>
		[DataMember]
		public string ResponderID
		{
			get { return _responderID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _responderID, value, () => this.ResponderID);
				}
				else
				{
					_responderID = value;
				}
			}
		}

		/// <summary>
		/// 联锁进路编号
		/// </summary>
		[DataMember]
		public string ApprochID
		{
			get { return _approchID; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _approchID, value, () => this.ApprochID);
				}
				else
				{
					_approchID = value;
				}
			}
		}

		/// <summary>
		/// 进路信息
		/// </summary>
		[DataMember]
		public string ApprochInfo
		{
			get { return _approchInfo; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _approchInfo, value, () => this.ApprochInfo);
				}
				else
				{
					_approchInfo = value;
				}
			}
		}

		/// <summary>
		/// 进路类型
		/// </summary>
		[DataMember]
		public string ApproachType
		{
			get { return _approachType; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _approachType, value, () => this.ApproachType);
				}
				else
				{
					_approachType = value;
				}
			}
		}

		/// <summary>
		/// 始端信号机名称
		/// </summary>
		[DataMember]
		public string StartAnnunciatorName
		{
			get { return _startAnnunciatorName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _startAnnunciatorName, value, () => this.StartAnnunciatorName);
				}
				else
				{
					_startAnnunciatorName = value;
				}
			}
		}

		/// <summary>
		/// 始端信号机显示
		/// </summary>
		[DataMember]
		public string StartAnnunciatorDisplay
		{
			get { return _startAnnunciatorDisplay; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _startAnnunciatorDisplay, value, () => this.StartAnnunciatorDisplay);
				}
				else
				{
					_startAnnunciatorDisplay = value;
				}
			}
		}

		/// <summary>
		/// 终端信号机
		/// </summary>
		[DataMember]
		public string EndAnnunciator
		{
			get { return _endAnnunciator; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _endAnnunciator, value, () => this.EndAnnunciator);
				}
				else
				{
					_endAnnunciator = value;
				}
			}
		}

		/// <summary>
		/// 应答器
		/// </summary>
		[DataMember]
		public string ExperiencedResponders
		{
			get { return _experiencedResponders; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _experiencedResponders, value, () => this.ExperiencedResponders);
				}
				else
				{
					_experiencedResponders = value;
				}
			}
		}

		/// <summary>
		/// 道岔
		/// </summary>
		[DataMember]
		public string ExperiencedTurnouts
		{
			get { return _experiencedTurnouts; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _experiencedTurnouts, value, () => this.ExperiencedTurnouts);
				}
				else
				{
					_experiencedTurnouts = value;
				}
			}
		}

		/// <summary>
		/// 线路速度
		/// </summary>
		[DataMember]
		public string ExperiencedSpeeds
		{
			get { return _experiencedSpeeds; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _experiencedSpeeds, value, () => this.ExperiencedSpeeds);
				}
				else
				{
					_experiencedSpeeds = value;
				}
			}
		}

		/// <summary>
		/// 轨道区段
		/// </summary>
		[DataMember]
		public string ExperiencedStationSections
		{
			get { return _experiencedStationSections; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _experiencedStationSections, value, () => this.ExperiencedStationSections);
				}
				else
				{
					_experiencedStationSections = value;
				}
			}
		}

		/// <summary>
		/// 灾害区段
		/// </summary>
		[DataMember]
		public string AffectedDisasters
		{
			get { return _affectedDisasters; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _affectedDisasters, value, () => this.AffectedDisasters);
				}
				else
				{
					_affectedDisasters = value;
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