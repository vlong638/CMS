//using Asiatom.Treasury.OutInterfacePlatform.ImportData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asiatom.Treasury.AccountPayable.ImportExport
{
    //public class ImportFileHelper
    //{
    //    /// <summary>
    //    /// 加载Credit数据
    //    /// CMS: .csv 
    //    /// WFS: .csv
    //    /// </summary>
    //    /// <param name="filePaths"></param>
    //    public static string[] GetCreditFiles(SystemCodeEnum type, string directoryPath)
    //    {
    //        string[] result = null;
    //        switch (type)
    //        {
    //            case SystemCodeEnum.CMS:
    //                result = LoadDirectory(directoryPath, "CMS*", true).Where(c => c.ToLower().EndsWith(".csv", StringComparison.OrdinalIgnoreCase)).ToArray();
    //                break;
    //            case SystemCodeEnum.WFS:
    //                result = LoadDirectory(directoryPath, "WFS*", true).Where(c => c.ToLower().EndsWith(".csv", StringComparison.OrdinalIgnoreCase)).ToArray();
    //                break;
    //        }
    //        return result;
    //    }
    //    /// <summary>
    //    /// 加载文件夹文件
    //    /// </summary>
    //    /// <param name="direcotryPath"></param>
    //    /// <param name="IsRecursive"></param>
    //    protected static string[] LoadDirectory(string direcotryPath, string searchPattern = "*", bool IsRecursive = false)
    //    {
    //        if (!Directory.Exists(direcotryPath))
    //        {
    //            throw new Exception(string.Format("文件夹路径{0}不存在", direcotryPath));
    //        }

    //        string[] filePaths;
    //        if (IsRecursive)
    //        {
    //            filePaths = Directory.GetFiles(direcotryPath, searchPattern, SearchOption.AllDirectories);
    //        }
    //        else
    //        {
    //            filePaths = Directory.GetFiles(direcotryPath, searchPattern, SearchOption.TopDirectoryOnly);
    //        }
    //        return filePaths;
    //    }
    //}
}
