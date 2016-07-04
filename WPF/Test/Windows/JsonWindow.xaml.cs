using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Json;
using WpfApplication2.Entity;
using WpfApplication2.Converter;

namespace WpfApplication2.Windows
{
    /// <summary>
    /// Interaction logic for JsonWindow.xaml
    /// </summary>
    public partial class JsonWindow : Window
    {
        public JsonWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //MyJsonConverter.Test();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ExcelWindow excelWin = new ExcelWindow();
            excelWin.Show();
        }
    }
}
