using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDataAccess.ADO_NET
{
    /// <summary>
    /// 数据链路层
    /// </summary>
    public class MyDAL
    {
        #region NestedTypes

        private IMySession _session;
        protected IMySession Session { get { return _session; } }
        protected string TableName { get; set; }

        #endregion

        #region Constructor

        public MyDAL(IMySession session)
        {
            _session = session;
        }

        #endregion

        //方法样例
        //public string GetOneUserCode()
        //{
        //    string sql = "select top 1 code from tb_user ";
        //    object obj = _session.ExecuteScalar(sql);
        //    return obj != null ? obj.ToString() : null;
        //}
    }
}
