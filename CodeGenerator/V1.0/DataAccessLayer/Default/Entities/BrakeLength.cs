using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyDataAccess.Entities
{
    /// <summary>
    /// 制动距离。
    /// </summary>
    [DataContract]
    public class BrakeLength
    {
        public BrakeLength()
        {
        }

        public BrakeLength(int speed, int slope, int length)
        {
            Speed = speed;
            Slope = slope;
            Length = length;
        }

        public BrakeLength(int speed, int slope, int length, int t300Length, int towLength)
            : this(speed, slope, length)
        {
        }

        /// <summary>
        /// 获取或设置速度。
        /// </summary>
        [DataMember]
        public int Speed { get; set; }

        /// <summary>
        /// 获取或设置坡度。
        /// </summary>
        [DataMember]
        public int Slope { get; set; }

        /// <summary>
        /// 获取或设置距离。
        /// </summary>
        [DataMember]
        public int Length { get; set; }
    }

}
