using System;
using System.Runtime.Serialization;

namespace WpfApplication2.Entity
{
    /// <summary>
    /// 线路数据表
    /// </summary>
    [DataContract]
    public class LineData
    {
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 车站名
        /// </summary>
        [DataMember]
        public string StationName { get; set; }
        /// <summary>
        /// 信号点名称
        /// </summary>
        [DataMember]
        public string SignalName { get; set; }
        /// <summary>
        /// 信号点里程
        /// </summary>
        [DataMember]
        public string SignalMileage { get; set; }
        /// <summary>
        /// 信号点类型
        /// </summary>
        [DataMember]
        public string SignalType { get; set; }
        /// <summary>
        /// 绝缘节类型
        /// </summary>
        [DataMember]
        public string IsolationType { get; set; }
        /// <summary>
        /// 轨道区段名称
        /// </summary>
        [DataMember]
        public string RailSectionName { get; set; }
        /// <summary>
        /// 轨道区段载频
        /// </summary>
        [DataMember]
        public string RailSectionCarrier { get; set; }
        /// <summary>
        /// 轨道区段长度
        /// </summary>
        [DataMember]
        public string RailSectionLength{ get; set; }
        /// <summary>
        /// 轨道区段区段属性
        /// </summary>
        [DataMember]
        public string RailSectionAttribute { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Markup { get; set; }
    }
}
