//using System;
//using System.Runtime.Serialization;

//namespace WpfApplication2.Entity
//{
//    /// <summary>
//    /// 车站信息表
//    /// </summary>
//    [DataContract]
//    public class StationInfo
//    {
//        /// <summary>
//        /// 序号
//        /// </summary>
//        private string _id;
//        [DataMember]
//        public string Id
//        {
//            get { return _id; }
//            set { _id = value; }
//        }
//        /// <summary>
//        /// 车站名称
//        /// </summary>
//        private string _stationName;
//        [DataMember]
//        public string StationName
//        {
//            get { return _stationName; }
//            set { _stationName = value; }
//        }
//        /// <summary>
//        /// 大区编号
//        /// </summary>
//        private string _regionID;
//        [DataMember]
//        public string RegionID
//        {
//            get { return _regionID; }
//            set { _regionID = value; }
//        }
//        /// <summary>
//        /// 小区编号
//        /// </summary>
//        private string _sectionID;
//        [DataMember]
//        public string SectionID
//        {
//            get { return _sectionID; }
//            set { _sectionID = value; }
//        }
//        /// <summary>
//        /// 车站编号
//        /// </summary>
//        private string _stationID;
//        [DataMember]
//        public string StationID
//        {
//            get { return _stationID; }
//            set { _stationID = value; }
//        }


//        ///// <summary>
//        ///// 批量新增
//        ///// </summary>
//        ///// <param name="dao">数据对象</param>
//        ///// <returns>成功/失败</returns>
//        //public bool Insert(List<BrakingInfo> daos)
//        //{
//        //    bool ret = true;
//        //    try
//        //    {
//        //        Session.Open();
//        //        Session.BeginTransaction();
//        //        for (int i = 0; i < daos.Count; i++)
//        //        {
//        //            _dal.Insert(daos[i]);
//        //        }

//        //        Session.CommitTransaction();
//        //    }
//        //    catch (Exception err)
//        //    {
//        //        ret = false;
//        //        Log.Error(daos, err);
//        //        Session.RollBackTransaction();
//        //    }
//        //    finally
//        //    {
//        //        Session.Close();
//        //    }
//        //    return ret;
//        //}

//    }
//}
