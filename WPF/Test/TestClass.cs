
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApplication2
{
    public class TestClass
    {
        static void main()
        {
            Application app = new Application();
            MainWindow win = new MainWindow();

            app.Startup += new StartupEventHandler(app_Startup);

            app.Run(win);
        }

        static void app_Startup(object sender, StartupEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            win.btn_test.Content = "test!";
        }

    }
}
