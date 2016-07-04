using VLCommon.AnyDB.Entities;
using VLCommon.AnyDB.Enums;
using VLCommon.AnyDB.Utilities;
using System;
using System.Data.Common;

namespace VLCommon.Oracle.Utilities
{
    //public class OracleParameterGenerator : DbParameterGenerator
    //{
    //    /// <summary>
    //    /// 获取对应字段原类型的OracleDbType
    //    /// </summary>
    //    /// <param name="type"></param>
    //    /// <returns></returns>
    //    private OracleDbType GetOracleDbTypeFromFieldItemType(FieldItemType type)
    //    {
    //        switch (type)
    //        {
    //            case FieldItemType.FLOAT:
    //            case FieldItemType.NUMBER:
    //                return OracleDbType.Decimal;
    //            case FieldItemType.NVARCHAR2:
    //                return OracleDbType.NVarchar2;
    //            case FieldItemType.VARCHAR2:
    //                return OracleDbType.Varchar2;
    //            case FieldItemType.DATE:
    //                return OracleDbType.Date;
    //            default:
    //                throw new NotImplementedException(string.Format("该FieldItemType:{0}未配置对应的OracleDbType", type));
    //        }
    //    }
    //    /// <summary>
    //    /// 仅通过基本元素产生DbParameter
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <param name="title"></param>
    //    /// <param name="type"></param>
    //    /// <returns></returns>
    //    public override DbParameter GetParameter(object value, string title, FieldItemType type)
    //    {
    //        return new OracleParameter(title, GetOracleDbTypeFromFieldItemType(type)) { Value = value };
    //    }
    //    /// <summary>
    //    /// 通过fieldItem获取DaParameter将默认进行内容校验
    //    /// </summary>
    //    /// <param name="fieldItem"></param>
    //    /// <param name="value"></param>
    //    /// <returns></returns>
    //    public override DbParameter GetParameter(object value, DBFieldItem fieldItem)
    //    {
    //        fieldItem.Validate(value);
    //        return new OracleParameter(fieldItem.Title, GetOracleDbTypeFromFieldItemType(fieldItem.Type), fieldItem.Length) { Value = value };
    //    }
    //}
}
