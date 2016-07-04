using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace WpfApplication2.Helper
{
    public abstract class MyEvent:ContentControl
    {
        //The event definition
        public static readonly RoutedEvent ClickEvent;
        //The event registration
        static MyEvent()
        {
            MyEvent.ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyEvent));
        }
        //Traditional event wrapper
        public event RoutedEventHandler Click
        {
            add
            {
                base.AddHandler(MyEvent.ClickEvent, value);
            }
            remove
            {
                base.RemoveHandler(MyEvent.ClickEvent, value);
            }
        }
    }
}
