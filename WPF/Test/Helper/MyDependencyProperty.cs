using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.ComponentModel;

namespace WpfApplication2.Helper
{
    /// <summary>
    ///自定义依赖项属性 对所有派生自DependencyObject的类可用 WPF所有的控件
    ///</summary>
    public class MyDependencyObject : DependencyObject, INotifyPropertyChanged
    {
        public MyDependencyObject()
        {
            //默认值应可通过其他地方设置
            PropertyText = string.Format("当前数额为{0}", FunctionedCount);
        }

        /// <summary>
        /// NPC接口 声明可监控的属性
        /// </summary>
        #region INPC property
        private string _propertyText;
        public string PropertyText
        {
            get { return _propertyText; }
            set { _propertyText = value; RaisePropertyChanged("PropertyText"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        /// <summary>
        /// 声明 依赖属性
        /// </summary>
        #region DependencyProperty
        private static readonly DependencyProperty FunctionedCountProperty = DependencyProperty.Register("FunctionedCount",
            typeof(int), typeof(MyDependencyObject), new FrameworkPropertyMetadata(1,new PropertyChangedCallback(OnFunctionedCountChanged)));

        public int FunctionedCount
        {
            set { SetValue(FunctionedCountProperty, value); }
            get { return (int)GetValue(FunctionedCountProperty); }
        }

        public static void OnFunctionedCountChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            MyDependencyObject obj = (MyDependencyObject)sender;
            obj.PropertyText = string.Format("当前数额为{0}", e.NewValue.ToString());
        }
        #endregion
    }
}
