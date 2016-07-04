using System;
using NPOI.HSSF.UserModel;
using System.IO;
using Microsoft.Win32;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization.Json;
using WpfApplication2.Data;
using WpfApplication2.Business;
using NPOI.SS.UserModel;

namespace WpfApplication2.Helper
{
    public class ExcelHelper
    {
        static string LogPath = System.Configuration.ConfigurationManager.AppSettings["DefaultLogPath"].ToString();
        public DataTable dt;
        TableMapping tm;
        HSSFWorkbook workbook;
        HSSFSheet sheet;
        HSSFCell cell;
        string fileName;
        int rowS, rowE, columnS, columnE;
        /// <summary>
        /// 初始化模型表
        /// </summary>
        static ExcelHelper()
        {
        }
        /// <summary>
        /// 打开文件夹
        /// </summary>
        public void ReadDirectory(string path = @"F:\工作文档\5.任务\3. 06.05 报文系统\Data")
        {
            List<FileInfo> files = GetAllFile(path, "*.xls");
            foreach (var file in files)
            {
                ReadWorkbook(file.FullName);
            }
        }
        List<FileInfo> GetAllFile(string targetDirName, string fileSearchPattern)
        {
            List<FileInfo> fileList = new List<FileInfo>();
            DirectoryInfo dirTarget = new DirectoryInfo(targetDirName);
            foreach (DirectoryInfo subDir in dirTarget.GetDirectories())
                fileList.AddRange(GetAllFile(subDir.FullName, fileSearchPattern));
            fileList.AddRange(dirTarget.GetFiles(fileSearchPattern));

            return fileList;
        }
        /// <summary>
        /// 打开Excel文件
        /// </summary>
        bool readFile(string path="")
        {
            if (string.IsNullOrEmpty(path))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*"; //只选取xls文件
                ofd.RestoreDirectory = true; 
                if (ofd.ShowDialog().Value == true)
                {
                    try
                    {
                        using (FileStream file = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            fileName = file.Name;
                            workbook = new HSSFWorkbook(file);
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        reportError(string.Format("{0}文件打开出错\n错误{1}", ofd.FileName, ex.Message));
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        fileName = file.Name;
                        workbook = new HSSFWorkbook(file);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    reportError(string.Format("{0}文件打开出错\n错误{1}",path, ex.Message));
                    return false;
                }
            }
        }
        /// <summary>
        /// 读取A1相关信息 初始化excel实体
        /// </summary>
        bool readHeader()
        {
            bool result = true;
            if (fileName.Contains("轨道区段与道岔"))
            {
                tm = new TableMapping(fileName);
                sheet = (HSSFSheet)workbook.GetSheetAt(0);
            }
            else
            {
                //获取A1内容
                sheet = (HSSFSheet)workbook.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                rows.MoveNext();
                HSSFRow row = (HSSFRow)rows.Current;
                cell = (HSSFCell)row.GetCell(0);
                if (cell != null && !string.IsNullOrEmpty(cell.ToString()))
                {
                    tm = new TableMapping(cell.ToString().Trim());
                    tm.SheetName = sheet.SheetName;
                    if (string.IsNullOrEmpty(tm.header))
                    {
                        reportError("没有获取到类型数据");
                        result = false;
                    }
                }
                else
                {
                    reportError("A1无数据");
                    result = false;
                }
            }
            return result;
        }
        public bool ReadWorkbook(string path="")
        {
            recordResult(string.Format("写入开始 记录时间{0}", DateTime.Now));
            bool result = false;
            if (readFile(path))
            {
                if (readHeader())
                {
                    try
                    {
                        switch (tm.header)
                        {
                            case "RBC信息":
                                convertWorkbookToDataTable("序号");
                                result = new RBCInfoManager().Insert(ConvertDataTableToEntity<RBCInfo>());
                                break;
                            case "车站信息":
                                convertWorkbookToDataTable("序号");
                                result = new StationInfoManager().Insert(ConvertDataTableToEntity<StationInfo>());
                                break;
                            case "道岔信息":
                                convertWorkbookToDataTable("序号");
                                result = new TurnoutInfoManager().Insert(ConvertDataTableToEntity<TurnoutInfo>());
                                break;
                            case "分相信息":
                                convertWorkbookToDataTable("序号");
                                result = new PhaseSplittingInfoManager().Insert(ConvertDataTableToEntity<PhaseSplittingInfo>());
                                break;
                            case "桥梁隧道信息":
                                convertWorkbookToDataTable("序号");
                                result = new BridgeAndTunnelInfoManager().Insert(ConvertDataTableToEntity<BridgeAndTunnelInfo>());
                                break;
                            case "断链明细":
                                convertWorkbookToDataTable("线名", 2);
                                result = new ChainScissionInfoManager().Insert(ConvertDataTableToEntity<ChainScissionInfo>());
                                break;
                            case "线路坡度":
                                convertWorkbookToDataTable("序号");
                                result = new GradientInfoManager().Insert(ConvertDataTableToEntity<GradientInfo>());
                                break;
                            case "线路速度":
                                convertWorkbookToDataTable("序号");
                                result = new SpeedInfoManager().Insert(ConvertDataTableToEntity<SpeedInfo>());
                                break;
                            case "信号数据":
                                convertWorkbookToDataTable("序号");
                                result = new SignalInfoManager().Insert(ConvertDataTableToEntity<SignalInfo>());
                                break;
                            case "侵限监控":
                                convertWorkbookToDataTable("序号");
                                result = new DisasterInfoManager().Insert(ConvertDataTableToEntity<DisasterInfo>());
                                break;
                            case "应答器位置":
                                convertWorkbookToDataTable("序号");
                                result = new TransponderLocationManager().Insert(ConvertDataTableToEntity<TransponderLocation>());
                                break;
                            case "轨道区段与道岔映射":
                                convertWorkbookToDataTable("序号");
                                result = new StationSectionMappingManager().Insert(ConvertDataTableToEntity<StationSectionMapping>());
                                break;
                            case "制动距离":
                                convertWorkbookToDataTable("序号");
                                result = new BrakingInfoManager().Insert(ConvertDataTableToEntity<BrakingInfo>());
                                break;
                            case "坐标系信息":
                                convertWorkbookToDataTable("序号");
                                result = new CoordinateInfoManager().Insert(ConvertDataTableToEntity<CoordinateInfo>());
                                break;
                            case "进路信息":
                                convertWorkbookToDataTable("序号");
                                result = new ApproachInfoManager().Insert(ConvertDataTableToEntity<ApproachInfo>());
                                break;
                            default: break;
                        }
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        reportError("DataTable转实体出错" + ex.Message);
                    }
                    if (result)
                    {
                        recordResult(string.Format("{0}写入sql成功", tm.header));
                    }
                    else
                    {
                        reportError(string.Format("{0}写入sql失败", tm.header));
                    }
                }
            }
            recordResult("写入结束");
            recordResult("");
            return result;
        }

        /// <summary>
        /// 定位sheet内有效坐标
        /// </summary>
        /// <param name="starter">起始位匹配字段</param>
        /// <param name="type">匹配类型:1:int 2:string</param>
        bool locateCoordinate(string starter, int type = 1)
        {
            rowS = rowE = columnS = columnE = 0;
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            int index = 0, iParse;
            bool IsStarterFounded = false;
            bool IsStarted = false;
            while (rows.MoveNext())
            {
                index++;
                HSSFRow row = (HSSFRow)rows.Current;
                if (row != null)
                {
                    //定位起始点
                    if (!IsStarterFounded)
                    {
                        for (int i = 0; i < row.LastCellNum; i++)
                        {
                            cell = (HSSFCell)row.GetCell(i);
                            if (cell == null)
                            {
                                continue;
                            }
                            if (cell.ToString().Trim() == starter)
                            {
                                rowE = rowS = index + 1;
                                columnS = i + 1;
                                columnE = columnS + tm.fields.Count - 1;
                                IsStarterFounded = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cell = (HSSFCell)row.GetCell(columnS - 1);
                        //中断检索条件 发现空值或非序号字符
                        if (cell != null)
                        {
                            var cellValue = cell.ToString().Trim();
                            if (!IsStarted)
                            {
                                if ((type == 1 && int.TryParse(cellValue, out iParse)) || (type == 2 && !string.IsNullOrEmpty(cellValue)))
                                {
                                    rowE = rowS = index;
                                    IsStarted = true;
                                }
                                continue;
                            }
                            else
                            {
                                if ((type == 1 && !int.TryParse(cellValue, out iParse)) || (type == 2 && string.IsNullOrEmpty(cellValue)))
                                {
                                    break;
                                }
                                else
                                {
                                    rowE = index;
                                }
                            }
                        }
                        else
                        {
                            if (IsStarted)
                                break;
                        }
                    }
                }
            }
            fastRecord();
            if (rowS == rowE)
            {
                reportError("无Excel表数据");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 创建DataTable
        /// </summary>
        bool createDataTable()
        {
            dt = new DataTable();
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            int index = 0;
            while (index < rowE)
            {
                rows.MoveNext();
                index++;

                if (index < rowS)
                    continue;

                HSSFRow row = (HSSFRow)rows.Current;
                if (row != null)
                {
                    if (index == rowS)
                    {
                        foreach (var p in tm.fields)
                        {
                            dt.Columns.Add(p);
                        }
                        //GroupID
                        dt.Columns.Add(tm.GUIDField);
                        //Category
                        if (tm.IsCategoryNeeded)
                        {
                            dt.Columns.Add(tm.CategoryField);
                        }
                    }
                }
                else
                {
                    reportError(string.Format("解析sheet表头:{0}失败", sheet.SheetName));
                    return false;
                }
            }
            recordResult(string.Format("解析sheet表头:{0}成功", sheet.SheetName));
            return true;
        }
        /// <summary>
        /// 添加DataTable表数据
        /// </summary>
        bool addDataToDataTable()
        {
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            int index = 0;
            while (index < rowE)
            {
                rows.MoveNext();
                index++;

                if (index < rowS)
                    continue;

                HSSFRow row = (HSSFRow)rows.Current;
                if (row != null)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = columnS; i <= columnE; i++)
                    {
                        cell = (HSSFCell)row.GetCell(i - 1);
                        if (cell == null)
                        {
                            continue;
                        }
                        if (cell.CellType == CellType.FORMULA)
                        {
                            dr[i - columnS] = (int)cell.NumericCellValue;
                        }
                        else
                        {
                            dr[i - columnS] = cell.ToString();
                        }
                    }
                    //GroupID
                    dr[columnE - columnS + 1] = tm.GUIDValue;
                    //Category
                    if (tm.IsCategoryNeeded)
                    {
                        dr[columnE - columnS + 2] = tm.CategoryValue;
                    }
                    dt.Rows.Add(dr);
                }
                else
                {
                    reportError(string.Format("解析sheet数据:{0}失败", sheet.SheetName));
                    return false;
                }
            }
            recordResult(string.Format("解析sheet数据:{0}成功", sheet.SheetName));
            return true;
        }
        /// <summary>
        /// workbook转datatable
        /// </summary>
        /// <param name="type">匹配类型:1:int 2:string</param>
        bool convertWorkbookToDataTable(string locator, int type = 1)
        {
            bool result = false;
            if (locateCoordinate(locator, type))
            {
                if (createDataTable())
                {
                    if (tm.IsCategoryNeeded)
                    {
                        result = true;
                        for (int i = 0; i < workbook.Workbook.NumSheets; i++)
                        {
                            sheet = (HSSFSheet)workbook.GetSheetAt(i);
                            tm.SheetName = sheet.SheetName;
                            if (tm.CategoryValue == "-1")
                            {
                                continue;
                            }
                            if (locateCoordinate(locator, type))
                            {
                                if (!addDataToDataTable())
                                {
                                    result = false;
                                    break;
                                }
                            }
                            else
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (addDataToDataTable())
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 定位sheet内有效坐标
        /// </summary>
        /// 利用泛型
        bool convertExcelToDataTable<T>() where T : class
        {
            dt = new DataTable();
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            int index = 0;
            while (index < rowE)
            {
                rows.MoveNext();
                index++;

                if (index < rowS)
                    continue;

                HSSFRow row = (HSSFRow)rows.Current;
                if (row != null)
                {
                    if (index == rowS)
                    {
                        //通过反射提取表头注入datatable
                        Type type = typeof(T);
                        PropertyInfo[] pArray = type.GetProperties();
                        foreach (var p in pArray)
                        {
                            dt.Columns.Add(p.Name);
                        }
                        columnE = columnS + pArray.Length - 1;
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = columnS; i <= columnE; i++)
                        {
                            cell = (HSSFCell)row.GetCell(i - 1);
                            if (cell == null)
                            {
                                continue;
                            }
                            dr[i - columnS] = cell.ToString();
                        }
                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        List<T> ConvertDataTableToEntity<T>() where T : class,new()
        {
            List<T> result = new List<T>();
            string source = JsonConvert.SerializeObject(dt, new DataTableConverter());
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<T>));
            StreamWriter wr = new StreamWriter(stream);
            wr.Write(source);
            wr.Flush();
            stream.Position = 0;

            Object obj = serializer.ReadObject(stream);
            result = (List<T>)obj;
            //try
            //{
            //    Object obj = serializer.ReadObject(stream);
            //    result = (List<T>)obj;
            //}
            //catch (Exception)
            //{
            //    //DataTable转实体出错
            //}
            return result;
        }
        #region 记录日志
        void reportError(string errorMessage)
        {
            recordResult(errorMessage);
        }

        void fastRecord()
        {
            recordResult(string.Format("定位有效坐标：{0}\t{1}\t{2}\t{3}\t{4}", rowS, rowE, columnS, columnE, sheet.SheetName));
        }
        void recordResult(string s)
        {
            StreamWriter sw = new StreamWriter(LogPath, true);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
        }
        #endregion
        ///// <summary>
        ///// 读取xls指定页、指定行、指定列的数值
        ///// </summary>
        ///// <param name="fileName">文件路径和文件名</param>
        ///// <param name="sheetNum">页</param>
        ///// <param name="rowNum">行</param>
        ///// <param name="colNum">列</param>
        ///// <returns>返回指定文件、页、行、列的数值</returns>
        //private string readXls(string fileName, int sheetNum, int rowNum, int colNum)
        //{
        //    try
        //    {
        //        HSSFWorkbook workbook = HSSFTestDataSamples.OpenSampleWorkbook(fileName);
        //        ExcelExtractor extractor = new ExcelExtractor(workbook);
        //        return extractor.CellValue(sheetNum, rowNum, colNum);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show("Error!\n请检查此文件是否已被打开或被其他应用程序占用！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return "";
        //    }
        //}
    }
}
