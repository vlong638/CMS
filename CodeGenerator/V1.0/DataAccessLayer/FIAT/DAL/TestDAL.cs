using FIAT.DDL.Entities;
using MyDataAccess.ADO_NET;
using System;
using System.Collections.Generic;
using System.Data;

namespace FIAT.DDL.DAL
{
    public class TestDAL : MyDAL
    {
        #region Constructor
        public TestDAL(IMySession session)
            : base(session)
        {
            this.TableName = "Test";
        }
        #endregion

        #region Methods
        //#region Insert
        ////public int InsertTestList(IEnumerable<Test> entityList)
        //public int InsertTest(Test entity)
        //{
        //    string sql = string.Format("insert into {0}({1}) values {2};", TableName, "", "");
        //    return Session.ExecuteNonQuery(sql);
        //}
        //#endregion

        //#region Delete
        ////public int DeleteTestList(IEnumerable<Test> entityList)
        //public int DeleteTest(int urid)
        //{
        //    string sql = string.Format("delete from {0} where urid = {1};", TableName, urid);
        //    return Session.ExecuteNonQuery(sql);
        //}
        //#endregion

        //#region Update
        ////public int UpdateTestList(IEnumerable<Test> entityList)
        //public int UpdateTest(Test entity)
        //{
        //    string sql = string.Format("update {0} set {2} where urid = {1};", TableName, "", "");
        //    return Session.ExecuteNonQuery(sql);
        //}
        //#endregion

        //#region Select
        //public int GetURID()
        //{
        //    string sql = string.Format("select max(urid)+1 from {0};", TableName);
        //    return Convert.ToInt32(Session.ExecuteScalar(sql));
        //}
        //public List<Test> GetTest()
        //{
        //    List<Test> result = new List<Test>();
        //    string sql = string.Format("select * from {0};", TableName);
        //    DataTable dt = Session.ExecuteDataTable(sql);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        result.Add(new Test(row));
        //    }
        //    return result;
        //}
        //#endregion
        #endregion

        #region ManualCode
        //手工添加的内容请于此处添加
        #endregion
    }
}
