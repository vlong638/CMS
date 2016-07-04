using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using WpfApplication2.Helper;

namespace WpfApplication2.MyControl.MyUserControl
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class TimeCounter : UserControl
    {
        /// <summary>
        /// 依赖属性包装成普通属性
        /// 不进行GetValue及SetValue外的操作
        /// 因为属性的确立是为了将Java的习惯改为.NET开发的习惯
        /// 而XAML在调用该属性时调用GetValue和SetValue方法 其他的内容将不被执行
        /// 依赖属性 同 路由事件
        /// </summary>

        #region 依赖属性
        /// 声明及注册依赖属性StartTime
        [Description("获取或设置起始时间")]
        [Category("StartTime Properties")]
        public DateTime StartTime
        {
            get { return (DateTime)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }
        public static DependencyProperty StartTimeProperty =
            DependencyProperty.Register("StartTime", typeof(DateTime), typeof(TimeCounter), new FrameworkPropertyMetadata(DateTime.Now, new PropertyChangedCallback(OnParameterUpdated)));
        /// 声明及注册依赖属性Duration
        [Description("获取或设置持续时间")]
        [Category("Duration Properties")]
        public int Duration
        {
            get { return (int)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }
        public static DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(int), typeof(TimeCounter), new FrameworkPropertyMetadata(1, new PropertyChangedCallback(OnParameterUpdated)));
        //依赖属性回调事件
        private static void OnParameterUpdated(DependencyObject sender, DependencyPropertyChangedEventArgs arg)
        {
            TimeCounter myControl = sender as TimeCounter;
            if (arg.NewValue.GetType() == typeof(int))
            {
                RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>((int)arg.OldValue, (int)arg.NewValue,DurationUpdatedEvent);
                myControl.RaiseEvent(args);
            }
            else if (arg.NewValue.GetType() == typeof(DateTime))
            {
                RoutedPropertyChangedEventArgs<DateTime> args = new RoutedPropertyChangedEventArgs<DateTime>((DateTime)arg.OldValue, (DateTime)arg.NewValue, StartTimeUpdatedEvent);
                myControl.RaiseEvent(args);
            }
        }        
        //更新及注册事件StartTime
        [Description("StartTime被更新后发生")]
        public event RoutedPropertyChangedEventHandler<DateTime> StartTimeUpdated
        {
            add
            {
                this.AddHandler(StartTimeUpdatedEvent, value);
            }
            remove
            {
                this.RemoveHandler(StartTimeUpdatedEvent, value);
            }
        }
        public static readonly RoutedEvent StartTimeUpdatedEvent =
            EventManager.RegisterRoutedEvent("StartTimeUpdated", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(TimeCounter));
        //更新及注册事件Duration
        [Description("Duration被更新后发生")]
        public event RoutedPropertyChangedEventHandler<int> DurationUpdated
        {
            add
            {
                this.AddHandler(DurationUpdatedEvent, value);
            }
            remove
            {
                this.RemoveHandler(DurationUpdatedEvent, value);
            }
        }
        public static readonly RoutedEvent DurationUpdatedEvent =
            EventManager.RegisterRoutedEvent("DurationUpdated", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(TimeCounter));
        #endregion



        #region RoutedEvent        
        //共享事件
        public RoutedEvent Click = MyEvent.ClickEvent.AddOwner(typeof(TimeCounter));
        #endregion

        /// <summary>
        /// 自定义命令
        /// </summary>
        #region Command
        public static RoutedUICommand UpdateStartTime = new RoutedUICommand("UpdateStartTime", "UpdateStartTime", typeof(TimeCounter));

        CommandBinding commandBinding =
            new CommandBinding(UpdateStartTime
            , new ExecutedRoutedEventHandler(ExecuteUpdateStartTime)
            , new CanExecuteRoutedEventHandler(CanExecuteUpdateStartTime));

        public static void ExecuteUpdateStartTime(object sender, ExecutedRoutedEventArgs arg)
        {
            TimeCounter myControl = sender as TimeCounter;
            if (myControl!=null)
            {
                myControl.StartTime = DateTime.Now;
            }
        }

        public static void CanExecuteUpdateStartTime(object sender, CanExecuteRoutedEventArgs arg)
        {
            TimeCounter myControl = sender as TimeCounter;
            arg.CanExecute = (myControl != null);
        }
        #endregion

        public TimeCounter()
        {
            InitializeComponent();
        }

        private void IntiPage()
        {
            this.btStartTime.Command = UpdateStartTime;
        }
    }
}
