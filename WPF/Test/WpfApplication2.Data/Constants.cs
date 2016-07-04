using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2.Data
{
    public class Constants
    {
        public static bool IS_TWOWAY_BINDING = true;

        #region 错误提示信息
        internal const string STORAGE_NAME_EMPTY = "仓库名称不能为空";
        internal const string STORAGE_MANAGER_EMPTY = "仓库管理员不能为空";
        internal const string STORAGE_ADDRESS_EMPTY = "仓库地址不能为空";
        internal const string TASK_NAME_EMPTY = "任务名不能为空";
        internal const string LOGMAIN_DESC_EMPTY = "日志内容不能为空";
        #endregion
    }
}
