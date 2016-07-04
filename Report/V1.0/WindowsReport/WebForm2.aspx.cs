using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WindowsReport
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ReportViewer1.LocalReport.ReportPath = @"C:\Users\Administrator\Documents\Visual Studio 2012\Projects\WindowsReport\WindowsReport\Report2.rdlc";
                this.ReportViewer1.LocalReport.DataSources.Clear();
                //这里的MyDataSet1与Report所绑定的数据库命名需一致
                //而后DataTable的TableName需和数据源所对应的表名一致
                var source = new Microsoft.Reporting.WebForms.ReportDataSource("MyDataSet1", new StudentCourseData().GetDataTable());
                this.ReportViewer1.LocalReport.DataSources.Add(source);
                this.ReportViewer1.LocalReport.Refresh();
            }

            ////this.ReportViewer1.LocalReport.ReportPath = @"C:\Users\Administrator\Documents\Visual Studio 2012\Projects\WindowsReport\WindowsReport\MircrosoftReport.rdlc";
            //this.ReportViewer1.LocalReport.Refresh();
        }
    }
}