﻿using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using MyEF6Tester.Models;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using(EntityContext ctx=new EntityContext())
	        {
                List<string> studentNames = ctx.TB_STUDENT.Select(c => c.NAME).ToList();
	        }

            //#region old
            //using (HREntities ctx = new HREntities())
            //{
            //    int max_id = 102;

            //    // LINQ to Entities query -- Retrieve employees with ID number less than max_id
            //    var OraLINQ1 = from e in ctx.EMPLOYEES
            //                   where e.EMPLOYEE_ID < max_id
            //                   select e;

            //    Console.WriteLine("LINQ to Entities Result");
            //    foreach (var result in OraLINQ1)
            //    {
            //        Console.WriteLine("ID: " + result.EMPLOYEE_ID +
            //            "    Name: " + result.FIRST_NAME +
            //            "    Salary: " + result.SALARY);
            //    }

            //    Console.WriteLine();
            //    Console.ReadLine();


            //    // LINQ using lambda expressions -- Select employees with ID number less than max_id
            //    // Then increase salary using stored procedure mapping
            //    var OraLINQ2 = ctx.EMPLOYEES.Where<EMPLOYEE>(emp => emp.EMPLOYEE_ID < max_id);

            //    foreach (var result in OraLINQ2)
            //        result.SALARY = 18000;

            //    ctx.SaveChanges();

            //    Console.WriteLine("Salaries Updated");
            //    Console.WriteLine();
            //    Console.ReadLine();


            //    //Entity SQL  -- Retrieve employees with ID number less than max_id
            //    string esql = "select e.EMPLOYEE_ID, e.FIRST_NAME, e.SALARY from HREntities.EMPLOYEEs as e where e.EMPLOYEE_ID < " + max_id;
            //    EntityConnection econn = new EntityConnection("name=HREntities");

            //    econn.Open();
            //    EntityCommand ecmd = econn.CreateCommand();
            //    ecmd.CommandText = esql;
            //    EntityDataReader ereader = ecmd.ExecuteReader(CommandBehavior.SequentialAccess);

            //    Console.WriteLine("Entity SQL Result");
            //    while (ereader.Read())
            //    {
            //        Console.WriteLine("ID: " + ereader.GetValue(0) +
            //            "    Name: " + ereader.GetValue(1) +
            //            "    Salary: " + ereader.GetValue(2));
            //    }
            //    Console.WriteLine();
            //    Console.ReadLine();


            //    int id = 100;
            //    int salary = 24000;

            //    foreach (var result in ctx.UPDATE_AND_RETURN_SALARY(id, salary))
            //    {
            //        Console.WriteLine("Name: " + result.FIRST_NAME + "  Updated Salary: " + result.SALARY);
            //    }

            //    Console.WriteLine();
            //    Console.ReadLine();

            //    // // Return an output parameter from a stored procedure
            //    ObjectParameter outparam = new ObjectParameter("outp", typeof(string));

            //    ctx.OUTPARAM(outparam);
            //    Console.WriteLine(outparam.Value);

            //    Console.WriteLine();
            //    Console.ReadLine();


            //    //Create new department entry
            //    var OraLINQ3 = new DEPARTMENT() { DEPARTMENT_ID = 280, DEPARTMENT_NAME = "Research" };
            //    ctx.DEPARTMENTS.AddObject(OraLINQ3);
            //    ctx.SaveChanges();

            //    Console.WriteLine("New department added");

            //    //Verify the new department exists
            //    var OraLINQ4 = from d in ctx.DEPARTMENTS
            //                   where d.DEPARTMENT_ID == 280
            //                   select d.DEPARTMENT_NAME;

            //    Console.WriteLine("Department Name: " + OraLINQ4.First());
            //    Console.ReadLine();

            //    //Delete new department entry
            //    ctx.DeleteObject(OraLINQ3);
            //    ctx.SaveChanges();
            //    Console.WriteLine("New department removed?");

            //    //Verify the department was removed
            //    if (OraLINQ4.FirstOrDefault() == null)
            //        Console.WriteLine("Yes, it was removed.");
            //    else
            //        Console.WriteLine("No, it was not removed.  Department Name: " + OraLINQ4.First());

            //    Console.ReadLine();
            //} 
            //#endregion
        }
    }
}