using VLCommon.AnyDB.Enums;
using System;

namespace VLCommon.AnyDB.Entities
{
    /// <summary>
    /// 数据库字段类
    /// 用以记录字段的数据库配置
    /// </summary>
    public class DBFieldItem
    {
        #region Properties
        public string Title { get; set; }
        public bool IsPrimaryKey { get; set; }
        public FieldItemType Type { get; set; }
        public int Length { get; set; }
        public int Accuracy { get; set; }
        public bool Nullable { get; set; }
        public string DefaultValue { get; set; }
        #endregion

        public DBFieldItem(string title, bool isPrimaryKey, FieldItemType type, int length, int accuracy, bool nullable, string defaultValue = null)
        {
            this.Title = title;
            this.IsPrimaryKey = isPrimaryKey;
            this.Type = type;
            this.Length = length;
            this.Accuracy = accuracy;
            this.Nullable = nullable;
            this.DefaultValue = defaultValue;
        }

        public void Validate(object value)
        {
            if (!Nullable && value == null)
            {
                throw new Exception(string.Format("字段{0}不可为空", this.Title));
            }
            if (Length != 0 && value != null && value.ToString().Length > Length)
            {
                throw new Exception(string.Format("字段{0}长度超过限制", this.Title));
            }
        }
    }
    ///// <summary>
    ///// 数据库字段类<T>
    ///// 用以记录字段的数据库配置
    ///// </summary>
    //public class DBFieldItem<T> : DBFieldItem
    //{
    //    #region Properties
    //    //private T _value = default(T);
    //    //public T Value
    //    //{
    //    //    get
    //    //    {
    //    //        if (!Nullable && this._value == null)
    //    //        {
    //    //            throw new Exception(string.Format("字段{0}不可为空", this.Title));
    //    //        }
    //    //        if (this._value.ToString().Length > Length)
    //    //        {
    //    //            throw new Exception(string.Format("字段{0}长度超过限制", this.Title));
    //    //        }
    //    //        return this._value;
    //    //    }
    //    //    set
    //    //    {
    //    //        if (!Nullable && value == null)
    //    //        {
    //    //            throw new Exception(string.Format("字段{0}不可为空", this.Title));
    //    //        }
    //    //        if (value.ToString().Length > Length)
    //    //        {
    //    //            throw new Exception(string.Format("字段{0}长度超过限制", this.Title));
    //    //        }
    //    //        this._value = value;
    //    //    }
    //    //}
    //    #endregion

    //    public DBFieldItem(string title, bool isPrimaryKey, FieldItemType type, int length, int accuracy, bool nullable, string defaultValue = null)
    //        : base(title, isPrimaryKey, type, length, accuracy, nullable, defaultValue)
    //    { }
    //}
}
