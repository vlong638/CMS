using FIATFileDataParser.FileParser;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIATFileDataParser
{
    public class CreditFileParser
    {
        #region 消息记录
        private StringBuilder sb = new StringBuilder();
        private bool _isSuccess=true;

        /// <summary>
        /// 执行状态
        /// </summary>
        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }
        /// <summary>
        /// 执行消息
        /// </summary>
        public string Message
        {
            get { return sb.ToString(); }
        }

        /// <summary>
        /// 记录常规消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void RecordInfo(string message, params object[] args)
        {
            sb.AppendFormat(message, args);
            sb.Append("\r\n"); ;
        }
        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void RecordError(string message, params object[] args)
        {
            IsSuccess = false;
            RecordInfo(message, args);
        } 
        #endregion

        #region Fields
        #endregion

        #region Porperties
        #endregion

        #region Constructors
        public CreditFileParser()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// 加载文件夹文件
        /// </summary>
        /// <param name="direcotryPath"></param>
        /// <param name="IsRecursive"></param>
        protected string[] LoadDirectory(string direcotryPath,string searchPattern="*", bool IsRecursive = false)
        {
            if (!Directory.Exists(direcotryPath))
	        {
                RecordError("文件夹路径{0}不存在",direcotryPath);
                return null;
	        }

            string[] filePaths;
            if (IsRecursive)
            {
                filePaths = Directory.GetFiles(direcotryPath, searchPattern, SearchOption.AllDirectories);
            }
            else
            {
                filePaths = Directory.GetFiles(direcotryPath, searchPattern, SearchOption.TopDirectoryOnly);
	        }
            return filePaths;
        }

        #region 贷方Credit
        /// <summary>
        /// 加载Credit数据
        /// CMS: .csv 
        /// WFS: .csv
        /// </summary>
        /// <param name="filePaths"></param>
        protected string[] GetCreditFiles(FileTypeEnum type,string directoryPath)
        {
            string[] result = null;
            switch (type)
            {
                case FileTypeEnum.CMS:
                    result = LoadDirectory(directoryPath, "CMS*", true).Where(c => c.ToLower().EndsWith(".csv", StringComparison.OrdinalIgnoreCase)).ToArray();
                    break;
                case FileTypeEnum.WFS:
                    result = LoadDirectory(directoryPath, "WFS*", true).Where(c => c.ToLower().EndsWith(".csv", StringComparison.OrdinalIgnoreCase)).ToArray();
                    break;
            }
            return result;
        }
        /// <summary>
        /// 获取贷方对象
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public CreditColleciton GetCredits(FileTypeEnum type,string directoryPath, bool isErrorStop = false)
        {
            CreditColleciton result = new CreditColleciton(type);
            //
            string[] filePaths = GetCreditFiles(type, directoryPath);
            //
            if (filePaths.Length > 0)
            {
                foreach (string filePath in filePaths)
                {
                    try 
	                {
                        //解析文件数据
                        result.Add(new CreditFileData(result, filePath));
	                }
	                catch (Exception ex)
	                {
                        RecordError(ex.ToString());

                        if (isErrorStop)
                        {
                            break;
                        }
	                }
                }
            }
            return result;
        }
        #endregion

        ///// <summary>
        ///// 解析贷方对象
        ///// </summary>
        ///// <param name="filePath"></param>
        ///// <returns></returns>
        //protected List<DirectCredit> ParseCredits(string filePath)
        //{
        //    try
        //    {
        //        using (StreamReader reader = File.OpenText(filePath))
        //        {
        //            DirectCredit credit = new DirectCredit();
        //            string text;
        //            while (string.IsNullOrEmpty(text = reader.ReadLine()))
        //            {

        //            }
        //            return credit;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RecordError(ex.ToString());
        //        return null;
        //    }
        //} 

        #region 借方Debit
        ///// <summary>
        ///// 加载Debit数据
        ///// CMS: .txt 
        ///// WFS: .dat
        ///// </summary>
        ///// <param name="filePaths"></param>
        //protected string[] GetDebitFiles(string directoryPath)
        //{
        //    string[] result = null;
        //    switch (Type)
        //    {
        //        case FileTypeEnum.CMS:
        //            result = LoadDirectory(directoryPath, "CMS*", true).Where(c => c.ToLower().EndsWith(".txt", StringComparison.OrdinalIgnoreCase)).ToArray();
        //            break;
        //        case FileTypeEnum.WFS:
        //            result = LoadDirectory(directoryPath, "WFS*", true).Where(c => c.ToLower().EndsWith(".dat", StringComparison.OrdinalIgnoreCase)).ToArray();
        //            break;
        //    }
        //    return result;
        //}
        //public List<DirectDebit> GetDebits(string directoryPath)
        //{
        //    List<DirectDebit> result = new List<DirectDebit>();
        //    string[] filePaths= LoadDirectory(directoryPath);
        //    if (filePaths.Length>0)
        //    {
        //        foreach (string filePath in filePaths)
        //        {
        //            result.Add(ParseDebits(filePath));
        //        }
        //    }
        //    return result;
        //}
        //protected DirectDebit ParseDebits(string filePath)
        //{
        //    try
        //    {
        //        using (StreamReader reader = File.OpenText(filePath))
        //        {
        //            DirectDebit debit = new DirectDebit();
        //            string text;
        //            while (string.IsNullOrEmpty(text = reader.ReadLine()))
        //            {

        //            }
        //            return debit;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RecordError(ex.ToString());
        //        return null;
        //    }
        //} 
        #endregion

        #endregion
    }
}
