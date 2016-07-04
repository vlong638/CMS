using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDataAccess.ADO_NET
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class MyBLL
    {
        #region NestedTypes

        private IMySession _session;
        protected IMySession Session { get { return Session; } }

        #endregion

        #region Constructor

        public MyBLL(IMySession session)
        {
            _session = session;
        }

        #endregion

        //方法样例
        //public string GetOneUserCode()
        //{
        //    return _dal.GetOneUserCode();
        //}
    }
}
