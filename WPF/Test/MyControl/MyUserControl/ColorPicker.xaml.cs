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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2.MyControl.MyUserControl
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        #region 依赖属性声明及包装
        private static DependencyProperty ColorProperty;
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static DependencyProperty RedProperty;
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        private static DependencyProperty GreenProperty;
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public static DependencyProperty BlueProperty;
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        public static DependencyProperty ContentTextProperty;
        public String ContentText
        {
            get { return (String)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }
        }
        #endregion

        public ColorPicker()
        {
            //注册依赖属性
            ColorProperty = DependencyProperty.Register("Color",
                typeof(Color), typeof(ColorPicker), new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red",
                typeof(byte), typeof(ColorPicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnRGBColorChanged)));
            GreenProperty = DependencyProperty.Register("Green",
                typeof(byte), typeof(ColorPicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnRGBColorChanged)));
            BlueProperty = DependencyProperty.Register("Blue",
                typeof(byte), typeof(ColorPicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnRGBColorChanged)));
            ContentTextProperty = DependencyProperty.Register("ContentText",
                typeof(String), typeof(ColorPicker), null);

            InitializeComponent();
        }
        /// <summary>
        /// 依赖属性回调函数
        /// </summary>
        public static void OnRGBColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color =colorPicker.Color;

            if (e.Property==RedProperty)
            {
                color.R = (byte)e.NewValue;
            }
            else if(e.Property==GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }
            else if (e.Property==BlueProperty)
            {
                color.B = (byte)e.NewValue;
            }

            colorPicker.Color = color;
        }
        public static void OnColorChanged(DependencyObject sender,DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color newColor = (Color)e.NewValue;
            Color oldColor = (Color)e.OldValue;
            ////更改颜色
            //colorPicker.Red = newColor.R;
            //colorPicker.Green = newColor.G;
            //colorPicker.Blue = newColor.B;
            //更改文本
            colorPicker.ContentText=string.Format("the new color is {0}", newColor.ToString());
            //定义事件消息
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldColor, newColor);
            args.RoutedEvent = ColorPicker.ColorChangedEvent;
            //触发事件
            colorPicker.RaiseEvent(args);
        }
        //定义 注册变色事件
        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", 
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
        //包装变色事件
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }


    }
}
