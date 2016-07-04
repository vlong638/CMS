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
using MyServiceClientHelper;

namespace WpfApplication2.Windows
{
    /// <summary>
    /// Interaction logic for WCFTestWindow.xaml
    /// </summary>
    public partial class WCFTestWindow : Window
    {
        public WCFTestWindow()
        {
            InitializeComponent();

            string code = ServiceHelper.ServiceClient.GetOneUserCode();
        }
    }
}
