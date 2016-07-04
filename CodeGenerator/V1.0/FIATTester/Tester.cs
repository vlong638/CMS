//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MyDataAccess.ADO_NET;
//using System.Data;
//using FIAT.DDL.Entities;
//using FIAT.DDL.DAL;
//using VLCommon.AnyDB.Enums;

//namespace FIATTester
//{
//    class Tester
//    {
//        public Tester()
//        {
 
//        }

//        private MySession _session;
//        public MySession Session
//        {
//            get
//            {
//                if (_session == null)
//                    _session = new MySession(DataProvider.Oracle);
//                return _session;
//            }
//        }

//        public bool GenerateStudent()
//        {
//            TB_STUDENT student = new TB_STUDENT();
//            student.URID = new Random().Next(10000);
//            student.NAME = "xjh";
//            student.AGE = 17;
//            student.REMARK1 = "rerer";
//            student.REMARK2 = "asfdsa";
//            return new TB_STUDENTDAL(Session).Insert(student) == 1;
//            //return false;
//        }
//        public bool GenerateBanks()
//        {
//    //URID	CODE	NAME	SYBANKID	DIRECTBANKCODE	DIRECTFLAG	DESCRIPTION	ISACTIVE	DISPLAYORDER	CREATEDON	CREATEDBY	LASTMODIFIEDON	LASTMODIFIEDBY	ROWVERSION
//    //28?	28	QLB	齐鲁银行	7010		0		1	1	2014/5/24 2:00:37	6000002	2014/5/24 2:00:37	6000002	1
//            //BANKS bank = new BANKS();
//            //bank.CODE = "QLB1";
//            //bank.NAME = "齐鲁银行1";
//            //bank.SYBANKID = 7010;
//            //bank.DIRECTBANKCODE = "0";
//            //bank.DIRECTFLAG = 1;
//            //return new BANKSDAL(Session).Insert(bank) == 1;
//            return false;
//        }
//        //public List<BANKS> GetBANKS()
//        //{
//        //    return new BANKSDAL(Session).GetBANKS();
//        //}
//        //public int GetURID()
//        //{
//        //    //return new BANKSDAL(Session).GetURID();
//        //}

//        //public bool GenerateAccounts()
//        //{
//        //    ACCOUNTS account = new ACCOUNTS();
//        //    account.
//        //    return new ACCOUNTSDAL(Session).InsertACCOUNTS(account) == 1;
//        //}

//        //public System.Data.Common.DbDataReader ExcuteDataReader(string sql)
//        //{
//        //    return Session.ExecuteDataReader(sql);
//        //}
//        //public DataTable ExcuteDataTable(string sql)
//        //{
//        //    return Session.ExecuteDataTable(sql);
//        //}
//        //public int ExecuteNonQuery(string sql)
//        //{
//        //    return Session.ExecuteNonQuery(sql);
//        //}
//    }
//}
