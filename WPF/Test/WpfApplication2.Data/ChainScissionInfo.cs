namespace WpfApplication2.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;

	/// <summary>
	/// 断链信息表
	/// </summary>
	[Serializable]
	[DataContract]
	public class ChainScissionInfo : Sui.ComponentModel.DataModelBase
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
		/// 线名
		/// </summary>
		private string _lineName;
		/// <summary>
		/// 行向类别
		/// </summary>
		private int _category;
		/// <summary>
		/// 断链类型
		/// </summary>
		private string _type;
		/// <summary>
		/// 起点里程
		/// </summary>
		private string _startMileage;
		/// <summary>
		/// 终点里程
		/// </summary>
		private string _endMileage;
		/// <summary>
		/// 长链
		/// </summary>
		private int? _longChain;
		/// <summary>
		/// 断链
		/// </summary>
		private int? _shortChain;
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ChainScissionInfo()
		{
			_iD = int.MinValue;
			_groupID = Guid.NewGuid();
			_lineName = null;
			_category = int.MinValue;
			_type = null;
			_startMileage = null;
			_endMileage = null;
			_longChain = null;
			_shortChain = null;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public ChainScissionInfo(ChainScissionInfo source)
		{
			_iD = source.ID;
			_groupID = source.GroupID;
			_lineName = source.LineName;
			_category = source.Category;
			_type = source.Type;
			_startMileage = source.StartMileage;
			_endMileage = source.EndMileage;
			_longChain = source.LongChain;
			_shortChain = source.ShortChain;
		}

		/// <summary>
		/// No identity column constructror.
		/// </summary>
		public ChainScissionInfo(Guid groupID, string lineName, int category, string type, string startMileage, string endMileage, int? longChain, int? shortChain)
		{
			_groupID = groupID;
			_lineName = lineName;
			_category = category;
			_type = type;
			_startMileage = startMileage;
			_endMileage = endMileage;
			_longChain = longChain;
			_shortChain = shortChain;
		}

		/// <summary>
		/// All column constructror.
		/// </summary>
		public ChainScissionInfo(int iD, Guid groupID, string lineName, int category, string type, string startMileage, string endMileage, int? longChain, int? shortChain)
		{
			_iD = iD;
			_groupID = groupID;
			_lineName = lineName;
			_category = category;
			_type = type;
			_startMileage = startMileage;
			_endMileage = endMileage;
			_longChain = longChain;
			_shortChain = shortChain;
		}

		/// <summary>
		/// Create instance from DataTable which has the structrue of ChainScissionInfo.
		/// </summary>
		/// <param name="dr">DataRow Data</param>
		public ChainScissionInfo(DataRow dr)
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
			data = dr["LineName"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_lineName = null;
			}
			else
			{
				_lineName = data.ToString();
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
			data = dr["Type"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_type = null;
			}
			else
			{
				_type = data.ToString();
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
			data = dr["LongChain"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_longChain = null;
			}
			else
			{
				_longChain = int.Parse(data.ToString());
			}
			data = dr["ShortChain"];
			if (data == null || string.IsNullOrEmpty(data.ToString()))
			{
				_shortChain = null;
			}
			else
			{
				_shortChain = int.Parse(data.ToString());
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
		/// 线名
		/// </summary>
		[DataMember]
		public string LineName
		{
			get { return _lineName; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _lineName, value, () => this.LineName);
				}
				else
				{
					_lineName = value;
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
		/// 断链类型
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
		/// 长链
		/// </summary>
		[DataMember]
		public int? LongChain
		{
			get { return _longChain; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _longChain, value, () => this.LongChain);
				}
				else
				{
					_longChain = value;
				}
			}
		}

		/// <summary>
		/// 断链
		/// </summary>
		[DataMember]
		public int? ShortChain
		{
			get { return _shortChain; }
			set
			{
				if (Constants.IS_TWOWAY_BINDING)
				{
					SetValue(ref _shortChain, value, () => this.ShortChain);
				}
				else
				{
					_shortChain = value;
				}
			}
		}

		#endregion

        #region ManualCode
        /// <summary>
        /// 短链长度
        /// </summary>
        private string _shortChainStr;
        [DataMember]
        public string ShortChainStr
        {
            get { return _shortChainStr; }
            set
            {
                _shortChainStr = value;
                if (!string.IsNullOrEmpty(_shortChainStr))
                {
                    _shortChain = int.Parse(_shortChainStr);
                }
            }
        }
        /// <summary>
        /// 长链长度
        /// </summary>
        private string _longChainStr;
        [DataMember]
        public string LongChainStr
        {
            get { return _longChainStr; }
            set
            {
                _longChainStr = value;
                if (!string.IsNullOrEmpty(_longChainStr))
                {
                    _longChain = int.Parse(_longChainStr);
                }
            }
        }
		#endregion
	}
}