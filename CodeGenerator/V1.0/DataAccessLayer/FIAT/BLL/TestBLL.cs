//using FIAT.DDL.DAL;
//using FIAT.DDL.Entities;
//using MyDataAccess.ADO_NET;
//using System;
//using System.Collections.Generic;
//using System.Data;

//namespace ServiceClientHelper.FIAT.BLL
//{
//    public class TestBLL : MyBLL
//    {
//        #region Fields
//        private TestDAL _TestDAL;
//        private TB_STUDENTDAL _StudentDAL; 
//        #endregion

//        #region Constructors
//        public TestBLL(IMySession session)
//            : base(session)
//        {
//            _TestDAL = new TestDAL(session);
//            _TestDAL = new TestDAL(session);
//        } 
//        #endregion

//        #region Methods
//        public int InsertStudent(TB_STUDENT student)
//        {
//            return _StudentDAL.Insert(student);
//        }

//        //#region Insert
//        ////public int BulkInsertTest(IEnumerable<Test> entityList)
//        //public int InsertTest(Test entity)
//        //{
//        //    return _TestDAL.InsertTest(entity);
//        //}
//        //#endregion

//        //#region Delete
//        ////public int BulkDeleteTest(IEnumerable<Test> entityList)
//        //public int DeleteTest(int urid)
//        //{
//        //    return _TestDAL.DeleteTest(urid);
//        //}
//        //#endregion

//        //#region Update
//        ////public int BulkUpdateTest(IEnumerable<Test> entityList)
//        //public int UpdateTest(Test entity)
//        //{
//        //    return _TestDAL.UpdateTest(entity);
//        //}
//        //#endregion

//        //#region Select
//        //public int GetURID()
//        //{
//        //    return _TestDAL.GetURID();
//        //}
//        //public List<Test> GetTest()
//        //{
//        //    return _TestDAL.GetTest();
//        //}
//        //#endregion
//        #endregion

//        #region ManualCode
//        //手工添加的内容请于此处添加
//        #endregion
//    }
//}
