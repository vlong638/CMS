using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIATFileDataParser.FileParser
{
    public enum FileTypeEnum
    {
        CMS,
        WFS
    }
    /// <summary>
    /// 导入数据集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //public abstract class ImportDataCollection<T> : List<FileEntity<FileLineEntity<T>>>
    public abstract class ImportDataCollection<T> : List<T>
    {
        public FileTypeEnum Type { get; set; }

        public ImportDataCollection()
        { }

        public virtual DataTable ToDataTable(string tableName) { throw new NotImplementedException(); }
    }
    /// <summary>
    /// 导入文件对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FileEntity<T> : List<T>
    {
        public ImportDataCollection<FileEntity<T>> Parent { set; get; }
        public string FilePath { set; get; }

        public FileEntity( ImportDataCollection<FileEntity<T>> parent,string filePath)
        {
            this.FilePath = filePath;
            this.Parent = parent;
        }

        public abstract void ParseFile(string filePath);
        public virtual DataTable ToDataTable(string tableName) { throw new NotImplementedException(); }
    }
    /// <summary>
    /// 导入文件行对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FileLineEntity<T>
    {
        public FileEntity<FileLineEntity<T>> Parent { get; set; }
        public T Data { get; set; }
        public int Index { get; set; }

        public FileLineEntity(FileEntity<FileLineEntity<T>> parent, int index)
        {
            this.Parent = parent;
            this.Index = index;
        }

        /// <summary>
        /// 初始化待解析字段 引用类型必须进行初始化
        /// </summary>
        protected virtual void InitItems()
        {
            Data = default(T);
        }
        /// <summary>
        /// 将文本行解析成数据对象
        /// </summary>
        /// <param name="text"></param>
        protected abstract void Parse(string text);
        /// <summary>
        /// 实体数据转DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public abstract DataRow ToDataRow(DataRow row);

    }
    /// <summary>
    /// 导入文件行字段对象
    /// </summary>
    public abstract class LineValueEntity
    {
        /// <summary>
        /// 列名
        /// </summary>
        protected string _key;
        public string Key { get { return GetKey(); } }
        public virtual void SetKey(string key)
        {
            this._key = key;
        }
        public virtual string GetKey()
        {
            return this._key;
        }
        /// <summary>
        /// 值
        /// </summary>
        protected string _value;
        public string Value { get { return GetValue(); } }
        public virtual void SetValue(string value)
        {
            this._value = value;
        }
        public virtual string GetValue()
        {
            return this._value;
        }
    }
}
