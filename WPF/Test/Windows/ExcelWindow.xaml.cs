using System.Windows;
using System.Windows.Documents;
using ExcelParser;
using System.Collections.Generic;
using WpfApplication2.Helper;

namespace WpfApplication2.Windows
{
    /// <summary>
    /// Interaction logic for ExcelWindow.xaml
    /// </summary>
    public partial class ExcelWindow : Window
    {
        public ExcelWindow()
        {
            InitializeComponent();
        }

        //下面是选择.XLS文件所在地的BUTTON
        private void btn_Read_Click(object sender, RoutedEventArgs e)
        {
            //ExcelParser.ExcelParser excelParser = new ExcelParser.ExcelParser();
            //List<TransponderLocation> daos = excelParser.GetTransponderLocation("文件位置");
            //List<TransponderLocation> daos = excelParser.GetTransponderLocation(@"F:\工作文档\5.任务\3. 06.05 报文系统\Data\11.应答器位置表(津秦正线)-V2.0.3-2013.11.18.xls");
            ExcelHelper eh = new ExcelHelper();
            //eh.ReadDirectory();
            if (!eh.ReadWorkbook())
            {
                lbl_Selected.Content = "执行失败";
            }
            else
            {
                lbl_Selected.Content = "执行成功";
            }
        }
    }
}
