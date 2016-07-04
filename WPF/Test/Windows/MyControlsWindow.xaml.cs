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
using WpfApplication2.MyControl.MyUserControl;

namespace WpfApplication2.Windows
{
    /// <summary>
    /// Interaction logic for MyControlsWindow.xaml
    /// </summary>
    public partial class MyControlsWindow : Window
    {
        public MyControlsWindow()
        {
            InitializeComponent();
        }


        //可通过INPC实现 这里测试事件使用
        private void ColorPicker_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            //((ColorPicker)sender).labelText.Content=string.Format("the new color is {0}", e.NewValue.ToString());
        }
    }
}
