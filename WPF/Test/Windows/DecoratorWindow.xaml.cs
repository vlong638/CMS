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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Decorator.xaml
    /// </summary>
    public partial class DecoratorWindow : Window
    {
        public DecoratorWindow()
        {
            InitializeComponent();

            InitialDecorator();
        }

        /// <summary>
        /// Decorator 指从System.Windows.Controls.Decorator类继承的控件
        /// 对其内的一个子元素的边缘进行修饰
        /// </summary>
        private void InitialDecorator()
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush(Colors.Red);
            border.Margin = new Thickness(5);

            TextBox tb = new TextBox();
            tb.Text = "TextBox Content";

            border.Child = tb;

            mainPanel.Children.Add(border);

        }
    }
}
