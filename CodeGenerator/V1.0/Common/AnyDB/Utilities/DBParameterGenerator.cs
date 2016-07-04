using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using System.Data.Common;

namespace VLCommon.AnyDB.Utilities
{
    public abstract class DbParameterGenerator
    {
        /// <summary>
        /// 通过标准参数生成DbParameter
        /// </summary>
        public abstract DbParameter GetParameter(object value, string title, FieldItemType type);
        /// <summary>
        /// 通过DBFieldItem生成的DbParameter
        /// </summary>
        public abstract DbParameter GetParameter(object value, DBFieldItem fieldItem);
    }
}
