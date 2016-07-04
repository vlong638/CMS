using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WindowsReport
{
    public class StudentCourseData
    {
        public DataSet GetDataSet()
        {
            DataSet result = new DataSet("StudentCourse");
            result.Tables.Add(GetDataTable());
            return result;
        }
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable("StudentCourseMapping");
            dt.Columns.Add("StudentName");
            dt.Columns.Add("Date");
            dt.Columns.Add("CourseName");
            dt.Columns.Add("Time");
            Random random = new Random();
            for (int date = 1; date < 31; date++)
            {
                int courseNumber = random.Next(1, 3);
                for (int j = 0; j < courseNumber; j++)
                {
                    string time = random.Next(24) + ":" + random.Next(60);
                    dt.Rows.Add("xjh", date, "课程" + random.Next(100), DateTime.Parse(time).ToString("hh:mm"));
                }
            }
            return dt;
        }
    }
}