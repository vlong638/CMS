using CodeGenerator.Helper;
using VLCommon.AnyDB.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodeGenerator.Helper.DDL
{
    /// <summary>
    /// 外部公开调用的解析器,负责DDL解析对象的调用,文件夹的指派等
    /// </summary>
    public class DDLManager
    {
        public void ConvertDirectory(
            string sourcePath = @"E:\WorkSpace\0.公用经验\MyCode\VL\CodeGenerator\V1.0\CodeGenerator\Helper\SourceFiles",
            string targetEntityPath = @"E:\WorkSpace\0.公用经验\MyCode\VL\CodeGenerator\V1.0\CodeGenerator\Helper\TargetFiles",
            string targetDALPath = @"E:\WorkSpace\0.公用经验\MyCode\VL\CodeGenerator\V1.0\CodeGenerator\Helper\TargetFiles",
            string targetBLLPath = @"E:\WorkSpace\0.公用经验\MyCode\VL\CodeGenerator\V1.0\CodeGenerator\Helper\TargetFiles",
            string dealedPath = @"E:\WorkSpace\0.公用经验\MyCode\VL\CodeGenerator\V1.0\CodeGenerator\Helper\DealedFiles",
            string failedPath = @"E:\WorkSpace\0.公用经验\MyCode\VL\CodeGenerator\V1.0\CodeGenerator\Helper\FailedFiles",
            string targetEntityNamespace = "GrowthSystem.DDL.Entities",
            string targetDALNamespace = "GrowthSystem.DDL.DAL",
            string targetBLLNamespace = "GrowthSystem.DDL.BLL"
            )
        {
            string[] sourceFiles = Directory.GetFiles(sourcePath);
            foreach (string sourceFile in sourceFiles)
            {
                //获取文件
                if (!File.Exists(sourceFile))
                    continue;
                FileInfo fileInfo = new FileInfo(sourceFile);
                //解析文件为DDL对象
                DDLEntity entity;
                try
                {
                    entity = ParseFile(DataProvider.SQLServer,sourceFile);
                }
                catch (Exception ex)
                {
                    GlobalLogHelper.WriteLog(ex);
                    continue;
                }
                //生成文件
                bool result = false;
                try
                {
                    result = entity.EntityFileGenerator.GenerateFile(Path.Combine(targetEntityPath, entity.EntityFileGenerator.DefaultFileName), targetEntityNamespace);
                    result = result & entity.DALFileGenerator.GenerateFile(Path.Combine(targetDALPath, entity.DALFileGenerator.DefaultFileName), targetDALNamespace, new List<string>() { targetEntityNamespace });
                    result = result & entity.BLLFileGenerator.GenerateFile(Path.Combine(targetBLLPath, entity.BLLFileGenerator.DefaultFileName), targetBLLNamespace, new List<string>() { targetEntityNamespace, targetDALNamespace });
                    //result = result && entity.GenerateBLLFile(targetEntityFile, targetEntityNamespace);
                }
                catch (Exception ex)
                {
                    result = false;
                    GlobalLogHelper.WriteLog(ex);
                }
                //生成文件后续处理
                //try
                //{
                //    if (result)
                //    {
                //        MoveFile(sourceFile, Path.Combine(dealedPath, entity.ClassName), true);
                //    }
                //    else
                //    {
                //        MoveFile(sourceFile, Path.Combine(failedPath, fileInfo.Name), true);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    GlobalLogHelper.WriteLog(ex.ToString());
                //}
            }
        }

        private static void MoveFile(string sourceFile, string targetFile,bool coverWhenExisted)
        {
            if (File.Exists(targetFile))
            {
                if (coverWhenExisted)
                {
                    File.Delete(targetFile);
                }
                else
                {
                    return;
                }
            }
            File.Move(sourceFile, targetFile);
        }
        private DDLEntity ParseFile(DataProvider dataProvider, string sourceFile)
        {
            DDLEntity entity;
            using (StreamReader sr = new StreamReader(sourceFile))
            {
                entity = new DDLEntity(dataProvider,sr);
            }
            return entity;
        }
    }
}
