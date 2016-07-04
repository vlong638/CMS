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
using System.ComponentModel;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for DependencyProperty.xaml
    /// </summary>
    public partial class DependencyPropertyWindow : Window
    {
        public DependencyPropertyWindow()
        {
            InitializeComponent();

            InitDependencyProperty();
        }

        private void InitDependencyProperty()
        {
            //包装的属性
            btn_3.Background = new SolidColorBrush(Colors.Red);

            //依赖项属性的SetValue
            SolidColorBrush brs01=new SolidColorBrush(Colors.Blue);
            btn_4.SetValue(Button.BackgroundProperty, brs01);

            //包装的属性
            SolidColorBrush brs02=(SolidColorBrush)btn_2.Background;
            lbl_01.Content = brs02.Color.ToString();

            //依赖项属性的GetValue
            SolidColorBrush brs03 = (SolidColorBrush)btn_2.GetValue(Button.BackgroundProperty);
            lbl_02.Content = brs03.Color.ToString();
        }
    }

}
