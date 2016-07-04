using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenDB.Data;
using log4net;

namespace WpfApplication2.Business
{


    /// <summary>
    /// 业务层基类
    /// </summary>
    public class BizBase
    {
        protected ILog Log;
        protected ISession Session;

        /// <summary>
        /// Initializes a new instance of the <see cref="BizBase"/> class.
        /// </summary>
        public BizBase()
        {
            this.Session = SessionFactory.NewSession();
            this.Log = LogManager.GetLogger(base.GetType());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BizBase"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public BizBase(ISession session)
        {
            this.Session = session;
            this.Log = LogManager.GetLogger(base.GetType());
        }
    }
}
